using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class PurchaseLogEntity : BaseEntity {
        private int purchaseOrderID;
        private string dsnNumber, subCode, stockCategory;
        private double qty, unitCostCN, unitCostLKR;

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

        public int ParentPurchaseOrderID {
            get {
                return purchaseOrderID;
            }
            set {
                purchaseOrderID = value;
                this.NotifyPropertyChanged( "ParentPurchaseOrderID" );
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

        public double UnitCostLKR {
            get {
                return unitCostLKR;
            }
            set {
                unitCostLKR = value;
                this.NotifyPropertyChanged( "UnitCostLKR" );
            }
        }

        public double UnitCostCNF {
            get {
                return unitCostCN;
            }
            set {
                unitCostCN = value;
                this.NotifyPropertyChanged( "UnitCostCNF" );
            }
        }
    }
}
