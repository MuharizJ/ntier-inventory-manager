namespace AFLStock.UI.Forms {
    partial class Form_PurchaseOrder_Search {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if ( disposing && (components != null) ) {
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
            this.groupBox_SearchCriteria = new System.Windows.Forms.GroupBox();
            this.label_Busy = new System.Windows.Forms.Label();
            this.button_ListPOs = new System.Windows.Forms.Button();
            this.checkBox_UseDates = new System.Windows.Forms.CheckBox();
            this.button_SearchPOs = new System.Windows.Forms.Button();
            this.dateTimePicker_ToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_FromDate = new System.Windows.Forms.DateTimePicker();
            this.label_FromDate = new System.Windows.Forms.Label();
            this.comboBox_Supplier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_POs = new System.Windows.Forms.GroupBox();
            this.dataGridView_POs = new System.Windows.Forms.DataGridView();
            this.groupBox_PoDetail = new System.Windows.Forms.GroupBox();
            this.dataGridView_POdetail = new System.Windows.Forms.DataGridView();
            this.button_SelectPO = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox_SearchCriteria.SuspendLayout();
            this.groupBox_POs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_POs)).BeginInit();
            this.groupBox_PoDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_POdetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_SearchCriteria
            // 
            this.groupBox_SearchCriteria.Controls.Add(this.label_Busy);
            this.groupBox_SearchCriteria.Controls.Add(this.button_ListPOs);
            this.groupBox_SearchCriteria.Controls.Add(this.checkBox_UseDates);
            this.groupBox_SearchCriteria.Controls.Add(this.button_SearchPOs);
            this.groupBox_SearchCriteria.Controls.Add(this.dateTimePicker_ToDate);
            this.groupBox_SearchCriteria.Controls.Add(this.label2);
            this.groupBox_SearchCriteria.Controls.Add(this.dateTimePicker_FromDate);
            this.groupBox_SearchCriteria.Controls.Add(this.label_FromDate);
            this.groupBox_SearchCriteria.Controls.Add(this.comboBox_Supplier);
            this.groupBox_SearchCriteria.Controls.Add(this.label1);
            this.groupBox_SearchCriteria.Location = new System.Drawing.Point(3, 2);
            this.groupBox_SearchCriteria.Name = "groupBox_SearchCriteria";
            this.groupBox_SearchCriteria.Size = new System.Drawing.Size(427, 100);
            this.groupBox_SearchCriteria.TabIndex = 0;
            this.groupBox_SearchCriteria.TabStop = false;
            this.groupBox_SearchCriteria.Text = "Search Criteria";
            // 
            // label_Busy
            // 
            this.label_Busy.AutoSize = true;
            this.label_Busy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Busy.ForeColor = System.Drawing.Color.Red;
            this.label_Busy.Location = new System.Drawing.Point(183, 83);
            this.label_Busy.Name = "label_Busy";
            this.label_Busy.Size = new System.Drawing.Size(241, 20);
            this.label_Busy.TabIndex = 10;
            this.label_Busy.Text = "System is Busy - Please Wait";
            this.label_Busy.Visible = false;
            // 
            // button_ListPOs
            // 
            this.button_ListPOs.Location = new System.Drawing.Point(318, 65);
            this.button_ListPOs.Name = "button_ListPOs";
            this.button_ListPOs.Size = new System.Drawing.Size(97, 23);
            this.button_ListPOs.TabIndex = 1;
            this.button_ListPOs.Text = "List All POs";
            this.button_ListPOs.UseVisualStyleBackColor = true;
            this.button_ListPOs.Click += new System.EventHandler(this.button_ListPOs_Click);
            // 
            // checkBox_UseDates
            // 
            this.checkBox_UseDates.AutoSize = true;
            this.checkBox_UseDates.Location = new System.Drawing.Point(318, 43);
            this.checkBox_UseDates.Name = "checkBox_UseDates";
            this.checkBox_UseDates.Size = new System.Drawing.Size(106, 17);
            this.checkBox_UseDates.TabIndex = 9;
            this.checkBox_UseDates.Text = "Search on Dates";
            this.checkBox_UseDates.UseVisualStyleBackColor = true;
            // 
            // button_SearchPOs
            // 
            this.button_SearchPOs.Location = new System.Drawing.Point(318, 12);
            this.button_SearchPOs.Name = "button_SearchPOs";
            this.button_SearchPOs.Size = new System.Drawing.Size(97, 23);
            this.button_SearchPOs.TabIndex = 8;
            this.button_SearchPOs.Text = "Search for POs";
            this.button_SearchPOs.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_ToDate
            // 
            this.dateTimePicker_ToDate.Location = new System.Drawing.Point(75, 68);
            this.dateTimePicker_ToDate.Name = "dateTimePicker_ToDate";
            this.dateTimePicker_ToDate.Size = new System.Drawing.Size(231, 20);
            this.dateTimePicker_ToDate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "To Date";
            // 
            // dateTimePicker_FromDate
            // 
            this.dateTimePicker_FromDate.Location = new System.Drawing.Point(75, 40);
            this.dateTimePicker_FromDate.Name = "dateTimePicker_FromDate";
            this.dateTimePicker_FromDate.Size = new System.Drawing.Size(231, 20);
            this.dateTimePicker_FromDate.TabIndex = 5;
            // 
            // label_FromDate
            // 
            this.label_FromDate.AutoSize = true;
            this.label_FromDate.Location = new System.Drawing.Point(12, 44);
            this.label_FromDate.Name = "label_FromDate";
            this.label_FromDate.Size = new System.Drawing.Size(56, 13);
            this.label_FromDate.TabIndex = 4;
            this.label_FromDate.Text = "From Date";
            // 
            // comboBox_Supplier
            // 
            this.comboBox_Supplier.FormattingEnabled = true;
            this.comboBox_Supplier.Location = new System.Drawing.Point(75, 13);
            this.comboBox_Supplier.Name = "comboBox_Supplier";
            this.comboBox_Supplier.Size = new System.Drawing.Size(233, 21);
            this.comboBox_Supplier.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Supplier";
            // 
            // groupBox_POs
            // 
            this.groupBox_POs.Controls.Add(this.dataGridView_POs);
            this.groupBox_POs.Location = new System.Drawing.Point(3, 108);
            this.groupBox_POs.Name = "groupBox_POs";
            this.groupBox_POs.Size = new System.Drawing.Size(427, 277);
            this.groupBox_POs.TabIndex = 1;
            this.groupBox_POs.TabStop = false;
            this.groupBox_POs.Text = "Purchase Order List";
            // 
            // dataGridView_POs
            // 
            this.dataGridView_POs.AllowUserToAddRows = false;
            this.dataGridView_POs.AllowUserToDeleteRows = false;
            this.dataGridView_POs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_POs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_POs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_POs.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_POs.MultiSelect = false;
            this.dataGridView_POs.Name = "dataGridView_POs";
            this.dataGridView_POs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_POs.Size = new System.Drawing.Size(421, 258);
            this.dataGridView_POs.TabIndex = 10;
            this.dataGridView_POs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_POs_CellDoubleClick);
            this.dataGridView_POs.SelectionChanged += new System.EventHandler(this.dataGridView_POs_SelectionChanged);
            // 
            // groupBox_PoDetail
            // 
            this.groupBox_PoDetail.Controls.Add(this.dataGridView_POdetail);
            this.groupBox_PoDetail.Location = new System.Drawing.Point(436, 2);
            this.groupBox_PoDetail.Name = "groupBox_PoDetail";
            this.groupBox_PoDetail.Size = new System.Drawing.Size(382, 380);
            this.groupBox_PoDetail.TabIndex = 2;
            this.groupBox_PoDetail.TabStop = false;
            this.groupBox_PoDetail.Text = "Purchase Order Detail";
            // 
            // dataGridView_POdetail
            // 
            this.dataGridView_POdetail.AllowUserToAddRows = false;
            this.dataGridView_POdetail.AllowUserToDeleteRows = false;
            this.dataGridView_POdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_POdetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_POdetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_POdetail.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_POdetail.MultiSelect = false;
            this.dataGridView_POdetail.Name = "dataGridView_POdetail";
            this.dataGridView_POdetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_POdetail.Size = new System.Drawing.Size(376, 361);
            this.dataGridView_POdetail.TabIndex = 11;
            // 
            // button_SelectPO
            // 
            this.button_SelectPO.Location = new System.Drawing.Point(3, 391);
            this.button_SelectPO.Name = "button_SelectPO";
            this.button_SelectPO.Size = new System.Drawing.Size(75, 23);
            this.button_SelectPO.TabIndex = 3;
            this.button_SelectPO.Text = "Select PO";
            this.button_SelectPO.UseVisualStyleBackColor = true;
            this.button_SelectPO.Click += new System.EventHandler(this.button_SelectPO_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(733, 391);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(85, 23);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "Cancel && Exit";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // Form_PurchaseOrder_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 423);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_SelectPO);
            this.Controls.Add(this.groupBox_PoDetail);
            this.Controls.Add(this.groupBox_POs);
            this.Controls.Add(this.groupBox_SearchCriteria);
            this.Name = "Form_PurchaseOrder_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search for Purchase Orders";
            this.Load += new System.EventHandler(this.Form_PurchaseOrder_Search_Load);
            this.groupBox_SearchCriteria.ResumeLayout(false);
            this.groupBox_SearchCriteria.PerformLayout();
            this.groupBox_POs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_POs)).EndInit();
            this.groupBox_PoDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_POdetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_SearchCriteria;
        private System.Windows.Forms.ComboBox comboBox_Supplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FromDate;
        private System.Windows.Forms.Label label_FromDate;
        private System.Windows.Forms.Button button_ListPOs;
        private System.Windows.Forms.CheckBox checkBox_UseDates;
        private System.Windows.Forms.Button button_SearchPOs;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox_POs;
        private System.Windows.Forms.GroupBox groupBox_PoDetail;
        private System.Windows.Forms.Button button_SelectPO;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.DataGridView dataGridView_POs;
        private System.Windows.Forms.DataGridView dataGridView_POdetail;
        private System.Windows.Forms.Label label_Busy;
    }
}