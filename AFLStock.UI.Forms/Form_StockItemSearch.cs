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
using AFLStock.WCF.Client.ServiceReference;

namespace AFLStock.UI.Forms {
    public partial class Form_StockItemSearch : Form {
        private StockConsumerLocal stockClient;

        private bool SECURITY_TOKEN = true; // this is for future security related stuff

        public Form_StockItemSearch() {
            InitializeComponent();

            stockClient = StockConsumerLocal.getClientInstance();
        }

        private void Form_StockItemList_Load( object sender, EventArgs e ) {
            comboBox_CurrentStockEquality.DataSource = AFLStock.Entities.BaseEntity.EQUALITY_LIST;
            comboBox_CurrentStockEquality.SelectedIndex = 0;

            dataGridView_StockItemList.AutoGenerateColumns = false;
            dataGridView_StockItemList.AutoSize = true;

            DataGridViewTextBoxColumn colTB_Cat = new DataGridViewTextBoxColumn();
            colTB_Cat.DataPropertyName = "StockCategory";
            colTB_Cat.HeaderText = "Stock Category";
            colTB_Cat.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_StockItemList.Columns.Add( colTB_Cat );

            DataGridViewTextBoxColumn colTB_DsnNum = new DataGridViewTextBoxColumn();
            colTB_DsnNum.DataPropertyName = "DesignNumber";
            colTB_DsnNum.HeaderText = "Design Number";
            colTB_DsnNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_StockItemList.Columns.Add( colTB_DsnNum );

            DataGridViewTextBoxColumn colTB_Subcode = new DataGridViewTextBoxColumn();
            colTB_Subcode.DataPropertyName = "SubCode";
            colTB_Subcode.HeaderText = "Sub Code";
            colTB_Subcode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_StockItemList.Columns.Add( colTB_Subcode );

            DataGridViewTextBoxColumn colTB_CurrentStock = new DataGridViewTextBoxColumn();
            colTB_CurrentStock.DataPropertyName = "Quantity";
            colTB_CurrentStock.HeaderText = "Current Stock";
            colTB_CurrentStock.ValueType = typeof( double );
            colTB_CurrentStock.DefaultCellStyle.Format = ("##,##0.00");
            colTB_CurrentStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_StockItemList.Columns.Add( colTB_CurrentStock );

            DataGridViewTextBoxColumn colTB_UnitType = new DataGridViewTextBoxColumn();
            colTB_UnitType.DataPropertyName = "UnitType";
            colTB_UnitType.HeaderText = "Unit Type";
            dataGridView_StockItemList.Columns.Add( colTB_UnitType );

            if ( SECURITY_TOKEN ) {
                DataGridViewTextBoxColumn colTB_Cost = new DataGridViewTextBoxColumn();
                colTB_Cost.DataPropertyName = "Cost";
                colTB_Cost.HeaderText = "Current Cost";
                colTB_Cost.DefaultCellStyle.Format = ( "##,##0.00" );
                colTB_Cost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView_StockItemList.Columns.Add( colTB_Cost );
            }

            dataGridView_StockItemList.SelectionChanged += new EventHandler( dataGridView_StockItemList_SelectionChanged );
            dataGridView_StockItemList.CellClick += new DataGridViewCellEventHandler( dataGridView_StockItemList_CellClick );

            // User Control *StockItemSelector*
            stockItemSelector_Control1.StockItemListRefinedEvent += new EventHandler( stockItemSelector_Control_StockItemListRefinedEvent );
        }

        private void dataGridView_StockItemList_CellClick( object sender, DataGridViewCellEventArgs e ) {
            enableDetailedQuantitiesButton((WCF.Client.ServiceReference.StockItemMaster_POCO)dataGridView_StockItemList.Rows[dataGridView_StockItemList.SelectedCells[0].RowIndex].DataBoundItem);
        }

