using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class UnitTypeEntity : BaseEntity {
        private string _unitType;

        public string UnitType {
            get {
                return _unitType;
            }
            set {
                _unitType = value;
                this.NotifyPropertyChanged( "UnitType" );
            }
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();

            result.AppendLine( "[Unit Type - " + UnitType + "]" );

            return result.ToString();
        }
    }
}
