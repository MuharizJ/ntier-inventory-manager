using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;

using AFLStock.Entities;

namespace AFLStock.UI.Forms {
    public partial class Form_BatchAddPurchaseStockItem : Form {
        StockItemMasterEntity _stockItemMasterEnt;

        List<double> _quantitiesToAdd;

        public Form_BatchAddPurchaseStockItem( StockItemMasterEntity stockItemMasterEnt, int poID, string supplierName, out List<double> quantitiesToAdd ) {
            InitializeComponent();
            _stockItemMasterEnt = stockItemMasterEnt;
            label_SupplierName.Text = supplierName;
            label_PurchaseOrderID.Text = poID.ToString();

            label_Category.Text = _stockItemMasterEnt.StockCategory;
            label_DesignNumber.Text = _stockItemMasterEnt.DesignNumber;
            label_SubCode.Text = _stockItemMasterEnt.SubCode;
            label_UnitType.Text = _stockItemMasterEnt.UnitType;

            textBox_Cost.Text = _stockItemMasterEnt.Cost_FinalUpdated.ToString();                 

            quantitiesToAdd = new List<double>();
            _quantitiesToAdd = quantitiesToAdd;
        }

        private void Form_BatchAddStockItem_Load( object sender, EventArgs e ) {
            dataGridView_ItemQuantityList.AutoGenerateColumns = false;
            dataGridView_ItemQuantityList.ColumnCount = 1;
            dataGridView_ItemQuantityList.ColumnHeadersVisible = true;
            dataGridView_ItemQuantityList.Columns[0].Width = 200;
            dataGridView_ItemQuantityList.Columns[0].Name = "Quantity";
        }

        private void button_AddStockItems_Click( object sender, EventArgs e ) {
            for ( int i = 0; i < dataGridView_ItemQuantityList.Rows.Count; i++ ) {
                try {
                    _quantitiesToAdd.Add( double.Parse( dataGridView_ItemQuantityList.Rows[i].Cells[0].Value.ToString() ) );
                }
                catch ( NullReferenceException ) {// ignore, its most probably an empty row or the last row
                }
                catch ( ArgumentNullException ) {// ignore, its most probably an empty row or the last row
                }
                catch ( FormatException ) {// Caused because the value in the text box is not a valid number
                    MessageBox.Show( dataGridView_ItemQuantityList.Rows[i].Cells[0].Value.ToString() + " is not a valid number",
                                        "INVALID NUMBER", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    dataGridView_ItemQuantityList.Rows.RemoveAt( i );
                    i -= 1; // since a row is being removed, we need to back track on the iterator and recheck at the current "i" level of the list
                }
            }

            try {
                _stockItemMasterEnt.Cost_FinalUpdated = double.Parse( textBox_Cost.Text );
            }
            catch(Exception){} // don't change the Cost of the master-object

            this.Close();
        }

        private void button_DeleteRow_Click( object sender, EventArgs e ) {
            try {
                dataGridView_ItemQuantityList.Rows.RemoveAt( dataGridView_ItemQuantityList.CurrentRow.Index );
            }
            catch ( InvalidOperationException ) {
                // An empty row was trying to be removed, ignore this
            }
        }
    }
}
