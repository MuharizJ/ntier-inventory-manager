using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

using AFLStock.Entities;
using AFLStock.Consumer;
using System.Diagnostics;

namespace AFLStock.UI.Forms {
    public partial class Form_PurchaseOrder : Form {
        const string NOSELECTION_SUPPLIER = "<Select a Supplier>";
        const string FORM_NOT_SAVED = "ORDER NOT SAVED";
        private PurchaseOrderEntity _purchaseOrder;
        private StockConsumerLocal stockClient;

        private List<PurchaseLogEntity> _deletedPurchaseLogs = new List<PurchaseLogEntity>();


        public Form_PurchaseOrder() {
            InitializeComponent();
            stockClient = StockConsumerLocal.getClientInstance();
        }

        public Form_PurchaseOrder( PurchaseOrderEntity purchaseOrder )
            : base() {
            _purchaseOrder = purchaseOrder;
        }

        #region Helpers
        private void enableGroupBoxes() {
            groupBox_ProductDetails.Enabled = true;
            groupBox_PurchaseItems.Enabled = true;

            if ( _purchaseOrder.PurchaseLogList == null ) {
                _purchaseOrder.PurchaseLogList = new BindingList<PurchaseLogEntity>();
            }
            dataGridView_PurchaseOrderLog.DataSource = _purchaseOrder.PurchaseLogList;
        }

        private void resetMasterDetails() {
            label_Saving.Text = "";

            if ( _purchaseOrder.Details == null ) {
                _purchaseOrder.Details = "";
            }
            textBox_Details.Text = _purchaseOrder.Details;

            if ( _purchaseOrder.ExternalReferenceId == null ) {
                _purchaseOrder.ExternalReferenceId = "";
            }
            textBox_ReferenceID.Text = _purchaseOrder.ExternalReferenceId;

            if ( _purchaseOrder.TransactionDate == null ) {
                _purchaseOrder.TransactionDate = DateTime.Today;
            }
            dateTimePicker_PurchaseDate.Value = _purchaseOrder.TransactionDate;

            label_PurchaseID.Text = _purchaseOrder.ID.ToString();

            loadSuppliers();

            enableGroupBoxes();
        }

