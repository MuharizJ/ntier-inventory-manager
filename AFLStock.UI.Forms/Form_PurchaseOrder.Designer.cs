namespace AFLStock.UI.Forms {
    partial class Form_PurchaseOrder {
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
            this.label_PurchaseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_Details = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_PurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label_Date = new System.Windows.Forms.Label();
            this.comboBox_Supplier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBox_ProductDetails = new System.Windows.Forms.GroupBox();
            this.textBox_Cost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stockItemSelector_Control = new AFLStock.UI.Forms.StockItemSelector_Control();
            this.button_BatchAdd = new System.Windows.Forms.Button();
            this.button_AddItem = new System.Windows.Forms.Button();
            this.textBox_Qty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_PurchaseItems = new System.Windows.Forms.GroupBox();
            this.dataGridView_PurchaseOrderLog = new System.Windows.Forms.DataGridView();
            this.menuStrip_File = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_File_NewPO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_File_OpenPO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_File_SaveClosePO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_File_DeletePO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_File_PrintPO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Admin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Admin_NewCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Admin_NewProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.label_Saving = new System.Windows.Forms.Label();
            this.groupBox_MasterDetails.SuspendLayout();
            this.groupBox_ProductDetails.SuspendLayout();
            this.groupBox_PurchaseItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PurchaseOrderLog)).BeginInit();
            this.menuStrip_File.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_MasterDetails
            // 
            this.groupBox_MasterDetails.Controls.Add(this.textBox_ReferenceID);
            this.groupBox_MasterDetails.Controls.Add(this.label3);
            this.groupBox_MasterDetails.Controls.Add(this.label_PurchaseID);
            this.groupBox_MasterDetails.Controls.Add(this.label10);
            this.groupBox_MasterDetails.Controls.Add(this.textBox_Details);
            this.groupBox_MasterDetails.Controls.Add(this.label2);
            this.groupBox_MasterDetails.Controls.Add(this.dateTimePicker_PurchaseDate);
            this.groupBox_MasterDetails.Controls.Add(this.label_Date);
            this.groupBox_MasterDetails.Controls.Add(this.comboBox_Supplier);
            this.groupBox_MasterDetails.Controls.Add(this.label1);
            this.groupBox_MasterDetails.Location = new System.Drawing.Point(13, 25);
            this.groupBox_MasterDetails.Name = "groupBox_MasterDetails";
            this.groupBox_MasterDetails.Size = new System.Drawing.Size(322, 203);
            this.groupBox_MasterDetails.TabIndex = 0;
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
            // label_PurchaseID
            // 
            this.label_PurchaseID.AutoSize = true;
            this.label_PurchaseID.Location = new System.Drawing.Point(111, 175);
            this.label_PurchaseID.Name = "label_PurchaseID";
            this.label_PurchaseID.Size = new System.Drawing.Size(69, 13);
            this.label_PurchaseID.TabIndex = 8;
            this.label_PurchaseID.Text = "NOT SAVED";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Purchase Order ID";
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
            // dateTimePicker_PurchaseDate
            // 
            this.dateTimePicker_PurchaseDate.Location = new System.Drawing.Point(59, 113);
            this.dateTimePicker_PurchaseDate.Name = "dateTimePicker_PurchaseDate";
            this.dateTimePicker_PurchaseDate.Size = new System.Drawing.Size(231, 20);
            this.dateTimePicker_PurchaseDate.TabIndex = 3;
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
            // comboBox_Supplier
            // 
            this.comboBox_Supplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Supplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Supplier.FormattingEnabled = true;
            this.comboBox_Supplier.Location = new System.Drawing.Point(57, 24);
            this.comboBox_Supplier.Name = "comboBox_Supplier";
            this.comboBox_Supplier.Size = new System.Drawing.Size(233, 21);
            this.comboBox_Supplier.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(775, 395);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 5;
            this.button_Save.TabStop = false;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // groupBox_ProductDetails
            // 
            this.groupBox_ProductDetails.Controls.Add(this.textBox_Cost);
            this.groupBox_ProductDetails.Controls.Add(this.label4);
            this.groupBox_ProductDetails.Controls.Add(this.stockItemSelector_Control);
            this.groupBox_ProductDetails.Controls.Add(this.button_BatchAdd);
            this.groupBox_ProductDetails.Controls.Add(this.button_AddItem);
            this.groupBox_ProductDetails.Controls.Add(this.textBox_Qty);
            this.groupBox_ProductDetails.Controls.Add(this.label5);
            this.groupBox_ProductDetails.Location = new System.Drawing.Point(13, 234);
            this.groupBox_ProductDetails.Name = "groupBox_ProductDetails";
            this.groupBox_ProductDetails.Size = new System.Drawing.Size(322, 184);
            this.groupBox_ProductDetails.TabIndex = 1;
            this.groupBox_ProductDetails.TabStop = false;
            this.groupBox_ProductDetails.Text = "Product Details";
            // 
            // textBox_Cost
            // 
            this.textBox_Cost.Enabled = false;
            this.textBox_Cost.Location = new System.Drawing.Point(230, 118);
            this.textBox_Cost.Name = "textBox_Cost";
            this.textBox_Cost.Size = new System.Drawing.Size(76, 20);
            this.textBox_Cost.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cost";
            // 
            // stockItemSelector_Control
            // 
            this.stockItemSelector_Control.Location = new System.Drawing.Point(3, 16);
            this.stockItemSelector_Control.Name = "stockItemSelector_Control";
            this.stockItemSelector_Control.Size = new System.Drawing.Size(310, 100);
            this.stockItemSelector_Control.TabIndex = 7;
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
            this.textBox_Qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Qty_KeyPress);
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
            this.groupBox_PurchaseItems.Controls.Add(this.dataGridView_PurchaseOrderLog);
            this.groupBox_PurchaseItems.Location = new System.Drawing.Point(347, 27);
            this.groupBox_PurchaseItems.Name = "groupBox_PurchaseItems";
            this.groupBox_PurchaseItems.Size = new System.Drawing.Size(506, 362);
            this.groupBox_PurchaseItems.TabIndex = 2;
            this.groupBox_PurchaseItems.TabStop = false;
            this.groupBox_PurchaseItems.Text = "Stock Items in this Purchase Order - You can Add, Delete or Edit them";
            // 
            // dataGridView_PurchaseOrderLog
            // 
            this.dataGridView_PurchaseOrderLog.AllowUserToAddRows = false;
            this.dataGridView_PurchaseOrderLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PurchaseOrderLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_PurchaseOrderLog.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_PurchaseOrderLog.Name = "dataGridView_PurchaseOrderLog";
            this.dataGridView_PurchaseOrderLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_PurchaseOrderLog.Size = new System.Drawing.Size(500, 343);
            this.dataGridView_PurchaseOrderLog.TabIndex = 13;
            this.dataGridView_PurchaseOrderLog.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_PurchaseOrderLog_CellBeginEdit);
            this.dataGridView_PurchaseOrderLog.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_PurchaseOrderLog_CellDoubleClick);
            this.dataGridView_PurchaseOrderLog.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_PurchaseOrderLog_UserDeletingRow);
            // 
            // menuStrip_File
            // 
            this.menuStrip_File.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File,
            this.toolStripMenuItem_Admin});
            this.menuStrip_File.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_File.Name = "menuStrip_File";
            this.menuStrip_File.Size = new System.Drawing.Size(859, 24);
            this.menuStrip_File.TabIndex = 5;
            this.menuStrip_File.Text = "menuStrip1";
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File_NewPO,
            this.toolStripMenuItem_File_OpenPO,
            this.toolStripSeparator3,
            this.toolStripMenuItem_File_SaveClosePO,
            this.toolStripSeparator4,
            this.toolStripMenuItem_File_DeletePO,
            this.toolStripSeparator1,
            this.toolStripMenuItem_File_PrintPO,
            this.toolStripSeparator2,
            this.toolStripMenuItem_File_Exit});
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem_File.Text = "File";
            // 
            // toolStripMenuItem_File_NewPO
            // 
            this.toolStripMenuItem_File_NewPO.Name = "toolStripMenuItem_File_NewPO";
            this.toolStripMenuItem_File_NewPO.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem_File_NewPO.Text = "New Purchase Order";
            // 
            // toolStripMenuItem_File_OpenPO
            // 
            this.toolStripMenuItem_File_OpenPO.Name = "toolStripMenuItem_File_OpenPO";
            this.toolStripMenuItem_File_OpenPO.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem_File_OpenPO.Text = "Open Purchase Order";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(224, 6);
            // 
            // toolStripMenuItem_File_SaveClosePO
            // 
            this.toolStripMenuItem_File_SaveClosePO.Name = "toolStripMenuItem_File_SaveClosePO";
            this.toolStripMenuItem_File_SaveClosePO.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem_File_SaveClosePO.Text = "Save && Close Purchase Order";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(224, 6);
            // 
            // toolStripMenuItem_File_DeletePO
            // 
            this.toolStripMenuItem_File_DeletePO.Name = "toolStripMenuItem_File_DeletePO";
            this.toolStripMenuItem_File_DeletePO.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem_File_DeletePO.Text = "Delete Purchase Order";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(224, 6);
            // 
            // toolStripMenuItem_File_PrintPO
            // 
            this.toolStripMenuItem_File_PrintPO.Name = "toolStripMenuItem_File_PrintPO";
            this.toolStripMenuItem_File_PrintPO.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem_File_PrintPO.Text = "Print";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(224, 6);
            // 
            // toolStripMenuItem_File_Exit
            // 
            this.toolStripMenuItem_File_Exit.Name = "toolStripMenuItem_File_Exit";
            this.toolStripMenuItem_File_Exit.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem_File_Exit.Text = "Exit";
            // 
            // toolStripMenuItem_Admin
            // 
            this.toolStripMenuItem_Admin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Admin_NewCategory,
            this.toolStripMenuItem_Admin_NewProduct});
            this.toolStripMenuItem_Admin.Name = "toolStripMenuItem_Admin";
            this.toolStripMenuItem_Admin.Size = new System.Drawing.Size(55, 20);
            this.toolStripMenuItem_Admin.Text = "Admin";
            // 
            // toolStripMenuItem_Admin_NewCategory
            // 
            this.toolStripMenuItem_Admin_NewCategory.Name = "toolStripMenuItem_Admin_NewCategory";
            this.toolStripMenuItem_Admin_NewCategory.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem_Admin_NewCategory.Text = "New Category";
            // 
            // toolStripMenuItem_Admin_NewProduct
            // 
            this.toolStripMenuItem_Admin_NewProduct.Name = "toolStripMenuItem_Admin_NewProduct";
            this.toolStripMenuItem_Admin_NewProduct.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem_Admin_NewProduct.Text = "New Product";
            // 
            // label_Saving
            // 
            this.label_Saving.AutoSize = true;
            this.label_Saving.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Saving.ForeColor = System.Drawing.Color.Red;
            this.label_Saving.Location = new System.Drawing.Point(349, 394);
            this.label_Saving.Name = "label_Saving";
            this.label_Saving.Size = new System.Drawing.Size(51, 16);
            this.label_Saving.TabIndex = 14;
            this.label_Saving.Text = "label6";
            // 
            // Form_PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 423);
            this.Controls.Add(this.label_Saving);
            this.Controls.Add(this.groupBox_PurchaseItems);
            this.Controls.Add(this.groupBox_ProductDetails);
            this.Controls.Add(this.groupBox_MasterDetails);
            this.Controls.Add(this.menuStrip_File);
            this.Controls.Add(this.button_Save);
            this.MainMenuStrip = this.menuStrip_File;
            this.Name = "Form_PurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Purchase - Create a New Stock Purchase Entry and Add Stock Items - Updates " +
    "Master Stock Inventory";
            this.Load += new System.EventHandler(this.Form_StockPurchase_Load);
            this.groupBox_MasterDetails.ResumeLayout(false);
            this.groupBox_MasterDetails.PerformLayout();
            this.groupBox_ProductDetails.ResumeLayout(false);
            this.groupBox_ProductDetails.PerformLayout();
            this.groupBox_PurchaseItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PurchaseOrderLog)).EndInit();
            this.menuStrip_File.ResumeLayout(false);
            this.menuStrip_File.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_MasterDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_PurchaseDate;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.ComboBox comboBox_Supplier;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.TextBox textBox_Details;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox_ProductDetails;
        private System.Windows.Forms.TextBox textBox_Qty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_BatchAdd;
        private System.Windows.Forms.Button button_AddItem;
        private System.Windows.Forms.GroupBox groupBox_PurchaseItems;
        private System.Windows.Forms.DataGridView dataGridView_PurchaseOrderLog;
        private System.Windows.Forms.Label label_PurchaseID;
        private System.Windows.Forms.Label label10;
        private StockItemSelector_Control stockItemSelector_Control;
        private System.Windows.Forms.TextBox textBox_ReferenceID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File_OpenPO;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File_NewPO;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File_SaveClosePO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File_DeletePO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Admin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Admin_NewCategory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Admin_NewProduct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File_PrintPO;
        private System.Windows.Forms.TextBox textBox_Cost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_Saving;
    }
}