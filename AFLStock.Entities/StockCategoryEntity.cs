using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class StockCategoryEntity : BaseEntity {

        private string catName;
        private bool mutable;

        public string CategoryName {
            get { return catName; }
            set {
                catName = value;
                this.NotifyPropertyChanged( "CategoryName" );
            }
        }

        public bool Mutable {
            get {
                return mutable;
            }
            set {
                mutable = value;
                this.NotifyPropertyChanged( "Mutable" );
            }
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();

            result.AppendLine( "[Category Name - " + CategoryName + "]" );

            return result.ToString();
        }
    }
}
