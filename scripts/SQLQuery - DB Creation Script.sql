SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

USE [AFL_Stock]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StockCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[Quantity_Mutable] [bit] NULL,
 CONSTRAINT [PK_StockCategory_1] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Supplier]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Supplier](
	[SupplerID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](50) NOT NULL,
	[RunningDebt] [float] NULL CONSTRAINT [DF_Supplier_RunningDebt]  DEFAULT ((0)),
 CONSTRAINT [PK_Supplier_1] PRIMARY KEY CLUSTERED 
(
	[SupplerID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer_1] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UnitType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UnitType](
	[UnitType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UnitType] PRIMARY KEY CLUSTERED 
(
	[UnitType] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockItemMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StockItemMaster](
	[StockItemID] [int] IDENTITY(1,1) NOT NULL,
	[DesignNumber] [nvarchar](50) NOT NULL,
	[SubCode] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[CurrentStock] [float] NOT NULL,
	[UnitType] [nvarchar](50) NOT NULL,
	[MinOrderLevel] [float] NOT NULL,
	[Cost_FinalUpdated] [float] NOT NULL,
	[Description] [nvarchar](50) NULL,
	[TotalQtySold] [float] NOT NULL CONSTRAINT [DF_StockItemMaster_TotalSold]  DEFAULT ((0)),
	[TotalQtyPurchased] [float] NOT NULL,
	[Quantity_Mutable] [bit] NOT NULL CONSTRAINT [DF_StockItemMaster_Quantity_Mutable]  DEFAULT ((0)),
 CONSTRAINT [PK_StockItem_1] PRIMARY KEY CLUSTERED 
(
	[StockItemID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseOrder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PurchaseOrder](
	[PurchaseOrderID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[ExternalReferenceId] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_TransactionPurchase] PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesLog](
	[SalesLogID] [int] NOT NULL,
	[SalesOrderID] [int] NOT NULL,
	[StockItemID] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[SalePrice] [float] NULL,
 CONSTRAINT [PK_SalesLog] PRIMARY KEY CLUSTERED 
(
	[SalesLogID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PurchaseLog](
	[PurchaseLogID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderID] [int] NOT NULL,
	[StockItemID] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[CostCN] [float] NULL,
	[CostLK] [float] NULL,
 CONSTRAINT [PK_PurchaseLog] PRIMARY KEY CLUSTERED 
(
	[PurchaseLogID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesOrder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesOrder](
	[SalesOrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[ExternalReferenceId] [nvarchar](50) NULL,
	[SaleDetails] [nvarchar](50) NULL,
	[Fulfilled] [bit] NOT NULL CONSTRAINT [DF_SalesOrder_Fulfilled]  DEFAULT ((0)),
 CONSTRAINT [PK_TransactionSale] PRIMARY KEY CLUSTERED 
(
	[SalesOrderID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockItemDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StockItemDetail](
	[StockItemDetailID] [int] IDENTITY(1,1) NOT NULL,
	[StockItemMasterID] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
 CONSTRAINT [PK_StockItemDetail] PRIMARY KEY CLUSTERED 
(
	[StockItemDetailID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StockItemMaster_StockCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[StockItemMaster]'))
ALTER TABLE [dbo].[StockItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_StockItemMaster_StockCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[StockCategory] ([CategoryID])
GO
ALTER TABLE [dbo].[StockItemMaster] CHECK CONSTRAINT [FK_StockItemMaster_StockCategory]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StockItemMaster_UnitType]') AND parent_object_id = OBJECT_ID(N'[dbo].[StockItemMaster]'))
ALTER TABLE [dbo].[StockItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_StockItemMaster_UnitType] FOREIGN KEY([UnitType])
REFERENCES [dbo].[UnitType] ([UnitType])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StockItemMaster] CHECK CONSTRAINT [FK_StockItemMaster_UnitType]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseOrder_Supplier]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseOrder]'))
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([SupplerID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Supplier]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesLog_SalesOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesLog]'))
ALTER TABLE [dbo].[SalesLog]  WITH CHECK ADD  CONSTRAINT [FK_SalesLog_SalesOrder] FOREIGN KEY([SalesOrderID])
REFERENCES [dbo].[SalesOrder] ([SalesOrderID])
GO
ALTER TABLE [dbo].[SalesLog] CHECK CONSTRAINT [FK_SalesLog_SalesOrder]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesLog_StockItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesLog]'))
ALTER TABLE [dbo].[SalesLog]  WITH CHECK ADD  CONSTRAINT [FK_SalesLog_StockItemMaster] FOREIGN KEY([StockItemID])
REFERENCES [dbo].[StockItemMaster] ([StockItemID])
GO
ALTER TABLE [dbo].[SalesLog] CHECK CONSTRAINT [FK_SalesLog_StockItemMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseLog_PurchaseOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseLog]'))
ALTER TABLE [dbo].[PurchaseLog]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseLog_PurchaseOrder] FOREIGN KEY([PurchaseOrderID])
REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseLog] CHECK CONSTRAINT [FK_PurchaseLog_PurchaseOrder]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseLog_StockItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseLog]'))
ALTER TABLE [dbo].[PurchaseLog]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseLog_StockItemMaster] FOREIGN KEY([StockItemID])
REFERENCES [dbo].[StockItemMaster] ([StockItemID])
GO
ALTER TABLE [dbo].[PurchaseLog] CHECK CONSTRAINT [FK_PurchaseLog_StockItemMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesOrder_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesOrder]'))
ALTER TABLE [dbo].[SalesOrder]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrder_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[SalesOrder] CHECK CONSTRAINT [FK_SalesOrder_Customer]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StockItemDetail_StockItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[StockItemDetail]'))
ALTER TABLE [dbo].[StockItemDetail]  WITH CHECK ADD  CONSTRAINT [FK_StockItemDetail_StockItemMaster] FOREIGN KEY([StockItemMasterID])
REFERENCES [dbo].[StockItemMaster] ([StockItemID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StockItemDetail] CHECK CONSTRAINT [FK_StockItemDetail_StockItemMaster]
