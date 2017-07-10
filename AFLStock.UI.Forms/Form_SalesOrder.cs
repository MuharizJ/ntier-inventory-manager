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
    public partial class Form_SalesOrder : Form {
        const string NOSELECTION_CUSTOMER = "<Select a Customer>";
        const string FORM_NOT_SAVED = "ORDER NOT SAVED";
        private SalesOrderEntity _salesOrder;
        private StockConsumerLocal stockClient;

        private List<StockItemQuantityLogEntity> _itemDetailsToAdd = new List<StockItemQuantityLogEntity>();

        public Form_SalesOrder() {
            InitializeComponent();
            stockClient = StockConsumerLocal.getClientInstance();
        }

        public Form_SalesOrder( SalesOrderEntity salesOrder )
            : this() {
                _salesOrder = salesOrder;
        }

        #region Helpers
        private void enableGroupBoxes() {
            groupBox_ProductDetails.Enabled = true;
            groupBox_PurchaseItems.Enabled = true;

            if ( _salesOrder.SalesLogList == null ) {
                _salesOrder.SalesLogList = new BindingList<SalesLogEntity>();
            }
            dataGridView_SalesOrderLog.DataSource = _salesOrder.SalesLogList;
        }

        private void resetMasterDetails() {
            if ( _salesOrder.Details == null ) {
                _salesOrder.Details = "";
            }
            textBox_Details.Text = _salesOrder.Details;

            if ( _salesOrder.ExternalReferenceId == null ) {
                _salesOrder.ExternalReferenceId = "";
            }
            textBox_ReferenceID.Text = _salesOrder.ExternalReferenceId;

            if ( _salesOrder.TransactionDate == null ) {
                _salesOrder.TransactionDate = DateTime.Today;
            }
            dateTimePicker_SaleDate.Value = _salesOrder.TransactionDate;

            label_SalesOrderID.Text = _salesOrder.ID.ToString();

            loadCustomer();

            enableGroupBoxes();
        }

        private void loadCustomer() {
            BindingList<CustomerEntity> customerList = stockClient.getCustomers();
            if ( customerList[0] == null || !customerList[0].CustomerName.Equals( NOSELECTION_CUSTOMER) ) {
                customerList.Insert( 0, new CustomerEntity { CustomerName  = NOSELECTION_CUSTOMER } );
            }

            comboBox_Customer.DataSource = customerList;
            comboBox_Customer.DisplayMember = "CustomerName";

            comboBox_Customer.SelectedIndex = 0;

            if ( _salesOrder.ID != int.MinValue ) {
                string selectedCustomer = _salesOrder.Customer;

                for ( int i = 0; i < ( (BindingList<CustomerEntity>) ( comboBox_Customer.DataSource ) ).Count; i++ ) {
                    CustomerEntity customer = ( (BindingList<CustomerEntity>) ( comboBox_Customer.DataSource ) )[i];
                    if ( customer.CustomerName.Equals( selectedCustomer ) ) {
                        comboBox_Customer.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        #endregion

        private void Form_SalesOrder_Load( object sender, EventArgs e ) {
            if ( _salesOrder == null || _salesOrder.ID < 0 ) { // This is a new Sales Order
                _salesOrder = new SalesOrderEntity();
                _salesOrder.SalesLogList= new BindingList<SalesLogEntity>();
            }

            dataGridView_SalesOrderLog.AutoGenerateColumns = false;
            dataGridView_SalesOrderLog.AutoSize = true;

            DataGridViewTextBoxColumn colTB_Cat = new DataGridViewTextBoxColumn();
            colTB_Cat.DataPropertyName = "StockCategory";
            colTB_Cat.HeaderText = "Stock Category";
            colTB_Cat.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_SalesOrderLog.Columns.Add( colTB_Cat );

            DataGridViewTextBoxColumn colTB_Dsn = new DataGridViewTextBoxColumn();
            colTB_Dsn.DataPropertyName = "DesignNumber";
            colTB_Dsn.HeaderText = "Design Number";
            colTB_Dsn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_SalesOrderLog.Columns.Add( colTB_Dsn );

            DataGridViewTextBoxColumn colTB_Subcode = new DataGridViewTextBoxColumn();
            colTB_Subcode.DataPropertyName = "SubCode";
            colTB_Subcode.HeaderText = "Sub Code";
            colTB_Subcode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_SalesOrderLog.Columns.Add( colTB_Subcode );

            DataGridViewTextBoxColumn colTB_Quantity = new DataGridViewTextBoxColumn();
            colTB_Quantity.DataPropertyName = "Quantity";
            colTB_Quantity.HeaderText = "Quantity";
            colTB_Quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_SalesOrderLog.Columns.Add( colTB_Quantity );

            resetMasterDetails();
        }

        #region ToolStripMenu-EventHandlers
        private void newSalesOrderToolStripMenuItem_Click( object sender, EventArgs e ) {
            DialogResult result = MessageBox.Show( "Start a new Sales Order? Any unsaved data will be LOST!", "Warning - Data Loss Possible", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
            if ( result == DialogResult.Yes ) {
                _salesOrder= new SalesOrderEntity();
                resetMasterDetails();
            }
        }

        private void openSalesOrderToolStripMenuItem_Click( object sender, EventArgs e ) {
            Form_SalesOrder_Search soSearchForm = new Form_SalesOrder_Search();
            soSearchForm.ShowDialog();

            if ( soSearchForm.SalesOrder != null && soSearchForm.SalesOrder.ID != int.MinValue ) {
                _salesOrder = soSearchForm.SalesOrder;
                MessageBox.Show( "Sales Order was succesfully opened and will be loaded" );
                resetMasterDetails();
            }
            else {
                MessageBox.Show( "Sales Order was NOT opened", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }

        private void saveCloseSalesOrderToolStripMenuItem_Click( object sender, EventArgs e ) {
            DialogResult result = MessageBox.Show( "Save Sales Order and Exit?", "Warning - Contents will be saved to the system", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
            if ( result == DialogResult.Yes ) {
                button_Save.PerformClick();
                this.Close();
            }
        }

        private void deleteSalesOrderToolStripMenuItem_Click( object sender, EventArgs e ) {
            throw new NotSupportedException();
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e ) {
            DialogResult result = MessageBox.Show( "Exit without saving?", "Warning - Data Loss Possible", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
            if ( result == DialogResult.Yes ) {
                this.Close();
            }
        }
        #endregion

        private void stockItemSelector_Control_StockItemListRefinedEvent( object sender, EventArgs e ) {
            StockItemMasterEntity itemEnt = stockItemSelector_Control.GetSelectedStockItemMaster();
            if ( itemEnt != null ) {
                // that means it has a Item Quantity List
                if ( !itemEnt.Mutable ) {
                    button_BatchAdd.Enabled = true;
                    textBox_Qty.Enabled = false;
                    button_AddItem.Enabled = false;
                }
                else {
                    button_BatchAdd.Enabled = false;
                    textBox_Qty.Enabled = true;
                    button_AddItem.Enabled = true;
                }
                label_AvailableBalance.Text = availableBalanceQuantity( itemEnt ).ToString();
            }
            else {
                button_AddItem.Enabled = false;
                button_BatchAdd.Enabled = false;
                textBox_Qty.Enabled = false;
                label_AvailableBalance.Text = "0.00";
            }
        }

        private void button_AddItem_Click( object sender, EventArgs e ) {
            SalesLogEntity soLogEnt = new SalesLogEntity();
            StockItemMasterEntity itemEnt = stockItemSelector_Control.GetSelectedStockItemMaster();

            if ( itemEnt != null ) {
                
                soLogEnt.DesignNumber = itemEnt.DesignNumber;
                soLogEnt.SubCode = itemEnt.SubCode;
                soLogEnt.StockCategory = itemEnt.StockCategory;
                soLogEnt.UnitPrice = itemEnt.Cost_FinalUpdated; // as same as the import cost

                try {
                    soLogEnt.Quantity = double.Parse( textBox_Qty.Text );
                }
                catch ( Exception ) {
                    MessageBox.Show( "Invalid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    textBox_Qty.Text = "";
                    textBox_Qty.Focus();
                    return;
                }

                if ( !verifyQuantity(itemEnt, soLogEnt.Quantity) ) {
                    MessageBox.Show( "The Quantity you entered is more than the available balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    textBox_Qty.Text = "";
                    textBox_Qty.Focus();
                    return;
                }

                _salesOrder.SalesLogList.Add( soLogEnt );

                textBox_Qty.Text = "";
                textBox_Qty.Focus();
            }
            else {
                MessageBox.Show( "Invalid Stock Item - Please use the Drop-Down-Boxes to select a Valid Item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );

                stockItemSelector_Control.ResetControl();
                textBox_Qty.Text = "";
                button_BatchAdd.Enabled = false;
                button_AddItem.Enabled = false;
            }
        }

        private double availableBalanceQuantity( StockItemMasterEntity itemEnt ) {
            double balanceStock = 0;

            if(itemEnt != null) {
                balanceStock = itemEnt.CurrentStock;

                if ( _salesOrder != null && _salesOrder.SalesLogList != null ) {
                    foreach ( SalesLogEntity salesLogEnt in _salesOrder.SalesLogList ) {
                        if ( salesLogEnt != null ) {
                            if ( salesLogEnt.StockCategory.Equals( itemEnt.StockCategory ) &&
                                salesLogEnt.DesignNumber.Equals( itemEnt.DesignNumber ) &&
                                salesLogEnt.SubCode.Equals( itemEnt.SubCode ) ) {
                                    balanceStock -= salesLogEnt.Quantity;
                            }
                        }
                    }
                }
            }

            return balanceStock;
        }

        private bool verifyQuantity( StockItemMasterEntity itemEnt, double qty ) {
            bool result = true;

            if ( availableBalanceQuantity( itemEnt ) < qty ) {
                result = false;
            }

            return result;
        }

        private void button_BatchAdd_Click( object sender, EventArgs e ) {
            StockItemMasterEntity itemMasterEnt = stockItemSelector_Control.GetSelectedStockItemMaster();
            
            if ( itemMasterEnt != null && !itemMasterEnt.Mutable ) {
                Form_BatchAddSalesStockItem formBatchAdd = new Form_BatchAddSalesStockItem( _salesOrder.ID, itemMasterEnt, _salesOrder.Customer, _itemDetailsToAdd );
                formBatchAdd.ShowDialog();
                foreach ( StockItemQuantityLogEntity itemDetailLog in formBatchAdd.SelectedStockItems ) {
                    if ( itemDetailLog != null ) {
                        if ( !_itemDetailsToAdd.Contains( itemDetailLog ) ) {
                            _itemDetailsToAdd.Add( itemDetailLog );
                        }
                        SalesLogEntity newSaleLogEnt = new SalesLogEntity();
                        newSaleLogEnt.DesignNumber = itemDetailLog.DesignNumber;
                        newSaleLogEnt.Quantity = itemDetailLog.Quantity;
                        newSaleLogEnt.StockCategory = itemDetailLog.StockCategory;
                        newSaleLogEnt.SubCode = itemDetailLog.SubCode;
                        newSaleLogEnt.UnitPrice = itemMasterEnt.Cost_FinalUpdated;
                        newSaleLogEnt.ParentSalesOrderID = _salesOrder.ID;

                        _salesOrder.SalesLogList.Add( newSaleLogEnt ); 
                    }
                }
            }
        }

        private void dataGridView_SalesOrderLog_UserDeletingRow( object sender, DataGridViewRowCancelEventArgs e ) {
            DataGridViewSelectedRowCollection selectedRows = dataGridView_SalesOrderLog.SelectedRows;

            foreach ( DataGridViewRow selectedRow in selectedRows ) {
                SalesLogEntity salesLogItem_Deleting = (SalesLogEntity) selectedRow.DataBoundItem;
                
                // If the Sales-Order-Log exists, make an immediate trip to the database and delete this SalesLogItem, this will also update the stock
                // item master table along with an addition to the 
                if ( stockClient.salesOrderLogExists( salesLogItem_Deleting.ID ) ) {
                    stockClient.deleteSalesOrderLog( salesLogItem_Deleting.ID );
                }
                // if not, we will just let the Datagrid remove this unsaved sales-order-log from the Lists
                // AND remove the associated StockItemDetail object from _itemDetailsToAdd
                else {
                    int indexToRemove = -1;
                    for ( int i = 0; i < _itemDetailsToAdd.Count; i++ ) {
                        StockItemQuantityLogEntity itemDetailEnt = _itemDetailsToAdd[i];
                        
                        // We have a MATCH
                        if ( itemDetailEnt.StockCategory.Equals( salesLogItem_Deleting.StockCategory ) &&
                            itemDetailEnt.DesignNumber.Equals( salesLogItem_Deleting.DesignNumber ) &&
                            itemDetailEnt.SubCode.Equals( salesLogItem_Deleting.SubCode ) &&
                            itemDetailEnt.Quantity == salesLogItem_Deleting.Quantity ) {
                            
                            indexToRemove = i;
                            break;
                        }
                    }

                    if ( indexToRemove != -1 ) {
                        _itemDetailsToAdd.RemoveAt( indexToRemove );                        
                    }                    
                }
            }
        }

        private void button_Save_Click( object sender, EventArgs e ) {
            // This list will be sent to the DAL instead of the full list of Purchase Logs to save network and processing resources
            BindingList<SalesLogEntity> soLogsThatNeedSaving = new BindingList<SalesLogEntity>();

            if ( setSalesOrder_FromControls() ) {
                // First we will find which PO-Logs need saving by checking their Dirty value
                foreach ( SalesLogEntity soLogEnt in _salesOrder.SalesLogList ) {
                    if ( soLogEnt.Dirty ) {
                        soLogsThatNeedSaving.Add( soLogEnt );
                    }
                }
            }
            else {
                return;
            }

            // By this point all validation has been done, we need to try and save this Sales Order
            BindingList<SalesLogEntity> soLogsThatDontNeedSaving = _salesOrder.SalesLogList;
            _salesOrder.SalesLogList = soLogsThatNeedSaving;

            bool result = saveSalesOrder();

            foreach ( SalesLogEntity soLogsUpdated in _salesOrder.SalesLogList ) {
                soLogsUpdated.Dirty = false;
            }

            _salesOrder.SalesLogList = soLogsThatDontNeedSaving;

            button_Save.Enabled = true;

            // The purchase order was updated successfully to the system OR NOT
            if ( result ) {
                // success
                label_SalesOrderID.Text = _salesOrder.ID.ToString();
                MessageBox.Show( "Sales Order was saved successfully" );
            }
            else {
                MessageBox.Show( "Sales Order was not saved due to an error", "Error", MessageBoxButtons.OK );
                resetMasterDetails();
            }
        }

        private bool saveSalesOrder() {
            bool result = false;
            try {
                result = stockClient.saveSalesOrder( _salesOrder);
            }
            catch ( Exception e ) {
                result = false;
            }

            return result;
        }

        private bool setSalesOrder_FromControls() {
            bool result = false;

            try {
                _salesOrder.Details = textBox_Details.Text;
                _salesOrder.ExternalReferenceId = textBox_ReferenceID.Text;
                _salesOrder.TransactionDate = dateTimePicker_SaleDate.Value;

                if ( _salesOrder.ID == int.MinValue ) {
                    // _purchaseOrder.Customer will be attempted to be set from the combo-box, if it failes (AKA null) then it will go directly to the catch
                    // if not, it will check to see whether no-selection-customer has been set
                    if ( ( _salesOrder.Customer = ( (CustomerEntity) ( comboBox_Customer.SelectedItem ) ).CustomerName ).Equals( NOSELECTION_CUSTOMER) ) {
                        _salesOrder.Customer = null; // better to reset this to null so in case i fail to catch this validation, it will fail somewhere else BADLY!
                        throw new Exception( "A valid Customer was not selected" );
                    }

                    // by this point, _salesOrder.Customer has been selected, here's another validation to check whether this Customer actually exists
                    if ( !stockClient.customerExists( _salesOrder.Customer) ) {
                        _salesOrder.Customer= null; // better to reset this to null so in case i fail to catch this validation, it will fail somewhere else BADLY!
                        throw new Exception( "This Customer doesn't exist in the system, Please ask your Administrator to create this Customer" );
                    }
                }
                else { // this is an already existing Sales order, if a valid Customer is not selected, we need to revert back to the old one
                    if ( comboBox_Customer.SelectedItem != null ) { // don't touch the customer-feild in the Sales Order if nothing is selected in the combo-box
                        if ( !stockClient.customerExists( _salesOrder.Customer) ) {
                            throw new Exception( "This Customer doesn't exist in the system, Please ask your Administrator to create this Customer" );
                        }
                        else if ( ( (CustomerEntity) ( comboBox_Customer.SelectedItem ) ).CustomerName.Equals( NOSELECTION_CUSTOMER ) ) {
                            throw new Exception( "A valid Customer was not selected" );
                        }
                        else {
                            _salesOrder.Customer = ( (CustomerEntity) ( comboBox_Customer.SelectedItem ) ).CustomerName;
                        }
                    }
                }
                result = true;
            }
            catch ( Exception ee ) {
                MessageBox.Show( "Oops, There was an ERROR! Sales Order was NOT Saved. Show this to your Admin: [REASON] - " + ee.Message );
            }

            return result;
        }
    }
}
