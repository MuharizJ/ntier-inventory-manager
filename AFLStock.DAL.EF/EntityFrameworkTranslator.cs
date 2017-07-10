using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using AFLStock.Entities;
using System.Collections;

namespace AFLStock.DAL.EF {
    public class EntityFrameworkTranslator {

        #region SalesOrder
        public static void EF2Entity_SalesOrder(SalesOrder source, SalesOrderEntity target) {
            target.Details = source.SaleDetails;
            target.ExternalReferenceId = source.ExternalReferenceId;
            target.ID = source.SalesOrderID;
            target.Customer = source.Customer.CustomerName;
            target.TransactionDate = source.TransactionDate;

            if (source.SalesLogs != null) {
                foreach (SalesLog salesLog in source.SalesLogs) {
                    SalesLogEntity salesLogEnt = new SalesLogEntity();
                    EF2Entity_SalesLog(salesLog, salesLogEnt);

                    if (target.SalesLogList == null) {
                        target.SalesLogList = new BindingList<SalesLogEntity>();
                    }

                    target.SalesLogList.Add(salesLogEnt);
                }
            }

            target.Dirty = false;
        }


        public static void EF2POCO_SalesOrder(SalesOrder source, SalesOrder_POCO target) {
            target.Details = source.SaleDetails;
            target.ID = source.SalesOrderID;
            target.ExternalReferenceID = source.ExternalReferenceId;
            target.CustomerName = source.Customer.CustomerName;
            target.SalesOrderDate = source.TransactionDate.ToShortDateString();

            if (source.SalesLogs != null) {
                Hashtable categoryQty = new Hashtable();
                Hashtable categoryUnitType = new Hashtable();

                foreach (SalesLog salesLog in source.SalesLogs) {
                    // if this hashtable doesn't have an entry for the category name, we need to make a new entry and add this quantity as the first value for this category
                    if (!categoryQty.ContainsKey(salesLog.StockItemMaster.StockCategory.CategoryName)) {
                        categoryQty.Add(salesLog.StockItemMaster.StockCategory.CategoryName, salesLog.Quantity);
                    }
                    else {
                        categoryQty[salesLog.StockItemMaster.StockCategory.CategoryName] = (double)categoryQty[salesLog.StockItemMaster.StockCategory.CategoryName]
                                                                                                            + salesLog.Quantity;
                        if (!categoryUnitType.ContainsKey(salesLog.StockItemMaster.StockCategory.CategoryName)) {
                            categoryUnitType.Add(salesLog.StockItemMaster.StockCategory.CategoryName, salesLog.StockItemMaster.UnitType);
                        }
                    }
                }

                foreach (String categoryName in categoryQty.Keys) {
                    SalesOrderDetail_POCO pocoDetail = new SalesOrderDetail_POCO();
                    pocoDetail.Quantity = (double)categoryQty[categoryName];
                    pocoDetail.StockCategory = categoryName;
                    pocoDetail.UnitType = (string)categoryUnitType[categoryName];

                    if (target.SalesOrderDetailList == null) {
                        target.SalesOrderDetailList = new List<SalesOrderDetail_POCO>();
                    }
                    target.SalesOrderDetailList.Add(pocoDetail);
                }
            }
        }
        #endregion

        #region SalesOrder-Log
        public static void EF2Entity_SalesLog(SalesLog source, SalesLogEntity target) {
            StockItemMaster itemMaster = source.StockItemMaster;

            target.UnitPrice = source.SalePrice == null ? 0 : (double)source.SalePrice;

            target.DesignNumber = source.StockItemMaster.DesignNumber;
            target.ID = source.SalesLogID;
            target.Quantity = source.Quantity;
            target.StockCategory = source.StockItemMaster.StockCategory.CategoryName;
            target.SubCode = source.StockItemMaster.SubCode;

            target.Dirty = false;
        }

        public static void Entity2EF_SalesLog(SalesLogEntity source, SalesLog target) {
            StockItemMaster stockItemMaster = AflStockDAO.GetInstance().GetStockItem(source.StockCategory, source.DesignNumber, source.SubCode);
            SalesOrder parentSalesOrdermaster = AflStockDAO.GetInstance().GetSalesOrder(source.ParentSalesOrderID);

            target.SalesOrder = parentSalesOrdermaster;
            target.SalesOrderID = parentSalesOrdermaster.SalesOrderID;
            target.Quantity = source.Quantity;
            target.StockItemID = stockItemMaster.StockItemID;
            target.StockItemMaster = stockItemMaster;
            target.SalePrice = source.UnitPrice;
        }
        #endregion

