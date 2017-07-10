namespace AFLStock.UI.Forms
{
    partial class Form_Main
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
            this.button_StockInfo = new System.Windows.Forms.Button();
            this.button_StockPurchases = new System.Windows.Forms.Button();
            this.button_StockSale = new System.Windows.Forms.Button();
            this.button_StockReturn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockValue_DataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_StockInfo
            // 
            this.button_StockInfo.Location = new System.Drawing.Point(12, 32);
            this.button_StockInfo.Name = "button_StockInfo";
            this.button_StockInfo.Size = new System.Drawing.Size(285, 41);
            this.button_StockInfo.TabIndex = 0;
            this.button_StockInfo.Text = "Stock Information && Maintenance";
            this.button_StockInfo.UseVisualStyleBackColor = true;
            this.button_StockInfo.Click += new System.EventHandler(this.button_StockInfo_Click);
            // 
            // button_StockPurchases
            // 
            this.button_StockPurchases.Location = new System.Drawing.Point(12, 84);
            this.button_StockPurchases.Name = "button_StockPurchases";
            this.button_StockPurchases.Size = new System.Drawing.Size(285, 41);
            this.button_StockPurchases.TabIndex = 1;
            this.button_StockPurchases.Text = "Stock Purchases (Inward Stock Movement)";
            this.button_StockPurchases.UseVisualStyleBackColor = true;
            this.button_StockPurchases.Click += new System.EventHandler(this.button_StockPurchases_Click);
            // 
            // button_StockSale
            // 
            this.button_StockSale.Location = new System.Drawing.Point(12, 136);
            this.button_StockSale.Name = "button_StockSale";
            this.button_StockSale.Size = new System.Drawing.Size(285, 41);
            this.button_StockSale.TabIndex = 2;
            this.button_StockSale.Text = "Sales (Outward Stock Movement)";
            this.button_StockSale.UseVisualStyleBackColor = true;
            this.button_StockSale.Click += new System.EventHandler(this.button_StockSale_Click);
            // 
            // button_StockReturn
            // 
            this.button_StockReturn.Location = new System.Drawing.Point(12, 188);
            this.button_StockReturn.Name = "button_StockReturn";
            this.button_StockReturn.Size = new System.Drawing.Size(285, 41);
            this.button_StockReturn.TabIndex = 3;
            this.button_StockReturn.Text = "Stock Returns (Inward Stock Movement)";
            this.button_StockReturn.UseVisualStyleBackColor = true;
            this.button_StockReturn.Click += new System.EventHandler(this.button_StockReturn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ReportingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(309, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem1,
            this.logoutToolStripMenuItem});
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.loginToolStripMenuItem.Text = "Credentials";
            // 
            // loginToolStripMenuItem1
            // 
            this.loginToolStripMenuItem1.Name = "loginToolStripMenuItem1";
            this.loginToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.loginToolStripMenuItem1.Text = "Login";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // ReportingToolStripMenuItem
            // 
            this.ReportingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockValue_DataToolStripMenuItem});
            this.ReportingToolStripMenuItem.Name = "ReportingToolStripMenuItem";
            this.ReportingToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ReportingToolStripMenuItem.Text = "Reports";
            // 
            // stockValue_DataToolStripMenuItem
            // 
            this.stockValue_DataToolStripMenuItem.Name = "stockValue_DataToolStripMenuItem";
            this.stockValue_DataToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.stockValue_DataToolStripMenuItem.Text = "Stock Value";
            this.stockValue_DataToolStripMenuItem.Click += new System.EventHandler(this.stockValue_DataToolStripMenuItem_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 242);
            this.Controls.Add(this.button_StockReturn);
            this.Controls.Add(this.button_StockSale);
            this.Controls.Add(this.button_StockPurchases);
            this.Controls.Add(this.button_StockInfo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AFL - Stock Application - Home";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_StockInfo;
        private System.Windows.Forms.Button button_StockPurchases;
        private System.Windows.Forms.Button button_StockSale;
        private System.Windows.Forms.Button button_StockReturn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockValue_DataToolStripMenuItem;
    }
}

