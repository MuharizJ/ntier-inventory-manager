namespace AFLStock.UI.Forms
{
    partial class Form_StockCategories
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
            this.textBox_CategoryName = new System.Windows.Forms.TextBox();
            this.button_NewCategory = new System.Windows.Forms.Button();
            this.groupBox_CategoryNames = new System.Windows.Forms.GroupBox();
            this.dataGridView_CategoryNames = new System.Windows.Forms.DataGridView();
            this.button_Commit = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox_NewCategory = new System.Windows.Forms.GroupBox();
            this.checkBox_QtyLog = new System.Windows.Forms.CheckBox();
            this.groupBox_CategoryNames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CategoryNames)).BeginInit();
            this.groupBox_NewCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name";
            // 
            // textBox_CategoryName
            // 
            this.textBox_CategoryName.Location = new System.Drawing.Point(86, 19);
            this.textBox_CategoryName.Name = "textBox_CategoryName";
            this.textBox_CategoryName.Size = new System.Drawing.Size(223, 20);
            this.textBox_CategoryName.TabIndex = 1;
            // 
            // button_NewCategory
            // 
            this.button_NewCategory.Location = new System.Drawing.Point(175, 45);
            this.button_NewCategory.Name = "button_NewCategory";
            this.button_NewCategory.Size = new System.Drawing.Size(134, 22);
            this.button_NewCategory.TabIndex = 3;
            this.button_NewCategory.Text = "Create New Category";
            this.button_NewCategory.UseVisualStyleBackColor = true;
            this.button_NewCategory.Click += new System.EventHandler(this.button_NewCategory_Click);
            // 
            // groupBox_CategoryNames
            // 
            this.groupBox_CategoryNames.Controls.Add(this.dataGridView_CategoryNames);
            this.groupBox_CategoryNames.Location = new System.Drawing.Point(15, 112);
            this.groupBox_CategoryNames.Name = "groupBox_CategoryNames";
            this.groupBox_CategoryNames.Size = new System.Drawing.Size(312, 323);
            this.groupBox_CategoryNames.TabIndex = 4;
            this.groupBox_CategoryNames.TabStop = false;
            this.groupBox_CategoryNames.Text = "Existing Category Names - Start typing to edit OR hit Delete";
            // 
            // dataGridView_CategoryNames
            // 
            this.dataGridView_CategoryNames.AllowUserToAddRows = false;
            this.dataGridView_CategoryNames.AllowUserToOrderColumns = true;
            this.dataGridView_CategoryNames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_CategoryNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CategoryNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_CategoryNames.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_CategoryNames.MultiSelect = false;
            this.dataGridView_CategoryNames.Name = "dataGridView_CategoryNames";
            this.dataGridView_CategoryNames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_CategoryNames.Size = new System.Drawing.Size(306, 304);
            this.dataGridView_CategoryNames.TabIndex = 0;
            this.dataGridView_CategoryNames.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CategoryNames_CellBeginEdit);
            this.dataGridView_CategoryNames.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CategoryNames_CellEndEdit);
            this.dataGridView_CategoryNames.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_CategoryNames_UserDeletingRow);
            // 
            // button_Commit
            // 
            this.button_Commit.Location = new System.Drawing.Point(188, 447);
            this.button_Commit.Name = "button_Commit";
            this.button_Commit.Size = new System.Drawing.Size(134, 23);
            this.button_Commit.TabIndex = 5;
            this.button_Commit.TabStop = false;
            this.button_Commit.Text = "Commit Changes && Exit";
            this.button_Commit.UseVisualStyleBackColor = true;
            this.button_Commit.Click += new System.EventHandler(this.button_Commit_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(18, 447);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.TabStop = false;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // groupBox_NewCategory
            // 
            this.groupBox_NewCategory.Controls.Add(this.checkBox_QtyLog);
            this.groupBox_NewCategory.Controls.Add(this.textBox_CategoryName);
            this.groupBox_NewCategory.Controls.Add(this.label1);
            this.groupBox_NewCategory.Controls.Add(this.button_NewCategory);
            this.groupBox_NewCategory.Location = new System.Drawing.Point(12, 12);
            this.groupBox_NewCategory.Name = "groupBox_NewCategory";
            this.groupBox_NewCategory.Size = new System.Drawing.Size(315, 72);
            this.groupBox_NewCategory.TabIndex = 8;
            this.groupBox_NewCategory.TabStop = false;
            this.groupBox_NewCategory.Text = "New Category Details";
            // 
            // checkBox_QtyLog
            // 
            this.checkBox_QtyLog.AutoSize = true;
            this.checkBox_QtyLog.Checked = true;
            this.checkBox_QtyLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_QtyLog.Location = new System.Drawing.Point(6, 45);
            this.checkBox_QtyLog.Name = "checkBox_QtyLog";
            this.checkBox_QtyLog.Size = new System.Drawing.Size(154, 17);
            this.checkBox_QtyLog.TabIndex = 2;
            this.checkBox_QtyLog.Text = "Category has Quantity Lists";
            this.checkBox_QtyLog.UseVisualStyleBackColor = true;
            // 
            // Form_StockCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 482);
            this.Controls.Add(this.groupBox_NewCategory);
            this.Controls.Add(this.button_Commit);
            this.Controls.Add(this.groupBox_CategoryNames);
            this.Controls.Add(this.button_Cancel);
            this.Name = "Form_StockCategories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add / Remove / Edit - Stock Categories";
            this.Load += new System.EventHandler(this.Form_StockCategories_Load);
            this.groupBox_CategoryNames.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CategoryNames)).EndInit();
            this.groupBox_NewCategory.ResumeLayout(false);
            this.groupBox_NewCategory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_CategoryName;
        private System.Windows.Forms.Button button_NewCategory;
        private System.Windows.Forms.GroupBox groupBox_CategoryNames;
        private System.Windows.Forms.DataGridView dataGridView_CategoryNames;
        private System.Windows.Forms.Button button_Commit;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.GroupBox groupBox_NewCategory;
        private System.Windows.Forms.CheckBox checkBox_QtyLog;
    }
}