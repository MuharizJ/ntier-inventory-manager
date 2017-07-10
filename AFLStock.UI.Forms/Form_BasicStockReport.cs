using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AFLStock.Consumer;
using AFLStock.Entities;

namespace AFLStock.UI.Forms {
    public partial class Form_BasicStockReport : Form {

        StockConsumerLocal stockClient;
        private HashSet<StockItemMasterEntity> stockItems_localCache;

        public Form_BasicStockReport() {
            InitializeComponent();

            stockClient = StockConsumerLocal.getClientInstance();
        }

        private void button_ListEverything_Click( object sender, EventArgs e ) {
            foreach ( TreeNode parentNode in treeView_StockItems.Nodes ) {
                parentNode.Checked = false;
                unCheckAllTreeNodes( parentNode ); // recursive call through all the children
            }
            treeView_StockItems.Refresh();

            label_StockValue.Text = stockClient.stockValue_Total().ToString( "N2" );
        }

        private void unCheckAllTreeNodes( TreeNode node ) {
            if ( node != null && node.Nodes.Count > 0 ) {
                foreach ( TreeNode nd in node.Nodes ) {
                    nd.Checked = false;
                    unCheckAllTreeNodes( nd );
                }
            }
        }

        private void Form_BasicStockReport_Load( object sender, EventArgs e ) {
            loadStockItemsIntoTree();
        }

        private void loadStockItemsIntoTree() {
            foreach ( StockCategoryEntity stockCategory in stockClient.getCategories() ) {

                List<TreeNode> designsForCategory = new List<TreeNode>();
                foreach ( string designName in stockClient.getStockItemDesignNumbers_ByCategory( stockCategory.CategoryName ) ) {

                    List<TreeNode> subCodesForDesign = new List<TreeNode>();
                    foreach ( string subCodeStr in stockClient.getStockItemSubCodes_ByCategoryDesignNumber( stockClient.getCategoryID( stockCategory.CategoryName ), designName ) ) {
                        
                        TreeNode subCode = new TreeNode( "-SUBCODE- " + subCodeStr );
                        subCodesForDesign.Add( subCode );
                    }

                    TreeNode design = new TreeNode( "-DSN- " + designName, subCodesForDesign.ToArray<TreeNode>() );
                    designsForCategory.Add( design );
                }

                TreeNode treeNode = new TreeNode( "-CATEGORY- " + stockCategory.CategoryName, designsForCategory.ToArray<TreeNode>() );

                treeView_StockItems.Nodes.Add( treeNode );
            }
        }

        private void treeView_StockItems_AfterCheck( object sender, TreeViewEventArgs e ) {
            // if not multiple recursive calls will happen as we attempt to programatically CHECK the child nodes of this parent node
            if ( e.Action != TreeViewAction.Unknown ) {
                if ( e.Node.Nodes.Count > 0 ) {
                    this.checkAllChildNodes( e.Node, e.Node.Checked );
                }
            }
        }

        private void checkAllChildNodes( TreeNode treeNode, bool nodeChecked ) {
            foreach ( TreeNode node in treeNode.Nodes ) {
                node.Checked = nodeChecked;
                if ( node.Nodes.Count > 0 ) { // recursive call --> Base condition to stop is when Count == 0 (no nodes to traverse)
                    this.checkAllChildNodes( node, nodeChecked );
                }
            }
        }

        private void button_Refine_Click( object sender, EventArgs e ) {
            button_Refine.Enabled = false;
            button_Refine.Refresh();

            double stockValue = 0;
            
            double qtyMeters = 0;
            double qtyUnits = 0;

            foreach ( TreeNode parentNode in treeView_StockItems.Nodes ) {
                stockValue += calculateStockValue( parentNode, ref qtyMeters, ref qtyUnits );
            }

            label_StockValue.Text = stockValue.ToString( "N2" );

            label_Quantities.Text = qtyMeters.ToString( "N2" ) + " METERS\n" + qtyUnits.ToString( "N2" ) + " UNITS";

            button_Refine.Enabled = true;
            button_Refine.Refresh();
        }

        private double calculateStockValue( TreeNode node, ref double qtyMeters, ref double qtyUnits ) {
            double thisValue = 0;

            // That means this is an actual Leaf, we have enough data to find the stock-item-master object
            if ( node.Checked && node.Text.Contains( "-SUBCODE- " ) ) {
                string dsn = node.Parent.Text;
                string cat = node.Parent.Parent.Text;

                dsn = dsn.Remove( 0, 6 );
                cat = cat.Remove( 0, 11 );
                string sub = node.Text.Remove( 0, 10 );

                StockItemMasterEntity itemSelected = stockClient.getStockItem_ByCategoryDesignSubcode( cat, dsn, sub );
                thisValue = itemSelected.CurrentStock * itemSelected.Cost_FinalUpdated;

                if ( itemSelected.UnitType.Equals( "METER" ) ) {
                    qtyMeters += itemSelected.CurrentStock;
                }
                else if ( itemSelected.UnitType.Equals( "UNIT" ) ) {
                    qtyUnits += itemSelected.CurrentStock;
                }
            }

            // recursively add IF this has children
            if ( node.Nodes.Count > 0 ) {
                foreach ( TreeNode childNode in node.Nodes ) {
                    thisValue += calculateStockValue( childNode, ref qtyMeters, ref qtyUnits );
                }
            }

            return thisValue;
        }
    }
}
