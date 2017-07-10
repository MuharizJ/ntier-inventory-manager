using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.ComponentModel;

using AFLStock.Entities;
using AFLStock.DAL.EF;

namespace AFLStock.Consumer {
    public class StockConsumerLocal {

        // The only instance of this class - Singleton
        private static StockConsumerLocal _instance;
        private AflStockDAO dao;

        // The only way to obtain an Instance of this class - Singleton
        public static StockConsumerLocal getClientInstance() {
            if ( _instance == null ) {
                throw new Exception( "You are attempting to use this software without propper credentials - Good luck with that!" );
            }
            return _instance;
        }

        public static StockConsumerLocal getClientInstance( string userID, string passWord, string serverName, string dbName ) {
            if ( _instance == null ) {
                _instance = new StockConsumerLocal(userID, passWord, serverName, dbName);
            }
            return _instance;
        }

        // Private constructor, the only way to make this is using the static getClientInstance() method - Singleton
        private StockConsumerLocal( string userID, string passWord, string serverName, string dbName ) {
            dao = AflStockDAO.GetInstance( userID, passWord, serverName, dbName);
        }

        #region Reporting
        public double stockValue_Total() {
            return dao.StockValue_Total();
        }

        #endregion


        #region SalesOrder
        public bool salesOrderExists( int soID ) {
            return dao.SalesOrderExists( soID );
        }

        public bool saveSalesOrder( SalesOrderEntity soEnt ) {
            bool result = false;
            if ( dao.CustomerExists( soEnt.Customer ) ) {
                result = dao.SaveSalesOrder( soEnt );
            }
            return result;
        }

        public bool deleteSalesOrder( int soID ) {
            bool result = false;
            if ( dao.SalesOrderExists( soID ) ) {
                result = dao.DeleteSalesOrder( soID );
            }
            return result;
        }

        public SalesOrderEntity getSalesOrder( int soID ) {
            SalesOrderEntity soEnt;

            soEnt = dao.GetSalesOrder_ByID( soID );

            return soEnt;
        }

        public BindingList<SalesOrderEntity> getSalesOrders_All() {
            return new BindingList<SalesOrderEntity>( dao.GetSalesOrders_All() );
        }

        public List<CategorisedOrderDetail_Transfer> getSalesDetails_SummarizedByCategory( SalesOrderEntity soEnt ) {
            List<CategorisedOrderDetail_Transfer> soDetails = new List<CategorisedOrderDetail_Transfer>();

            Hashtable listsForCategories = new Hashtable();

            foreach ( SalesLogEntity soLogEnt in soEnt.SalesLogList ) {
                if ( !listsForCategories.ContainsKey( soLogEnt.StockCategory ) ) {
                    listsForCategories.Add( soLogEnt.StockCategory, new List<SalesLogEntity>() );
                    List<SalesLogEntity> newList = (List<SalesLogEntity>) listsForCategories[soLogEnt.StockCategory];
                    newList.Add( soLogEnt );
                }
                else {
                    List<SalesLogEntity> existingList = (List<SalesLogEntity>) listsForCategories[soLogEnt.StockCategory];
                    existingList.Add( soLogEnt );
                }
            }

            foreach ( DictionaryEntry de in listsForCategories ) {
                string categoryName = (string) de.Key;
                string unitType = "";
                double qty = 0.0;

                List<SalesLogEntity> listOfLogs = (List<SalesLogEntity>) de.Value;
                foreach ( SalesLogEntity soLogEnt in listOfLogs ) {
                    if ( qty == 0 ) { // quickest way to see whether this is the first time this loop is being run
                        // this is a HACK, but i don't know any other way to get the unit-type information
                        // ***** we are also assuming that one category can only have ONE UNIT TYPE
                        unitType = dao.GetStockItem_ByCategoryDesignSubcode( soLogEnt.StockCategory, soLogEnt.DesignNumber, soLogEnt.SubCode ).UnitType;
                    }
                    qty += soLogEnt.Quantity;
                }

                CategorisedOrderDetail_Transfer newPOdetail = new CategorisedOrderDetail_Transfer {
                    Category = categoryName,
                    UnitType = unitType,
                    Quantity = qty
                };

                soDetails.Add( newPOdetail );
            }

            return soDetails;
        }

        public bool salesOrderLogExists( int soId ) {
            return dao.SalesOrderLogExists( soId );
        }

        public bool deleteSalesOrderLog( int soId ) {
            return dao.DeleteSalesOrderLog( soId );
        }
        #endregion

        #region PurchaseOrder
        public bool purchaseOrderExists( int poID ) {
            return dao.PurchaseOrderExists( poID );
        }

        public bool savePurchaseOrder( PurchaseOrderEntity poEnt ) {
            bool result = false;
            if ( dao.SupplierExists( poEnt.Supplier ) ) {
                result = dao.SavePurchaseOrder( poEnt );
            }

            return result;
        }

        public bool deletePurchaseOrder( int poID ) {
            bool result = false;
            if ( dao.PurchaseOrderExists( poID ) ) {
                result = dao.DeletePurchaseOrder( poID );
            }
            return result;
        }

