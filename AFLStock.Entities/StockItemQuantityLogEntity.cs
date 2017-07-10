using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class StockItemQuantityLogEntity : BaseEntity {
        private string dsnNumber, subCode, stockCategory;
        private double qty;

        public string DesignNumber {
            get {
                return dsnNumber;
            }
            set {
                dsnNumber = value;
                this.NotifyPropertyChanged( "DesignNumber" );
            }
        }

        public string SubCode {
            get {
                return subCode;
            }
            set {
                subCode = value;
                this.NotifyPropertyChanged( "SubCode" );
            }
        }

        public string StockCategory {
            get {
                return stockCategory;
            }
            set {
                stockCategory = value;
                this.NotifyPropertyChanged( "StockCategory" );
            }
        }

        public double Quantity {
            get {
                return qty;
            }
            set {
                qty = value;
                this.NotifyPropertyChanged( "Quantity" );
            }
        }

    }
}