        private void dataGridView_StockItemList_SelectionChanged( object sender, EventArgs e ) {
            try {
                enableDetailedQuantitiesButton((WCF.Client.ServiceReference.StockItemMaster_POCO)dataGridView_StockItemList.SelectedRows[0].DataBoundItem);
            }
            catch ( Exception ) {
            }
        }

        private void enableDetailedQuantitiesButton(WCF.Client.ServiceReference.StockItemMaster_POCO selectedItem) {
            if ( selectedItem.HasQuantityList ) {
                button_detailedQuantities.Enabled = true;
            }
            else {
                button_detailedQuantities.Enabled = false;
            }
        }

        private void refineStockItemsToDisplay() {
            startBusy();
            label_TotalMeters.Visible = false;
            label_TotalUnits.Visible = false;
            
            button_detailedQuantities.Enabled = false;

            int catID = int.MinValue;
            string designNumber = StockItemSelector_Control.NOSELECTION_DESIGN;
            string subcode = StockItemSelector_Control.NOSELECTION_SUBCODE;

            WCF.Client.ServiceReference.StockItemMaster_POCO[] stockItems = null;

            try {
                catID = stockItemSelector_Control1.StockCategoryID;
            }
            catch { }

            try {
                designNumber = stockItemSelector_Control1.DesignNumber;
            }
            catch { }

            try {
                subcode = stockItemSelector_Control1.SubCode;
            }
            catch { }

            AFLStockServiceClient client = new AFLStockServiceClient();

            // need to search on all the above criteria
            if ( catID != int.MinValue &&
                    !designNumber.Equals( StockItemSelector_Control.NOSELECTION_DESIGN ) &&
                    !subcode.Equals( StockItemSelector_Control.NOSELECTION_SUBCODE ) ) {
                stockItems = client.GetStockItemsByCategoryDesignNumberSubCode_Simplified( catID, designNumber, subcode );
            }
            else if ( catID != int.MinValue && !designNumber.Equals( StockItemSelector_Control.NOSELECTION_DESIGN ) ) {
                stockItems = client.GetStockItemsByCategoryDesignNumber_Simplified( catID, designNumber );
            }
            else if ( catID != int.MinValue ) {
                stockItems = client.GetStockItemsByCategory_Simplified( catID );
            }
            else {
                stockItems = client.GetStockItemsAll_Simplified();
            }

            setStockItemListDataSource( stockItems );
            endBusy();
        }

        private void stockItemSelector_Control_StockItemListRefinedEvent( object sender, EventArgs e ) {
            refineStockItemsToDisplay();
        }

        private void setStockItemListDataSource(WCF.Client.ServiceReference.StockItemMaster_POCO[] theList) {
            dataGridView_StockItemList.DataSource = theList;
            dataGridView_StockItemList.ClearSelection();
            button_detailedQuantities.Enabled = false;

            double totalMeters = 0;
            double totalUnits = 0;

            foreach (WCF.Client.ServiceReference.StockItemMaster_POCO itemPOCO in theList) {
                if ( itemPOCO.UnitType.Equals( "METER" ) ) {
                    totalMeters += itemPOCO.Quantity;
                }
                else if ( itemPOCO.UnitType.Equals( "UNIT" ) ) {

                    totalUnits += itemPOCO.Quantity;
                }
            }

            if ( totalMeters > 0 ) {
                label_TotalMeters.Text = "Total Meters: " + totalMeters.ToString();
                label_TotalMeters.Visible = true;
            }

            if ( totalUnits > 0 ) {
                label_TotalUnits.Text = "Total Units: " + totalUnits.ToString();
                label_TotalUnits.Visible = true;
            }
        }

        private void startBusy() {
            label_Busy.Visible = true;
            label_Busy.Refresh();
            button_ListAll.Enabled = false;
            button_RefineSearch.Enabled = false;
            button_ListAll.Refresh();
            button_RefineSearch.Refresh();
        }