        public PurchaseOrderEntity getPurchaseOrder( int poID ) {
            PurchaseOrderEntity poEnt;

            poEnt = dao.GetPurchaseOrder_ByID( poID );

            return poEnt;
        }

        /* SLOW Operation over WAN network
         */
        public BindingList<PurchaseOrderEntity> getPurchaseOrders_All() {
            return new BindingList<PurchaseOrderEntity>( dao.GetPurchaseOrders_All() );
        }

        public List<CategorisedOrderDetail_Transfer> getPurchaseOrderDetails_SummarizedByCategory(PurchaseOrderEntity poEnt) {
            List<CategorisedOrderDetail_Transfer> poDetails = new List<CategorisedOrderDetail_Transfer>();
            
            Hashtable listsForCategories = new Hashtable();

            foreach ( PurchaseLogEntity poLogEnt in poEnt.PurchaseLogList ) {
                if ( !listsForCategories.ContainsKey( poLogEnt.StockCategory ) ) {
                    listsForCategories.Add( poLogEnt.StockCategory, new List<PurchaseLogEntity>() );
                    List<PurchaseLogEntity> newList = (List<PurchaseLogEntity>) listsForCategories[poLogEnt.StockCategory];
                    newList.Add( poLogEnt );
                }
                else {
                    List<PurchaseLogEntity> existingList = (List<PurchaseLogEntity>) listsForCategories[poLogEnt.StockCategory];
                    existingList.Add( poLogEnt );
                }
            }

            foreach ( DictionaryEntry de in listsForCategories ) {
                string categoryName = (string) de.Key;
                string unitType = "";
                double qty = 0.0;

                List<PurchaseLogEntity> listOfLogs = (List<PurchaseLogEntity>) de.Value;
                foreach ( PurchaseLogEntity poLogEnt in listOfLogs ) {
                    if ( qty == 0 ) { // quickest way to see whether this is the first time this loop is being run
                        // this is a HACK, but i don't know any other way to get the unit-type information
                        // ***** we are also assuming that one category can only have ONE UNIT TYPE
                        unitType = dao.GetStockItem_ByCategoryDesignSubcode( poLogEnt.StockCategory, poLogEnt.DesignNumber, poLogEnt.SubCode ).UnitType;
                    }                    
                    qty += poLogEnt.Quantity;
                }
                
                CategorisedOrderDetail_Transfer newPOdetail = new CategorisedOrderDetail_Transfer { Category = categoryName,
                                                                                              UnitType = unitType,
                                                                                              Quantity = qty };

                poDetails.Add( newPOdetail );
            }
            
            return poDetails;
        }


        #endregion

        #region Customer
        private List<CustomerEntity> _customerList;

        private void loadCustomers() {
            _customerList = dao.GetCustomers();
        }

        public bool customerExists( string customerName ) {
            return dao.CustomerExists( customerName );
        }

        public bool customerExists( int customerID) {
            return dao.CustomerExists( customerID );
        }

        public BindingList<CustomerEntity> getCustomers() {
            if ( _customerList == null ) {
                loadCustomers();
            }
            return new BindingList<CustomerEntity>( _customerList );
        }

        public List<string> getCustomerNames() {
            if ( _customerList == null ) {
                loadCustomers();
            }

            List<string> customerNames = new List<string>( _customerList.Count );
            foreach ( CustomerEntity custEnt in _customerList) {
                customerNames.Add( custEnt.CustomerName );
            }

            return customerNames;
        }
        #endregion

        #region Supplier
        private List<SupplierEntity> _supplierList;        

        // probably should call this via the webservice layer or something
        private void loadSuppliers() {
            _supplierList = dao.GetSuppliers();
        }

        public bool SupplierExists( string supplierName ) {
            return dao.SupplierExists( supplierName );
        }

        public BindingList<SupplierEntity> getSuppliers() {
            if ( _supplierList == null ) {
                loadSuppliers();
            }
            return new BindingList<SupplierEntity>( _supplierList );
        }

        public BindingList<SupplierEntity> getSuppliers( string filter_supplierName ) {
            if ( _supplierList == null ) {
                loadSuppliers();
            }

            BindingList<SupplierEntity> tempSupplierList;

            if ( filter_supplierName == null || filter_supplierName.Equals( "" ) ) {
                tempSupplierList = new BindingList<SupplierEntity>( _supplierList );
            }
            else {
                tempSupplierList = new BindingList<SupplierEntity>();
                foreach ( SupplierEntity supEnt in _supplierList ) {
                    if ( supEnt.SupplierName.Contains( filter_supplierName ) ) {
                        tempSupplierList.Add( supEnt );
                    }
                }
            }

            return tempSupplierList;
        }

        public List<string> getSupplierNames() {
            if ( _supplierList == null ) {
                loadSuppliers();
            }

            List<string> supplierNames = new List<string>( _supplierList.Count );
            foreach ( SupplierEntity supEnt in _supplierList ) {
                supplierNames.Add( supEnt.SupplierName );
            }

            return supplierNames;
        }
        #endregion

