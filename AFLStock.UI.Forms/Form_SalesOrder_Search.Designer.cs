namespace AFLStock.UI.Forms {
    partial class Form_SalesOrder_Search {
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
            this.groupBox_SearchCriteria = new System.Windows.Forms.GroupBox();
            this.button_ListSOs = new System.Windows.Forms.Button();
            this.checkBox_UseDates = new System.Windows.Forms.CheckBox();
            this.button_SearchSOs = new System.Windows.Forms.Button();
            this.dateTimePicker_ToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_FromDate = new System.Windows.Forms.DateTimePicker();
            this.label_FromDate = new System.Windows.Forms.Label();
            this.comboBox_Customer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_SOs = new System.Windows.Forms.GroupBox();
            this.dataGridView_SOs = new System.Windows.Forms.DataGridView();
            this.groupBox_SoDetail = new System.Windows.Forms.GroupBox();
            this.dataGridView_SOdetail = new System.Windows.Forms.DataGridView();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_SelectSO = new System.Windows.Forms.Button();
            this.label_Busy = new System.Windows.Forms.Label();
            this.groupBox_SearchCriteria.SuspendLayout();
            this.groupBox_SOs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SOs)).BeginInit();
            this.groupBox_SoDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SOdetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_SearchCriteria
            // 
            this.groupBox_SearchCriteria.Controls.Add(this.button_ListSOs);
            this.groupBox_SearchCriteria.Controls.Add(this.checkBox_UseDates);
            this.groupBox_SearchCriteria.Controls.Add(this.button_SearchSOs);
            this.groupBox_SearchCriteria.Controls.Add(this.dateTimePicker_ToDate);
            this.groupBox_SearchCriteria.Controls.Add(this.label2);
            this.groupBox_SearchCriteria.Controls.Add(this.dateTimePicker_FromDate);
            this.groupBox_SearchCriteria.Controls.Add(this.label_FromDate);
            this.groupBox_SearchCriteria.Controls.Add(this.comboBox_Customer);
            this.groupBox_SearchCriteria.Controls.Add(this.label1);
            this.groupBox_SearchCriteria.Location = new System.Drawing.Point(12, 12);
            this.groupBox_SearchCriteria.Name = "groupBox_SearchCriteria";
            this.groupBox_SearchCriteria.Size = new System.Drawing.Size(427, 100);
            this.groupBox_SearchCriteria.TabIndex = 1;
            this.groupBox_SearchCriteria.TabStop = false;
            this.groupBox_SearchCriteria.Text = "Search Criteria";
            // 
            // button_ListSOs
            // 
            this.button_ListSOs.Location = new System.Drawing.Point(318, 65);
            this.button_ListSOs.Name = "button_ListSOs";
            this.button_ListSOs.Size = new System.Drawing.Size(97, 23);
            this.button_ListSOs.TabIndex = 1;
            this.button_ListSOs.Text = "List All SO\'s";
            this.button_ListSOs.UseVisualStyleBackColor = true;
            this.button_ListSOs.Click += new System.EventHandler(this.button_ListPOs_Click);
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
            // button_SearchSOs
            // 
            this.button_SearchSOs.Location = new System.Drawing.Point(318, 12);
            this.button_SearchSOs.Name = "button_SearchSOs";
            this.button_SearchSOs.Size = new System.Drawing.Size(97, 23);
            this.button_SearchSOs.TabIndex = 8;
            this.button_SearchSOs.Text = "Search for SOs";
            this.button_SearchSOs.UseVisualStyleBackColor = true;
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
            // comboBox_Customer
            // 
            this.comboBox_Customer.FormattingEnabled = true;
            this.comboBox_Customer.Location = new System.Drawing.Point(75, 13);
            this.comboBox_Customer.Name = "comboBox_Customer";
            this.comboBox_Customer.Size = new System.Drawing.Size(233, 21);
            this.comboBox_Customer.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer";
            // 
            // groupBox_SOs
            // 
            this.groupBox_SOs.Controls.Add(this.dataGridView_SOs);
            this.groupBox_SOs.Location = new System.Drawing.Point(12, 118);
            this.groupBox_SOs.Name = "groupBox_SOs";
            this.groupBox_SOs.Size = new System.Drawing.Size(427, 277);
            this.groupBox_SOs.TabIndex = 2;
            this.groupBox_SOs.TabStop = false;
            this.groupBox_SOs.Text = "Sales Order List";
            // 
            // dataGridView_SOs
            // 
            this.dataGridView_SOs.AllowUserToAddRows = false;
            this.dataGridView_SOs.AllowUserToDeleteRows = false;
            this.dataGridView_SOs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SOs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_SOs.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_SOs.MultiSelect = false;
            this.dataGridView_SOs.Name = "dataGridView_SOs";
            this.dataGridView_SOs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SOs.Size = new System.Drawing.Size(421, 258);
            this.dataGridView_SOs.TabIndex = 10;
            this.dataGridView_SOs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_SOs_CellDoubleClick);
            this.dataGridView_SOs.SelectionChanged += new System.EventHandler(this.dataGridView_SOs_SelectionChanged);
            // 
            // groupBox_SoDetail
            // 
            this.groupBox_SoDetail.Controls.Add(this.dataGridView_SOdetail);
            this.groupBox_SoDetail.Location = new System.Drawing.Point(445, 15);
            this.groupBox_SoDetail.Name = "groupBox_SoDetail";
            this.groupBox_SoDetail.Size = new System.Drawing.Size(382, 380);
            this.groupBox_SoDetail.TabIndex = 3;
            this.groupBox_SoDetail.TabStop = false;
            this.groupBox_SoDetail.Text = "Sales Order Detail";
            // 
            // dataGridView_SOdetail
            // 
            this.dataGridView_SOdetail.AllowUserToAddRows = false;
            this.dataGridView_SOdetail.AllowUserToDeleteRows = false;
            this.dataGridView_SOdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SOdetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SOdetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_SOdetail.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_SOdetail.MultiSelect = false;
            this.dataGridView_SOdetail.Name = "dataGridView_SOdetail";
            this.dataGridView_SOdetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SOdetail.Size = new System.Drawing.Size(376, 361);
            this.dataGridView_SOdetail.TabIndex = 11;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(742, 401);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(85, 23);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.Text = "Cancel && Exit";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_SelectSO
            // 
            this.button_SelectSO.Location = new System.Drawing.Point(12, 401);
            this.button_SelectSO.Name = "button_SelectSO";
            this.button_SelectSO.Size = new System.Drawing.Size(112, 23);
            this.button_SelectSO.TabIndex = 5;
            this.button_SelectSO.Text = "Select Sales Order";
            this.button_SelectSO.UseVisualStyleBackColor = true;
            this.button_SelectSO.Click += new System.EventHandler(this.button_SelectSO_Click);
            // 
            // label_Busy
            // 
            this.label_Busy.AutoSize = true;
            this.label_Busy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Busy.ForeColor = System.Drawing.Color.Red;
            this.label_Busy.Location = new System.Drawing.Point(198, 95);
            this.label_Busy.Name = "label_Busy";
            this.label_Busy.Size = new System.Drawing.Size(241, 20);
            this.label_Busy.TabIndex = 11;
            this.label_Busy.Text = "System is Busy - Please Wait";
            this.label_Busy.Visible = false;
            // 
            // Form_SalesOrder_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 429);
            this.Controls.Add(this.label_Busy);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_SelectSO);
            this.Controls.Add(this.groupBox_SoDetail);
            this.Controls.Add(this.groupBox_SOs);
            this.Controls.Add(this.groupBox_SearchCriteria);
            this.Name = "Form_SalesOrder_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_SalesOrder_Search";
            this.Load += new System.EventHandler(this.Form_SalesOrder_Search_Load);
            this.groupBox_SearchCriteria.ResumeLayout(false);
            this.groupBox_SearchCriteria.PerformLayout();
            this.groupBox_SOs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SOs)).EndInit();
            this.groupBox_SoDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SOdetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_SearchCriteria;
        private System.Windows.Forms.Button button_ListSOs;
        private System.Windows.Forms.CheckBox checkBox_UseDates;
        private System.Windows.Forms.Button button_SearchSOs;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FromDate;
        private System.Windows.Forms.Label label_FromDate;
        private System.Windows.Forms.ComboBox comboBox_Customer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_SOs;
        private System.Windows.Forms.DataGridView dataGridView_SOs;
        private System.Windows.Forms.GroupBox groupBox_SoDetail;
        private System.Windows.Forms.DataGridView dataGridView_SOdetail;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_SelectSO;
        private System.Windows.Forms.Label label_Busy;
    }
}