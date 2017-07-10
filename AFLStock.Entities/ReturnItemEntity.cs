using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFLStock.Entities {
    public class ReturnItemEntity {
        public int TransactionId { get; set; }
        public StockItemMasterEntity StockItem { get; set; }
        public decimal Quantity { get; set; }
    }
}
