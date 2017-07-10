namespace AFLStock.UI.Forms
{
    partial class Form_BatchAddPurchaseStockItem
    {
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
            this.textBox_Cost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label_UnitType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_SubCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_DesignNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Category = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_SupplierName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_PurchaseOrderID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_AddStockItems = new System.Windows.Forms.Button();
            this.dataGridView_ItemQuantityList = new System.Windows.Forms.DataGridView();
            this.button_DeleteRow = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox_MasterDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ItemQuantityList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_MasterDetails
            // 
            this.groupBox_MasterDetails.Controls.Add(this.textBox_Cost);
            this.groupBox_MasterDetails.Controls.Add(this.label8);
            this.groupBox_MasterDetails.Controls.Add(this.label_UnitType);
            this.groupBox_MasterDetails.Controls.Add(this.label4);
            this.groupBox_MasterDetails.Controls.Add(this.label_SubCode);
            this.groupBox_MasterDetails.Controls.Add(this.label5);
            this.groupBox_MasterDetails.Controls.Add(this.label_DesignNumber);
            this.groupBox_MasterDetails.Controls.Add(this.label3);
            this.groupBox_MasterDetails.Controls.Add(this.label_Category);
            this.groupBox_MasterDetails.Controls.Add(this.label7);
            this.groupBox_MasterDetails.Controls.Add(this.label_SupplierName);
            this.groupBox_MasterDetails.Controls.Add(this.label2);
            this.groupBox_MasterDetails.Controls.Add(this.label_PurchaseOrderID);
            this.groupBox_MasterDetails.Controls.Add(this.label1);
            this.groupBox_MasterDetails.Location = new System.Drawing.Point(12, 12);
            this.groupBox_MasterDetails.Name = "groupBox_MasterDetails";
            this.groupBox_MasterDetails.Size = new System.Drawing.Size(325, 206);
            this.groupBox_MasterDetails.TabIndex = 0;
            this.groupBox_MasterDetails.TabStop = false;
            this.groupBox_MasterDetails.Text = "Purchase Order Detail";
            // 
            // textBox_Cost
            // 
            this.textBox_Cost.Location = new System.Drawing.Point(128, 172);
            this.textBox_Cost.Name = "textBox_Cost";
            this.textBox_Cost.Size = new System.Drawing.Size(123, 20);
            this.textBox_Cost.TabIndex = 17;
            this.textBox_Cost.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Cost";
            // 
            // label_UnitType
            // 
            this.label_UnitType.AutoSize = true;
            this.label_UnitType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_UnitType.Location = new System.Drawing.Point(125, 150);
            this.label_UnitType.Name = "label_UnitType";
            this.label_UnitType.Size = new System.Drawing.Size(94, 13);
            this.label_UnitType.TabIndex = 16;
            this.label_UnitType.Text = "FAKE UNIT TYPE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Unit Type";
            // 
            // label_SubCode
            // 
            this.label_SubCode.AutoSize = true;
            this.label_SubCode.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_SubCode.Location = new System.Drawing.Point(124, 124);
            this.label_SubCode.Name = "label_SubCode";
            this.label_SubCode.Size = new System.Drawing.Size(92, 13);
            this.label_SubCode.TabIndex = 14;
            this.label_SubCode.Text = "FAKE SUB CODE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Sub Code";
            // 
            // label_DesignNumber
            // 
            this.label_DesignNumber.AutoSize = true;
            this.label_DesignNumber.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_DesignNumber.Location = new System.Drawing.Point(123, 99);
            this.label_DesignNumber.Name = "label_DesignNumber";
            this.label_DesignNumber.Size = new System.Drawing.Size(128, 13);
            this.label_DesignNumber.TabIndex = 12;
            this.label_DesignNumber.Text = "FAKE DESIGN NUMBER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Design Number";
            // 
            // label_Category
            // 
            this.label_Category.AutoSize = true;
            this.label_Category.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_Category.Location = new System.Drawing.Point(123, 74);
            this.label_Category.Name = "label_Category";
            this.label_Category.Size = new System.Drawing.Size(96, 13);
            this.label_Category.TabIndex = 10;
            this.label_Category.Text = "FAKE CATEGORY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Category";
            // 
            // label_SupplierName
            // 
            this.label_SupplierName.AutoSize = true;
            this.label_SupplierName.Location = new System.Drawing.Point(120, 49);
            this.label_SupplierName.Name = "label_SupplierName";
            this.label_SupplierName.Size = new System.Drawing.Size(103, 13);
            this.label_SupplierName.TabIndex = 3;
            this.label_SupplierName.Text = "Fake Supplier Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Supplier Name:";
            // 
            // label_PurchaseOrderID
            // 
            this.label_PurchaseOrderID.AutoSize = true;
            this.label_PurchaseOrderID.Location = new System.Drawing.Point(120, 26);
            this.label_PurchaseOrderID.Name = "label_PurchaseOrderID";
            this.label_PurchaseOrderID.Size = new System.Drawing.Size(45, 13);
            this.label_PurchaseOrderID.TabIndex = 1;
            this.label_PurchaseOrderID.Text = "Fake ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purchase Order ID:";
            // 
            // button_AddStockItems
            // 
            this.button_AddStockItems.Location = new System.Drawing.Point(74, 407);
            this.button_AddStockItems.Name = "button_AddStockItems";
            this.button_AddStockItems.Size = new System.Drawing.Size(117, 33);
            this.button_AddStockItems.TabIndex = 2;
            this.button_AddStockItems.Text = "Add items && Close";
            this.button_AddStockItems.UseVisualStyleBackColor = true;
            this.button_AddStockItems.Click += new System.EventHandler(this.button_AddStockItems_Click);
            // 
            // dataGridView_ItemQuantityList
            // 
            this.dataGridView_ItemQuantityList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ItemQuantityList.Location = new System.Drawing.Point(197, 230);
            this.dataGridView_ItemQuantityList.Name = "dataGridView_ItemQuantityList";
            this.dataGridView_ItemQuantityList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ItemQuantityList.Size = new System.Drawing.Size(134, 210);
            this.dataGridView_ItemQuantityList.TabIndex = 1;
            // 
            // button_DeleteRow
            // 
            this.button_DeleteRow.Location = new System.Drawing.Point(75, 368);
            this.button_DeleteRow.Name = "button_DeleteRow";
            this.button_DeleteRow.Size = new System.Drawing.Size(116, 33);
            this.button_DeleteRow.TabIndex = 13;
            this.button_DeleteRow.TabStop = false;
            this.button_DeleteRow.Text = "Delete Selected Row";
            this.button_DeleteRow.UseVisualStyleBackColor = true;
            this.button_DeleteRow.Click += new System.EventHandler(this.button_DeleteRow_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Enter Quantities Here ";
            // 
            // Form_BatchAddPurchaseStockItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 451);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_DeleteRow);
            this.Controls.Add(this.dataGridView_ItemQuantityList);
            this.Controls.Add(this.button_AddStockItems);
            this.Controls.Add(this.groupBox_MasterDetails);
            this.Name = "Form_BatchAddPurchaseStockItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Batch Add A Stock Item";
            this.Load += new System.EventHandler(this.Form_BatchAddStockItem_Load);
            this.groupBox_MasterDetails.ResumeLayout(false);
            this.groupBox_MasterDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ItemQuantityList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_MasterDetails;
        private System.Windows.Forms.Label label_SupplierName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_PurchaseOrderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_AddStockItems;
        private System.Windows.Forms.DataGridView dataGridView_ItemQuantityList;
        private System.Windows.Forms.Button button_DeleteRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_UnitType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_SubCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_DesignNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Category;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Cost;
        private System.Windows.Forms.Label label8;
    }
}