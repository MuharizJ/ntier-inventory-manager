delete from Customer
delete from PurchaseLog
delete from PurchaseOrder
delete from SalesLog
delete from SalesOrder
delete from StockItemDetail
delete from StockItemMaster
delete from StockCategory
delete from Supplier
delete from UnitType

DBCC CHECKIDENT (Customer, reseed, 0)
DBCC CHECKIDENT (PurchaseLog, reseed, 0)
DBCC CHECKIDENT (PurchaseOrder, reseed, 0)
DBCC CHECKIDENT (SalesLog, reseed, 0)
DBCC CHECKIDENT (SalesOrder, reseed, 0)
DBCC CHECKIDENT (StockItemDetail, reseed, 0)
DBCC CHECKIDENT (StockItemMaster, reseed, 0)
DBCC CHECKIDENT (StockCategory, reseed, 0)
DBCC CHECKIDENT (Supplier, reseed, 0)
DBCC CHECKIDENT (UnitType, reseed, 0)


 