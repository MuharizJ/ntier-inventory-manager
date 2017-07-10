using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using AFLStock.Entities;

namespace AFLStock.WCF.Service {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAFLStockService {
        [OperationContract]
        List<PurchaseOrder_POCO> GetPurchaseOrders_Simplified();

        [OperationContract]
        List<SalesOrder_POCO> GetSalesOrders_Simplified();

        [OperationContract]
        double TotalStockValue();

        [OperationContract]
        List<StockItemMaster_POCO> GetStockItemsAll_Simplified();

        [OperationContract]
        List<StockItemMaster_POCO> GetStockItemsByCategory_Simplified(int catID);

        [OperationContract]
        List<StockItemMaster_POCO> GetStockItemsByCategoryDesignNumber_Simplified(int catID, string designNumber);

        [OperationContract]
        List<StockItemMaster_POCO> GetStockItemsByCategoryDesignNumberSubCode_Simplified(int catID, string designNumber, string subCode);
    }
}
