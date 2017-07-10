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
    public partial class Form_PurchaseOrder_Search : Form {
        const string NOSELECTION_SUPPLIER = "<Select a Supplier>";

        PurchaseOrderEntity _purchaseOrder;
        StockConsumerLocal stockClient = StockConsumerLocal.getClientInstance();

        public PurchaseOrderEntity PurchaseOrder {
            get {
                return _purchaseOrder;
            }
        }

        public Form_PurchaseOrder_Search() {
            InitializeComponent();
            _purchaseOrder = null;
        }
        
        private void Form_PurchaseOrder_Search_Load(object sender, EventArgs e) {
            #region DataGridView-PurchaseOrder
            dataGridView_POs.AutoGenerateColumns = false;
            dataGridView_POs.AutoSize = true;

            DataGridViewTextBoxColumn colTB_ID = new DataGridViewTextBoxColumn();
            colTB_ID.DataPropertyName = "ID";
            colTB_ID.HeaderText = "ID";
            colTB_ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_POs.Columns.Add( colTB_ID );

            DataGridViewTextBoxColumn colTB_Supplier = new DataGridViewTextBoxColumn();
            colTB_Supplier.DataPropertyName = "SupplierName";
            colTB_Supplier.HeaderText = "Supplier Name";
            colTB_Supplier.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_POs.Columns.Add( colTB_Supplier );

            DataGridViewTextBoxColumn colTB_Details = new DataGridViewTextBoxColumn();
            colTB_Details.DataPropertyName = "Details";
            colTB_Details.HeaderText = "Details";
            colTB_Details.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_POs.Columns.Add( colTB_Details );

            DataGridViewTextBoxColumn colTB_TransactionDate = new DataGridViewTextBoxColumn();
            colTB_TransactionDate.DataPropertyName = "PurchaseOrderDate";
            colTB_TransactionDate.HeaderText = "Purchase Order Date";
            colTB_TransactionDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_POs.Columns.Add( colTB_TransactionDate );

            DataGridViewTextBoxColumn colTB_ExternalReferenceId = new DataGridViewTextBoxColumn();
            colTB_ExternalReferenceId.DataPropertyName = "ExternalReferenceID";
            colTB_ExternalReferenceId.HeaderText = "External Reference ID";
            colTB_ExternalReferenceId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_POs.Columns.Add( colTB_ExternalReferenceId );
            #endregion

            #region DataGridView-CategorisedOrderDetail_Transfer
            dataGridView_POdetail.AutoGenerateColumns = false;
            dataGridView_POdetail.AutoSize = true;

            DataGridViewTextBoxColumn colTB_DetailCategory = new DataGridViewTextBoxColumn();
            colTB_DetailCategory.DataPropertyName = "StockCategory";
            colTB_DetailCategory.HeaderText = "Stock Category";
            colTB_DetailCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_POdetail.Columns.Add( colTB_DetailCategory );

            DataGridViewTextBoxColumn colTB_TotalStock = new DataGridViewTextBoxColumn();
            colTB_TotalStock.DataPropertyName = "Quantity";
            colTB_TotalStock.HeaderText = "Total Quantity";
            colTB_TotalStock.ValueType = typeof( double );
            colTB_TotalStock.DefaultCellStyle.Format = ( "##,##0.00" );
            colTB_TotalStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_POdetail.Columns.Add( colTB_TotalStock );

            DataGridViewTextBoxColumn colTB_UnitType = new DataGridViewTextBoxColumn();
            colTB_UnitType.DataPropertyName = "UnitType";
            colTB_UnitType.HeaderText = "Unit Type";
            dataGridView_POdetail.Columns.Add( colTB_UnitType );
            #endregion
        }

        private void button_Cancel_Click(object sender, EventArgs e) {
            _purchaseOrder = null;
            this.Close();
        }

        private void loadSuppliers() {
            BindingList<SupplierEntity> supplierList = stockClient.getSuppliers();
            if ( supplierList[0] == null || !supplierList[0].SupplierName.Equals( NOSELECTION_SUPPLIER ) ) {
                supplierList.Insert( 0, new SupplierEntity { SupplierName = NOSELECTION_SUPPLIER } );
            }

            comboBox_Supplier.DataSource = supplierList;
            comboBox_Supplier.DisplayMember = "SupplierName";

            comboBox_Supplier.SelectedIndex = 0;
        }

        private void button_ListPOs_Click(object sender, EventArgs e) {
            button_ListPOs.Enabled = false;
            label_Busy.Visible = true;
            label_Busy.Refresh();
            
            /*
            dataGridView_POs.DataSource = stockClient.getPurchaseOrders_All();
            */

            // this is the new WCF Service call to get all the purchase orders in POCO form (PurchaseOrder_POCO array)
            AFLStockServiceClient client = new AFLStockServiceClient();
            dataGridView_POs.DataSource = client.GetPurchaseOrders_Simplified();

            label_Busy.Visible = false;
            button_ListPOs.Enabled = true;
        }

        private void dataGridView_POs_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            button_SelectPO.PerformClick();
        }

        private void dataGridView_POs_SelectionChanged(object sender, EventArgs e) {
            if ( dataGridView_POs.CurrentRow != null && dataGridView_POs.CurrentRow.DataBoundItem != null ) {
                AFLStock.WCF.Client.ServiceReference.PurchaseOrder_POCO poPOCO = (AFLStock.WCF.Client.ServiceReference.PurchaseOrder_POCO)dataGridView_POs.CurrentRow.DataBoundItem;

                dataGridView_POdetail.DataSource = poPOCO.PurchaseOrderDetailList;
                dataGridView_POdetail.ClearSelection();
            }
        }

        private void button_SelectPO_Click(object sender, EventArgs e) {
            int poID = int.MinValue;

            if (dataGridView_POs.CurrentRow != null && dataGridView_POs.CurrentRow.DataBoundItem != null)
            {
                AFLStock.WCF.Client.ServiceReference.PurchaseOrder_POCO poPOCO = (AFLStock.WCF.Client.ServiceReference.PurchaseOrder_POCO) dataGridView_POs.CurrentRow.DataBoundItem;
                poID = poPOCO.ID;
            }

            if (stockClient.purchaseOrderExists(poID))
            {
                _purchaseOrder = stockClient.getPurchaseOrder(poID);
            }

            // _purchaseOrder will either be null OR it will be loaded via a legal poID obtained from the WCF transferred POCO objects
            this.Close();
        }
    }
}
