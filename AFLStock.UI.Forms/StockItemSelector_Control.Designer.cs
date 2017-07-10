namespace AFLStock.UI.Forms {
    partial class StockItemSelector_Control {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_subCode = new System.Windows.Forms.ComboBox();
            this.comboBox_MasterCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_StockCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Busy = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sub Code";
            // 
            // comboBox_subCode
            // 
            this.comboBox_subCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_subCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_subCode.FormattingEnabled = true;
            this.comboBox_subCode.Location = new System.Drawing.Point(121, 63);
            this.comboBox_subCode.Name = "comboBox_subCode";
            this.comboBox_subCode.Size = new System.Drawing.Size(191, 21);
            this.comboBox_subCode.TabIndex = 22;
            this.comboBox_subCode.SelectedIndexChanged += new System.EventHandler(this.comboBox_subCode_SelectedIndexChanged);
            // 
            // comboBox_MasterCode
            // 
            this.comboBox_MasterCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_MasterCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_MasterCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_MasterCode.FormattingEnabled = true;
            this.comboBox_MasterCode.Location = new System.Drawing.Point(121, 33);
            this.comboBox_MasterCode.Name = "comboBox_MasterCode";
            this.comboBox_MasterCode.Size = new System.Drawing.Size(191, 21);
            this.comboBox_MasterCode.TabIndex = 21;
            this.comboBox_MasterCode.SelectedIndexChanged += new System.EventHandler(this.comboBox_MasterCode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 30);
            this.label2.TabIndex = 20;
            this.label2.Text = "Master Code";
            // 
            // comboBox_StockCategory
            // 
            this.comboBox_StockCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_StockCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_StockCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_StockCategory.FormattingEnabled = true;
            this.comboBox_StockCategory.Location = new System.Drawing.Point(121, 3);
            this.comboBox_StockCategory.Name = "comboBox_StockCategory";
            this.comboBox_StockCategory.Size = new System.Drawing.Size(191, 21);
            this.comboBox_StockCategory.TabIndex = 19;
            this.comboBox_StockCategory.SelectedIndexChanged += new System.EventHandler(this.comboBox_StockCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 30);
            this.label1.TabIndex = 18;
            this.label1.Text = "Category";
            // 
            // label_Busy
            // 
            this.label_Busy.AutoSize = true;
            this.label_Busy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Busy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Busy.ForeColor = System.Drawing.Color.Red;
            this.label_Busy.Location = new System.Drawing.Point(121, 90);
            this.label_Busy.Name = "label_Busy";
            this.label_Busy.Size = new System.Drawing.Size(191, 30);
            this.label_Busy.TabIndex = 24;
            this.label_Busy.Text = "System is Busy - Please Wait";
            this.label_Busy.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_Busy, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_StockCategory, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_subCode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_MasterCode, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(315, 102);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // StockItemSelector_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StockItemSelector_Control";
            this.Size = new System.Drawing.Size(315, 102);
            this.Load += new System.EventHandler(this.StockItemSelector_Control_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_subCode;
        private System.Windows.Forms.ComboBox comboBox_MasterCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_StockCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Busy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
