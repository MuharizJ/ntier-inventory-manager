using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Threading;

using AFLStock.Entities;

namespace AFLStock.DAL.EF {
    public class AflStockDAO {

        private static AflStockDAO stockItemDAO_Instance;

        private AFLStock_Entities afl_EF_Objects;

        public static AflStockDAO GetInstance() {
            if ( stockItemDAO_Instance == null ) {
                throw new Exception( "Trying to get access to the database without initializing it - ie: no uid/pword supplied" );
            }
            return stockItemDAO_Instance;
        }

        public static AflStockDAO GetInstance( string userID, string passWord, string serverName, string dbName ) {
            if ( stockItemDAO_Instance == null ) {
                stockItemDAO_Instance = new AflStockDAO( userID, passWord, serverName, dbName );
            }
            return stockItemDAO_Instance;
        }

        private AflStockDAO(string userID, string passWord, string serverName, string dbName) {
            string providerName = "System.Data.SqlClient";
            string databaseName = dbName;

            SqlConnectionStringBuilder sqlBuilder =
            new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.PersistSecurityInfo=true;;
            sqlBuilder.UserID = userID;
            sqlBuilder.Password = passWord;

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
            new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;
            

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/AFLStock_Model.csdl|res://*/AFLStock_Model.ssdl|res://*/AFLStock_Model.msl";

            Console.WriteLine( entityBuilder.ToString() );

            afl_EF_Objects = new AFLStock_Entities( new EntityConnection( entityBuilder.ToString() ) );
        }

        #region Reporting
        public double StockValue_Total() {
            double value = 0;

            foreach ( StockItemMaster stockItem in afl_EF_Objects.StockItemMasters ) {
                double qty = stockItem.CurrentStock;
                double unitPrice = stockItem.Cost_FinalUpdated;

                value += ( qty * unitPrice );
            }


            return value;
        }
        #endregion

        #region SalesOrder
        public bool SalesOrderExists( int salesOrderID ) {
            return GetSalesOrder(salesOrderID) != null;
        }

        public bool DeleteSalesOrder( int soID) {
            bool result = true;

            if ( SalesOrderExists( soID ) ) {
                SalesOrder soToDelete = GetSalesOrder( soID );

                // this will impact the StockItemMaster quantity field AND the StockItemDetail entries associated with these purchase quantities
                // This will make SalesLogs.Count many trips over the network to the Database
                if ( soToDelete.SalesLogs != null && soToDelete.SalesLogs.Count > 0 ) {
                    SalesLog[] salesLogs = new SalesLog[soToDelete.SalesLogs.Count];
                    soToDelete.SalesLogs.CopyTo( salesLogs, 0 );

                    for ( int i = 0; i < salesLogs.Length; i++ ) {
                        SalesLog soLog = salesLogs[i];
                        DeleteSalesOrderLog( soLog.SalesLogID);
                    }
                }

                afl_EF_Objects.SalesOrders.DeleteObject( soToDelete );
                afl_EF_Objects.SaveChanges();
                result = true;
            }

            return result;                 
        }

        internal SalesOrder GetSalesOrder( int salesOrderID ) {
            return ( from so in afl_EF_Objects.SalesOrders
                     where so.SalesOrderID == salesOrderID
                     select so ).FirstOrDefault<SalesOrder>();
        }

        public SalesOrderEntity GetSalesOrder_ByID( int salesOrderID ) {
            SalesOrder salesOrder = GetSalesOrder(salesOrderID);
            SalesOrderEntity salesOrderEnt = new SalesOrderEntity();

            EntityFrameworkTranslator.EF2Entity_SalesOrder( salesOrder, salesOrderEnt );

            return salesOrderEnt;
        }

        [Obsolete("GetSalesOrders_All() is deprecated due to the long network lookup, please use the WCF GetSalesOrders_Simplified() instead")]
        public List<SalesOrderEntity> GetSalesOrders_All() {
            List<SalesOrder> salesOrders = ( from so in afl_EF_Objects.SalesOrders
                                             select so ).ToList<SalesOrder>();

            List<SalesOrderEntity> soEnts = new List<SalesOrderEntity>( salesOrders.Count );

            foreach ( SalesOrder so in salesOrders ) {
                SalesOrderEntity soEnt = new SalesOrderEntity();
                EntityFrameworkTranslator.EF2Entity_SalesOrder( so, soEnt );
                soEnts.Add( soEnt );
            }

            return soEnts;
        }

        public List<SalesOrder_POCO> GetSalesOrders_Simplified() {
            List<SalesOrder> sos = (from so in afl_EF_Objects.SalesOrders
                                       select so).ToList<SalesOrder>();

            List<SalesOrder_POCO> pocoSoList = new List<SalesOrder_POCO>(sos.Count);

            foreach (SalesOrder so in sos) {
                SalesOrder_POCO socoSO = new SalesOrder_POCO();
                EntityFrameworkTranslator.EF2POCO_SalesOrder(so, socoSO);
                pocoSoList.Add(socoSO);
            }

            return pocoSoList;
        }

        public bool SaveSalesOrder( SalesOrderEntity soEnt ) {
            bool result = false;
            int soID = soEnt.ID;

            if ( SalesOrderExists( soID ) ) { // this is an update
                SalesOrder soToUpdate = GetSalesOrder( soID );
                soToUpdate.SaleDetails = soEnt.Details;
                soToUpdate.ExternalReferenceId = soEnt.ExternalReferenceId;
                soToUpdate.CustomerID = GetCustomerID( soEnt.Customer);
                soToUpdate.TransactionDate = soEnt.TransactionDate;

                try {
                    for ( int i = 0; i < soEnt.SalesLogList.Count; i++ ) {
                        SalesLogEntity soLogEnt = soEnt.SalesLogList[i];
                        soLogEnt.ParentSalesOrderID = soEnt.ID;
                        SaveSalesOrderLog_NoPersistence( soLogEnt ); // each Sales log is updated afterwards

                        // if this Entity has been marked for deletion, this would have been deleted by the save feature
                        // therefore, we need to remove this from DTO-entity list also 
                        if ( soLogEnt.MarkedForDeletion ) {
                            soEnt.SalesLogList.RemoveAt( i );
                            i--;
                        }
                    }
                    afl_EF_Objects.SaveChanges(); // Save all the above Sales-Logs and this SalesOrder
                    result = true;
                }
                catch ( Exception e ) {
                    throw new Exception( "Error during Updating Existing Sales Order\n" + e.ToString() );
                }
            }
            else {
                if ( CustomerExists( soEnt.Customer ) ) {
                    SalesOrder newSalesOrder = new SalesOrder();
                    newSalesOrder.CustomerID = GetCustomerID(soEnt.Customer);
                    newSalesOrder.ExternalReferenceId = soEnt.ExternalReferenceId;
                    newSalesOrder.SaleDetails = soEnt.Details;
                    newSalesOrder.TransactionDate = soEnt.TransactionDate;

                    try {
                        afl_EF_Objects.SalesOrders.AddObject( newSalesOrder );
                        // create the sales-order first because we need a reference to it during creation of the sales-logs
                        afl_EF_Objects.SaveChanges();

                        // update the Entity's ID so it can be observed from the caller
                        soEnt.ID = newSalesOrder.SalesOrderID;

                        foreach ( SalesLogEntity soLogEnt in soEnt.SalesLogList ) {
                            soLogEnt.ParentSalesOrderID = soEnt.ID;
                            SaveSalesOrderLog_NoPersistence( soLogEnt );
                        }
                        afl_EF_Objects.SaveChanges(); // because the savesalesorder-log method does not persist

                        result = true;
                    }
                    catch ( Exception ) {
                        throw new Exception( "Error during Saving New Sales Order" );
                    }
                }
                else {
                    throw new Exception( "Cannot create a SalesOrder without a valid Customer" );
                }
            }

            return result;
        }

