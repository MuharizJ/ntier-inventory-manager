using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;

using AFLStock.Consumer;
using AFLStock.Security;

namespace AFLStock.UI.Forms {
    public partial class Form_Main : Form {
        public Form_Main() {
            InitializeComponent();
        }

        private void button_StockPurchases_Click( object sender, EventArgs e ) {
            new Form_PurchaseOrder().Show();
        }

        private void button_StockInfo_Click( object sender, EventArgs e ) {
            new Form_StockItemSearch().Show();
        }

        private void button_StockSale_Click( object sender, EventArgs e ) {
            new Form_SalesOrder().Show();
        }

        private void Form_Main_Load(object sender, EventArgs e) {
            Form_Login loginForm = new Form_Login();
            loginForm.ShowDialog();
            string uid = loginForm.UserName;
            string pword = loginForm.Password;
            string serverName = ConfigurationManager.AppSettings["ServerName"];
            string dbName = ConfigurationManager.AppSettings["DBName"];


            if ( uid.Equals( Form_Login.NOSELECTION_UID ) || pword.Equals( Form_Login.NOSELECTION_PWORD ) ) {
                MessageBox.Show( "You have failed to login to this application - good luck going any further", "Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Error );
                this.Close();
            }
            else {
                // this line of code initiates the login procedure for the db, without this, the application wont let you touch the database
                StockConsumerLocal.getClientInstance( uid, pword, serverName, dbName );
            }
        }

        private void stockValue_DataToolStripMenuItem_Click( object sender, EventArgs e ) {
            new Form_BasicStockReport().Show();
        }

        private void button_StockReturn_Click(object sender, EventArgs e) {

        }
    }
}
