using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AFLStock.Entities;
using AFLStock.Consumer;

namespace AFLStock.UI.Forms {
    public partial class Form_BatchAddSalesStockItem : Form {
        private List<StockItemQuantityLogEntity> _selectedStockItems;
        private StockConsumerLocal _stockClient;

        public List<StockItemQuantityLogEntity> SelectedStockItems {
            get {
                return _selectedStockItems;
            }
        }

        public Form_BatchAddSalesStockItem() {
            InitializeComponent();
        }

        public Form_BatchAddSalesStockItem( int soID, StockItemMasterEntity stockItem, string customerName, List<StockItemQuantityLogEntity> itemsAlreadyInSO )
            : this() {

            label_Category.Text = stockItem.StockCategory;
            label_DesignNumber.Text = stockItem.DesignNumber;
            label_SalesOrderID.Text = soID.ToString();
            label_SubCode.Text = stockItem.SubCode;
            label_CustomerName.Text = customerName;
            label_UnitType.Text = stockItem.UnitType;

            _stockClient = StockConsumerLocal.getClientInstance();
            _selectedStockItems = new List<StockItemQuantityLogEntity>();

            DataGridViewTextBoxColumn colTB_Qty = new DataGridViewTextBoxColumn();
            colTB_Qty.DataPropertyName = "Quantity";
            colTB_Qty.HeaderText = "Quantity";
            colTB_Qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_StockItemDetails.Columns.Add( colTB_Qty );

            BindingList<StockItemQuantityLogEntity> tempQtyLog = _stockClient.GetStockItemDetails_ByStockItemMasterID( stockItem.ID );
            BindingList<StockItemQuantityLogEntity> itemQtyLog = new BindingList<StockItemQuantityLogEntity>();
            // O(n^2) now go through and remove any stock-items that are already in the Sales Order (you cannot double select a stock item)
            foreach ( StockItemQuantityLogEntity itemLog in tempQtyLog ) {
                if ( !itemsAlreadyInSO.Contains( itemLog ) ) {
                    itemQtyLog.Add( itemLog );
                }
            }

            dataGridView_StockItemDetails.DataSource = itemQtyLog;
            dataGridView_StockItemDetails.Focus();
        }

        private void button_SelectClose_Click( object sender, EventArgs e ) {
            if ( dataGridView_StockItemDetails.SelectedRows != null ) {
                foreach (DataGridViewRow row in dataGridView_StockItemDetails.SelectedRows ) {
                    StockItemQuantityLogEntity stockItemDetail = (StockItemQuantityLogEntity) row.DataBoundItem;
                    _selectedStockItems.Add( stockItemDetail );
                }
            }
            this.Close();
        }
    }
}
