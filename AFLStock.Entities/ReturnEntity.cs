using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class ReturnEntity {
        public int TransactionId { get; set; }
        public string ExternalReferenceId { get; set; }
        public string Customer { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<ReturnItemEntity> ReturnItemList { get; set; }
        public string Details { get; set; }
    }
}
