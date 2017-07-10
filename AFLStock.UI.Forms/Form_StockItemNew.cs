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
    public partial class Form_StockItemNew : Form {
        public static string NOSELECTION_CATEGORY = "<Select a Category>";
        public static string NOSELECTION_UNIT_TYPE = "<Select a Unit Type>";
        public static string NOSELECTION_SUB_CODES = "<Enter sub-codes in this list>"; 

        List<string> _subcodes;

        StockConsumerLocal stockClient;

        public Form_StockItemNew() {
            InitializeComponent();

            stockClient = StockConsumerLocal.getClientInstance();

            resetDataGridView_SubCodes();
        }

        private void resetDataGridView_SubCodes() {
            _subcodes = new List<string>();
        }

        private void disableInputControls() {
            textBox_MasterCode.Enabled = false;
            textBox_Description.Enabled = false;
            comboBox_UnitType.Enabled = false;
            textBox_MinOrderQty.Enabled = false;
            textBox_CostCNF.Enabled = false;
            textBox_CostLKR.Enabled = false;
            checkBox_QuantityList.Enabled = false;
            button_Save.Enabled = false;
            dataGridView_SubCodes.Enabled = false;
        }

        private void enableInputControls() {
            textBox_MasterCode.Enabled = true;
            textBox_Description.Enabled = true;
            comboBox_UnitType.Enabled = true;
            textBox_MinOrderQty.Enabled = true;
            textBox_CostCNF.Enabled = true;
            textBox_CostLKR.Enabled = true;
            checkBox_QuantityList.Enabled = true;
            dataGridView_SubCodes.Enabled = true;

            if ( comboBox_UnitType.SelectedItem != null && !(((UnitTypeEntity) comboBox_UnitType.SelectedItem).UnitType.Equals( NOSELECTION_UNIT_TYPE )) ) {
                button_Save.Enabled = true;
            }
            else {
                button_Save.Enabled = false;
            }
        }

        private void resetInputControls() {
            textBox_MasterCode.Text = "";
            textBox_Description.Text = "";
            textBox_MinOrderQty.Text = "";
            textBox_CostCNF.Text = "";
            textBox_CostLKR.Text = "";

            comboBox_UnitType.SelectedIndex = 0;
            checkBox_QuantityList.Checked = true;

            resetDataGridView_SubCodes();
        }

        private void loadCategories() {
            BindingList<StockCategoryEntity> stockCategoryList = stockClient.getCategories();

            Boolean defaultExists = false;
            foreach ( StockCategoryEntity catEnt in stockCategoryList ) {
                if ( catEnt.CategoryName.Equals( NOSELECTION_CATEGORY ) ) {
                    defaultExists = true;
                    break;
                }
            }

            if ( !defaultExists ) {
                stockCategoryList.Insert( 0, new StockCategoryEntity {
                    CategoryName = NOSELECTION_CATEGORY
                } );
            }

            comboBox_StockCategory.DataSource = stockCategoryList;
            comboBox_StockCategory.DisplayMember = "CategoryName";

            comboBox_StockCategory.SelectedIndex = 0;
        }

        private void loadUnitTypes() {
            BindingList<UnitTypeEntity> unitTypes = stockClient.getUnitTypes();
            
            Boolean defaultExists = false;
            foreach ( UnitTypeEntity unitType in unitTypes ) {
                if ( unitType.UnitType.Equals( NOSELECTION_UNIT_TYPE ) ) {
                    defaultExists = true;
                    break;
                }
            }

            if ( !defaultExists ) {
                unitTypes.Insert( 0, new UnitTypeEntity { UnitType = NOSELECTION_UNIT_TYPE } );
            }

            comboBox_UnitType.DisplayMember = "UnitType";
            comboBox_UnitType.DataSource = unitTypes;
        }

        private void Form_StockItemNew_Load( object sender, EventArgs e ) {
            loadCategories();
            loadUnitTypes();

            dataGridView_SubCodes.AutoGenerateColumns = false;
            dataGridView_SubCodes.ColumnCount = 1;
            dataGridView_SubCodes.ColumnHeadersVisible = true;
            dataGridView_SubCodes.Columns[0].Width = 200;
            dataGridView_SubCodes.Columns[0].Name = "Sub Code";
        }

        private void comboBox_StockCategory_SelectedIndexChanged( object sender, EventArgs e ) {
            try {
                if ( comboBox_StockCategory.SelectedItem != null && !( (StockCategoryEntity) ( comboBox_StockCategory.SelectedItem ) ).CategoryName.Equals( NOSELECTION_CATEGORY ) ) {
                    enableInputControls();
                    checkBox_QuantityList.Checked = !( (StockCategoryEntity) ( comboBox_StockCategory.SelectedItem ) ).Mutable;
                }
                else {
                    disableInputControls();
                }
            }
            catch ( Exception ee) {
                MessageBox.Show(ee.ToString());
            }
        }

        private void comboBox_UnitType_SelectedIndexChanged(object sender, EventArgs e) {
            if ( comboBox_UnitType.SelectedItem != null && !(((UnitTypeEntity) comboBox_UnitType.SelectedItem).UnitType.Equals( NOSELECTION_UNIT_TYPE )) ) {
                button_Save.Enabled = true;
            }
            else {
                button_Save.Enabled = false;
            }
        }

        private void button_Exit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button_Save_Click(object sender, EventArgs e) {
            StringBuilder errorList = new StringBuilder();

            StockCategoryEntity stockCategory = (StockCategoryEntity) comboBox_StockCategory.SelectedItem;
            UnitTypeEntity unitType = (UnitTypeEntity) comboBox_UnitType.SelectedItem;

            
            string designNumber = textBox_MasterCode.Text;
            if ( designNumber == null || designNumber.Length == 0 ) {
                errorList.AppendLine( "Design Number / Master Code cannot be empty" );
            }

            string description = textBox_Description.Text;

            double minOrder = 0;
            try {
                minOrder = double.Parse(textBox_MinOrderQty.Text);
            }
            catch {}

            double costCNF = 0;
            try {
                costCNF = double.Parse( textBox_CostCNF.Text );
            }
            catch {}

            double costLKR = 0;
            try {
                costLKR = double.Parse( textBox_CostLKR.Text );
            }
            catch {}

            if ( errorList.Length == 0 ) {
                BindingList<StockItemMasterEntity> stockItemMasters = new BindingList<StockItemMasterEntity>();

                for ( int i = 0; i < dataGridView_SubCodes.Rows.Count; i++ ) {
                    if ( dataGridView_SubCodes.Rows[i].Cells[0] != null &&
                        dataGridView_SubCodes.Rows[i].Cells[0].Value != null &&
                        dataGridView_SubCodes.Rows[i].Cells[0].Value.ToString().Length > 0 ) {
                        
                           string subCode = dataGridView_SubCodes.Rows[i].Cells[0].Value.ToString();

                            StockItemMasterEntity stockItemEnt = new StockItemMasterEntity();
                            stockItemEnt.Cost_FinalUpdated = costLKR;
                            stockItemEnt.CurrentStock = 0;
                            stockItemEnt.Description = description;
                            stockItemEnt.SubCode = subCode;
                            stockItemEnt.DesignNumber = designNumber;
                            stockItemEnt.UnitType = unitType.UnitType;
                            stockItemEnt.StockCategory = stockCategory.CategoryName;

                            stockItemEnt.MinOrderLevel = minOrder;
                            stockItemEnt.Mutable = !checkBox_QuantityList.Checked;
                            stockItemEnt.SellingPrice_External = 0;
                            stockItemEnt.SellingPrice_Internal = 0;
                            stockItemEnt.TotalQuantityPurchased = 0;
                            stockItemEnt.TotalQuantitySold = 0;

                            stockItemMasters.Add( stockItemEnt ); 
                    }
                }

                if ( stockClient.saveStockItemList( stockItemMasters ) ) {
                    MessageBox.Show( "Stock items were successfully created", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
                else {
                    MessageBox.Show( "Some or All items were not saved", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                resetDataGridView_SubCodes();
                textBox_MasterCode.SelectAll();
                textBox_MasterCode.Focus();
            }
            else {
                MessageBox.Show( errorList.ToString(), "Errors in input data", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
    }
}