        private void endBusy() {
            button_RefineSearch.Enabled = true;
            button_ListAll.Enabled = true;
            label_Busy.Visible = false;
        }

        private void button_ListAll_Click( object sender, EventArgs e ) {
            stockItemSelector_Control1.ResetControl();
            refineStockItemsToDisplay();
        }

        private void button_detailedQuantities_Click( object sender, EventArgs e ) {
            WCF.Client.ServiceReference.StockItemMaster_POCO  stockItemPoco = null;

            try {
                stockItemPoco = (WCF.Client.ServiceReference.StockItemMaster_POCO)dataGridView_StockItemList.CurrentRow.DataBoundItem;
            }
            catch ( Exception ) { }

            new Form_StockItemQuantityLog(stockItemPoco).Show(this);
        }

        private void button_RefineSearch_Click( object sender, EventArgs e ) {
            // first reset the datagrid's datasource with whatever the user has refined it to using the master search group
            refineStockItemsToDisplay();
            
            double qtyFilter = double.MinValue;
            if ( textBox_CurrentStock.Text != null && textBox_CurrentStock.Text.Length > 0 ) {
                try {
                    qtyFilter = double.Parse( textBox_CurrentStock.Text );
                }
                catch ( Exception ) {
                    MessageBox.Show( "Invalid Quantity Value" );
                    textBox_CurrentStock.Text = "";
                } 
            }

            string textFilter = textBox_ContainsText.Text;
            string comparitor = comboBox_CurrentStockEquality.SelectedItem.ToString();

            WCF.Client.ServiceReference.StockItemMaster_POCO[] stockItems = (WCF.Client.ServiceReference.StockItemMaster_POCO[])dataGridView_StockItemList.DataSource;
            List<WCF.Client.ServiceReference.StockItemMaster_POCO> filteredList = new List<WCF.Client.ServiceReference.StockItemMaster_POCO>(stockItems.Length);

            if (stockItems == null || stockItems.Length <= 1) {
                return;
            }

            foreach (WCF.Client.ServiceReference.StockItemMaster_POCO itemPoco in stockItems) {
                if (searchCriteriaCheck(itemPoco, qtyFilter, comparitor, textFilter)) {
                    filteredList.Add(itemPoco);
                }
            }

            // we should convert this list back to array format because we keep using it in that format throughout the Class
            setStockItemListDataSource(filteredList.ToArray < WCF.Client.ServiceReference.StockItemMaster_POCO>());
        }

        private bool searchCriteriaCheck(  WCF.Client.ServiceReference.StockItemMaster_POCO itemPoco, double qtyFilter, string comparitor, string textFilter ) {
            bool result = true;
            
            if ( textFilter != null && textFilter.Length > 0 ) {
                string designNumber = itemPoco.DesignNumber.ToUpper();
                textFilter = textFilter.ToUpper();

                if ( !designNumber.Contains( textFilter ) ) {
                    result = false;
                }
            }

            if ( qtyFilter != double.MinValue ) {
                if ( comparitor.Equals( BaseEntity.EQUALITY_STRING_EQUAL ) ) {
                    if (itemPoco.Quantity != qtyFilter) {
                        result = false;
                    }
                }
                else if ( comparitor.Equals( BaseEntity.EQUALITY_STRING_GREATER_THAN ) ) {
                    if (itemPoco.Quantity < qtyFilter) {
                        result = false;
                    }
                }
                else if ( comparitor.Equals( BaseEntity.EQUALITY_STRING_LESS_THAN ) ) {
                    if (itemPoco.Quantity > qtyFilter) {
                        result = false;
                    }
                }
            }

            return result;
        }

        private void button_ResetSearch_Click( object sender, EventArgs e ) {
            refineStockItemsToDisplay();
        }

        private void textBox_ContainsText_KeyPress( object sender, KeyPressEventArgs e ) {
            if ( e.KeyChar == 13 ) {
                button_RefineSearch.PerformClick();
            }
        }
    }
}