        #endregion

        #region SalesOrderLog
        public bool SalesOrderLogExists( int soLogID ) {
            return GetSalesOrderLog( soLogID ) != null;
        }
        
        internal SalesLog GetSalesOrderLog(int soLogID){
            return ( from soLog in afl_EF_Objects.SalesLogs
                     where soLog.SalesLogID == soLogID
                     select soLog).FirstOrDefault<SalesLog>();
        }

        /* 1) Deletes a SalesLog with the given ID
           2) Adds the SalesLog's Quantity to the current stock from the master-stock-item table
           3) Creates a stock-item-detail (quantity log item) with the exact same quantity IF the related item-master has itemized qty list */
        public bool DeleteSalesOrderLog( int salesLogToDelete ) {
            bool result = false;

            if ( SalesOrderLogExists( salesLogToDelete ) ) {
                try {
                    SalesLog salesLog = GetSalesOrderLog( salesLogToDelete );
                    double oldLogQuantity = salesLog.Quantity;
                    StockItemMaster stockItem = salesLog.StockItemMaster;

                    afl_EF_Objects.SalesLogs.DeleteObject( salesLog );

                    stockItem.CurrentStock += oldLogQuantity;

                    if ( !stockItem.Quantity_Mutable ) { // that means we need to update the quantity list also --> Add to it
                        StockItemDetail itemDetail = new StockItemDetail();
                        itemDetail.Quantity = oldLogQuantity;
                        itemDetail.StockItemMaster = stockItem;
                        itemDetail.StockItemMasterID = stockItem.StockItemID;
                        afl_EF_Objects.StockItemDetails.AddObject( itemDetail );
                    }

                    afl_EF_Objects.SaveChanges();
                    result = true;
                }
                catch ( Exception ) {}
            }

            return result;
        }

        /* It would be good to do this method Without Saving Changed. However, we need to persist the changes because
         * It updates the total quantity in the stock-item-master
         * */
        public bool SaveSalesOrderLog_NoPersistence( SalesLogEntity soLogEnt ) {
            bool result = false;

            if ( SalesOrderLogExists( soLogEnt.ID ) ) { // This is an update
                if ( soLogEnt.MarkedForDeletion ) { // this is to be deleted --> warning, this affects the stock-item-master's qty and also its item detail logs
                    DeleteSalesOrderLog( soLogEnt.ID );
                    result = true;
                }
                else {
                                       
                    /* Unlike Purchase Orders, Sales Order's cannot be updated in this manner. The system does not allow you to select a non-existing
                     * stock item for sale. Therefore, the solution is to DELETE this Sales Order Entry and select the correct one
                     * NO EDITTING OF SALES-LOGS
                     * */
                }
            }
            else { // New Sales-Order-Log
                SalesLog newSalesLog = new SalesLog();
                EntityFrameworkTranslator.Entity2EF_SalesLog( soLogEnt, newSalesLog );
                afl_EF_Objects.SalesLogs.AddObject( newSalesLog );

                StockItemMaster stockItem = GetStockItem( soLogEnt.StockCategory, soLogEnt.DesignNumber, soLogEnt.SubCode );

                if ( stockItem.Quantity_Mutable ) {
                    stockItem.CurrentStock -= newSalesLog.Quantity;
                    result = true;
                }
                else {
                    // this cannot fail, it was matched up from the UI
                    StockItemDetail closestMatch = GetStockItemDetail_ClosestMatch( stockItem.StockItemID, newSalesLog.Quantity);
                    if ( closestMatch != null ) {
                        afl_EF_Objects.StockItemDetails.DeleteObject( closestMatch );
                        stockItem.CurrentStock -= newSalesLog.Quantity;
                        result = true;
                    }
                    else {
                        afl_EF_Objects.SalesLogs.DeleteObject( newSalesLog ); // because it was added at the very beginning of the method
                        throw new Exception( "The selected stock item was not found! It could not be added to the Sales Order" );
                    }
                }
                afl_EF_Objects.SaveChanges();
            }
            return result;
        }
        #endregion