        #region PurchaseOrder
        public static void EF2Entity_PurchaseOrder(PurchaseOrder source, PurchaseOrderEntity target) {
            target.Details = source.Description;
            target.ExternalReferenceId = source.ExternalReferenceId;
            target.ID = source.PurchaseOrderID;
            target.Supplier = source.Supplier.SupplierName;
            target.TransactionDate = source.TransactionDate;

            if (source.PurchaseLogs != null) {
                foreach (PurchaseLog purchaseLog in source.PurchaseLogs) {
                    PurchaseLogEntity purchaseLogEnt = new PurchaseLogEntity();
                    EF2Entity_PurchaseLog(purchaseLog, purchaseLogEnt);

                    if (target.PurchaseLogList == null) {
                        target.PurchaseLogList = new BindingList<PurchaseLogEntity>();
                    }

                    target.PurchaseLogList.Add(purchaseLogEnt);
                }
            }

            target.Dirty = false;
        }

        public static void EF2POCO_PurchaseOrder(PurchaseOrder source, PurchaseOrder_POCO target) {
            target.Details = source.Description;
            target.ID = source.PurchaseOrderID;
            target.ExternalReferenceID = source.ExternalReferenceId;
            target.SupplierName = source.Supplier.SupplierName;
            target.PurchaseOrderDate = source.TransactionDate.ToShortDateString();

            if (source.PurchaseLogs != null) {
                Hashtable categoryQty = new Hashtable();
                Hashtable categoryUnitType = new Hashtable();

                foreach (PurchaseLog purchaseLog in source.PurchaseLogs) {
                    // if this hashtable doesn't have an entry for the category name, we need to make a new entry and add this quantity as the first value for this category
                    if (!categoryQty.ContainsKey(purchaseLog.StockItemMaster.StockCategory.CategoryName)) {
                        categoryQty.Add(purchaseLog.StockItemMaster.StockCategory.CategoryName, purchaseLog.Quantity);
                    }
                    else {
                        categoryQty[purchaseLog.StockItemMaster.StockCategory.CategoryName] = (double)categoryQty[purchaseLog.StockItemMaster.StockCategory.CategoryName]
                                                                                                            + purchaseLog.Quantity;
                        if (!categoryUnitType.ContainsKey(purchaseLog.StockItemMaster.StockCategory.CategoryName)) {
                            categoryUnitType.Add(purchaseLog.StockItemMaster.StockCategory.CategoryName, purchaseLog.StockItemMaster.UnitType);
                        }
                    }
                }

                foreach (String categoryName in categoryQty.Keys) {
                    PurchaseOrderDetail_POCO pocoDetail = new PurchaseOrderDetail_POCO();
                    pocoDetail.Quantity = (double)categoryQty[categoryName];
                    pocoDetail.StockCategory = categoryName;
                    pocoDetail.UnitType = (string)categoryUnitType[categoryName];

                    if (target.PurchaseOrderDetailList == null) {
                        target.PurchaseOrderDetailList = new List<PurchaseOrderDetail_POCO>();
                    }
                    target.PurchaseOrderDetailList.Add(pocoDetail);
                }
            }
        }
        #endregion

        #region PurchaseOrder-Log
        public static void EF2Entity_PurchaseLog(PurchaseLog source, PurchaseLogEntity target) {
            StockItemMaster itemMaster = source.StockItemMaster;

            target.DesignNumber = source.StockItemMaster.DesignNumber;
            target.ID = source.PurchaseLogID;
            target.Quantity = source.Quantity;
            target.StockCategory = source.StockItemMaster.StockCategory.CategoryName;
            target.SubCode = source.StockItemMaster.SubCode;

            target.Dirty = false;
        }

        public static void Entity2EF_PurchaseLog(PurchaseLogEntity source, PurchaseLog target) {
            StockItemMaster stockItemMaster = AflStockDAO.GetInstance().GetStockItem(source.StockCategory, source.DesignNumber, source.SubCode);
            PurchaseOrder parentPOmaster = AflStockDAO.GetInstance().GetPurchaseOrder(source.ParentPurchaseOrderID);

            target.PurchaseOrder = parentPOmaster;
            target.PurchaseOrderID = parentPOmaster.PurchaseOrderID;
            target.Quantity = source.Quantity;
            target.StockItemID = stockItemMaster.StockItemID;
            target.StockItemMaster = stockItemMaster;
            target.CostLK = source.UnitCostLKR;
        }
        #endregion