        #region Stock-Item
        public bool StockItemExists( int stockItemID ) {
            return dao.StockItemExists( stockItemID );
        }

        public bool StockItemExists( int catID, string designNumber, string subCode ) {
            return dao.StockItemExists( catID, designNumber, subCode );
        }

        public BindingList<StockItemMasterEntity> getStockItems_All() {
            return new BindingList<StockItemMasterEntity>( dao.GetStockItems_All() );
        }

        public List<string> getStockItemSubCodes_ByCategoryDesignNumber( int categoryID, string designNumber ) {
            return dao.GetStockItemSubCodes_ByDesignCategory( categoryID, designNumber );
        }

        public List<string> getStockItemDesignNumbers_ByCategory( string categoryName ) {
            return getStockItemDesignNumbers_ByCategory( getCategoryID(categoryName) );
        }

        public List<string> getStockItemDesignNumbers_ByCategory( int categoryID ) {
            BindingList<StockItemMasterEntity> itemEnts = getStockItems_ByCategory( categoryID );

            List<string> itemNames = new List<string>();
            foreach ( StockItemMasterEntity item in itemEnts ) {
                if ( !itemNames.Contains( item.DesignNumber ) ) {
                    itemNames.Add( item.DesignNumber );
                }
            }
            return itemNames;
        }

        public BindingList<StockItemMasterEntity> getStockItems_ByCategory( string categoryName ) {
            return new BindingList<StockItemMasterEntity>( dao.GetStockItems_ByCategory( categoryName ) );
        }

        public BindingList<StockItemMasterEntity> getStockItems_ByCategory( int categoryID ) {
            return new BindingList<StockItemMasterEntity>( dao.GetStockItems_ByCategory( categoryID ) );
        }

        public BindingList<StockItemMasterEntity> getStockItems_ByCategoryDesignSubcode( int catID, string designNumber, string subcode ) {
            return new BindingList<StockItemMasterEntity>( dao.GetStockItems_ByCategoryDesignSubcode( catID, designNumber, subcode ) );
        }

        public BindingList<StockItemMasterEntity> getStockItems_ByCategoryDesign( int catID, string designNumber ) {
            return new BindingList<StockItemMasterEntity>( dao.GetStockItems_ByCategoryDesign( catID, designNumber ) );
        }

        public BindingList<StockItemMasterEntity> getStockItems_ByCategoryDesign( string catName, string designNumber ) {
            return new BindingList<StockItemMasterEntity>( dao.GetStockItems_ByCategoryDesign( catName, designNumber ) );
        }

        public StockItemMasterEntity getStockItem_ByCategoryDesignSubcode( string categoryName, string designNumber, string subcode ) {
            return dao.GetStockItem_ByCategoryDesignSubcode( categoryName, designNumber, subcode );
        }

        public bool saveStockItem( StockItemMasterEntity itemToSave ) {
            return dao.SaveStockItemMaster( itemToSave );
        }

        public bool saveStockItemList( BindingList<StockItemMasterEntity> stockItemsToPersist ) {
            return dao.SaveStockItemMaster_List( new List<StockItemMasterEntity>(stockItemsToPersist) );
        }

        public bool deleteStockItem( int id ) {
            throw new NotSupportedException();
        }

        public void StockItemDesign_UpdateCosts(string catName, string dsnNumber, double newCost) {
            dao.StockItemDesign_UpdateCosts( catName, dsnNumber, newCost );
        }
        #endregion

        #region StockItemDetails-Quantity-Logs

        public BindingList<StockItemQuantityLogEntity> GetStockItemDetails_ByStockItemMasterID( int masterItemID ) {
            return new BindingList<StockItemQuantityLogEntity>( dao.GetStockItemDetailList( masterItemID ) );
        }

        #endregion

        #region Categories

        public int getCategoryID( string categoryName ) {
            return dao.GetStockCategoryID( categoryName );
        }

        public string getCategoryName( int catID ) {
            return dao.GetStockCategoryName( catID );
        }

        public BindingList<StockCategoryEntity> getCategories() {
            return new BindingList<StockCategoryEntity>( dao.GetStockCategories() );
        }

        public List<string> getCategoryNames() {
            BindingList<StockCategoryEntity> categoryList = getCategories();
            List<string> catNameStrings = new List<string>();

            foreach ( StockCategoryEntity ent in categoryList ) {
                catNameStrings.Add( ent.CategoryName );
            }

            return catNameStrings;
        }

        public void saveStockCategory( StockCategoryEntity categoryToSave ) {
            throw new NotSupportedException();
        }

        public bool deleteStockCategory( int id ) {
            throw new NotSupportedException();
        }

        public void saveStockCategoryList( BindingList<StockCategoryEntity> categoryListToPersist ) {
            dao.SaveStockCategories( new List<StockCategoryEntity>(categoryListToPersist) );
        }
        #endregion

        #region UnitTypes
        public BindingList<UnitTypeEntity> getUnitTypes() {
            return new BindingList<UnitTypeEntity>( dao.GetUnitTypes() );
        }
        #endregion
    }
}
