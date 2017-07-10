namespace AFLStock.UI.Forms
{
    partial class Form_StockItemSearch
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
            this.stockItemSelector_Control1 = new AFLStock.UI.Forms.StockItemSelector_Control();
            this.comboBox_CurrentStockEquality = new System.Windows.Forms.ComboBox();
            this.button_RefineSearch = new System.Windows.Forms.Button();
            this.textBox_CurrentStock = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_StockItemList = new System.Windows.Forms.GroupBox();
            this.dataGridView_StockItemList = new System.Windows.Forms.DataGridView();
            this.button_detailedQuantities = new System.Windows.Forms.Button();
            this.groupBox_SearchRefinement = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_RefineSearchCriteria = new System.Windows.Forms.TableLayoutPanel();
            this.label_Busy = new System.Windows.Forms.Label();
            this.button_ResetSearch = new System.Windows.Forms.Button();
            this.textBox_ContainsText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_ListAll = new System.Windows.Forms.Button();
            this.label_TotalMeters = new System.Windows.Forms.Label();
            this.label_TotalUnits = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel_FirstRow = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Row1Col2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_MasterDetail.SuspendLayout();
            this.groupBox_StockItemList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_StockItemList)).BeginInit();
            this.groupBox_SearchRefinement.SuspendLayout();
            this.tableLayoutPanel_RefineSearchCriteria.SuspendLayout();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel_FirstRow.SuspendLayout();
            this.tableLayoutPanel_Row1Col2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_MasterDetail
            // 
            this.groupBox_MasterDetail.Controls.Add(this.stockItemSelector_Control1);
            this.groupBox_MasterDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_MasterDetail.Location = new System.Drawing.Point(4, 4);
            this.groupBox_MasterDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_MasterDetail.Name = "groupBox_MasterDetail";
            this.groupBox_MasterDetail.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_MasterDetail.Size = new System.Drawing.Size(472, 175);
            this.groupBox_MasterDetail.TabIndex = 1;
            this.groupBox_MasterDetail.TabStop = false;
            this.groupBox_MasterDetail.Text = "Search Criteria Details";
            // 
            // stockItemSelector_Control1
            // 
            this.stockItemSelector_Control1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockItemSelector_Control1.Location = new System.Drawing.Point(4, 19);
            this.stockItemSelector_Control1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.stockItemSelector_Control1.Name = "stockItemSelector_Control1";
            this.stockItemSelector_Control1.Size = new System.Drawing.Size(464, 152);
            this.stockItemSelector_Control1.TabIndex = 0;
            // 
            // comboBox_CurrentStockEquality
            // 
            this.comboBox_CurrentStockEquality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_CurrentStockEquality.FormattingEnabled = true;
            this.comboBox_CurrentStockEquality.Location = new System.Drawing.Point(254, 4);
            this.comboBox_CurrentStockEquality.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_CurrentStockEquality.Name = "comboBox_CurrentStockEquality";
            this.comboBox_CurrentStockEquality.Size = new System.Drawing.Size(295, 24);
            this.comboBox_CurrentStockEquality.TabIndex = 18;
            this.comboBox_CurrentStockEquality.TabStop = false;
            // 
            // button_RefineSearch
            // 
            this.button_RefineSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_RefineSearch.Location = new System.Drawing.Point(254, 90);
            this.button_RefineSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_RefineSearch.Name = "button_RefineSearch";
            this.button_RefineSearch.Size = new System.Drawing.Size(295, 35);
            this.button_RefineSearch.TabIndex = 15;
            this.button_RefineSearch.TabStop = false;
            this.button_RefineSearch.Text = "Refine Search";
            this.button_RefineSearch.UseVisualStyleBackColor = true;
            this.button_RefineSearch.Click += new System.EventHandler(this.button_RefineSearch_Click);
            // 
            // textBox_CurrentStock
            // 
            this.textBox_CurrentStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_CurrentStock.Location = new System.Drawing.Point(154, 4);
            this.textBox_CurrentStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_CurrentStock.Name = "textBox_CurrentStock";
            this.textBox_CurrentStock.Size = new System.Drawing.Size(92, 22);
            this.textBox_CurrentStock.TabIndex = 8;
            this.textBox_CurrentStock.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 43);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current Stock";
            // 
            // groupBox_StockItemList
            // 
            this.groupBox_StockItemList.Controls.Add(this.dataGridView_StockItemList);
            this.groupBox_StockItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_StockItemList.Location = new System.Drawing.Point(4, 195);
            this.groupBox_StockItemList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_StockItemList.Name = "groupBox_StockItemList";
            this.groupBox_StockItemList.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_StockItemList.Size = new System.Drawing.Size(1200, 660);
            this.groupBox_StockItemList.TabIndex = 2;
            this.groupBox_StockItemList.TabStop = false;
            this.groupBox_StockItemList.Text = "Stock Item List";
            // 
            // dataGridView_StockItemList
            // 
            this.dataGridView_StockItemList.AllowUserToAddRows = false;
            this.dataGridView_StockItemList.AllowUserToDeleteRows = false;
            this.dataGridView_StockItemList.AllowUserToOrderColumns = true;
            this.dataGridView_StockItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_StockItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_StockItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_StockItemList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_StockItemList.Location = new System.Drawing.Point(4, 19);
            this.dataGridView_StockItemList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_StockItemList.MultiSelect = false;
            this.dataGridView_StockItemList.Name = "dataGridView_StockItemList";
            this.dataGridView_StockItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_StockItemList.Size = new System.Drawing.Size(1192, 637);
            this.dataGridView_StockItemList.TabIndex = 0;
            // 
            // button_detailedQuantities
            // 
            this.button_detailedQuantities.Enabled = false;
            this.button_detailedQuantities.Location = new System.Drawing.Point(4, 4);
            this.button_detailedQuantities.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_detailedQuantities.Name = "button_detailedQuantities";
            this.button_detailedQuantities.Size = new System.Drawing.Size(185, 28);
            this.button_detailedQuantities.TabIndex = 4;
            this.button_detailedQuantities.Text = "Show Detailed Quantities";
            this.button_detailedQuantities.UseVisualStyleBackColor = true;
            this.button_detailedQuantities.Click += new System.EventHandler(this.button_detailedQuantities_Click);
            // 
            // groupBox_SearchRefinement
            // 
            this.groupBox_SearchRefinement.Controls.Add(this.tableLayoutPanel_RefineSearchCriteria);
            this.groupBox_SearchRefinement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_SearchRefinement.Location = new System.Drawing.Point(4, 4);
            this.groupBox_SearchRefinement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_SearchRefinement.Name = "groupBox_SearchRefinement";
            this.groupBox_SearchRefinement.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_SearchRefinement.Size = new System.Drawing.Size(561, 167);
            this.groupBox_SearchRefinement.TabIndex = 3;
            this.groupBox_SearchRefinement.TabStop = false;
            this.groupBox_SearchRefinement.Text = "Refine Search Criteria";
            // 
            // tableLayoutPanel_RefineSearchCriteria
            // 
            this.tableLayoutPanel_RefineSearchCriteria.ColumnCount = 3;
            this.tableLayoutPanel_RefineSearchCriteria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel_RefineSearchCriteria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel_RefineSearchCriteria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.tableLayoutPanel_RefineSearchCriteria.Controls.Add(this.label_Busy, 2, 3);
            this.tableLayoutPanel_RefineSearchCriteria.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel_RefineSearchCriteria.Controls.Add(this.textBox_CurrentStock, 1, 0);
            this.tableLayoutPanel_RefineSearchCriteria.Controls.Add(this.button_ResetSearch, 1, 2);
            this.tableLayoutPanel_RefineSearchCriteria.Controls.Add(this.comboBox_CurrentStockEquality, 2, 0);
            this.tableLayoutPanel_RefineSearchCriteria.Controls.Add(this.textBox_ContainsText, 2, 1);
            this.tableLayoutPanel_RefineSearchCriteria.Controls.Add(this.button_RefineSearch, 2, 2);
            this.tableLayoutPanel_RefineSearchCriteria.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel_RefineSearchCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_RefineSearchCriteria.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel_RefineSearchCriteria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel_RefineSearchCriteria.Name = "tableLayoutPanel_RefineSearchCriteria";
            this.tableLayoutPanel_RefineSearchCriteria.RowCount = 4;
            this.tableLayoutPanel_RefineSearchCriteria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel_RefineSearchCriteria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel_RefineSearchCriteria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel_RefineSearchCriteria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel_RefineSearchCriteria.Size = new System.Drawing.Size(553, 144);
            this.tableLayoutPanel_RefineSearchCriteria.TabIndex = 0;
            // 
            // label_Busy
            // 
            this.label_Busy.AutoSize = true;
            this.label_Busy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Busy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Busy.ForeColor = System.Drawing.Color.Red;
            this.label_Busy.Location = new System.Drawing.Point(254, 129);
            this.label_Busy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Busy.Name = "label_Busy";
            this.label_Busy.Size = new System.Drawing.Size(295, 15);
            this.label_Busy.TabIndex = 23;
            this.label_Busy.Text = "System is Busy - Please Wait";
            this.label_Busy.Visible = false;
            // 
            // button_ResetSearch
            // 
            this.button_ResetSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ResetSearch.Location = new System.Drawing.Point(154, 90);
            this.button_ResetSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ResetSearch.Name = "button_ResetSearch";
            this.button_ResetSearch.Size = new System.Drawing.Size(92, 35);
            this.button_ResetSearch.TabIndex = 22;
            this.button_ResetSearch.TabStop = false;
            this.button_ResetSearch.Text = "Reset";
            this.button_ResetSearch.UseVisualStyleBackColor = true;
            this.button_ResetSearch.Click += new System.EventHandler(this.button_ResetSearch_Click);
            // 
            // textBox_ContainsText
            // 
            this.textBox_ContainsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ContainsText.Location = new System.Drawing.Point(254, 47);
            this.textBox_ContainsText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_ContainsText.Name = "textBox_ContainsText";
            this.textBox_ContainsText.Size = new System.Drawing.Size(295, 22);
            this.textBox_ContainsText.TabIndex = 21;
            this.textBox_ContainsText.TabStop = false;
            this.textBox_ContainsText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ContainsText_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 43);
            this.label1.TabIndex = 20;
            this.label1.Text = "Design Like";
            // 
            // button_ListAll
            // 
            this.button_ListAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ListAll.Location = new System.Drawing.Point(573, 4);
            this.button_ListAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ListAll.Name = "button_ListAll";
            this.button_ListAll.Size = new System.Drawing.Size(135, 167);
            this.button_ListAll.TabIndex = 19;
            this.button_ListAll.Text = "List All Stock Items";
            this.button_ListAll.UseVisualStyleBackColor = true;
            this.button_ListAll.Click += new System.EventHandler(this.button_ListAll_Click);
            // 
            // label_TotalMeters
            // 
            this.label_TotalMeters.AutoSize = true;
            this.label_TotalMeters.Location = new System.Drawing.Point(197, 0);
            this.label_TotalMeters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_TotalMeters.Name = "label_TotalMeters";
            this.label_TotalMeters.Size = new System.Drawing.Size(91, 17);
            this.label_TotalMeters.TabIndex = 5;
            this.label_TotalMeters.Text = "Total Meters:";
            this.label_TotalMeters.Visible = false;
            // 
            // label_TotalUnits
            // 
            this.label_TotalUnits.AutoSize = true;
            this.label_TotalUnits.Location = new System.Drawing.Point(296, 0);
            this.label_TotalUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_TotalUnits.Name = "label_TotalUnits";
            this.label_TotalUnits.Size = new System.Drawing.Size(80, 17);
            this.label_TotalUnits.TabIndex = 6;
            this.label_TotalUnits.Text = "Total Units:";
            this.label_TotalUnits.Visible = false;
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_FirstRow, 0, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.groupBox_StockItemList, 0, 1);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 3;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(1208, 955);
            this.tableLayoutPanel_Main.TabIndex = 20;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button_detailedQuantities);
            this.flowLayoutPanel1.Controls.Add(this.label_TotalMeters);
            this.flowLayoutPanel1.Controls.Add(this.label_TotalUnits);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 863);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1200, 88);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // tableLayoutPanel_FirstRow
            // 
            this.tableLayoutPanel_FirstRow.ColumnCount = 2;
            this.tableLayoutPanel_FirstRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel_FirstRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel_FirstRow.Controls.Add(this.groupBox_MasterDetail, 0, 0);
            this.tableLayoutPanel_FirstRow.Controls.Add(this.tableLayoutPanel_Row1Col2, 1, 0);
            this.tableLayoutPanel_FirstRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_FirstRow.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel_FirstRow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel_FirstRow.Name = "tableLayoutPanel_FirstRow";
            this.tableLayoutPanel_FirstRow.RowCount = 1;
            this.tableLayoutPanel_FirstRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_FirstRow.Size = new System.Drawing.Size(1200, 183);
            this.tableLayoutPanel_FirstRow.TabIndex = 0;
            // 
            // tableLayoutPanel_Row1Col2
            // 
            this.tableLayoutPanel_Row1Col2.ColumnCount = 2;
            this.tableLayoutPanel_Row1Col2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel_Row1Col2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Row1Col2.Controls.Add(this.button_ListAll, 1, 0);
            this.tableLayoutPanel_Row1Col2.Controls.Add(this.groupBox_SearchRefinement, 0, 0);
            this.tableLayoutPanel_Row1Col2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Row1Col2.Location = new System.Drawing.Point(484, 4);
            this.tableLayoutPanel_Row1Col2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel_Row1Col2.Name = "tableLayoutPanel_Row1Col2";
            this.tableLayoutPanel_Row1Col2.RowCount = 1;
            this.tableLayoutPanel_Row1Col2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Row1Col2.Size = new System.Drawing.Size(712, 175);
            this.tableLayoutPanel_Row1Col2.TabIndex = 2;
            // 
            // Form_StockItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 955);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_StockItemSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Items - Search";
            this.Load += new System.EventHandler(this.Form_StockItemList_Load);
            this.groupBox_MasterDetail.ResumeLayout(false);
            this.groupBox_StockItemList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_StockItemList)).EndInit();
            this.groupBox_SearchRefinement.ResumeLayout(false);
            this.tableLayoutPanel_RefineSearchCriteria.ResumeLayout(false);
            this.tableLayoutPanel_RefineSearchCriteria.PerformLayout();
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel_FirstRow.ResumeLayout(false);
            this.tableLayoutPanel_Row1Col2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_MasterDetail;
        private System.Windows.Forms.TextBox textBox_CurrentStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_RefineSearch;
        private System.Windows.Forms.ComboBox comboBox_CurrentStockEquality;
        private System.Windows.Forms.GroupBox groupBox_StockItemList;
        private System.Windows.Forms.DataGridView dataGridView_StockItemList;
        private System.Windows.Forms.GroupBox groupBox_SearchRefinement;
        private System.Windows.Forms.Button button_detailedQuantities;
        private System.Windows.Forms.Button button_ListAll;
        private System.Windows.Forms.TextBox textBox_ContainsText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ResetSearch;
        private System.Windows.Forms.Label label_TotalMeters;
        private System.Windows.Forms.Label label_TotalUnits;
        private System.Windows.Forms.Label label_Busy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_RefineSearchCriteria;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_FirstRow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Row1Col2;
        private StockItemSelector_Control stockItemSelector_Control1;
    }
}