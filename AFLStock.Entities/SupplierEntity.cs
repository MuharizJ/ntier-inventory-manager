using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class SupplierEntity : BaseEntity {
        private string supplierName;

        public string SupplierName {
            get {
                return supplierName;
            }
            set {
                supplierName = value;
                this.NotifyPropertyChanged( "SupplierName" );
            }
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();

            result.AppendLine( "[Supplier Name - " + SupplierName + "]" );

            return result.ToString();
        }
    }
}
