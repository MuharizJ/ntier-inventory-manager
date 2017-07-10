using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class StockItemMasterEntity : BaseEntity {
        private string dsnNumber, subCode, stockCategory, description, unitType;
        private double currStock, minOrder, cost, priceInternal, priceExternal, totalQtySold, totalQtyPurchased;
        private bool mutable;

        private List<StockItemQuantityLogEntity> quantityDetailedList;

        public override void ResetEntity() {
            Mutable = false;
            DesignNumber = null;
            SubCode = null;
            StockCategory = null;
            Description = null;
            CurrentStock = double.MinValue;
            UnitType = null;
            MinOrderLevel = double.MinValue;
            Cost_FinalUpdated = double.MinValue;
            SellingPrice_External = double.MinValue;
            SellingPrice_Internal = double.MinValue;
            QuantityDetailedList = null;
            TotalQuantitySold = double.MinValue;
            TotalQuantityPurchased = double.MinValue;

            Dirty = false;
        }

        /* 
         * This indicates whether the quantity in this stock item can be directly
         * increased or decreased.
         * A) Stock In (Purchase)   - without ADDING to StockItemDetail table
         * B) Stock Out (Sale)      - without LOOKING-UP the StockItemDetail table
         */
        public bool Mutable {
            get {
                return mutable;
            }
            set {
                mutable = value;
                this.NotifyPropertyChanged( "Mutable" );
            }
        }

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

        public string Description {
            get {
                return description;
            }
            set {
                description = value;
                this.NotifyPropertyChanged( "Description" );
            }
        }

        public double CurrentStock {
            get {
                return currStock;
            }
            set {
                currStock = value;
                this.NotifyPropertyChanged( "CurrentStock" );
            }
        }

        public string UnitType {
            get {
                return unitType;
            }
            set {
                unitType = value;
                this.NotifyPropertyChanged( "UnitType" );
            }

        }

        public double MinOrderLevel {
            get {
                return minOrder;
            }
            set {
                minOrder = value;
                this.NotifyPropertyChanged( "MinOrderLevel" );
            }
        }


        public double Cost_FinalUpdated {
            get {
                return cost;
            }
            set {
                cost = value;
                this.NotifyPropertyChanged( "Cost_FinalUpdated" );
            }
        }

        public double TotalQuantitySold {
            get {
                return totalQtySold;
            }
            set {
                totalQtySold = value;
                this.NotifyPropertyChanged( "TotalQuantitySold" );
            }
        }

        public double TotalQuantityPurchased {
            get {
                return totalQtyPurchased;
            }
            set {
                totalQtyPurchased = value;
                this.NotifyPropertyChanged( "TotalQuantityPurchased" );
            }
        }

        public double SellingPrice_Internal {
            get {
                return priceInternal;
            }
            set {
                priceInternal = value;
                this.NotifyPropertyChanged( "SellingPrice_Internal" );
            }
        }

        public double SellingPrice_External {
            get {
                return priceExternal;
            }
            set {
                priceExternal = value;
                this.NotifyPropertyChanged( "SellingPrice_External" );
            }
        }

        public List<StockItemQuantityLogEntity> QuantityDetailedList {
            get {
                if ( quantityDetailedList == null ) {
                    quantityDetailedList = new List<StockItemQuantityLogEntity>();
                }
                return quantityDetailedList;
            }
            set {
                quantityDetailedList = value;
                this.NotifyPropertyChanged( "QuantityDetailedList" );
            }
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();

            result.AppendLine( "[Design - " + DesignNumber );
            result.AppendLine( "Sub Code - " + SubCode );
            result.AppendLine( "Stock Category - " + StockCategory );
            result.AppendLine( "Current Stock - " + CurrentStock );
            result.AppendLine( "Minimum Order Level - " + MinOrderLevel );
            result.AppendLine( "Final Cost of Purchase - " + Cost_FinalUpdated + "]" );

            return result.ToString();
        }
    }
}