        private void loadSuppliers() {
            BindingList<SupplierEntity> supplierList = stockClient.getSuppliers();
            if ( supplierList[0] == null || !supplierList[0].SupplierName.Equals( NOSELECTION_SUPPLIER ) ) {
                supplierList.Insert( 0, new SupplierEntity { SupplierName = NOSELECTION_SUPPLIER } );
            }

            comboBox_Supplier.DataSource = supplierList;
            comboBox_Supplier.DisplayMember = "SupplierName";

            comboBox_Supplier.SelectedIndex = 0;

            if ( _purchaseOrder.ID != int.MinValue ) {
                string selectedSupplier = _purchaseOrder.Supplier;

                for ( int i = 0; i < ( (BindingList<SupplierEntity>) ( comboBox_Supplier.DataSource ) ).Count; i++ ) {
                    SupplierEntity supplier = ( (BindingList<SupplierEntity>) ( comboBox_Supplier.DataSource ) )[i];
                    if ( supplier.SupplierName.Equals( selectedSupplier ) ) {
                        comboBox_Supplier.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        #endregion

        private void Form_StockPurchase_Load( object sender, EventArgs e ) {
            // This is a new Purchase Order
            if ( _purchaseOrder == null || _purchaseOrder.ID < 0 ) {
                _purchaseOrder = new PurchaseOrderEntity();
                _purchaseOrder.PurchaseLogList = new BindingList<PurchaseLogEntity>();
            }

            dataGridView_PurchaseOrderLog.AutoGenerateColumns = false;
            dataGridView_PurchaseOrderLog.AutoSize = true;

            DataGridViewTextBoxColumn colTB_Cat = new DataGridViewTextBoxColumn();
            colTB_Cat.DataPropertyName = "StockCategory";
            colTB_Cat.HeaderText = "Stock Category";
            colTB_Cat.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_PurchaseOrderLog.Columns.Add( colTB_Cat );

            DataGridViewTextBoxColumn colTB_Dsn = new DataGridViewTextBoxColumn();
            colTB_Dsn.DataPropertyName = "DesignNumber";
            colTB_Dsn.HeaderText = "Design Number";
            colTB_Dsn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_PurchaseOrderLog.Columns.Add( colTB_Dsn );

            DataGridViewTextBoxColumn colTB_Subcode = new DataGridViewTextBoxColumn();
            colTB_Subcode.DataPropertyName = "SubCode";
            colTB_Subcode.HeaderText = "Sub Code";
            colTB_Subcode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_PurchaseOrderLog.Columns.Add( colTB_Subcode );

            DataGridViewTextBoxColumn colTB_Quantity = new DataGridViewTextBoxColumn();
            colTB_Quantity.DataPropertyName = "Quantity";
            colTB_Quantity.HeaderText = "Quantity";
            colTB_Quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_PurchaseOrderLog.Columns.Add( colTB_Quantity );

            resetMasterDetails();

            // The user control being hooked up to a local event-handler method called "stockItemSelector_Control_StockItemListRefinedEvent"
            stockItemSelector_Control.StockItemListRefinedEvent += new EventHandler( stockItemSelector_Control_StockItemListRefinedEvent );

            attachToolStripMenuEventHandlers();
        }

        #region ToolStripMenu-EventHandlers
        private void attachToolStripMenuEventHandlers() {
            toolStripMenuItem_Admin_NewCategory.Click += new EventHandler( toolStripMenuItem_Admin_NewCategory_Click );
            toolStripMenuItem_Admin_NewProduct.Click += new EventHandler( toolStripMenuItem_Admin_NewProduct_Click );
            toolStripMenuItem_File_NewPO.Click += new EventHandler( toolStripMenuItem_File_NewPO_Click );
            toolStripMenuItem_File_DeletePO.Click += new EventHandler( toolStripMenuItem_File_DeletePO_Click );
            toolStripMenuItem_File_Exit.Click += new EventHandler( toolStripMenuItem_File_Exit_Click );
            toolStripMenuItem_File_OpenPO.Click += new EventHandler( toolStripMenuItem_File_OpenPO_Click );
            toolStripMenuItem_File_SaveClosePO.Click += new EventHandler( toolStripMenuItem_File_SaveClosePO_Click );
        }

        private void toolStripMenuItem_File_OpenPO_Click( object sender, EventArgs e ) {
            Form_PurchaseOrder_Search poSearchForm = new Form_PurchaseOrder_Search();
            poSearchForm.ShowDialog();

            if ( poSearchForm.PurchaseOrder != null && poSearchForm.PurchaseOrder.ID != int.MinValue ) {
                _purchaseOrder = poSearchForm.PurchaseOrder;
                MessageBox.Show( "Purchase Order was succesfully opened and will be loaded" );
                resetMasterDetails();
            }
            else {
                MessageBox.Show( "Purchase Order was NOT opened", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }

        private void toolStripMenuItem_File_NewPO_Click( object sender, EventArgs e ) {
            DialogResult result = MessageBox.Show( "Start a new Purchase Order? Any unsaved data will be LOST!", "Warning - Data Loss Possible", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
            if ( result == DialogResult.Yes ) {
                _purchaseOrder = new PurchaseOrderEntity();
                resetMasterDetails();
            }
        }

        private void toolStripMenuItem_File_SaveClosePO_Click( object sender, EventArgs e ) {
            DialogResult result = MessageBox.Show( "Save Purchase Order and Exit?", "Warning - Contents will be saved to the system", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
            if ( result == DialogResult.Yes ) {
                button_Save.PerformClick();
                this.Close();
            }
        }

        private void toolStripMenuItem_File_Exit_Click( object sender, EventArgs e ) {
            DialogResult result = MessageBox.Show( "Exit without saving?", "Warning - Data Loss Possible", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
            if ( result == DialogResult.Yes ) {
                this.Close();
            }
        }

        private void toolStripMenuItem_File_DeletePO_Click( object sender, EventArgs e ) {
            if ( _purchaseOrder.ID != int.MinValue ) {
                DialogResult result = MessageBox.Show( "This Purchase Order is already in the system. Deleting it will affect the stock quantities. Are you sure you want to proceed?", "Imminent - Data Loss!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
                if ( result == DialogResult.Yes ) {
                    stockClient.deletePurchaseOrder( _purchaseOrder.ID );
                    _purchaseOrder = new PurchaseOrderEntity();
                    resetMasterDetails();
                }
            }
            else {
                DialogResult result = MessageBox.Show( "This Purchase Order has not been saved. Do you wish to delete it?", "Warning - Data Loss Possible", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
                if ( result == DialogResult.Yes ) {
                    _purchaseOrder = new PurchaseOrderEntity();
                    resetMasterDetails();
                }
            }
        }

        private void toolStripMenuItem_Admin_NewProduct_Click( object sender, EventArgs e ) {
            new Form_StockItemNew().ShowDialog();
            stockItemSelector_Control.ResetControl();
        }

        private void toolStripMenuItem_Admin_NewCategory_Click( object sender, EventArgs e ) {
            new Form_StockCategories().ShowDialog();
            stockItemSelector_Control.ResetControl();
        }
        #endregion

        private void stockItemSelector_Control_StockItemListRefinedEvent( object sender, EventArgs e ) {
            StockItemMasterEntity itemEnt = stockItemSelector_Control.GetSelectedStockItemMaster();
            if ( itemEnt != null ) {
                textBox_Qty.Enabled = true;
                button_AddItem.Enabled = true;
                textBox_Cost.Enabled = true;
                textBox_Cost.Text = itemEnt.Cost_FinalUpdated.ToString();

                if ( !itemEnt.Mutable ) {
                    button_BatchAdd.Enabled = true;
                }
                else {
                    button_BatchAdd.Enabled = false;
                }
            }
            else {
                button_AddItem.Enabled = false;
                button_BatchAdd.Enabled = false;
                textBox_Qty.Enabled = false;
                textBox_Cost.Enabled = false;
                textBox_Cost.Text = "";
            }
        }

        private void button_AddItem_Click( object sender, EventArgs e ) {
            PurchaseLogEntity poLogEnt = new PurchaseLogEntity();
            StockItemMasterEntity itemEnt = stockItemSelector_Control.GetSelectedStockItemMaster();

            if ( itemEnt != null ) {
                double oldPrice = itemEnt.Cost_FinalUpdated;
                double newPrice = double.MinValue;
                try {
                    newPrice = double.Parse( textBox_Cost.Text );
                }
                catch ( Exception ) {
                    newPrice = itemEnt.Cost_FinalUpdated;
                    textBox_Cost.Text = newPrice.ToString();
                }

                poLogEnt.DesignNumber = itemEnt.DesignNumber;
                poLogEnt.SubCode = itemEnt.SubCode;
                poLogEnt.StockCategory = itemEnt.StockCategory;
                poLogEnt.UnitCostLKR = newPrice;

                try {
                    poLogEnt.Quantity = double.Parse( textBox_Qty.Text );
                }
                catch ( Exception ) {
                    MessageBox.Show( "Invalid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    textBox_Qty.Text = "";
                    textBox_Qty.Focus();
                    return;
                }

                _purchaseOrder.PurchaseLogList.Add( poLogEnt );

                dataGridView_PurchaseOrderLog.FirstDisplayedScrollingRowIndex = _purchaseOrder.PurchaseLogList.Count-1;
                
                textBox_Qty.Text = "";
                textBox_Qty.Focus();

                if ( newPrice != oldPrice ) { // we need to ask the user if he wants to update all the stock-item's costs
                    if ( MessageBox.Show( "The cost for the produce type:\t" +
                      itemEnt.StockCategory +
                      itemEnt.DesignNumber +
                      "\thas been changed, do you wish to update these changes to the system?",
                      "Data change warning",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Warning ) == DialogResult.Yes ) {
                        stockClient.StockItemDesign_UpdateCosts( itemEnt.StockCategory, itemEnt.DesignNumber, newPrice );
                    }
                }
            }
            else {
                MessageBox.Show( "Invalid Stock Item - Please use the Drop-Down-Boxes to select a Valid Item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );

                stockItemSelector_Control.ResetControl();
                textBox_Qty.Text = "";
                button_BatchAdd.Enabled = false;
            }
        }

        private void button_BatchAdd_Click( object sender, EventArgs e ) {
            StockItemMasterEntity itemMasterEnt = stockItemSelector_Control.GetSelectedStockItemMaster();
            double oldPrice = itemMasterEnt.Cost_FinalUpdated;

            if ( itemMasterEnt != null ) {
                List<double> quantitiesToAdd;
                new Form_BatchAddPurchaseStockItem( itemMasterEnt, _purchaseOrder.ID, _purchaseOrder.Supplier, out quantitiesToAdd ).ShowDialog( this );

                if ( itemMasterEnt.Cost_FinalUpdated != oldPrice ) {
                    // Ask the user whether he wants to update all the stock items with this design number to the new cost
                    if ( MessageBox.Show( "The cost for the produce type: " +
                                          itemMasterEnt.StockCategory +
                                          itemMasterEnt.DesignNumber +
                                          "has been changed, do you wish to update these changes to the system?",
                                          "Data change warning",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning ) == DialogResult.Yes ) {
                        stockClient.StockItemDesign_UpdateCosts( itemMasterEnt.StockCategory, itemMasterEnt.DesignNumber, itemMasterEnt.Cost_FinalUpdated );
                    }
                }

                foreach ( double d in quantitiesToAdd ) {
                    PurchaseLogEntity poLogEnt = new PurchaseLogEntity();
                    poLogEnt.DesignNumber = itemMasterEnt.DesignNumber;
                    poLogEnt.Quantity = d;
                    poLogEnt.StockCategory = itemMasterEnt.StockCategory;
                    poLogEnt.SubCode = itemMasterEnt.SubCode;

                    _purchaseOrder.PurchaseLogList.Add( poLogEnt );
                }
            }
            else {
                MessageBox.Show( "Cannot initiate Batch-Add, Invalid Stock Item Selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void button_Save_Click( object sender, EventArgs e ) {
            // This list will be sent to the DAL instead of the full list of Purchase Logs to save network and processing resources
            BindingList<PurchaseLogEntity> poLogsThatNeedSaving = new BindingList<PurchaseLogEntity>();

            // The setPurchaseOrder_FromControls() method validates input
            if ( setPurchaseOrder_FromControls() ) {
                
                // First we will find which PO-Logs need saving by checking their Dirty value
                foreach ( PurchaseLogEntity poLogEnt in _purchaseOrder.PurchaseLogList ) {
                    if ( poLogEnt.Dirty ) {
                        poLogsThatNeedSaving.Add( poLogEnt );
                    }
                }

                // _deletedPurchaseLogs keeps track of poLogs that were removed from the
                // datagridview --> these must be added back and sent to the DAL for real deletion
                foreach ( PurchaseLogEntity deletedPoLogEnt in _deletedPurchaseLogs ) {                    
                    if ( !_purchaseOrder.PurchaseLogList.Contains( deletedPoLogEnt ) ) {
                        poLogsThatNeedSaving.Add( deletedPoLogEnt );
                    }
                }
                _deletedPurchaseLogs = new List<PurchaseLogEntity>();
            }
            else { // if validation failed, no need to continue
                return;
            }            

            // By this point, all validation has occurred in the setPurchaseOrder_FromControls - The only thing left to do is save the po
            // we will start a thread for the Network-Based Save Call
            // then we will do some wait animations and give the user some options to cancel out of long network calls

            label_Saving.Text = "Attempting to Save - This can take some time. Please be patient";
            button_Save.Enabled = false;
            button_Save.Refresh();
            label_Saving.Refresh();

            BindingList<PurchaseLogEntity> poLogsThatDontNeedSaving = _purchaseOrder.PurchaseLogList;
            _purchaseOrder.PurchaseLogList = poLogsThatNeedSaving;
            
            bool result = savePurchaseOrder();
            
            foreach ( PurchaseLogEntity poLogsUpdated in _purchaseOrder.PurchaseLogList ) {
                poLogsUpdated.Dirty = false;
            }

            _purchaseOrder.PurchaseLogList = poLogsThatDontNeedSaving;

            label_Saving.Text = "";
            button_Save.Enabled = true;
            button_Save.Refresh();
            label_Saving.Refresh();

            // The purchase order was updated successfully to the system OR NOT
            if ( result ) {
                // success
                label_PurchaseID.Text = _purchaseOrder.ID.ToString();
                MessageBox.Show( "Purchase Order was saved successfully" );
            }
            else {
                MessageBox.Show( "Purchase Order was not saved due to an error", "Error", MessageBoxButtons.OK );
                resetMasterDetails();
            }
        }

        private bool savePurchaseOrder() {
            bool result = false;
            try {
                result = stockClient.savePurchaseOrder( _purchaseOrder );
            }
            catch ( Exception e ) {
                result = false;
            }

            return result;
        }

        private bool setPurchaseOrder_FromControls() {
            bool result = false;

            try {
                _purchaseOrder.Details = textBox_Details.Text;
                _purchaseOrder.ExternalReferenceId = textBox_ReferenceID.Text;
                _purchaseOrder.TransactionDate = dateTimePicker_PurchaseDate.Value;

                // If this is an unsaved Purchase-Order, there is no supplier in the datastore set for this PO, so some care is needed
                if ( _purchaseOrder.ID == int.MinValue ) {
                    // _purchaseOrder.Supplier will be attempted to be set from the combo-box, if it failes (AKA null) then it will go directly to the catch
                    // if not, it will check to see whether no-selection-supplier has been set
                    if ( ( _purchaseOrder.Supplier = ( (SupplierEntity) ( comboBox_Supplier.SelectedItem ) ).SupplierName ).Equals( NOSELECTION_SUPPLIER ) ) {
                        _purchaseOrder.Supplier = null; // better to reset this to null so in case i fail to catch this validation, it will fail somewhere else BADLY!
                        throw new Exception( "A valid supplier was not selected" );
                    }

                    // by this point, _purchaseOrder.Supplier has been selected, here's another validation to check whether this supplier actually exists
                    if ( !stockClient.SupplierExists( _purchaseOrder.Supplier ) ) {
                        _purchaseOrder.Supplier = null; // better to reset this to null so in case i fail to catch this validation, it will fail somewhere else BADLY!
                        throw new Exception( "This supplier doesn't exist in the system, Please ask your Administrator to create this Supplier" );
                    }
                }
                else { // this is an already existing purchase order, if a valid supplier is not selected, we need to revert back to the old one
                    if ( comboBox_Supplier.SelectedItem != null ) { // don't touch the supplier-feild in the PO if nothing is selected in the combo-box
                        if ( !stockClient.SupplierExists( _purchaseOrder.Supplier ) ) {
                            throw new Exception( "This supplier doesn't exist in the system, Please ask your Administrator to create this Supplier" );
                        }
                        else if ( ( (SupplierEntity) ( comboBox_Supplier.SelectedItem ) ).SupplierName.Equals( NOSELECTION_SUPPLIER ) ) {
                            throw new Exception( "A valid supplier was not selected" );
                        }
                        else {
                            _purchaseOrder.Supplier = ( (SupplierEntity) ( comboBox_Supplier.SelectedItem ) ).SupplierName;
                        }
                    }
                }

                result = true;
            }
            catch ( Exception ee ) {
                MessageBox.Show( "Oops, There was an ERROR! Purchase Order was NOT Saved. [REASON] - " + ee.Message );
            }

            return result;
        }

        private void dataGridView_PurchaseOrderLog_UserDeletingRow( object sender, DataGridViewRowCancelEventArgs e ) {
            DataGridViewSelectedRowCollection selectedRows = dataGridView_PurchaseOrderLog.SelectedRows;
            foreach ( DataGridViewRow selectedRow in selectedRows ) {
                PurchaseLogEntity selectedItem = (PurchaseLogEntity) selectedRow.DataBoundItem;
                if ( selectedItem.ID != int.MinValue && !_deletedPurchaseLogs.Contains( selectedItem ) ) {
                    _deletedPurchaseLogs.Add( selectedItem );
                    selectedItem.MarkedForDeletion = true;
                    selectedItem.Dirty = true;
                }
            }
        }

        private void textBox_Qty_KeyPress( object sender, KeyPressEventArgs e ) {
            if ( e.KeyChar == (char) Keys.Return ) {
                button_AddItem.PerformClick();
            }
        }

        private void dataGridView_PurchaseOrderLog_CellDoubleClick( object sender, DataGridViewCellEventArgs e ) {
            try {
                int indexOfQty = 3; // this is the index of the column Quantity

                PurchaseLogEntity selectedLogEnt = (PurchaseLogEntity) dataGridView_PurchaseOrderLog.Rows[e.RowIndex].DataBoundItem;
                DataGridViewCell cell = dataGridView_PurchaseOrderLog.Rows[e.RowIndex].Cells[indexOfQty];
                dataGridView_PurchaseOrderLog.CurrentCell = cell;
                dataGridView_PurchaseOrderLog.BeginEdit( true );
            }
            catch ( Exception ee ) {
                MessageBox.Show( ee.ToString() );
            }
        }

        private void dataGridView_PurchaseOrderLog_CellBeginEdit( object sender, DataGridViewCellCancelEventArgs e ) {
            try {
                int indexOfQty = 3; // this is the index of the column Quantity

                if ( e.ColumnIndex != indexOfQty ) {
                    PurchaseLogEntity selectedLogEnt = (PurchaseLogEntity) dataGridView_PurchaseOrderLog.Rows[e.RowIndex].DataBoundItem;
                    DataGridViewCell cell = dataGridView_PurchaseOrderLog.Rows[e.RowIndex].Cells[indexOfQty];
                    dataGridView_PurchaseOrderLog.CurrentCell = cell;
                }
            }
            catch ( Exception ee ) {
                MessageBox.Show( ee.ToString() );
            }
        }
    }
}
