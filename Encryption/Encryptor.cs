using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;  // This is for password validation
using System.Security.Cryptography;  // This is where the hash functions reside

namespace AFLStock.Security {
    public class Encryptor {

        public static string GeneratePasswordHash( string thisPassword ) {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] tmpSource;
            byte[] tmpHash;

            tmpSource = ASCIIEncoding.ASCII.GetBytes( thisPassword ); // Turn password into byte array
            tmpHash = md5.ComputeHash( tmpSource );

            StringBuilder sOuput = new StringBuilder( tmpHash.Length );
            for ( int i = 0; i < tmpHash.Length; i++ ) {
                sOuput.Append( tmpHash[i].ToString( "X2" ) );  // X2 formats to hexadecimal
            }
            return sOuput.ToString();
        }

        // This will remove bad potential malicous sql attack input from the password
        public static string sanitizeInput( string thisInput ) {
            Regex regX = new Regex( @"([<>""'%;()&])" );
            return regX.Replace( thisInput, "" );
        }
    }
}
