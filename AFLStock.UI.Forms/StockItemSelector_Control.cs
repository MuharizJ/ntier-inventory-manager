using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AFLStock.Consumer;
using AFLStock.Entities;

namespace AFLStock.UI.Forms {
    public partial class StockItemSelector_Control : UserControl {

        private StockConsumerLocal stockClient;

        public static string NOSELECTION_DESIGN = "<Select a Design Number>";
        public static string NOSELECTION_CATEGORY = "<Select a Category>";
        public static string NOSELECTION_SUBCODE = "<Select a Sub-Code>";

        public event EventHandler StockItemListRefinedEvent;

        protected virtual void OnStockItemListRefinedEvent( EventArgs e ) {
            if ( StockItemListRefinedEvent != null ) {
                StockItemListRefinedEvent( this, e );
            }
        }

        public StockItemSelector_Control() {
            InitializeComponent();
        }

        private void StockItemSelector_Control_Load( object sender, EventArgs e ) {
            try {
                stockClient = StockConsumerLocal.getClientInstance();
                reloadStockCategories();
            }
            catch ( Exception ) {
                // uncomment this for production deployment
                // MessageBox.Show( "Fatal Error - Could NOT load the stock categories - Contact Admin or revert to prayer:\t" + ee.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        public StockItemMasterEntity GetSelectedStockItemMaster() {
            if ( !StockCategoryName.Equals( NOSELECTION_CATEGORY ) &&
                    !DesignNumber.Equals( StockItemSelector_Control.NOSELECTION_DESIGN ) &&
                    !SubCode.Equals( StockItemSelector_Control.NOSELECTION_SUBCODE ) ) {
                return stockClient.getStockItem_ByCategoryDesignSubcode( StockCategoryName, DesignNumber, SubCode );
            }
            else {
                return null;
            }
        }

        #region Properties
        public string StockCategoryName {
            get {
                string selectedCategory = NOSELECTION_CATEGORY;

                try {
                    selectedCategory = ( (StockCategoryEntity) comboBox_StockCategory.SelectedItem ).CategoryName;
                }
                catch ( Exception ) { }

                return selectedCategory;
            }
        }

        public int StockCategoryID {
            get {
                int selectedCategory = int.MinValue;

                try {
                    selectedCategory = ( (StockCategoryEntity) comboBox_StockCategory.SelectedItem ).ID;
                }
                catch ( Exception ) { }

                return selectedCategory;
            }
        }

        public string DesignNumber {
            get {
                string desingNumber = NOSELECTION_DESIGN;

                try {
                    desingNumber = comboBox_MasterCode.SelectedItem.ToString();
                }
                catch ( Exception ) { }

                return desingNumber;
            }
        }

        public string SubCode {
            get {
                string subCode = NOSELECTION_SUBCODE;

                try {
                    subCode = comboBox_subCode.SelectedItem.ToString();
                }
                catch ( Exception ) { }

                return subCode;
            }
        }
        #endregion

        private void comboBox_StockCategory_SelectedIndexChanged( object sender, EventArgs e ) {
            // RESET the sub-codes combo box
            comboBox_subCode.DataSource = null;
            comboBox_MasterCode.DataSource = null;

            if ( !( (StockCategoryEntity) comboBox_StockCategory.SelectedItem ).CategoryName.Equals( NOSELECTION_CATEGORY ) ) {
                startBusy();
                StockCategoryEntity stk = (StockCategoryEntity) comboBox_StockCategory.SelectedItem;
                List<string> itemDesignNumberList = stockClient.getStockItemDesignNumbers_ByCategory( stk.ID );
                itemDesignNumberList.Insert( 0, NOSELECTION_DESIGN );

                if ( itemDesignNumberList == null || itemDesignNumberList.Count == 0 ) {
                    comboBox_MasterCode.DataSource = null;
                }
                else {
                    comboBox_MasterCode.DataSource = itemDesignNumberList;
                }

                endBusy();

                // subscribe to this event an do what you need to do when the Selected Stock Category has changed
                OnStockItemListRefinedEvent( EventArgs.Empty );
            }
        }

        private void comboBox_MasterCode_SelectedIndexChanged( object sender, EventArgs e ) {
            if ( comboBox_MasterCode.SelectedItem != null && !comboBox_MasterCode.SelectedItem.ToString().Equals( NOSELECTION_DESIGN ) ) {
                int catID = int.MinValue;
                string designNumber = null;

                try {
                    startBusy();
                    catID = ( (StockCategoryEntity) comboBox_StockCategory.SelectedItem ).ID;
                    designNumber = comboBox_MasterCode.SelectedItem.ToString();

                    List<string> subCodesList = stockClient.getStockItemSubCodes_ByCategoryDesignNumber( catID, designNumber );

                    if ( subCodesList == null || subCodesList.Count == 0 ) {
                        comboBox_subCode.DataSource = null;
                    }
                    else {
                        subCodesList.Insert( 0, NOSELECTION_SUBCODE );
                        comboBox_subCode.DataSource = subCodesList;
                    }

                    endBusy();

                    // The Master code has been changed, the subscribers should do what they need to
                    OnStockItemListRefinedEvent( EventArgs.Empty );
                }
                catch ( NullReferenceException ) { // possibly an Empty Category - a category without items
                    endBusy();
                }
            }
        }

        private void comboBox_subCode_SelectedIndexChanged( object sender, EventArgs e ) {
            // The Sub code has been changed, the subscribers should do what they need to
            OnStockItemListRefinedEvent( EventArgs.Empty );
        }

        public void ResetControl() {
            reloadStockCategories();
            comboBox_MasterCode.DataSource = null;
            comboBox_subCode.DataSource = null;
        }

        private void reloadStockCategories() {
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

        private void startBusy() {
            label_Busy.Visible = true;
            label_Busy.Refresh();

            comboBox_StockCategory.Enabled = false;
            comboBox_MasterCode.Enabled = false;
            comboBox_subCode.Enabled = false;
        }

        private void endBusy() {
            label_Busy.Visible = false;

            comboBox_StockCategory.Enabled = true;
            comboBox_MasterCode.Enabled = true;
            comboBox_subCode.Enabled = true;
        }
    }
}
