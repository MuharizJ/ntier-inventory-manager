update  StockItemMaster
set Quantity_Mutable = (select Quantity_Mutable 
						from StockCategory 
						where StockCategory.CategoryID = StockItemMaster.CategoryID)
where StockItemMaster.CategoryID = 22
