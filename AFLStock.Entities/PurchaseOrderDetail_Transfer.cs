using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class CategorisedOrderDetail_Transfer {
        public string Category {get; set;}
        public double Quantity {get; set;}
        public string UnitType {get; set;}
    }
}
