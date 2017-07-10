namespace AFLStock.UI.Forms {
    partial class Form_BasicStockReport {
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
            this.button_ListEverything = new System.Windows.Forms.Button();
            this.label_StockValue = new System.Windows.Forms.Label();
            this.groupBox_StockItemSelection = new System.Windows.Forms.GroupBox();
            this.treeView_StockItems = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_Quantities = new System.Windows.Forms.Label();
            this.button_Refine = new System.Windows.Forms.Button();
            this.groupBox_StockItemSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ListEverything
            // 
            this.button_ListEverything.Location = new System.Drawing.Point(735, 482);
            this.button_ListEverything.Name = "button_ListEverything";
            this.button_ListEverything.Size = new System.Drawing.Size(78, 34);
            this.button_ListEverything.TabIndex = 10;
            this.button_ListEverything.TabStop = false;
            this.button_ListEverything.Text = "List Total Inventory Values";
            this.button_ListEverything.UseVisualStyleBackColor = true;
            this.button_ListEverything.Click += new System.EventHandler(this.button_ListEverything_Click);
            // 
            // label_StockValue
            // 
            this.label_StockValue.AutoSize = true;
            this.label_StockValue.ForeColor = System.Drawing.Color.Red;
            this.label_StockValue.Location = new System.Drawing.Point(730, 28);
            this.label_StockValue.Name = "label_StockValue";
            this.label_StockValue.Size = new System.Drawing.Size(28, 13);
            this.label_StockValue.TabIndex = 2;
            this.label_StockValue.Text = "0.00";
            // 
            // groupBox_StockItemSelection
            // 
            this.groupBox_StockItemSelection.Controls.Add(this.treeView_StockItems);
            this.groupBox_StockItemSelection.Location = new System.Drawing.Point(12, 12);
            this.groupBox_StockItemSelection.Name = "groupBox_StockItemSelection";
            this.groupBox_StockItemSelection.Size = new System.Drawing.Size(606, 542);
            this.groupBox_StockItemSelection.TabIndex = 0;
            this.groupBox_StockItemSelection.TabStop = false;
            this.groupBox_StockItemSelection.Text = "Select the Items to generate report for";
            // 
            // treeView_StockItems
            // 
            this.treeView_StockItems.CheckBoxes = true;
            this.treeView_StockItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_StockItems.Location = new System.Drawing.Point(3, 16);
            this.treeView_StockItems.Name = "treeView_StockItems";
            this.treeView_StockItems.Size = new System.Drawing.Size(600, 523);
            this.treeView_StockItems.TabIndex = 2;
            this.treeView_StockItems.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_StockItems_AfterCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(624, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stock Value in LKR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stock Quantities";
            // 
            // label_Quantities
            // 
            this.label_Quantities.AutoSize = true;
            this.label_Quantities.ForeColor = System.Drawing.Color.Red;
            this.label_Quantities.Location = new System.Drawing.Point(732, 59);
            this.label_Quantities.Name = "label_Quantities";
            this.label_Quantities.Size = new System.Drawing.Size(69, 26);
            this.label_Quantities.TabIndex = 6;
            this.label_Quantities.Text = "0.00 METER\r\n0.00 UNIT\r\n";
            // 
            // button_Refine
            // 
            this.button_Refine.Location = new System.Drawing.Point(624, 522);
            this.button_Refine.Name = "button_Refine";
            this.button_Refine.Size = new System.Drawing.Size(189, 29);
            this.button_Refine.TabIndex = 2;
            this.button_Refine.Text = "Search on Selection";
            this.button_Refine.UseVisualStyleBackColor = true;
            this.button_Refine.Click += new System.EventHandler(this.button_Refine_Click);
            // 
            // Form_BasicStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 566);
            this.Controls.Add(this.button_Refine);
            this.Controls.Add(this.label_Quantities);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox_StockItemSelection);
            this.Controls.Add(this.label_StockValue);
            this.Controls.Add(this.button_ListEverything);
            this.Name = "Form_BasicStockReport";
            this.Text = "Form Basic Stock Report";
            this.Load += new System.EventHandler(this.Form_BasicStockReport_Load);
            this.groupBox_StockItemSelection.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ListEverything;
        private System.Windows.Forms.Label label_StockValue;
        private System.Windows.Forms.GroupBox groupBox_StockItemSelection;
        private System.Windows.Forms.TreeView treeView_StockItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Quantities;
        private System.Windows.Forms.Button button_Refine;
    }
}