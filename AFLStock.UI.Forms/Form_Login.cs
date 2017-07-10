using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using AFLStock.Entities;

namespace AFLStock.UI.Forms {
    public partial class Form_Login : Form {

        private class Text_DTO {
            public string Text { get; set; }
        }

        public const string NOSELECTION_UID = "<Select a User Name>";
        public const string NOSELECTION_PWORD = "...";
        private static int loginAttempts = 0;

        private string _userName = NOSELECTION_UID;
        private string _password = NOSELECTION_PWORD; 

        private List<Text_DTO> _loginIDs;

        public Form_Login() {
            InitializeComponent();
        }

        internal string UserName {
            get {
                string temp = _userName;
                _userName = NOSELECTION_UID; // you can only access this once
                return temp;
            }
        }

        internal string Password {
            get {
                string temp = _password;
                _password = NOSELECTION_PWORD; // you can only access this once
                return temp;
            }
        }

        private void Form_Login_Load( object sender, EventArgs e ) {
            _loginIDs = new List<Text_DTO>( Settings_AFLStock_Logins.Default.Properties.Count );

            foreach ( SettingsProperty settingProp in Settings_AFLStock_Logins.Default.Properties ) {
                _loginIDs.Add( new Text_DTO { Text = settingProp.Name } );
            }            
            _loginIDs.Insert( 0, new Text_DTO { Text = NOSELECTION_UID } );
            
            comboBox_LoginIDs.DataSource = _loginIDs;
            comboBox_LoginIDs.DisplayMember = "Text";
        }

        private void button_Login_Click( object sender, EventArgs e ) {
            Text_DTO selectedUserID = (Text_DTO) comboBox_LoginIDs.SelectedItem;
            StringBuilder errorMessage = new StringBuilder();

            if ( selectedUserID.Text.Equals( NOSELECTION_UID ) ) {
                errorMessage.AppendLine( "Invalid User Name" );
            }
            else {
                string passwordText = textBox_Password.Text;
                string userPasswordHash = AFLStock.Security.Encryptor.GeneratePasswordHash( passwordText );
                string correctPasswordHash = "";
                try {
                    correctPasswordHash = (string) Settings_AFLStock_Logins.Default[selectedUserID.Text];
                }
                catch ( Exception ee) {
                    MessageBox.Show( ee.ToString() );
                    throw;
                }

                if ( !userPasswordHash.Equals( correctPasswordHash ) ) {
                    errorMessage.AppendLine( "Invalid Password for user: " + selectedUserID.Text );
                    loginAttempts += 1;
                }
                else {
                    _password = passwordText;
                    _userName = selectedUserID.Text;
                    errorMessage = new StringBuilder(); // reset all error messages
                }
            }

            // tried to login 3 times
            if ( loginAttempts > 2 ) {
                _password = NOSELECTION_PWORD;
                _userName = NOSELECTION_UID;
                MessageBox.Show( "You have too many failed login attempts - Application will now close down" );
                this.Close();
            }

            if ( errorMessage.Length > 0 ) {
                MessageBox.Show( errorMessage.ToString() + "\nLogin Attempts - " + loginAttempts, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else {
                MessageBox.Show( "Login Success for - " + selectedUserID.Text, "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void textBox_Password_KeyPress( object sender, KeyPressEventArgs e ) {
            if ( e.KeyChar == 13 ) {
                button_Login.PerformClick();
            }
        }
    }
}