        #region StockMasterItem
        public static void EF2POCO_StockMasterItem(StockItemMaster source, StockItemMaster_POCO target) {
            target.Cost = source.Cost_FinalUpdated;
            target.DesignNumber = source.DesignNumber;
            target.HasQuantityList = !source.Quantity_Mutable; // if quantity can be directly changed without manipulating the list of items, that means it doesn't have a quantity list
            target.StockCategory = source.StockCategory.CategoryName;
            target.SubCode = source.SubCode;
            target.Quantity = source.CurrentStock;
            target.UnitType = source.UnitType;

            // that means this item CAN have a list of stock-items attached to it
            if (!source.Quantity_Mutable) {
                target.HasQuantityList = true;
                double qty = 0;
                // only proceed if there are entries; This should NEVER fail if the Parent IF condition passed, oh well what the hell
                if (source.StockItemDetails != null && source.StockItemDetails.Count > 0) {
                    target.QuantityList = new List<double>();

                    foreach (StockItemDetail itemDetail in source.StockItemDetails) {
                        target.QuantityList.Add(itemDetail.Quantity);

                        qty += itemDetail.Quantity; // calculate the correct stock-quantity for the DTO-MasterStockItem using each individual item-detail
                    }
                }

                // this will ensure that during retrieval, we have an accurate recalculated stock-value for each detailed-quantity existing stock master item
                target.Quantity = qty;
            }
        }

        public static void EF2Entity_StockMasterItem(StockItemMaster source, StockItemMasterEntity target) {
            target.QuantityDetailedList = null; // this will be set correctly IF this item is capable of having a Detailed Quantity List
            target.CurrentStock = source.CurrentStock; // this will also be RECALCULATED correctly IF this item is capable of having a Detailed Quantity List
            target.Cost_FinalUpdated = source.Cost_FinalUpdated;
            target.Description = source.Description;
            target.DesignNumber = source.DesignNumber;
            target.ID = source.StockItemID;
            target.MarkedForDeletion = false;
            target.MinOrderLevel = source.MinOrderLevel;
            target.Mutable = source.Quantity_Mutable;
            target.SellingPrice_External = double.MinValue;
            target.SellingPrice_Internal = double.MinValue;
            target.StockCategory = source.StockCategory.CategoryName;
            target.SubCode = source.SubCode;
            target.TotalQuantityPurchased = source.TotalQtyPurchased;
            target.TotalQuantitySold = source.TotalQtySold;
            target.UnitType = source.UnitType;

            // that means this item CAN have a list of stock-items attached to it
            if (!source.Quantity_Mutable) {
                double qty = 0;
                // only proceed if there are entries; This should NEVER fail if the Parent IF condition passed, oh well what the hell
                if (source.StockItemDetails != null && source.StockItemDetails.Count > 0) {
                    target.QuantityDetailedList = new List<StockItemQuantityLogEntity>();

                    foreach (StockItemDetail itemDetail in source.StockItemDetails) {
                        StockItemQuantityLogEntity itemDetailEnt = new StockItemQuantityLogEntity();
                        EF2Entity_StockItemDetail(itemDetail, itemDetailEnt); // copy all the data from the Entity-Framework object to the DTO-Entity

                        target.QuantityDetailedList.Add(itemDetailEnt); // Add the DTO-StockItemDetail-Entity to the DTO-MasterStockItem's quantity detailed list

                        qty += itemDetail.Quantity; // calculate the correct stock-quantity for the DTO-MasterStockItem using each individual item-detail
                    }
                }

                // this will ensure that during retrieval, we have an accurate recalculated stock-value for each detailed-quantity existing stock master item
                target.CurrentStock = qty;
            }

            target.Dirty = false;
        }

