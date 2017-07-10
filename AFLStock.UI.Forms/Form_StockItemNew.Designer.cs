namespace AFLStock.UI.Forms
{
    partial class Form_StockItemNew
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
            this.groupBox_MasterDetail = new System.Windows.Forms.GroupBox();
            this.comboBox_UnitType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_SubCodes = new System.Windows.Forms.GroupBox();
            this.dataGridView_SubCodes = new System.Windows.Forms.DataGridView();
            this.button_Save = new System.Windows.Forms.Button();
            this.checkBox_QuantityList = new System.Windows.Forms.CheckBox();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_CostLKR = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_CostCNF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_MinOrderQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_MasterCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_StockCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBox_MasterDetail.SuspendLayout();
            this.groupBox_SubCodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubCodes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_MasterDetail
            // 
            this.groupBox_MasterDetail.Controls.Add(this.comboBox_UnitType);
            this.groupBox_MasterDetail.Controls.Add(this.label3);
            this.groupBox_MasterDetail.Controls.Add(this.groupBox_SubCodes);
            this.groupBox_MasterDetail.Controls.Add(this.button_Save);
            this.groupBox_MasterDetail.Controls.Add(this.checkBox_QuantityList);
            this.groupBox_MasterDetail.Controls.Add(this.textBox_Description);
            this.groupBox_MasterDetail.Controls.Add(this.label9);
            this.groupBox_MasterDetail.Controls.Add(this.textBox_CostLKR);
            this.groupBox_MasterDetail.Controls.Add(this.label7);
            this.groupBox_MasterDetail.Controls.Add(this.textBox_CostCNF);
            this.groupBox_MasterDetail.Controls.Add(this.label6);
            this.groupBox_MasterDetail.Controls.Add(this.textBox_MinOrderQty);
            this.groupBox_MasterDetail.Controls.Add(this.label5);
            this.groupBox_MasterDetail.Controls.Add(this.textBox_MasterCode);
            this.groupBox_MasterDetail.Controls.Add(this.label2);
            this.groupBox_MasterDetail.Controls.Add(this.comboBox_StockCategory);
            this.groupBox_MasterDetail.Controls.Add(this.label1);
            this.groupBox_MasterDetail.Location = new System.Drawing.Point(12, 7);
            this.groupBox_MasterDetail.Name = "groupBox_MasterDetail";
            this.groupBox_MasterDetail.Size = new System.Drawing.Size(354, 486);
            this.groupBox_MasterDetail.TabIndex = 0;
            this.groupBox_MasterDetail.TabStop = false;
            this.groupBox_MasterDetail.Text = "Stock Item Details";
            // 
            // comboBox_UnitType
            // 
            this.comboBox_UnitType.FormattingEnabled = true;
            this.comboBox_UnitType.Location = new System.Drawing.Point(109, 116);
            this.comboBox_UnitType.Name = "comboBox_UnitType";
            this.comboBox_UnitType.Size = new System.Drawing.Size(237, 21);
            this.comboBox_UnitType.TabIndex = 4;
            this.comboBox_UnitType.SelectedIndexChanged += new System.EventHandler(this.comboBox_UnitType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Unit Type";
            // 
            // groupBox_SubCodes
            // 
            this.groupBox_SubCodes.Controls.Add(this.dataGridView_SubCodes);
            this.groupBox_SubCodes.Location = new System.Drawing.Point(162, 246);
            this.groupBox_SubCodes.Name = "groupBox_SubCodes";
            this.groupBox_SubCodes.Size = new System.Drawing.Size(180, 230);
            this.groupBox_SubCodes.TabIndex = 8;
            this.groupBox_SubCodes.TabStop = false;
            this.groupBox_SubCodes.Text = "Sub Codes List";
            // 
            // dataGridView_SubCodes
            // 
            this.dataGridView_SubCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SubCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SubCodes.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_SubCodes.Name = "dataGridView_SubCodes";
            this.dataGridView_SubCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SubCodes.Size = new System.Drawing.Size(174, 211);
            this.dataGridView_SubCodes.TabIndex = 9;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(11, 453);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(145, 23);
            this.button_Save.TabIndex = 12;
            this.button_Save.Text = "Create Stock Items";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // checkBox_QuantityList
            // 
            this.checkBox_QuantityList.AutoSize = true;
            this.checkBox_QuantityList.Checked = true;
            this.checkBox_QuantityList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_QuantityList.Location = new System.Drawing.Point(11, 223);
            this.checkBox_QuantityList.Name = "checkBox_QuantityList";
            this.checkBox_QuantityList.Size = new System.Drawing.Size(282, 17);
            this.checkBox_QuantityList.TabIndex = 24;
            this.checkBox_QuantityList.Text = "Does this Stock Item have Individual Quantity Entries?";
            this.checkBox_QuantityList.UseVisualStyleBackColor = true;
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(109, 85);
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(237, 20);
            this.textBox_Description.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Description";
            // 
            // textBox_CostLKR
            // 
            this.textBox_CostLKR.Location = new System.Drawing.Point(260, 186);
            this.textBox_CostLKR.Name = "textBox_CostLKR";
            this.textBox_CostLKR.Size = new System.Drawing.Size(82, 20);
            this.textBox_CostLKR.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(199, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cost LKR";
            // 
            // textBox_CostCNF
            // 
            this.textBox_CostCNF.Location = new System.Drawing.Point(109, 187);
            this.textBox_CostCNF.Name = "textBox_CostCNF";
            this.textBox_CostCNF.Size = new System.Drawing.Size(82, 20);
            this.textBox_CostCNF.TabIndex = 6;
            this.textBox_CostCNF.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cost CNF";
            // 
            // textBox_MinOrderQty
            // 
            this.textBox_MinOrderQty.Location = new System.Drawing.Point(109, 153);
            this.textBox_MinOrderQty.Name = "textBox_MinOrderQty";
            this.textBox_MinOrderQty.Size = new System.Drawing.Size(82, 20);
            this.textBox_MinOrderQty.TabIndex = 5;
            this.textBox_MinOrderQty.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Min Order Qty";
            // 
            // textBox_MasterCode
            // 
            this.textBox_MasterCode.Location = new System.Drawing.Point(107, 53);
            this.textBox_MasterCode.Name = "textBox_MasterCode";
            this.textBox_MasterCode.Size = new System.Drawing.Size(237, 20);
            this.textBox_MasterCode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Master Code";
            // 
            // comboBox_StockCategory
            // 
            this.comboBox_StockCategory.FormattingEnabled = true;
            this.comboBox_StockCategory.Location = new System.Drawing.Point(107, 22);
            this.comboBox_StockCategory.Name = "comboBox_StockCategory";
            this.comboBox_StockCategory.Size = new System.Drawing.Size(237, 21);
            this.comboBox_StockCategory.TabIndex = 1;
            this.comboBox_StockCategory.SelectedIndexChanged += new System.EventHandler(this.comboBox_StockCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category";
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(279, 499);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(72, 23);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // Form_StockItemNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 528);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.groupBox_MasterDetail);
            this.Name = "Form_StockItemNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Stock Item";
            this.Load += new System.EventHandler(this.Form_StockItemNew_Load);
            this.groupBox_MasterDetail.ResumeLayout(false);
            this.groupBox_MasterDetail.PerformLayout();
            this.groupBox_SubCodes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubCodes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_MasterDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_StockCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_MinOrderQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_MasterCode;
        private System.Windows.Forms.TextBox textBox_CostLKR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_CostCNF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_QuantityList;
        private System.Windows.Forms.GroupBox groupBox_SubCodes;
        private System.Windows.Forms.ComboBox comboBox_UnitType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_SubCodes;
    }
}