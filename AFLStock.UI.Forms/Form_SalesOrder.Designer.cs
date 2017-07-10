namespace AFLStock.UI.Forms {
    partial class Form_SalesOrder {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox_MasterDetails = new System.Windows.Forms.GroupBox();
            this.textBox_ReferenceID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_SalesOrderID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_Details = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_SaleDate = new System.Windows.Forms.DateTimePicker();
            this.label_Date = new System.Windows.Forms.Label();
            this.comboBox_Customer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_ProductDetails = new System.Windows.Forms.GroupBox();
            this.label_AvailableBalance = new System.Windows.Forms.Label();
            this.stockItemSelector_Control = new AFLStock.UI.Forms.StockItemSelector_Control();
            this.button_BatchAdd = new System.Windows.Forms.Button();
            this.button_AddItem = new System.Windows.Forms.Button();
            this.textBox_Qty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_PurchaseItems = new System.Windows.Forms.GroupBox();
            this.dataGridView_SalesOrderLog = new System.Windows.Forms.DataGridView();
            this.button_Save = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSalesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSalesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveCloseSalesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSalesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_MasterDetails.SuspendLayout();
            this.groupBox_ProductDetails.SuspendLayout();
            this.groupBox_PurchaseItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SalesOrderLog)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_MasterDetails
            // 
            this.groupBox_MasterDetails.Controls.Add(this.textBox_ReferenceID);
            this.groupBox_MasterDetails.Controls.Add(this.label3);
            this.groupBox_MasterDetails.Controls.Add(this.label_SalesOrderID);
            this.groupBox_MasterDetails.Controls.Add(this.label10);
            this.groupBox_MasterDetails.Controls.Add(this.textBox_Details);
            this.groupBox_MasterDetails.Controls.Add(this.label2);
            this.groupBox_MasterDetails.Controls.Add(this.dateTimePicker_SaleDate);
            this.groupBox_MasterDetails.Controls.Add(this.label_Date);
            this.groupBox_MasterDetails.Controls.Add(this.comboBox_Customer);
            this.groupBox_MasterDetails.Controls.Add(this.label1);
            this.groupBox_MasterDetails.Location = new System.Drawing.Point(12, 24);
            this.groupBox_MasterDetails.Name = "groupBox_MasterDetails";
            this.groupBox_MasterDetails.Size = new System.Drawing.Size(322, 203);
            this.groupBox_MasterDetails.TabIndex = 1;
            this.groupBox_MasterDetails.TabStop = false;
            this.groupBox_MasterDetails.Text = "Master Details";
            // 
            // textBox_ReferenceID
            // 
            this.textBox_ReferenceID.Location = new System.Drawing.Point(58, 147);
            this.textBox_ReferenceID.Name = "textBox_ReferenceID";
            this.textBox_ReferenceID.Size = new System.Drawing.Size(232, 20);
            this.textBox_ReferenceID.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ref ID";
            // 
            // label_SalesOrderID
            // 
            this.label_SalesOrderID.AutoSize = true;
            this.label_SalesOrderID.Location = new System.Drawing.Point(111, 175);
            this.label_SalesOrderID.Name = "label_SalesOrderID";
            this.label_SalesOrderID.Size = new System.Drawing.Size(69, 13);
            this.label_SalesOrderID.TabIndex = 8;
            this.label_SalesOrderID.Text = "NOT SAVED";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Sales Order ID";
            // 
            // textBox_Details
            // 
            this.textBox_Details.Location = new System.Drawing.Point(57, 55);
            this.textBox_Details.Name = "textBox_Details";
            this.textBox_Details.Size = new System.Drawing.Size(233, 20);
            this.textBox_Details.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Details";
            // 
            // dateTimePicker_SaleDate
            // 
            this.dateTimePicker_SaleDate.Location = new System.Drawing.Point(59, 113);
            this.dateTimePicker_SaleDate.Name = "dateTimePicker_SaleDate";
            this.dateTimePicker_SaleDate.Size = new System.Drawing.Size(231, 20);
            this.dateTimePicker_SaleDate.TabIndex = 3;
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Location = new System.Drawing.Point(10, 117);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(30, 13);
            this.label_Date.TabIndex = 1;
            this.label_Date.Text = "Date";
            // 
            // comboBox_Customer
            // 
            this.comboBox_Customer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Customer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Customer.FormattingEnabled = true;
            this.comboBox_Customer.Location = new System.Drawing.Point(57, 24);
            this.comboBox_Customer.Name = "comboBox_Customer";
            this.comboBox_Customer.Size = new System.Drawing.Size(233, 21);
            this.comboBox_Customer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // groupBox_ProductDetails
            // 
            this.groupBox_ProductDetails.Controls.Add(this.label_AvailableBalance);
            this.groupBox_ProductDetails.Controls.Add(this.stockItemSelector_Control);
            this.groupBox_ProductDetails.Controls.Add(this.button_BatchAdd);
            this.groupBox_ProductDetails.Controls.Add(this.button_AddItem);
            this.groupBox_ProductDetails.Controls.Add(this.textBox_Qty);
            this.groupBox_ProductDetails.Controls.Add(this.label5);
            this.groupBox_ProductDetails.Location = new System.Drawing.Point(12, 233);
            this.groupBox_ProductDetails.Name = "groupBox_ProductDetails";
            this.groupBox_ProductDetails.Size = new System.Drawing.Size(322, 184);
            this.groupBox_ProductDetails.TabIndex = 10;
            this.groupBox_ProductDetails.TabStop = false;
            this.groupBox_ProductDetails.Text = "Product To Add";
            // 
            // label_AvailableBalance
            // 
            this.label_AvailableBalance.AutoSize = true;
            this.label_AvailableBalance.ForeColor = System.Drawing.Color.Red;
            this.label_AvailableBalance.Location = new System.Drawing.Point(176, 121);
            this.label_AvailableBalance.Name = "label_AvailableBalance";
            this.label_AvailableBalance.Size = new System.Drawing.Size(28, 13);
            this.label_AvailableBalance.TabIndex = 13;
            this.label_AvailableBalance.Text = "0.00";
            // 
            // stockItemSelector_Control
            // 
            this.stockItemSelector_Control.Location = new System.Drawing.Point(3, 15);
            this.stockItemSelector_Control.Name = "stockItemSelector_Control";
            this.stockItemSelector_Control.Size = new System.Drawing.Size(315, 100);
            this.stockItemSelector_Control.TabIndex = 7;
            this.stockItemSelector_Control.StockItemListRefinedEvent += new System.EventHandler(this.stockItemSelector_Control_StockItemListRefinedEvent);
            // 
            // button_BatchAdd
            // 
            this.button_BatchAdd.Enabled = false;
            this.button_BatchAdd.Location = new System.Drawing.Point(176, 145);
            this.button_BatchAdd.Name = "button_BatchAdd";
            this.button_BatchAdd.Size = new System.Drawing.Size(69, 23);
            this.button_BatchAdd.TabIndex = 12;
            this.button_BatchAdd.Text = "Batch Add";
            this.button_BatchAdd.UseVisualStyleBackColor = true;
            this.button_BatchAdd.Click += new System.EventHandler(this.button_BatchAdd_Click);
            // 
            // button_AddItem
            // 
            this.button_AddItem.Enabled = false;
            this.button_AddItem.Location = new System.Drawing.Point(98, 144);
            this.button_AddItem.Name = "button_AddItem";
            this.button_AddItem.Size = new System.Drawing.Size(69, 23);
            this.button_AddItem.TabIndex = 11;
            this.button_AddItem.Text = "Add Item";
            this.button_AddItem.UseVisualStyleBackColor = true;
            this.button_AddItem.Click += new System.EventHandler(this.button_AddItem_Click);
            // 
            // textBox_Qty
            // 
            this.textBox_Qty.Enabled = false;
            this.textBox_Qty.Location = new System.Drawing.Point(98, 118);
            this.textBox_Qty.Name = "textBox_Qty";
            this.textBox_Qty.Size = new System.Drawing.Size(72, 20);
            this.textBox_Qty.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Qty";
            // 
            // groupBox_PurchaseItems
            // 
            this.groupBox_PurchaseItems.Controls.Add(this.dataGridView_SalesOrderLog);
            this.groupBox_PurchaseItems.Location = new System.Drawing.Point(340, 24);
            this.groupBox_PurchaseItems.Name = "groupBox_PurchaseItems";
            this.groupBox_PurchaseItems.Size = new System.Drawing.Size(506, 393);
            this.groupBox_PurchaseItems.TabIndex = 11;
            this.groupBox_PurchaseItems.TabStop = false;
            this.groupBox_PurchaseItems.Text = "Stock Items in this Sales Order";
            // 
            // dataGridView_SalesOrderLog
            // 
            this.dataGridView_SalesOrderLog.AllowUserToAddRows = false;
            this.dataGridView_SalesOrderLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SalesOrderLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SalesOrderLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_SalesOrderLog.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_SalesOrderLog.Name = "dataGridView_SalesOrderLog";
            this.dataGridView_SalesOrderLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SalesOrderLog.Size = new System.Drawing.Size(500, 374);
            this.dataGridView_SalesOrderLog.TabIndex = 13;
            this.dataGridView_SalesOrderLog.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_SalesOrderLog_UserDeletingRow);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(768, 423);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 12;
            this.button_Save.TabStop = false;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(857, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSalesOrderToolStripMenuItem,
            this.openSalesOrderToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveCloseSalesOrderToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteSalesOrderToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newSalesOrderToolStripMenuItem
            // 
            this.newSalesOrderToolStripMenuItem.Name = "newSalesOrderToolStripMenuItem";
            this.newSalesOrderToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.newSalesOrderToolStripMenuItem.Text = "New Sales Order";
            this.newSalesOrderToolStripMenuItem.Click += new System.EventHandler(this.newSalesOrderToolStripMenuItem_Click);
            // 
            // openSalesOrderToolStripMenuItem
            // 
            this.openSalesOrderToolStripMenuItem.Name = "openSalesOrderToolStripMenuItem";
            this.openSalesOrderToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.openSalesOrderToolStripMenuItem.Text = "Open Sales Order";
            this.openSalesOrderToolStripMenuItem.Click += new System.EventHandler(this.openSalesOrderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // saveCloseSalesOrderToolStripMenuItem
            // 
            this.saveCloseSalesOrderToolStripMenuItem.Name = "saveCloseSalesOrderToolStripMenuItem";
            this.saveCloseSalesOrderToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.saveCloseSalesOrderToolStripMenuItem.Text = "Save && Close Sales Order";
            this.saveCloseSalesOrderToolStripMenuItem.Click += new System.EventHandler(this.saveCloseSalesOrderToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // deleteSalesOrderToolStripMenuItem
            // 
            this.deleteSalesOrderToolStripMenuItem.Name = "deleteSalesOrderToolStripMenuItem";
            this.deleteSalesOrderToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.deleteSalesOrderToolStripMenuItem.Text = "Delete Sales Order";
            this.deleteSalesOrderToolStripMenuItem.Click += new System.EventHandler(this.deleteSalesOrderToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(202, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form_SalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 457);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.groupBox_PurchaseItems);
            this.Controls.Add(this.groupBox_ProductDetails);
            this.Controls.Add(this.groupBox_MasterDetails);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_SalesOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Order";
            this.Load += new System.EventHandler(this.Form_SalesOrder_Load);
            this.groupBox_MasterDetails.ResumeLayout(false);
            this.groupBox_MasterDetails.PerformLayout();
            this.groupBox_ProductDetails.ResumeLayout(false);
            this.groupBox_ProductDetails.PerformLayout();
            this.groupBox_PurchaseItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SalesOrderLog)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_MasterDetails;
        private System.Windows.Forms.TextBox textBox_ReferenceID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_SalesOrderID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_Details;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_SaleDate;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.ComboBox comboBox_Customer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_ProductDetails;
        private System.Windows.Forms.Button button_BatchAdd;
        private System.Windows.Forms.Button button_AddItem;
        private System.Windows.Forms.TextBox textBox_Qty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox_PurchaseItems;
        private System.Windows.Forms.DataGridView dataGridView_SalesOrderLog;
        private System.Windows.Forms.Button button_Save;
        private StockItemSelector_Control stockItemSelector_Control;
        private System.Windows.Forms.Label label_AvailableBalance;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSalesOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSalesOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveCloseSalesOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteSalesOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}