        /*  QuantityDetailedList is being used to do the calculating of the Total Stock during Loading and Storing of a Master-Stock-Item
         * 
         * TODO: Implement code to handle the quantity changes during UPDATES to the Total-Quantity-Sold and Total-Quantity-Purchased fields in the data-store
         */
        public static void Entity2EF_StockMasterItem(StockItemMasterEntity source, StockItemMaster target) {
            AflStockDAO dao = AflStockDAO.GetInstance();
            StockCategoryEntity catEntity = dao.GetStockCategory(source.StockCategory);
            int catID = catEntity.ID;

            target.CategoryID = catID;
            target.Cost_FinalUpdated = source.Cost_FinalUpdated;
            target.Description = source.Description;
            target.DesignNumber = source.DesignNumber;
            target.MinOrderLevel = source.MinOrderLevel;
            target.Quantity_Mutable = source.Mutable;
            target.StockItemID = source.ID;
            target.SubCode = source.SubCode;
            target.TotalQtyPurchased = source.TotalQuantityPurchased;
            target.TotalQtySold = source.TotalQuantitySold;
            target.UnitType = source.UnitType;

            if (!source.Mutable) { // that means, this item should have a detailed-quantity-list

                // we must convert and attach every single DTO-StockItemDetailEntity to a Entity-Framework counterpart and attach it to the master
                double qty = 0;

                // This should Never be null OR 0, but just in case
                if (source.QuantityDetailedList != null && source.QuantityDetailedList.Count > 0) {

                    List<int> indexesToRemoveAt = new List<int>();

                    for (int i = 0; i < source.QuantityDetailedList.Count; i++) {
                        StockItemQuantityLogEntity itemDetailEnt = source.QuantityDetailedList[i];

                        if (dao.StockItemDetailExists(itemDetailEnt.ID)) {
                            StockItemDetail itemDetail = dao.GetStockItemDetail(itemDetailEnt.ID);

                            if (itemDetailEnt.MarkedForDeletion) { // this was an existing saved item and needs to be reduced from the quantity of the master-item

                                // ********************** WARNING --> THE NEXT LINE OF CODE ATTEMPTS TO UPDATE THE DATA-STORE BY DELETING AN OBJECT
                                dao.DeleteStockItemDetail(itemDetail);
                            }
                            else {
                                Entity2EF_StockItemDetail(itemDetailEnt, itemDetail, target);
                                qty += itemDetailEnt.Quantity;
                            }
                        }
                        else { // this a brand new Addition to this StockItemMaster Object --> YAY --> we need to persist this mother bitch
                            StockItemDetail newItemDetail = new StockItemDetail();
                            Entity2EF_StockItemDetail(itemDetailEnt, newItemDetail, target);
                            itemDetailEnt.ID = newItemDetail.StockItemDetailID; // not that it matters, this Entity object will be out of scope in the next line
                            qty += itemDetailEnt.Quantity;
                        }
                    }

                    // goes through the QuantityDetails list and removes anything that has been deleted above
                    foreach (int i in indexesToRemoveAt) {
                        source.QuantityDetailedList.RemoveAt(i);
                    }
                }
                target.CurrentStock = qty;
            }
            else {
                target.CurrentStock = source.CurrentStock;
            }
        }

        #endregion

        #region StockItemDetail

        public static void EF2Entity_StockItemDetail(StockItemDetail source, StockItemQuantityLogEntity target) {
            target.ID = source.StockItemDetailID;
            target.DesignNumber = source.StockItemMaster.DesignNumber;
            target.SubCode = source.StockItemMaster.SubCode;
            target.StockCategory = source.StockItemMaster.StockCategory.CategoryName;
            target.Quantity = source.Quantity;

            target.Dirty = false;
        }


        // no need to set the ID because this should be automatic via the Data Base's Identity column
        public static void Entity2EF_StockItemDetail(StockItemQuantityLogEntity source, StockItemDetail target, StockItemMaster parentItemMaster) {
            target.Quantity = source.Quantity;
            target.StockItemMaster = parentItemMaster;
            target.StockItemMasterID = parentItemMaster.StockItemID;

            target.StockItemMaster = parentItemMaster;
        }

        #endregion

        #region StockCategory

        public static void EF2Entity_StockCategory(StockCategory source, StockCategoryEntity target) {
            target.CategoryName = source.CategoryName;
            target.ID = source.CategoryID;
            target.Mutable = source.Quantity_Mutable == null ? false : (bool)source.Quantity_Mutable;

            target.Dirty = false;
        }

        public static void Entity2EF_StockCategory(StockCategoryEntity source, StockCategory target) {
            target.CategoryID = source.ID;
            target.CategoryName = source.CategoryName;

            target.Quantity_Mutable = source.Mutable;
        }
        #endregion

        #region UnitType
        public static void EF2Entity_UnitType(UnitType source, UnitTypeEntity target) {
            target.ID = int.MinValue; // we don't use ID's for unit types
            target.UnitType = source.UnitType1;

            target.Dirty = false;
        }
        #endregion
    }
}
