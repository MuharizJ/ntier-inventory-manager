using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class CustomerEntity : BaseEntity {
        private string customerName;

        public string CustomerName {
            get {
                return customerName;
            }
            set {
                customerName = value;
                this.NotifyPropertyChanged( "CustomerName" );
            }
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();

            result.AppendLine( "[Customer Name - " + CustomerName + "]" );

            return result.ToString();
        }
    }
}
