namespace AFLStock.UI.Forms
{
    partial class Form_StockItemQuantityLog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_Category = new System.Windows.Forms.Label();
            this.label_DesignNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_SubCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_QtyLogList = new System.Windows.Forms.GroupBox();
            this.dataGridView_QtyLogList = new System.Windows.Forms.DataGridView();
            this.label_UnitType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_QtyTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_QtyLogList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_QtyLogList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // label_Category
            // 
            this.label_Category.AutoSize = true;
            this.label_Category.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Category.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_Category.Location = new System.Drawing.Point(116, 0);
            this.label_Category.Name = "label_Category";
            this.label_Category.Size = new System.Drawing.Size(165, 18);
            this.label_Category.TabIndex = 1;
            this.label_Category.Text = "FAKE CATEGORY";
            // 
            // label_DesignNumber
            // 
            this.label_DesignNumber.AutoSize = true;
            this.label_DesignNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DesignNumber.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_DesignNumber.Location = new System.Drawing.Point(116, 18);
            this.label_DesignNumber.Name = "label_DesignNumber";
            this.label_DesignNumber.Size = new System.Drawing.Size(165, 18);
            this.label_DesignNumber.TabIndex = 3;
            this.label_DesignNumber.Text = "FAKE DESIGN NUMBER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Design Number";
            // 
            // label_SubCode
            // 
            this.label_SubCode.AutoSize = true;
            this.label_SubCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SubCode.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_SubCode.Location = new System.Drawing.Point(116, 36);
            this.label_SubCode.Name = "label_SubCode";
            this.label_SubCode.Size = new System.Drawing.Size(165, 18);
            this.label_SubCode.TabIndex = 5;
            this.label_SubCode.Text = "FAKE SUB CODE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sub Code";
            // 
            // groupBox_QtyLogList
            // 
            this.groupBox_QtyLogList.Controls.Add(this.dataGridView_QtyLogList);
            this.groupBox_QtyLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_QtyLogList.Location = new System.Drawing.Point(3, 103);
            this.groupBox_QtyLogList.Name = "groupBox_QtyLogList";
            this.groupBox_QtyLogList.Size = new System.Drawing.Size(290, 342);
            this.groupBox_QtyLogList.TabIndex = 6;
            this.groupBox_QtyLogList.TabStop = false;
            this.groupBox_QtyLogList.Text = "Item Quantities";
            // 
            // dataGridView_QtyLogList
            // 
            this.dataGridView_QtyLogList.AllowUserToAddRows = false;
            this.dataGridView_QtyLogList.AllowUserToDeleteRows = false;
            this.dataGridView_QtyLogList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_QtyLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_QtyLogList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_QtyLogList.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_QtyLogList.Name = "dataGridView_QtyLogList";
            this.dataGridView_QtyLogList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_QtyLogList.Size = new System.Drawing.Size(284, 323);
            this.dataGridView_QtyLogList.TabIndex = 7;
            // 
            // label_UnitType
            // 
            this.label_UnitType.AutoSize = true;
            this.label_UnitType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_UnitType.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_UnitType.Location = new System.Drawing.Point(116, 54);
            this.label_UnitType.Name = "label_UnitType";
            this.label_UnitType.Size = new System.Drawing.Size(165, 21);
            this.label_UnitType.TabIndex = 8;
            this.label_UnitType.Text = "FAKE UNIT TYPE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Unit Type";
            // 
            // label_QtyTotal
            // 
            this.label_QtyTotal.AutoSize = true;
            this.label_QtyTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_QtyTotal.ForeColor = System.Drawing.Color.Red;
            this.label_QtyTotal.Location = new System.Drawing.Point(151, 0);
            this.label_QtyTotal.Name = "label_QtyTotal";
            this.label_QtyTotal.Size = new System.Drawing.Size(61, 19);
            this.label_QtyTotal.TabIndex = 10;
            this.label_QtyTotal.Text = "TOTAL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(84, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "TOTAL";
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(3, 3);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 11;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_QtyLogList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 488);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button_Close);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label_QtyTotal);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 451);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(290, 34);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 94);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_UnitType, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label_Category, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label_SubCode, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label_DesignNumber, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(284, 75);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // Form_StockItemQuantityLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 488);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_StockItemQuantityLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detailed Quantities";
            this.Load += new System.EventHandler(this.Form_StockItemQuantityLog_Load);
            this.groupBox_QtyLogList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_QtyLogList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Category;
        private System.Windows.Forms.Label label_DesignNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_SubCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox_QtyLogList;
        private System.Windows.Forms.DataGridView dataGridView_QtyLogList;
        private System.Windows.Forms.Label label_UnitType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_QtyTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}