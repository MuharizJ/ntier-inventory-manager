using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using AFLStock.DAL.EF;
using AFLStock.Entities;

namespace AFLStock.WCF.Service {
    public class AFLStockService : IAFLStockService {
        private AflStockDAO dao;

        private AflStockDAO GetDAO(string userID, string passWord, string serverName, string dbName) {
            return AflStockDAO.GetInstance(userID, passWord, serverName, dbName);
        }

        public double TotalStockValue() {
            dao = GetDAO("AFL_Super", "afl1981", "Muhariz-Home", "AFL_Stock");
            return dao.StockValue_Total();
        }

        public List<PurchaseOrder_POCO> GetPurchaseOrders_Simplified() {
            dao = GetDAO("AFL_Super", "afl1981", "Muhariz-Home", "AFL_Stock");

            List<PurchaseOrder_POCO> poList = null;

            if (dao != null) {
                poList = dao.GetPurchaseOrders_Simplified();
            }

            return poList;
        }

        public List<SalesOrder_POCO> GetSalesOrders_Simplified() {
            dao = GetDAO("AFL_Super", "afl1981", "Muhariz-Home", "AFL_Stock");

            List<SalesOrder_POCO> soList = null;

            if (dao != null) {
                soList = dao.GetSalesOrders_Simplified();
            }

            return soList;
        }

        public List<StockItemMaster_POCO> GetStockItemsAll_Simplified() {
            dao = GetDAO("AFL_Super", "afl1981", "Muhariz-Home", "AFL_Stock");

            List<StockItemMaster_POCO> stockItemsList = null;

            if (dao != null) {
                stockItemsList = dao.GetStockItemsAll_Simplified();
            }

            return stockItemsList;
        }

        public List<StockItemMaster_POCO> GetStockItemsByCategory_Simplified(int catID) {
            dao = GetDAO("AFL_Super", "afl1981", "Muhariz-Home", "AFL_Stock");
            
            List<StockItemMaster_POCO> stockItemsList = null;

            if (dao != null) {
                stockItemsList = dao.GetStockItemsByCategory_Simplified(catID);
            }

            return stockItemsList;
        }

        public List<StockItemMaster_POCO> GetStockItemsByCategoryDesignNumber_Simplified(int catID, string designNumber) {
            dao = GetDAO("AFL_Super", "afl1981", "Muhariz-Home", "AFL_Stock");
            
            List<StockItemMaster_POCO> stockItemsList = null;

            if (dao != null) {
                stockItemsList = dao.GetStockItemsByCategoryDesign_Simplified(catID, designNumber);
            }

            return stockItemsList;
        }

        public List<StockItemMaster_POCO> GetStockItemsByCategoryDesignNumberSubCode_Simplified(int catID, string designNumber, string subCode) {
            dao = GetDAO("AFL_Super", "afl1981", "Muhariz-Home", "AFL_Stock");

            List<StockItemMaster_POCO> stockItemsList = null;

            if (dao != null) {
                stockItemsList = dao.GetStockItemsByCategoryDesignSubCode_Simplified(catID, designNumber, subCode);
            }

            return stockItemsList;
        }
    }
}
