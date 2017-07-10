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

using AFLStock.WCF.Client.ServiceReference;

namespace AFLStock.UI.Forms {
    public partial class Form_SalesOrder_Search : Form {
        const string NOSELECTION_CUSTOMER = "<Select a Customer>";

        SalesOrderEntity _salesOrder;
        StockConsumerLocal stockClient = StockConsumerLocal.getClientInstance();

        public SalesOrderEntity SalesOrder {
            get {
                return _salesOrder;
            }
        }

        public Form_SalesOrder_Search() {
            InitializeComponent();
            _salesOrder = null;
        }

        private void Form_SalesOrder_Search_Load( object sender, EventArgs e ) {
            #region DataGridView-SalesOrder
            dataGridView_SOs.AutoGenerateColumns = false;
            dataGridView_SOs.AutoSize = true;

            DataGridViewTextBoxColumn colTB_ID = new DataGridViewTextBoxColumn();
            colTB_ID.DataPropertyName = "ID";
            colTB_ID.HeaderText = "ID";
            colTB_ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_SOs.Columns.Add( colTB_ID );

            DataGridViewTextBoxColumn colTB_Customer = new DataGridViewTextBoxColumn();
            colTB_Customer.DataPropertyName = "CustomerName";
            colTB_Customer.HeaderText = "Customer Name";
            colTB_Customer.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_SOs.Columns.Add( colTB_Customer );

            DataGridViewTextBoxColumn colTB_Details = new DataGridViewTextBoxColumn();
            colTB_Details.DataPropertyName = "Details";
            colTB_Details.HeaderText = "Details";
            colTB_Details.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_SOs.Columns.Add( colTB_Details );

            DataGridViewTextBoxColumn colTB_TransactionDate = new DataGridViewTextBoxColumn();
            colTB_TransactionDate.DataPropertyName = "SalesOrderDate";
            colTB_TransactionDate.HeaderText = "Sales Order Date";
            colTB_TransactionDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_SOs.Columns.Add( colTB_TransactionDate );

            DataGridViewTextBoxColumn colTB_ExternalReferenceId = new DataGridViewTextBoxColumn();
            colTB_ExternalReferenceId.DataPropertyName = "ExternalReferenceID";
            colTB_ExternalReferenceId.HeaderText = "External Reference ID";
            colTB_ExternalReferenceId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_SOs.Columns.Add( colTB_ExternalReferenceId );
            #endregion

            #region DataGridView-CategorisedOrderDetail_Transfer
            dataGridView_SOdetail.AutoGenerateColumns = false;
            dataGridView_SOdetail.AutoSize = true;

            DataGridViewTextBoxColumn colTB_DetailCategory = new DataGridViewTextBoxColumn();
            colTB_DetailCategory.DataPropertyName = "StockCategory";
            colTB_DetailCategory.HeaderText = "Stock Category";
            colTB_DetailCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_SOdetail.Columns.Add( colTB_DetailCategory );

            DataGridViewTextBoxColumn colTB_TotalStock = new DataGridViewTextBoxColumn();
            colTB_TotalStock.DataPropertyName = "Quantity";
            colTB_TotalStock.HeaderText = "Total Quantity";
            colTB_TotalStock.ValueType = typeof( double );
            colTB_TotalStock.DefaultCellStyle.Format = ( "##,##0.00" );
            colTB_TotalStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_SOdetail.Columns.Add( colTB_TotalStock );

            DataGridViewTextBoxColumn colTB_UnitType = new DataGridViewTextBoxColumn();
            colTB_UnitType.DataPropertyName = "UnitType";
            colTB_UnitType.HeaderText = "Unit Type";
            dataGridView_SOdetail.Columns.Add( colTB_UnitType );
            #endregion
        }

        private void button_Cancel_Click( object sender, EventArgs e ) {
            _salesOrder = null;
            this.Close();
        }

        private void loadCustomers() {
            BindingList<CustomerEntity> customerList = stockClient.getCustomers();
            if ( customerList[0] == null || !customerList[0].CustomerName.Equals( NOSELECTION_CUSTOMER) ) {
                customerList.Insert( 0, new CustomerEntity{ CustomerName = NOSELECTION_CUSTOMER } );
            }

            comboBox_Customer.DataSource = customerList;
            comboBox_Customer.DisplayMember = "CustomerName";

            comboBox_Customer.SelectedIndex = 0;
        }

        private void button_ListPOs_Click( object sender, EventArgs e ) {
            button_ListSOs.Enabled = false;
            label_Busy.Visible = true;
            label_Busy.Refresh();

            /* This is the old deprecated call that goes to the DAL through the network - takes way too long
            dataGridView_SOs.DataSource = stockClient.getSalesOrders_All();
             * */
            AFLStockServiceClient client = new AFLStockServiceClient();
            dataGridView_SOs.DataSource = client.GetSalesOrders_Simplified();

            label_Busy.Visible = false;
            button_ListSOs.Enabled = true;
        }

        private void dataGridView_SOs_CellDoubleClick( object sender, DataGridViewCellEventArgs e ) {
            button_SelectSO.PerformClick();
        }

        private void dataGridView_SOs_SelectionChanged(object sender, EventArgs e) {
            if (dataGridView_SOs.CurrentRow != null && dataGridView_SOs.CurrentRow.DataBoundItem != null) {
                AFLStock.WCF.Client.ServiceReference.SalesOrder_POCO soPOCO = (AFLStock.WCF.Client.ServiceReference.SalesOrder_POCO)dataGridView_SOs.CurrentRow.DataBoundItem;

                dataGridView_SOdetail.DataSource = soPOCO.SalesOrderDetailList;
                dataGridView_SOdetail.ClearSelection();
            }
        }

        private void button_SelectSO_Click( object sender, EventArgs e ) {
            int soID = int.MinValue;

            if (dataGridView_SOs.CurrentRow != null && dataGridView_SOs.CurrentRow.DataBoundItem != null) {
                AFLStock.WCF.Client.ServiceReference.SalesOrder_POCO soPOCO = (AFLStock.WCF.Client.ServiceReference.SalesOrder_POCO)dataGridView_SOs.CurrentRow.DataBoundItem;
                soID = soPOCO.ID;
            }

            if (stockClient.salesOrderExists(soID)) {
                _salesOrder = stockClient.getSalesOrder(soID);
            }

            // _salesOrder will either be null OR it will be loaded via a legal poID obtained from the WCF transferred POCO objects
            this.Close();
        }
    }
}
