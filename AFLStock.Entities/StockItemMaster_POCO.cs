using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace AFLStock.Entities {
    [DataContract]
    public class StockItemMaster_POCO {
        [DataMember]
        public string StockCategory { get; set; }

        [DataMember]
        public string DesignNumber { get; set; }

        [DataMember]
        public string SubCode { get; set; }

        [DataMember]
        public double Quantity { get; set; }

        [DataMember]
        public string UnitType { get; set; }

        [DataMember]
        public double Cost { get; set; }

        [DataMember]
        public bool HasQuantityList { get; set; }

        [DataMember]
        public List<double> QuantityList { get; set; }
    }
}
