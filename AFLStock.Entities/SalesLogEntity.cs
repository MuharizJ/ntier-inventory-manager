using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class SalesLogEntity : BaseEntity {
        private int salesOrderID;
        private string dsnNumber, subCode, stockCategory;
        private double qty, unitPrice;

        #region StockItem
        public string DesignNumber {
            get {
                return dsnNumber;
            }
            set {
                dsnNumber = value;
                this.NotifyPropertyChanged( "DesignNumber" );
                Dirty = true;
            }
        }

        public string SubCode {
            get {
                return subCode;
            }
            set {
                subCode = value;
                this.NotifyPropertyChanged( "SubCode" );
                Dirty = true;
            }
        }

        public string StockCategory {
            get {
                return stockCategory;
            }
            set {
                stockCategory = value;
                this.NotifyPropertyChanged( "StockCategory" );
                Dirty = true;
            }
        }
        #endregion

        public int ParentSalesOrderID {
            get {
                return salesOrderID;
            }
            set {
                salesOrderID = value;
                this.NotifyPropertyChanged( "ParentSalesOrderID" );
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

        public double UnitPrice {
            get {
                return unitPrice;
            }
            set {
                unitPrice = value;
                this.NotifyPropertyChanged( "UnitPrice" );
            }
        }
    }
}
