using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace AFLStock.Entities {
    [DataContract]
    public class PurchaseOrder_POCO {
        [DataMember]
        public string SupplierName { get; set; }

        [DataMember]
        public string Details { get; set; }

        [DataMember]
        public string ExternalReferenceID { get; set; }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string PurchaseOrderDate { get; set; }

        [DataMember]
        public List<PurchaseOrderDetail_POCO> PurchaseOrderDetailList { get; set; }
    }

    [DataContract]
    public class PurchaseOrderDetail_POCO {
        [DataMember]
        public string StockCategory { get; set; }

        [DataMember]
        public double Quantity { get; set; }

        [DataMember]
        public string UnitType { get; set; }
    }
}