        #region PurchaseOrder
        public bool DeletePurchaseOrder( int poID ) {
            bool result = false;

            if ( PurchaseOrderExists( poID ) ) {
                PurchaseOrder poToDelete = GetPurchaseOrder( poID );

                // this will impact the StockItemMaster quantity field AND the StockItemDetail entries associated with these purchase quantities
                if ( poToDelete.PurchaseLogs != null && poToDelete.PurchaseLogs.Count > 0 ) {
                    PurchaseLog[] purchaseLogs = new PurchaseLog[poToDelete.PurchaseLogs.Count];
                    poToDelete.PurchaseLogs.CopyTo( purchaseLogs, 0 );

                    for ( int i = 0; i < purchaseLogs.Length; i++ ) {
                        PurchaseLog poLog = purchaseLogs[i];
                        DeletePurchaseOrderLog( poLog.PurchaseLogID );
                    }
                }

                afl_EF_Objects.PurchaseOrders.DeleteObject( poToDelete );
                afl_EF_Objects.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool PurchaseOrderExists( int poID ) {
            return GetPurchaseOrder(poID) != null;
        }

        public bool SavePurchaseOrder( PurchaseOrderEntity poEnt ) {
            bool result = false;
            int poID = poEnt.ID;

            if ( PurchaseOrderExists( poID ) ) // this is an existing purchase order, this is a save
            {
                PurchaseOrder poToUpdate = GetPurchaseOrder( poID );
                poToUpdate.Description = poEnt.Details;
                poToUpdate.ExternalReferenceId = poEnt.ExternalReferenceId;
                poToUpdate.SupplierID = GetSupplierID( poEnt.Supplier );
                poToUpdate.TransactionDate = poEnt.TransactionDate;

                try {
                    for ( int i = 0; i < poEnt.PurchaseLogList.Count; i++ ) {
                        PurchaseLogEntity poLogEnt = poEnt.PurchaseLogList[i];
                        poLogEnt.ParentPurchaseOrderID = poEnt.ID;
                        SavePurchaseOrderLog_NoPersistence( poLogEnt ); // each purchase log is updated afterwards

                        // if this Entity has been marked for deletion, this would have been deleted by the save feature
                        // therefore, we need to remove this from DTO-entity list also 
                        if ( poLogEnt.MarkedForDeletion ) {
                            poEnt.PurchaseLogList.RemoveAt( i );
                            i--;
                        }

                        // Testing Code --> Simulating network delay Thread.Sleep( 1000 );
                    }
                    afl_EF_Objects.SaveChanges(); // save all the purchase-order-logs AND this parent purchase order
                    result = true;
                }
                catch ( Exception e ) { 
                    throw new Exception( "Error during Updating Existing Purchase Order\n" + e.ToString() );
                }
            }
            else // brand new purchase order - create a new item in the data-store
            {
                if ( SupplierExists( poEnt.Supplier ) ) {
                    PurchaseOrder newPO = new PurchaseOrder();
                    newPO.SupplierID = GetSupplierID( poEnt.Supplier );
                    newPO.TransactionDate = poEnt.TransactionDate;
                    newPO.ExternalReferenceId = poEnt.ExternalReferenceId;
                    newPO.Description = poEnt.Details;

                    try {
                        afl_EF_Objects.AddToPurchaseOrders( newPO );
                        afl_EF_Objects.SaveChanges(); // create the purchase order first because the children logs will need this parent po's id

                        // update the Entity's ID so it can be observed from the caller
                        poEnt.ID = newPO.PurchaseOrderID;

                        // now attempt to save the entire PurchaseOrder's individual purchase logs
                        foreach ( PurchaseLogEntity poLogEnt in poEnt.PurchaseLogList ) {
                            poLogEnt.ParentPurchaseOrderID = poEnt.ID;
                            SavePurchaseOrderLog_NoPersistence( poLogEnt );
                        }

                        result = true;
                        afl_EF_Objects.SaveChanges();
                    }
                    catch ( Exception ) {
                        throw new Exception( "Error during saving New Purchase Order" );
                    }
                }
                else {
                    throw new Exception( "Cannot create a new purchase order if the Supplier doesn't exist" );
                }
            }

            return result;
        }

        internal PurchaseOrder GetPurchaseOrder( int poID ) {
            return ( from po in afl_EF_Objects.PurchaseOrders
                     where po.PurchaseOrderID == poID
                     select po ).FirstOrDefault<PurchaseOrder>();
        }

        public PurchaseOrderEntity GetPurchaseOrder_ByID( int poID ) {
            PurchaseOrder purchaseOrder = GetPurchaseOrder(poID);
            PurchaseOrderEntity poEnt = new PurchaseOrderEntity();

            EntityFrameworkTranslator.EF2Entity_PurchaseOrder( purchaseOrder, poEnt );

            return poEnt;
        }

        [Obsolete("GetPurchaseOrders_All() is deprecated due to the long network lookup, please use the WCF GetPurchaseOrders_Simplified() instead")]
        public List<PurchaseOrderEntity> GetPurchaseOrders_All() {
            List<PurchaseOrder> pos = (from po in afl_EF_Objects.PurchaseOrders
                                             select po).ToList<PurchaseOrder>();

            List<PurchaseOrderEntity> poEnts = new List<PurchaseOrderEntity>( pos.Count );

            foreach ( PurchaseOrder po in pos ) {
                PurchaseOrderEntity poEnt = new PurchaseOrderEntity();
                EntityFrameworkTranslator.EF2Entity_PurchaseOrder( po, poEnt );
                poEnts.Add( poEnt );
            }

            return poEnts;
        }

        /* This method is a first attempt at solving the above crazy lookup in GetPurchaseOrders_All()
         * This is called via a WCF Service called AFLStockService
         * 
         * The POCO is a DataContract with DataMembers (Serialization) that is compatible for WCF use
         * */
        public List<PurchaseOrder_POCO> GetPurchaseOrders_Simplified()
        {
            List<PurchaseOrder> pos = (from po in afl_EF_Objects.PurchaseOrders
                                       select po).ToList<PurchaseOrder>();

            List<PurchaseOrder_POCO> pocoPoList = new List<PurchaseOrder_POCO>(pos.Count);

            foreach (PurchaseOrder po in pos)
            {
                PurchaseOrder_POCO pocoPO = new PurchaseOrder_POCO();
                EntityFrameworkTranslator.EF2POCO_PurchaseOrder(po, pocoPO);
                pocoPoList.Add(pocoPO);
            }

            return pocoPoList;
        }

        #endregion

        #region PurchaseOrderLog
        public bool PurchaseOrderLogExists( int poLogID ) {
            return GetPurchaseOrderLog( poLogID ) != null;
        }

        internal PurchaseLog GetPurchaseOrderLog( int poLogID ) {
            return ( from poLog in afl_EF_Objects.PurchaseLogs
                     where poLog.PurchaseLogID == poLogID
                     select poLog ).FirstOrDefault<PurchaseLog>();
        }
              

        /* 1) Deletes a PurchaseLog with the given ID
         * 2) Reduces the current stock from the master-stock-item table
         * 3) removes any stock-item-detail (quantity log item) with the exact same quantity as this from the stock-item-master related tables
         * 4) ***** NO PERSISTANCE - THE CALLER TO THIS METHOD MUST CALL SAVECHANGES() *************
         * */
        private bool DeletePurchaseOrderLog( int poLogIDToDelete ) {
            bool result = false;

            if (PurchaseOrderLogExists(poLogIDToDelete)) {
                try {
                    PurchaseLog poLog = GetPurchaseOrderLog(poLogIDToDelete);
                    double oldLogQuantity = poLog.Quantity;
                    StockItemMaster stockItem = poLog.StockItemMaster;

                    afl_EF_Objects.PurchaseLogs.DeleteObject(poLog);

                    stockItem.CurrentStock -= oldLogQuantity;

                    if (!stockItem.Quantity_Mutable) { // that means we need to update the quantity list also
                        StockItemDetail closestMatch = GetStockItemDetail_ClosestMatch(stockItem.StockItemID, oldLogQuantity);
                        afl_EF_Objects.StockItemDetails.DeleteObject(closestMatch);
                    }

                    result = true;
                }
                catch (Exception e) {
                    throw new Exception("AFLStock.DAL.EF.AflStockDAO.cs | DeletePurchaseOrderLog(int poLogIDToDelete) | The Purchase Order Log to be deleted could not be deleted due to the following cause: \n" + e.ToString());
                } 
            }

            return result;
        }

        /* This method only creates the objects and updates their data. The actual call to SaveChanges() is not done here simply
         * due to optimizations --> it will be called by SavePurchaseOrder which should be the only way to call this
         * */
        private bool SavePurchaseOrderLog_NoPersistence( PurchaseLogEntity poLogEnt ) {
            bool result = false;

            if ( PurchaseOrderLogExists( poLogEnt.ID ) ) { // this is an update
                if ( poLogEnt.MarkedForDeletion ) {
                    /*   This entire purchase log needs to be removed and deducted from the master-stock-items quantity
                         1) We need REDUCE the stock quantity in the Stock-Master-Item table
                         2) IF that stock-master-item has a Quantity-Log-List we need to locate that item and remove it from the list 
                     * */
                    result = DeletePurchaseOrderLog(poLogEnt.ID);
                }
                else { // An update in the quantity maybe? Maybe there's no update at all, but this is a pessimistic aproach and we save everything
                    PurchaseLog poLog = GetPurchaseOrderLog( poLogEnt.ID );
                    double oldLogQuantity = poLog.Quantity;
                    StockItemMaster stockItem = poLog.StockItemMaster;

                    double quantityDifference = poLogEnt.Quantity - oldLogQuantity;

                    EntityFrameworkTranslator.Entity2EF_PurchaseLog( poLogEnt, poLog ); // this will transfer all dto data to the persistence-object

                    if ( stockItem.Quantity_Mutable ) {
                        stockItem.CurrentStock += quantityDifference;
                    }
                    else {
                        // this is where things get VERY tricky, we need to try and find the closes StockItemDetail (quantity detail entry)
                        // for this stock-item-master object, if it exists GOOD. If it doesnt, it could mean that it has already been sold - this shouldnt be possible
                        // we need a better system to deal with these returns & or deletions

                        stockItem.CurrentStock += quantityDifference;

                        StockItemDetail closestMatch = GetStockItemDetail_ClosestMatch( stockItem.StockItemID, oldLogQuantity );
                        // this might through a Nullreference exception IF the item doesn't exist
                        closestMatch.Quantity += quantityDifference;
                    }
                    result = true;
                }
            }
            else { // this is a new purchase-log created by the user, it needs to be stored to the database
                PurchaseLog poLog = new PurchaseLog();
                EntityFrameworkTranslator.Entity2EF_PurchaseLog( poLogEnt, poLog ); // this will transfer all dto data to the NEW persistence-object
                afl_EF_Objects.PurchaseLogs.AddObject( poLog );

                /* Update the Master-Stock-Item to reflect this new addition of goods into the system
                 * */
                StockItemMaster stockItem = GetStockItem( poLogEnt.StockCategory, poLogEnt.DesignNumber, poLogEnt.SubCode );
                if ( stockItem.Quantity_Mutable ) {
                    stockItem.CurrentStock += poLogEnt.Quantity;
                }
                else {
                    stockItem.CurrentStock += poLogEnt.Quantity;

                    // also need to add to the Quantity-Log-List of this master item
                    StockItemDetail itemQuantityLog = new StockItemDetail();
                    itemQuantityLog.Quantity = poLogEnt.Quantity;
                    itemQuantityLog.StockItemMaster = stockItem;
                    itemQuantityLog.StockItemMasterID = stockItem.StockItemID;
                    afl_EF_Objects.StockItemDetails.AddObject( itemQuantityLog );
                }

                poLogEnt.ID = poLog.PurchaseLogID;
                result = true;
            }
            return result;
        }

        #endregion

        #region Supplier
        public bool SupplierExists( int supplierID ) {
            return ( from supp in afl_EF_Objects.Suppliers
                     where supp.SupplerID == supplierID
                     select supp ).FirstOrDefault<Supplier>() != null;
        }

        public bool DeleteSupplier( SupplierEntity supplierEnt ) {
            bool result = false;

            if ( SupplierExists( supplierEnt.ID ) ) {
                try {
                    Supplier supplier = GetSupplier( supplierEnt.ID );
                    afl_EF_Objects.Suppliers.DeleteObject( supplier );
                    afl_EF_Objects.SaveChanges();
                    result = true;
                }
                catch ( Exception ) { }
            }

            return result;
        }

        public bool SaveSupplier( SupplierEntity supplierEnt ) {
            bool result = false;

            if ( SupplierExists( supplierEnt.ID ) ) { // this is an update
                Supplier supplierToUpdate = GetSupplier( supplierEnt.ID );
                supplierToUpdate.SupplierName = supplierEnt.SupplierName;
                afl_EF_Objects.SaveChanges();
            }
            else { // this is a new Supplier all together
                try {
                    Supplier newSupplier = new Supplier();
                    newSupplier.SupplierName = supplierEnt.SupplierName;
                    afl_EF_Objects.Suppliers.AddObject( newSupplier );
                    afl_EF_Objects.SaveChanges();
                    result = true;
                }
                catch ( Exception ) { }

            }

            return result;
        }

        public bool SupplierExists( string supplierName ) {
            return ( from supp in afl_EF_Objects.Suppliers
                     where supp.SupplierName.Equals( supplierName )
                     select supp ).FirstOrDefault<Supplier>() != null;
        }

        public List<SupplierEntity> GetSuppliers() {
            List<SupplierEntity> supplierList = ( from supp in afl_EF_Objects.Suppliers
                                                  select new SupplierEntity {
                                                      SupplierName = supp.SupplierName,
                                                      ID = supp.SupplerID
                                                  } ).ToList<SupplierEntity>();
            return supplierList;

        }

        public List<string> GetSupplierNames() {
            List<string> supplierNames = new List<string>();

            foreach ( SupplierEntity supp in GetSuppliers() ) {
                supplierNames.Add( supp.SupplierName );
            }

            return supplierNames;
        }

        public int GetSupplierID( string supplierName ) {
            return ( from supp in afl_EF_Objects.Suppliers
                     where supp.SupplierName.Equals( supplierName )
                     select supp ).FirstOrDefault<Supplier>().SupplerID;
        }

        public string GetSupplierName( int supplierID ) {
            return ( from supp in afl_EF_Objects.Suppliers
                     where supp.SupplerID == supplierID
                     select supp ).FirstOrDefault<Supplier>().SupplierName;
        }

        internal Supplier GetSupplier( int supplierID ) {
            return ( from supp in afl_EF_Objects.Suppliers
                     where supp.SupplerID == supplierID
                     select supp ).First<Supplier>();
        }

        #endregion

        #region Customers
        public bool CustomerExists( int customerID ) {
            return ( from cust in afl_EF_Objects.Customers
                     where cust.CustomerId == customerID
                     select cust ).FirstOrDefault<Customer>() != null;
        }

        public bool CustomerExists( string customerName ) {
            return ( from cust in afl_EF_Objects.Customers
                     where cust.CustomerName.Equals( customerName )
                     select cust ).FirstOrDefault<Customer>() != null;
        }

        public List<CustomerEntity> GetCustomers() {
            List<CustomerEntity> customerList = ( from cus in afl_EF_Objects.Customers
                                                  select new CustomerEntity {
                                                      CustomerName = cus.CustomerName,
                                                      ID = cus.CustomerId
                                                  } ).ToList<CustomerEntity>();
            return customerList;
        }

        public List<string> GetCustomerNames() {
            List<string> customerNames = new List<string>();

            foreach ( CustomerEntity cusEnt in GetCustomers() ) {
                customerNames.Add( cusEnt.CustomerName );
            }

            return customerNames;
        }

        public int GetCustomerID( string customerName ) {
            return ( from cus in afl_EF_Objects.Customers
                     where cus.CustomerName.Equals( customerName )
                     select cus ).FirstOrDefault<Customer>().CustomerId;
        }

        public string GetCustomerName( int customerID ) {
            return ( from cus in afl_EF_Objects.Customers
                     where cus.CustomerId == customerID
                     select cus ).FirstOrDefault<Customer>().CustomerName;
        }
        #endregion

        #region Group-Tags
        public bool GroupExists(int groupID) {
            return (from groupTag in afl_EF_Objects.Groups
                    where groupTag.GroupID == groupID
                    select groupTag).FirstOrDefault<Group>() != null;
        }

        public bool GroupExists(string groupName) {
            return (from groupTag in afl_EF_Objects.Groups
                    where groupTag.GroupName.Equals(groupName)
                    select groupTag).FirstOrDefault<Group>() != null;
        }

        public List<string> GetGroupNames() {
            List<string> groupList = (from grp in afl_EF_Objects.Groups
                                      orderby grp.GroupName
                                      select grp.GroupName).ToList<string>();
            return groupList;
        }

        public int GetGroupID(string groupName) {
            return (from grp in afl_EF_Objects.Groups
                    where grp.GroupName.Equals(groupName)
                    select grp).FirstOrDefault<Group>().GroupID;
        }

        public string GetGroupName(int groupID) {
            return (from grp in afl_EF_Objects.Groups
                    where grp.GroupID == groupID
                    select grp).FirstOrDefault<Group>().GroupName;
        }

        public void SaveGroup(GroupEntity groupEntity) {

            /*
            foreach (GroupEntity stockCatEnt in catEnts) {
                StockCategory stockCategory = null;
                if (CategoryExists(stockCatEnt.ID)) {
                    stockCategory = GetStockCategory(stockCatEnt.ID);

                    if (stockCatEnt.MarkedForDeletion) { // this could be a delete
                        afl_EF_Objects.StockCategories.DeleteObject(stockCategory);
                    }
                    else {
                        EntityFrameworkTranslator.Entity2EF_StockCategory(stockCatEnt, stockCategory);
                    }
                }
                else {
                    stockCategory = new StockCategory();
                    afl_EF_Objects.StockCategories.AddObject(stockCategory);
                    EntityFrameworkTranslator.Entity2EF_StockCategory(stockCatEnt, stockCategory);
                }
            }
            afl_EF_Objects.SaveChanges();
             * */
        }
        #endregion

        #region Category
        public bool CategoryExists( int categoryID ) {
            return ( from cat in afl_EF_Objects.StockCategories
                     where cat.CategoryID == categoryID
                     select cat ).FirstOrDefault<StockCategory>() != null;
        }

        public bool CategoryExists( string categoryName ) {
            return ( from cat in afl_EF_Objects.StockCategories
                     where cat.CategoryName.Equals( categoryName )
                     select cat ).FirstOrDefault<StockCategory>() != null;
        }

        public List<string> GetStockCategoryNames() {
            List<string> categoryList = ( from stk in afl_EF_Objects.StockCategories
                                          orderby stk.CategoryName
                                          select stk.CategoryName ).ToList<string>();
            return categoryList;
        }

        public int GetStockCategoryID( string categoryName ) {
            return ( from catt in afl_EF_Objects.StockCategories
                     where catt.CategoryName.Equals( categoryName )
                     select catt ).FirstOrDefault<StockCategory>().CategoryID;
        }

        public string GetStockCategoryName( int catID ) {
            return ( from catt in afl_EF_Objects.StockCategories
                     where catt.CategoryID == catID
                     select catt ).FirstOrDefault<StockCategory>().CategoryName;
        }

        public StockCategoryEntity GetStockCategory( string stockCatName ) {
            StockCategory stkCat = ( from stk in afl_EF_Objects.StockCategories
                                     where stk.CategoryName.Equals( stockCatName )
                                     select stk ).FirstOrDefault<StockCategory>();
            StockCategoryEntity catEntity = new StockCategoryEntity();

            EntityFrameworkTranslator.EF2Entity_StockCategory( stkCat, catEntity );

            return catEntity;
        }

        public List<StockCategoryEntity> GetStockCategories() {
            List<StockCategory> stockCategories = ( from catt in afl_EF_Objects.StockCategories
                                                    orderby catt.CategoryName
                                                    select catt ).ToList<StockCategory>();
            List<StockCategoryEntity> stockCategoryEnts = new List<StockCategoryEntity>();

            foreach ( StockCategory stkCat in stockCategories ) {
                StockCategoryEntity catEntity = new StockCategoryEntity();
                EntityFrameworkTranslator.EF2Entity_StockCategory( stkCat, catEntity );
                stockCategoryEnts.Add( catEntity );
            }

            return stockCategoryEnts;
        }

        public StockCategory GetStockCategory(int id) {
            return (from catt in afl_EF_Objects.StockCategories
                    where catt.CategoryID == id
                    select catt).FirstOrDefault<StockCategory>();
        }

        public void SaveStockCategories(List<StockCategoryEntity> catEnts) {
            foreach ( StockCategoryEntity stockCatEnt in catEnts ) {
                StockCategory stockCategory = null;
                if ( CategoryExists( stockCatEnt.ID ) ) {
                    stockCategory = GetStockCategory( stockCatEnt.ID );

                    if ( stockCatEnt.MarkedForDeletion ) { // this could be a delete
                        afl_EF_Objects.StockCategories.DeleteObject( stockCategory );
                    }
                    else {
                        EntityFrameworkTranslator.Entity2EF_StockCategory( stockCatEnt, stockCategory );
                    }
                }
                else {
                    stockCategory = new StockCategory();
                    afl_EF_Objects.StockCategories.AddObject( stockCategory );
                    EntityFrameworkTranslator.Entity2EF_StockCategory( stockCatEnt, stockCategory );
                }
            }
            afl_EF_Objects.SaveChanges();
        }

        #endregion

        #region StockItem-DesignNumber-SubCode-MASTERITEM
        public bool StockItemExists( int itemID ) {
            return ( from stk in afl_EF_Objects.StockItemMasters
                     where stk.StockItemID == itemID
                     select stk ).FirstOrDefault<StockItemMaster>() != null;
        }

        public bool StockItemExists( int catID, string designNumber, string subCode ) {
            return ( from stk in afl_EF_Objects.StockItemMasters
                     where stk.CategoryID == catID &&
                             stk.DesignNumber.Equals( designNumber ) &&
                             stk.SubCode.Equals( subCode )
                     select stk ).FirstOrDefault<StockItemMaster>() != null;
        }

        public bool SaveStockItemMaster_List(List<StockItemMasterEntity> stockItemList) {
            bool result = false;

            foreach ( StockItemMasterEntity itemEnt in stockItemList ) {
                result = SaveStockItemMaster( itemEnt );
            }

            return result;
        }

        public bool SaveStockItemMaster( StockItemMasterEntity itemMasterEnt ) {
            bool result = false;

            if ( StockItemExists( itemMasterEnt.ID ) ) { // old stock-master-item object, needs to be UPDATED
                StockItemMaster itemMaster = GetStockItem( itemMasterEnt.ID );

                if ( itemMasterEnt.MarkedForDeletion ) { // if this is to be deleted, delete the darn thing
                    result = DeleteStockItemMaster( itemMaster );
                    itemMasterEnt.ID = int.MinValue;
                    itemMasterEnt.ResetEntity();
                }
                else {
                    // WARNING - The below method deletes StockItem-Quantity-Logs (StockItemDetails) from the datastore if they have been marked for deletion
                    EntityFrameworkTranslator.Entity2EF_StockMasterItem( itemMasterEnt, itemMaster );
                }
            }
            else {// brand new Stock Item Master Object, this needs to be created and persisted

                // First make sure we wont add duplicates because the Pkey might be an ID
                // ensure only one StockItemMaster exists with a unique category-dsn-subcode combination
                if ( !StockItemExists(GetStockCategoryID(itemMasterEnt.StockCategory), itemMasterEnt.DesignNumber, itemMasterEnt.SubCode) ) {
                    StockItemMaster itemMaster = new StockItemMaster();
                    EntityFrameworkTranslator.Entity2EF_StockMasterItem( itemMasterEnt, itemMaster );
                    afl_EF_Objects.StockItemMasters.AddObject( itemMaster ); 
                }                
            }

            afl_EF_Objects.SaveChanges();
            result = true;

            return result;
        }

        public void StockItemDesign_UpdateCosts(string catName, string designNumber, double newCost) {
            int catID = GetStockCategoryID( catName );
            List<StockItemMaster> itemMasters = (from itemMaster in afl_EF_Objects.StockItemMasters
                                                 where itemMaster.CategoryID == catID && itemMaster.DesignNumber.Equals( designNumber )
                                                 select itemMaster).ToList<StockItemMaster>();

            foreach ( StockItemMaster itemMaster in itemMasters ) {
                itemMaster.Cost_FinalUpdated = newCost;
            }
            afl_EF_Objects.SaveChanges();
        }

        public bool DeleteStockItemMaster( StockItemMasterEntity itemMasterEnt ) {
            bool result = false;

            if ( StockItemExists( itemMasterEnt.ID ) ) {
                StockItemMaster itemMaster = GetStockItem( itemMasterEnt.ID );
                result = DeleteStockItemMaster( itemMaster );
            }

            return result;
        }

        internal bool DeleteStockItemMaster( StockItemMaster itemMaster ) {
            bool result = false;

            if ( StockItemExists( itemMaster.StockItemID ) ) {
                if ( !itemMaster.Quantity_Mutable ) {
                    foreach ( StockItemDetail itemDetail in itemMaster.StockItemDetails ) {
                        afl_EF_Objects.StockItemDetails.DeleteObject( itemDetail );
                    }
                }
                afl_EF_Objects.StockItemMasters.DeleteObject( itemMaster );

                afl_EF_Objects.SaveChanges();
            }

            return result;
        }


        public List<string> GetStockItemDesignNumbers_ByCategory( string categoryName ) {
            int catID = GetStockCategoryID( categoryName );

            List<string> designNumberList = ( from item in afl_EF_Objects.StockItemMasters
                                              where item.CategoryID == catID
                                              select item.DesignNumber ).ToList<string>();
            return designNumberList;
        }

        public List<string> GetStockItemSubCodes_ByDesignCategory( int catID, string designNumber ) {
            List<string> subCodeList = ( from item in afl_EF_Objects.StockItemMasters
                                         where item.CategoryID == catID && item.DesignNumber.Equals( designNumber )
                                         select item.SubCode ).ToList<string>();

            return subCodeList;
        }

        public List<string> GetStockItemSubCodes_ByDesignCategory( string categoryName, string designNumber ) {
            int catID = GetStockCategoryID( categoryName );

            List<string> subCodeList = ( from item in afl_EF_Objects.StockItemMasters
                                         where item.CategoryID == catID && item.DesignNumber.Equals( designNumber )
                                         select item.SubCode ).ToList<string>();

            return subCodeList;
        }

        public StockItemMasterEntity GetStockItem_ByCategoryDesignSubcode( string categoryName, string designNumber, string subCode ) {
            int catID = GetStockCategoryID( categoryName );
            return GetStockItems_ByCategoryDesignSubcode( catID, designNumber, subCode )[0];
        }

        public StockItemMasterEntity GetStockItem_ByID( int stockItemMasterID ) {
            StockItemMasterEntity itemMasterEnt = new StockItemMasterEntity();
            StockItemMaster itemMaster = GetStockItem( stockItemMasterID );

            EntityFrameworkTranslator.EF2Entity_StockMasterItem( itemMaster, itemMasterEnt );

            return itemMasterEnt;
        }

        internal StockItemMaster GetStockItem( int stockItemMasterID ) {
            // get the actual StockMasterItem from the database
            StockItemMaster stockItemMaster = ( from itemMaster in afl_EF_Objects.StockItemMasters
                                                where itemMaster.StockItemID.Equals( stockItemMasterID )
                                                select itemMaster ).FirstOrDefault<StockItemMaster>();

            return stockItemMaster;
        }

        internal StockItemMaster GetStockItem( string categoryName, string designNumber, string subCode ) {
            int catID = GetStockCategoryID( categoryName );

            StockItemMaster itemMaster = ( from item in afl_EF_Objects.StockItemMasters
                                           where ( item.CategoryID == catID )
                                                    && ( item.DesignNumber.Equals( designNumber )
                                                    && ( item.SubCode.Equals( subCode ) ) )
                                           select item ).First<StockItemMaster>();

            return itemMaster;
        }

        /*
         * Returns all the stock items
         * NOTE - Crazy lookup against the StockCategories table to correctly get the "Category Name" not the ID
         * */
        public List<StockItemMasterEntity> GetStockItems_All() {
            List<StockItemMaster> stockItemMasters = ( from item in afl_EF_Objects.StockItemMasters
                                                       orderby item.CategoryID, item.DesignNumber, item.SubCode
                                                       select item ).ToList<StockItemMaster>();

            List<StockItemMasterEntity> stockItemMastersEntities = createStockItemEntityList(stockItemMasters);

            return stockItemMastersEntities;
        }

        public List<StockItemMasterEntity> GetStockItems_ByCategory( string catName ) {
            int catID = ( from catt in afl_EF_Objects.StockCategories
                          where catt.CategoryName.Equals( catName )
                          select catt ).FirstOrDefault<StockCategory>().CategoryID;

            // yes we know that the categoryName string will be looked up again for no reason but less code right?
            return GetStockItems_ByCategory( catID );
        }

        public List<StockItemMasterEntity> GetStockItems_ByCategory( int catID ) {
            List<StockItemMaster> stockItemMasters = ( from item in afl_EF_Objects.StockItemMasters
                                                       where item.CategoryID.Equals( catID )
                                                       orderby item.DesignNumber, item.SubCode
                                                       select item ).ToList<StockItemMaster>();

            List<StockItemMasterEntity> stockItemMastersEntities = createStockItemEntityList(stockItemMasters);

            return stockItemMastersEntities;
        }

        public List<StockItemMasterEntity> GetStockItems_ByDesign( string designNumber ) {
            List<StockItemMaster> stockItemMasters = ( from item in afl_EF_Objects.StockItemMasters
                                                       where item.DesignNumber.Equals( designNumber )
                                                       orderby item.SubCode
                                                       select item ).ToList<StockItemMaster>();

            List<StockItemMasterEntity> stockItemMastersEntities = createStockItemEntityList(stockItemMasters);

            return stockItemMastersEntities;
        }

        public List<StockItemMasterEntity> GetStockItems_ByCategoryDesign( int catID, string designNumber ) {
            List<StockItemMaster> stockItemMasters = ( from item in afl_EF_Objects.StockItemMasters
                                                       where ( item.CategoryID == catID ) && ( item.DesignNumber.Equals( designNumber ) )
                                                       orderby item.DesignNumber, item.SubCode
                                                       select item ).ToList<StockItemMaster>();

            List<StockItemMasterEntity> stockItemMastersEntities = createStockItemEntityList(stockItemMasters);

            return stockItemMastersEntities;
        }

        public List<StockItemMasterEntity> GetStockItems_ByCategoryDesign( string categoryName, string designNumber ) {
            int catID = GetStockCategoryID( categoryName );
            return GetStockItems_ByCategoryDesign(catID, designNumber);
        }

        public List<StockItemMasterEntity> GetStockItems_ByDesignSubcode( string designNumber, string subCode ) {
            List<StockItemMaster> stockItemMasters = ( from item in afl_EF_Objects.StockItemMasters
                                                       where ( item.DesignNumber.Equals( designNumber ) && item.SubCode.Equals( subCode ) )
                                                       orderby item.CategoryID, item.DesignNumber, item.SubCode
                                                       select item ).ToList<StockItemMaster>();

            List<StockItemMasterEntity> stockItemMastersEntities = createStockItemEntityList(stockItemMasters);

            return stockItemMastersEntities;
        }

        // This method will only return one StockItemMasterEntity even though its a List
        public List<StockItemMasterEntity> GetStockItems_ByCategoryDesignSubcode( int catID, string designNumber, string subCode ) {
            List<StockItemMaster> stockItemMasters = ( from item in afl_EF_Objects.StockItemMasters
                                                       where ( item.CategoryID == catID )
                                                                && ( item.DesignNumber.Equals( designNumber )
                                                                && ( item.SubCode.Equals( subCode ) ) )
                                                       select item ).ToList<StockItemMaster>();

            List<StockItemMasterEntity> stockItemMastersEntities = createStockItemEntityList(stockItemMasters);

            return stockItemMastersEntities;
        }

        private List<StockItemMasterEntity> createStockItemEntityList(List<StockItemMaster> stockItemMasters) {
            List<StockItemMasterEntity> stockItemMastersEntities = new List<StockItemMasterEntity>(stockItemMasters.Count);

            foreach (StockItemMaster itemMaster in stockItemMasters) {
                StockItemMasterEntity itemMasterEntity = new StockItemMasterEntity();
                EntityFrameworkTranslator.EF2Entity_StockMasterItem(itemMaster, itemMasterEntity);
                stockItemMastersEntities.Add(itemMasterEntity);
            }

            return stockItemMastersEntities;
        }
        #endregion

        #region StockItem-POCO-Simplified-lookups
        public List<StockItemMaster_POCO> GetStockItemsAll_Simplified() {
            List<StockItemMaster> stockItemMasters = (from item in afl_EF_Objects.StockItemMasters
                                                      orderby item.CategoryID, item.DesignNumber, item.SubCode
                                                      select item).ToList<StockItemMaster>();

            List<StockItemMaster_POCO> stockItemList = createStockItemPocoList(stockItemMasters);

            return stockItemList;
        }

        public List<StockItemMaster_POCO> GetStockItemsByCategory_Simplified(int catID) {
            List<StockItemMaster> stockItemMasters = (from item in afl_EF_Objects.StockItemMasters
                                                      where item.CategoryID.Equals(catID)
                                                      orderby item.DesignNumber, item.SubCode
                                                      select item).ToList<StockItemMaster>();

            List<StockItemMaster_POCO> stockItemList = createStockItemPocoList(stockItemMasters);

            return stockItemList;
        }

        public List<StockItemMaster_POCO> GetStockItemsByCategoryDesign_Simplified(int catID, string designNumber) {
            List<StockItemMaster> stockItemMasters = (from item in afl_EF_Objects.StockItemMasters
                                                      where (item.CategoryID == catID) && (item.DesignNumber.Equals(designNumber))
                                                      orderby item.DesignNumber, item.SubCode
                                                      select item).ToList<StockItemMaster>();

            List<StockItemMaster_POCO> stockItemList = createStockItemPocoList(stockItemMasters);

            return stockItemList;
        }

        public List<StockItemMaster_POCO> GetStockItemsByCategoryDesignSubCode_Simplified(int catID, string designNumber, string subCode) {
            List<StockItemMaster> stockItemMasters = (from item in afl_EF_Objects.StockItemMasters
                                                      where (item.CategoryID == catID)
                                                               && (item.DesignNumber.Equals(designNumber)
                                                               && (item.SubCode.Equals(subCode)))
                                                      select item).ToList<StockItemMaster>();

            
            List<StockItemMaster_POCO> stockItemList = createStockItemPocoList(stockItemMasters);

            return stockItemList;
        }

        private List<StockItemMaster_POCO> createStockItemPocoList(List<StockItemMaster> stockItemMasters) {
            List<StockItemMaster_POCO> stockItemList = new List<StockItemMaster_POCO>(stockItemMasters.Count);

            foreach (StockItemMaster itemMaster in stockItemMasters) {
                StockItemMaster_POCO itemPOCO = new StockItemMaster_POCO();
                EntityFrameworkTranslator.EF2POCO_StockMasterItem(itemMaster, itemPOCO);
                stockItemList.Add(itemPOCO);
            }

            return stockItemList;
        }
        #endregion

        #region StockItemDetail-Quantity_Details
        public bool StockItemDetailExists( int id ) {
            return ( from itemDetail in afl_EF_Objects.StockItemDetails
                     where itemDetail.StockItemDetailID == id
                     select itemDetail ).FirstOrDefault<StockItemDetail>() != null;
        }

        internal StockItemDetail GetStockItemDetail( int stockItemDetailID ) {
            return ( from itemdetail in afl_EF_Objects.StockItemDetails
                     where itemdetail.StockItemDetailID == stockItemDetailID
                     orderby itemdetail.StockItemMaster.DesignNumber, itemdetail.StockItemMaster.SubCode
                     select itemdetail ).First<StockItemDetail>();
        }

        internal bool DeleteStockItemDetail( StockItemDetail itemDetail ) {
            bool result = false;

            try {
                afl_EF_Objects.StockItemDetails.DeleteObject( itemDetail );
                afl_EF_Objects.SaveChanges();
                result = true;
            }
            catch ( Exception ) { }

            return result;
        }

        internal StockItemDetail GetStockItemDetail_ClosestMatch( int stockItemMasterID, double qty ) {
            StockItemDetail closestMatch = ( from itemDetail in afl_EF_Objects.StockItemDetails
                                             where itemDetail.StockItemMasterID == stockItemMasterID &&
                                                    itemDetail.Quantity == qty
                                             select itemDetail ).First<StockItemDetail>();

            if ( closestMatch == null ) { // big trouble, the item we were looking for didnt exist, we need to find the closest to this
                // TODO: Handle this, i don't know how or what to do here :( :( :( 
            }

            return closestMatch;
        }

        public List<StockItemQuantityLogEntity> GetStockItemDetailList( int stockItemMasterID ) {
            StockItemMaster stockItemMaster = GetStockItem( stockItemMasterID );

            // only proceed to load the stock-item-details if a StockItemMaster with the above ID exists
            // AND this StockItemMaster has been labelled as having Quantity-Not-Mutable-Directly
            if ( stockItemMaster != null && !stockItemMaster.Quantity_Mutable ) {
                return GetStockItemQuantityLogList( stockItemMaster );
            }
            else {
                return null;
            }

        }

        public List<StockItemQuantityLogEntity> GetStockItemQuantityLogList( StockItemMaster stockItemMaster ) {
            // The flag "Quantity_Mutable" means that this item's quantity can be directly deleted or added without needing item-detail lists
            if ( !stockItemMaster.Quantity_Mutable ) {
                // obtain the category-id int value, string designNumber and Subcode from the above obtained stock-master item
                int stockItemMasterID = stockItemMaster.StockItemID;
                int catID = stockItemMaster.CategoryID;
                string designNumber = stockItemMaster.DesignNumber;
                string subCode = stockItemMaster.SubCode;

                // use the above id value to obtain the category name
                string categoryName = ( from catt in afl_EF_Objects.StockCategories
                                        where catt.CategoryID.Equals( catID )
                                        select catt ).FirstOrDefault<StockCategory>().CategoryName;


                List<StockItemDetail> itemDetailList = (from itemDetail in afl_EF_Objects.StockItemDetails
                                                        where itemDetail.StockItemMasterID == stockItemMasterID
                                                        orderby itemDetail.StockItemMaster.DesignNumber, itemDetail.StockItemMaster.SubCode
                                                        select itemDetail).ToList<StockItemDetail>();

                List<StockItemQuantityLogEntity> itemDetailEnts = new List<StockItemQuantityLogEntity>( itemDetailList.Count );

                foreach ( StockItemDetail itemDetail in itemDetailList ) {
                    StockItemQuantityLogEntity qtyLog = new StockItemQuantityLogEntity();

                    EntityFrameworkTranslator.EF2Entity_StockItemDetail( itemDetail, qtyLog );

                    itemDetailEnts.Add( qtyLog );
                }

                return itemDetailEnts;
            }
            else {
                return null;
            }
        }
        #endregion

        #region UnitType
        public List<UnitTypeEntity> GetUnitTypes() {
            List<UnitType> unitTypes = ( from unitType in afl_EF_Objects.UnitTypes
                                         select unitType ).ToList<UnitType>();

            List<UnitTypeEntity> unitTypeEnts = new List<UnitTypeEntity>();

            foreach ( UnitType unitType in unitTypes ) {
                UnitTypeEntity ent = new UnitTypeEntity();

                EntityFrameworkTranslator.EF2Entity_UnitType( unitType, ent );
                unitTypeEnts.Add( ent );
            }

            return unitTypeEnts;
        }
        #endregion       
    }
}
