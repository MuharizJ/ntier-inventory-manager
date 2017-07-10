using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace AFLStock.Entities {
    [DataContract]
    public class SalesOrder_POCO {
        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string Details { get; set; }

        [DataMember]
        public string ExternalReferenceID { get; set; }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string SalesOrderDate { get; set; }

        [DataMember]
        public List<SalesOrderDetail_POCO> SalesOrderDetailList { get; set; }
    }

    [DataContract]
    public class SalesOrderDetail_POCO {
        [DataMember]
        public string StockCategory { get; set; }

        [DataMember]
        public double Quantity { get; set; }

        [DataMember]
        public string UnitType { get; set; }
    }
}
