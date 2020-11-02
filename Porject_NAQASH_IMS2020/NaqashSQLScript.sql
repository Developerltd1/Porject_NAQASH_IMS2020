USE [master]
GO
/****** Object:  Database [NAQ_DB2020]    Script Date: 22/10/2020 10:34:49 AM ******/
CREATE DATABASE [NAQ_DB2020]
GO
ALTER DATABASE [NAQ_DB2020] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET ARITHABORT OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [NAQ_DB2020] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NAQ_DB2020] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NAQ_DB2020] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NAQ_DB2020] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NAQ_DB2020] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NAQ_DB2020] SET  MULTI_USER 
GO
ALTER DATABASE [NAQ_DB2020] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NAQ_DB2020] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NAQ_DB2020] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NAQ_DB2020] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [NAQ_DB2020] SET DELAYED_DURABILITY = DISABLED 
GO

USE [NAQ_DB2020]
GO


/****** Object:  User [Aqib]    Script Date: 22/10/2020 10:34:49 AM ******/
CREATE USER [Aqib] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Aqib]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Aqib]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Aqib]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 22/10/2020 10:34:50 AM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[CustomerContact] [varchar](50) NOT NULL,
	[CustomerDetails] [varchar](50) NOT NULL,
	[CreatedByUser_ID] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblExpenses]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblExpenses](
	[ExpensesID] [int] IDENTITY(1,1) NOT NULL,
	[ExpensesTitle] [varchar](50) NOT NULL,
	[ExpensesType] [varchar](250) NOT NULL,
	[ExpensesDetails] [varchar](500) NOT NULL,
	[CreatedByUser_ID] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[ActivityDate] [datetime] NOT NULL,
	[Amount] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_tblExpenses] PRIMARY KEY CLUSTERED 
(
	[ExpensesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblForm]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblForm](
	[FormID] [int] IDENTITY(1,1) NOT NULL,
	[FormActualName] [varchar](50) NOT NULL,
	[FormDisplayName] [varchar](50) NOT NULL,
	[FormDetails] [varchar](150) NOT NULL,
	[CreatedByUser_ID] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tblForm] PRIMARY KEY CLUSTERED 
(
	[FormID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblFormRolePermission]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFormRolePermission](
	[RolePermissionID] [int] IDENTITY(1,1) NOT NULL,
	[Role_ID] [int] NOT NULL,
	[Form_ID] [int] NOT NULL,
 CONSTRAINT [PK_tblRolePermission] PRIMARY KEY CLUSTERED 
(
	[RolePermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProduct](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[BarCode] [varchar](50) NOT NULL,
	[Category_ID] [int] NOT NULL,
	[ProductType] [varchar](50) NOT NULL,
	[ProductBrand] [varchar](50) NOT NULL,
	[ProductSize] [varchar](20) NOT NULL,
	[ProductColor] [varchar](20) NOT NULL,
	[ProductPicture] [varchar](max) NOT NULL,
	[CreatedByUser_ID] [int] NOT NULL,
	[ProductDetails] [varchar](350) NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[BarCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_tblProduct_Barcode] UNIQUE NONCLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPurchase]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPurchase](
	[PurchaseID] [int] IDENTITY(1,1) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[ActualPrice] [int] NOT NULL,
	[PurchaseQty] [int] NOT NULL,
	[PurchaseTotal] [int] NOT NULL,
	[Supplier_ID] [int] NOT NULL,
	[Product_ID] [int] NOT NULL,
	[CreatedByUser_ID] [int] NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tblStock] PRIMARY KEY CLUSTERED 
(
	[PurchaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblRoles]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRoles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[RoleDetails] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblRoles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSalesOrder]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSalesOrder](
	[SalesOrderID] [int] IDENTITY(1,1) NOT NULL,
	[SalesCustomer_ID] [int] NOT NULL,
	[SalesProduct_ID] [int] NOT NULL,
	[SalesPicture_ID] [int] NOT NULL,
	[SalesOrderCurrentDate] [datetime] NOT NULL,
	[SalesOrderDueDate] [datetime] NOT NULL,
	[SalesOrderInvoiceNo] [varchar](50) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[CreatedByUser_ID] [int] NOT NULL,
	[TotalBill] [decimal](18, 0) NOT NULL,
	[Advance] [decimal](18, 0) NOT NULL,
	[Balance] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_tblSalesOrder] PRIMARY KEY CLUSTERED 
(
	[SalesOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_tblSalesOrder] UNIQUE NONCLUSTERED 
(
	[SalesOrderInvoiceNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSalesPicture]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSalesPicture](
	[SalesPictureID] [int] IDENTITY(1,1) NOT NULL,
	[SalesPictureNo] [varchar](50) NOT NULL,
	[SalesPictureImage] [varchar](max) NULL,
	[SalesPictureUnitPrice] [int] NOT NULL,
	[PictureQty] [int] NULL,
	[SalesPictureTotal] [int] NOT NULL,
	[CreatedByUser_ID] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[SalesOrder_ID] [int] NOT NULL,
	[isStudio] [varchar](50) NOT NULL,
	[PicCategory] [varchar](50) NULL,
	[PicType] [varchar](50) NULL,
	[PicBrand] [varchar](50) NULL,
	[PicSize] [varchar](50) NULL,
 CONSTRAINT [PK_tblSalesPicture] PRIMARY KEY CLUSTERED 
(
	[SalesPictureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSalesProduct]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSalesProduct](
	[SalesProductID] [int] IDENTITY(1,1) NOT NULL,
	[SalesProductUnitPrice] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[SalesProductTotal] [int] NOT NULL,
	[CreatedByUser_ID] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[Product_ID] [int] NOT NULL,
	[SalesOrder_ID] [int] NOT NULL,
 CONSTRAINT [PK_tblSales] PRIMARY KEY CLUSTERED 
(
	[SalesProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblStock]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblStock](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[Product_ID] [int] NOT NULL,
	[Barcode] [varchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
	[ConsumeQty] [int] NOT NULL,
	[UnitPrice] [int] NOT NULL,
	[CreatedByUser_ID] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[Purchase_Id] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_tblStock_1] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSupplier]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSupplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [varchar](99) NOT NULL,
	[SupplierPhoneNo] [varchar](12) NULL,
	[SupplierMobileNo] [varchar](12) NOT NULL,
	[SupplierAddress] [varchar](150) NULL,
	[SupplierPicture] [varchar](max) NOT NULL,
 CONSTRAINT [PK_tblSupplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserPassword] [varchar](50) NOT NULL,
	[UserDesignation] [varchar](50) NOT NULL,
	[UserPicture] [varchar](max) NULL,
	[EntryDate] [datetime] NOT NULL,
	[CreatedByUser_ID] [int] NOT NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserRoles]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserRoles](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Role_ID] [int] NOT NULL,
 CONSTRAINT [PK_tblUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblCategory] ADD  CONSTRAINT [DF_tblCategory_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[tblCustomer] ADD  CONSTRAINT [DF_tblCustomer_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[tblExpenses] ADD  CONSTRAINT [DF_tblExpenses_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[tblExpenses] ADD  CONSTRAINT [DF_tblExpenses_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tblExpenses] ADD  CONSTRAINT [DF_tblExpenses_isDelete]  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[tblForm] ADD  CONSTRAINT [DF_tblForm_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[tblPurchase] ADD  CONSTRAINT [DF_tblStock_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[tblSalesOrder] ADD  CONSTRAINT [DF_tblSalesOrder_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[tblSalesPicture] ADD  CONSTRAINT [DF_tblSalesPicture_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[tblSalesPicture] ADD  CONSTRAINT [DF_tblSalesPicture_isStudio]  DEFAULT ((1)) FOR [isStudio]
GO
ALTER TABLE [dbo].[tblSalesProduct] ADD  CONSTRAINT [DF_tblSales_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[tblStock] ADD  CONSTRAINT [DF_tblStock_EntryDate_1]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[tblStock] ADD  CONSTRAINT [DF_tblStock_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
/****** Object:  StoredProcedure [dbo].[_UpdateSupplier]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[_UpdateSupplier]
( 
	@SupplierID INT,
	@SupplierName VARCHAR(99),
	@SupplierPhoneNo VARCHAR(12),
	@SupplierMobileNo VARCHAR(12),
	@SupplierAddress VARCHAR(150),
	@SupplierPicture VARCHAR(MAX),
	@_Status BIT OUTPUT,
	@_StatusDetails VARCHAR(100) OUTPUT
)
AS
BEGIN 

BEGIN TRY 

	Update tblSupplier SET SupplierName=@SupplierName,SupplierPhoneNo=@SupplierPhoneNo,SupplierMobileNo=@SupplierMobileNo,SupplierAddress=@SupplierAddress,SupplierPicture=@SupplierPicture
	WHERE SupplierID=@SupplierID
 
	SET @_Status = 1
	SET @_StatusDetails = 'DONE'
END TRY
BEGIN CATCH 
	SET @_Status = 0
	SET @_StatusDetails = ERROR_MESSAGE()
END CATCH
END
-----------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[CRUDExpenses]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CRUDExpenses]
( 
	@CreatedByUser_ID INT,
	@ActivityDate datetime,
	@Amount INT,
	@ExpensesTitle VARCHAR(50),
	@ExpensesType VARCHAR(250),
	@ExpensesDetails VARCHAR(500),
	@_Status BIT OUTPUT,
	@_StatusDetails VARCHAR(100) OUTPUT
)
AS
BEGIN 

BEGIN TRY 

	INSERT INTO tblExpenses
	(CreatedByUser_ID,ExpensesTitle,ExpensesType,ExpensesDetails,ActivityDate,Amount) 
	VALUES 
	(@CreatedByUser_ID,@ExpensesTitle,@ExpensesType,@ExpensesDetails,@ActivityDate,@Amount)
 
	SET @_Status = 1
	SET @_StatusDetails = 'DONE'
END TRY
BEGIN CATCH 
	SET @_Status = 0
	SET @_StatusDetails = ERROR_MESSAGE()
END CATCH
END
-----------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[Expenses_DeleteMeansIsActive]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Expenses_DeleteMeansIsActive]
( 
	@ExpensesID INT,
	@_Status BIT OUTPUT,
	@_StatusDetails VARCHAR(100) OUTPUT
)
AS
BEGIN 

BEGIN TRY 

	Update tblExpenses SET isActive=0
	WHERE ExpensesID=@ExpensesID
 
	SET @_Status = 1
	SET @_StatusDetails = 'DONE'
END TRY
BEGIN CATCH 
	SET @_Status = 0
	SET @_StatusDetails = ERROR_MESSAGE()
END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[Expenses_UpdateByID]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Expenses_UpdateByID]
( 
	@ExpensesID INT,
	@Amount INT,
	@ActivityDate DATETIME,
	@ExpensesTitle VARCHAR(50),
	@ExpensesType VARCHAR(250),
	@ExpensesDetails VARCHAR(500),
	@_Status BIT OUTPUT,
	@_StatusDetails VARCHAR(100) OUTPUT
)
AS
BEGIN 

BEGIN TRY 

	Update tblExpenses SET Amount=@Amount,ActivityDate=@ActivityDate,ExpensesTitle=@ExpensesTitle,ExpensesType=@ExpensesType,ExpensesDetails=@ExpensesDetails
	WHERE ExpensesID=@ExpensesID
 
	SET @_Status = 1
	SET @_StatusDetails = 'DONE'
END TRY
BEGIN CATCH 
	SET @_Status = 0
	SET @_StatusDetails = ERROR_MESSAGE()
END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[getAllFromExpenses]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getAllFromExpenses]
( 
	@_Status BIT OUTPUT,
	@_StatusDetails VARCHAR(100) OUTPUT
)
AS
BEGIN 

BEGIN TRY 
--format(ActivityDate, '	') as 'Date2',
    SELECT ExpensesID,CONVERT (varchar(10), ActivityDate, 103)  as 'Date',LTRIM(RIGHT(CONVERT(VARCHAR(20), ActivityDate, 100), 7)) as 'Time',ExpensesTitle,ExpensesType,ExpensesDetails,Amount  
	FROM tblExpenses
 WHERE isActive = 1
	SET @_Status = 1
	SET @_StatusDetails = 'DONE'
END TRY
BEGIN CATCH 
	SET @_Status = 0
	SET @_StatusDetails = ERROR_MESSAGE()
END CATCH
END
-----------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[tblExpenses_Create]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblExpenses_Create]
( 
	@CreatedByUser_ID INT,
	@EntryDate DATETIME,
	@ExpensesTitle VARCHAR(50),
	@ExpensesType VARCHAR(250),
	@ExpensesDetails VARCHAR(500),
	@_Status BIT OUTPUT,
	@_StatusDetails VARCHAR(100) OUTPUT
)
AS
BEGIN 

BEGIN TRY 

	INSERT INTO tblExpenses
	(CreatedByUser_ID,EntryDate,ExpensesTitle,ExpensesType,ExpensesDetails) 
	VALUES 
	(@CreatedByUser_ID,@EntryDate,@ExpensesTitle,@ExpensesType,@ExpensesDetails)
 
	SET @_Status = 1
	SET @_StatusDetails = 'DONE'
END TRY
BEGIN CATCH 
	SET @_Status = 0
	SET @_StatusDetails = ERROR_MESSAGE()
END CATCH
END
-----------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[tblExpenses_SelectAll]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblExpenses_SelectAll]
( 
	@_Status BIT OUTPUT,
	@_StatusDetails VARCHAR(100) OUTPUT
)
AS
BEGIN 

BEGIN TRY 

	SELECT ExpensesID,CreatedByUser_ID,Amount,EntryDate,ActivityDate,isActive,isDelete,ExpensesTitle,ExpensesType,ExpensesDetails 
	FROM tblExpenses
 
	SET @_Status = 1
	SET @_StatusDetails = 'DONE'
END TRY
BEGIN CATCH 
	SET @_Status = 0
	SET @_StatusDetails = ERROR_MESSAGE()
END CATCH
END
-----------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[UpdateSalesOrder]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateSalesOrder]
( 
	@SalesOrderID INT,
	@SalesOrderCurrentDate DATETIME,
	@SalesOrderDueDate DATETIME,
	@TotalBill DECIMAL,
	@Advance DECIMAL,
	@Balance DECIMAL,
	@SalesOrderInvoiceNo VARCHAR(50),
	@_Status BIT OUTPUT,
	@_StatusDetails VARCHAR(100) OUTPUT
)
AS
BEGIN 

BEGIN TRY 

	Update tblSalesOrder SET SalesOrderCurrentDate=@SalesOrderCurrentDate,SalesOrderDueDate=@SalesOrderDueDate,
	TotalBill=@TotalBill,Advance=@Advance,Balance=@Balance,SalesOrderInvoiceNo=@SalesOrderInvoiceNo
	WHERE SalesOrderID=@SalesOrderID
 
	SET @_Status = 1
	SET @_StatusDetails = 'DONE'
END TRY
BEGIN CATCH 
	SET @_Status = 0
	SET @_StatusDetails = ERROR_MESSAGE()
END CATCH
END
-----------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[usp_BarcodeReport]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_BarcodeReport]
(
  @Barcode VARCHAR(50),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
	    
		IF( @Barcode = 'All' OR @Barcode = 'all' OR @Barcode = 'ALL' )
		BEGIN
		  Select p.Barcode,c.CategoryName,p.ProductType,p.ProductBrand,p.ProductSize,p.ProductColor,p.ProductPicture,'' as 'pDate'--,convert(varchar, pr.PurchaseDate, 100) as 'PurchaseDate'  
		  from tblProduct p
		  Inner Join tblCategory c On  c.CategoryID = p.Category_ID
		  --Inner Join tblPurchase pr On  pr.Product_ID = p.ProductID
		END
		ELSE
		BEGIN
		  Select p.Barcode,c.CategoryName,p.ProductType,p.ProductBrand,p.ProductSize,p.ProductColor,p.ProductPicture,'' as 'pDate'--,convert(varchar, pr.PurchaseDate, 100) as 'PurchaseDate' , 
		  from tblProduct p
		  Inner Join tblCategory c On  c.CategoryID = p.Category_ID
		 -- Inner Join tblPurchase pr On  pr.Product_ID = p.ProductID
		  Where p.BarCode = @Barcode --'1t1b146e'  --
		END

		 SET @Status = 1
		  SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_CheckAvalibleStock]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_CheckAvalibleStock]
(
	@ConsumeQty Int,
	@Product_id Int,
	@Status bit OUTPUT,
	@StatusDetails Varchar(50) OUTPUT
)
As 
Begin

	Declare @DatabaseTotalStock Varchar(50)
	Set @DatabaseTotalStock = (Select sum(s.Qty - s.ConsumeQty) From tblStock s Where Product_ID = @Product_id )

if @ConsumeQty > @DatabaseTotalStock
Begin
    Set @Status=1
	Set @StatusDetails= 'You Have Only '+ @DatabaseTotalStock + ' Qty Available.'
	Return;

End
Else
Begin
	Set @Status=0
	Return;
End

end


GO
/****** Object:  StoredProcedure [dbo].[usp_CheckInvoiceNoIfExists]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_CheckInvoiceNoIfExists]
(@SalesOrderInvoiceNo INT,
 @Status BIT OUTPUT,
 @StatusDetails VARCHAR(200) OUTPUT)
as
BEGIN
BEGIN TRY
	IF NOT EXISTS (Select SalesOrderInvoiceNo from tblSalesOrder Where SalesOrderInvoiceNo = @SalesOrderInvoiceNo)
		BEGIN
			SET @Status = 1
			SET @StatusDetails = 'OK'
		END
	ELSE
		BEGIN
			SET @Status = 0
			SET @StatusDetails = @SalesOrderInvoiceNo +':  Already Exists !'
		END
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_CheckInvoiceNumberStep1]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_CheckInvoiceNumberStep1]
(
  @InvoiceNo Varchar(50),
  @Status bit OUTPUT,
  @StatusDetails Varchar(50) OUTPUT
)
As 
Begin
 BEGIN TRY
	
   	SELECT so.SalesOrderID, c.CustomerID,c.CustomerName,c.CustomerContact,c.CustomerDetails,
   	so.Advance,so.Balance,so.TotalBill,
	so.SalesOrderCurrentDate,so.SalesOrderDueDate
    from tblSalesOrder so
   	INNER JOIN tblCustomer c ON c.CustomerID =  so.SalesCustomer_ID
   	WHERE so.SalesOrderInvoiceNo = @InvoiceNo
   
     Set @Status=1
   	Set @StatusDetails= 'SUCCESS'
   	Return;
 END TRY
 BEGIN CATCH
 	SET @Status = 0
 	SET @StatusDetails = ERROR_MESSAGE() 
 END CATCH

End


GO
/****** Object:  StoredProcedure [dbo].[usp_CheckInvoiceNumberStep2]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_CheckInvoiceNumberStep2]
(
  @SalesOrder_ID INT,
  @Status bit OUTPUT,
  @StatusDetails Varchar(50) OUTPUT
)
As 
Begin
 BEGIN TRY
	
   	SELECT sp.SalesProductID as 'ID',sp.SalesProductUnitPrice as 'UnitPrice',sp.Qty as 'Qty',sp.SalesProductTotal as 'UnitTotalPrice',
	p.BarCode as 'BarCode',c.CategoryName as 'Category',
	p.ProductType as 'Type',p.ProductBrand as 'Brand',p.ProductSize as 'Size',p.ProductColor as 'Color'
    from tblSalesProduct sp
   	INNER JOIN tblProduct p ON p.ProductID =  sp.Product_ID
	INNER JOIN tblCategory c ON c.CategoryID =  p.Category_ID
   	WHERE sp.SalesOrder_ID = @SalesOrder_ID

	UNION

	SELECT pp.SalesPictureID as 'ID',pp.SalesPictureUnitPrice as 'UnitPrice',pp.PictureQty as 'Qty',pp.SalesPictureTotal as 'UnitTotalPrice',
	'BarCode',pp.PicCategory as 'Category',
	pp.PicType as 'Type',pp.PicBrand as 'Brand',pp.PicSize as 'Size','Color'
    from tblSalesPicture pp
   	WHERE pp.SalesOrder_ID = @SalesOrder_ID
   
    Set @Status=1
   	Set @StatusDetails= 'SUCCESS'
   	Return;
 END TRY
 BEGIN CATCH
 	SET @Status = 0
 	SET @StatusDetails = ERROR_MESSAGE() 
 END CATCH

End


GO
/****** Object:  StoredProcedure [dbo].[usp_CRUDCategory]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_CRUDCategory]
(
  @Action VARCHAR(20),
  @CategoryName VARCHAR(100),
  @CategoryID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
 IF @Action = 'spINSERT'
BEGIN  
      INSERT INTO tblCategory (CategoryName)VALUES(@CategoryName)
	  SET @Status = 1
	  SET @StatusDetails = 'Record Save Successfully'
END
IF @Action = 'spUPDATE'  
BEGIN  
      UPDATE tblCategory SET CategoryName=@CategoryName
	  WHERE CategoryID=@CategoryID  
	  SET @Status = 1
	  SET @StatusDetails = 'Record Update Successfully'
END    
IF @Action = 'spDELETE'  
BEGIN  
        DELETE tblCategory WHERE CategoryID=@CategoryID  
		SET @Status = 1
		SET @StatusDetails = 'Record Delete Successfully'

END
IF @Action = 'spSELECT'  
BEGIN  
        SELECT CategoryID ,CategoryName  FROM tblCategory  ORDER BY CategoryName ASC
		SET @Status = 1
		SET @StatusDetails = 'All Record Get'
END 
IF @Action = 'spSELECTbyID' 
BEGIN 
        SELECT CategoryID ,CategoryName  FROM tblCategory 
        WHERE CategoryID=@CategoryID  
		SET @Status = 1
		SET @StatusDetails = 'Singal Record Get'

END     
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



--BEGIN


-- IF @Action = 'spINSERT'
--BEGIN  
--BEGIN TRY
--      INSERT INTO tblCategory (CategoryName)VALUES(@CategoryName)
--	  SET @Status = 1
--	  SET @StatusDetails = 'Record Save Successfully'
--END TRY
--BEGIN CATCH
--	SET @Status = 0
--	SET @StatusDetails = ERROR_MESSAGE() 
--END CATCH
--END
--IF @Action = 'spUPDATE'  
--BEGIN  
--BEGIN TRY
--      UPDATE tblCategory SET CategoryName=@CategoryName
--	  WHERE CategoryID=@CategoryID  
--	  SET @Status = 1
--	  SET @StatusDetails = 'Record Update Successfully'
--END TRY
--BEGIN CATCH
--	SET @Status = 0
--	SET @StatusDetails = ERROR_MESSAGE() 
--END CATCH
--END    
--IF @Action = 'spDELETE'  
--BEGIN  
--BEGIN TRY
--        DELETE tblCategory WHERE CategoryID=@CategoryID  
--		SET @Status = 1
--		SET @StatusDetails = 'Record Delete Successfully'
--		END TRY
--BEGIN CATCH
--	SET @Status = 0
--	SET @StatusDetails = ERROR_MESSAGE() 
--END CATCH
--END
--IF @Action = 'spSELECT'  
--BEGIN  
--BEGIN TRY
--        SELECT CategoryID ,CategoryName  FROM tblCategory  ORDER BY CategoryName ASC
--		SET @Status = 1
--		SET @StatusDetails = 'All Record Get'
--END TRY
--BEGIN CATCH
--	SET @Status = 0
--	SET @StatusDetails = ERROR_MESSAGE() 
--END CATCH
--END 
    
--IF @Action = 'spSELECTbyID'  
--BEGIN  
--BEGIN TRY
--        SELECT CategoryID ,CategoryName  FROM tblCategory 
--        WHERE CategoryID=@CategoryID  
--		SET @Status = 1
--		SET @StatusDetails = 'Singal Record Get'
--		END TRY
--BEGIN CATCH
--	SET @Status = 0
--	SET @StatusDetails = ERROR_MESSAGE() 
--END CATCH
--END     

--END







GO
/****** Object:  StoredProcedure [dbo].[usp_CRUDProduct]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[usp_CRUDProduct]
(
  @ProductID INT,
  @ProductType VARCHAR(100),
  @ProductBrand VARCHAR(100),
  @ProductSize VARCHAR(100),
  @ProductColor VARCHAR(100),
  @ProductPicture VARCHAR(MAX),
  @BarCode VARCHAR(50),
  @Category_ID INT,
  @CreatedByUser_ID INT,
  @Action VARCHAR(100),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
 IF @Action = 'spINSERT'
BEGIN  
      INSERT INTO tblProduct(ProductType,ProductBrand,ProductSize,ProductColor,ProductPicture,BarCode,Category_ID,CreatedByUser_ID)
			    VALUES(@ProductType,@ProductBrand,@ProductSize,@ProductColor,@ProductPicture,@BarCode,@Category_ID,@CreatedByUser_ID)
	  SET @Status = 1
	  SET @StatusDetails = 'Record Save Successfully'
END
IF @Action = 'spUPDATE'  
BEGIN  
      UPDATE tblProduct SET ProductType=@ProductType,ProductBrand=@ProductBrand,ProductSize=@ProductSize,CreatedByUser_ID =@CreatedByUser_ID,
	  BarCode=@BarCode, ProductColor=@ProductColor,ProductPicture=@ProductPicture,Category_ID=@Category_ID
	  WHERE ProductID=@ProductID  
	  SET @Status = 1
	  SET @StatusDetails = 'Record Update Successfully'
END    
IF @Action = 'spDELETE'  
BEGIN  
        DELETE tblProduct WHERE ProductID=@ProductID  
		SET @Status = 1
		SET @StatusDetails = 'Record Delete Successfully'
END
IF @Action = 'spSELECT'  
BEGIN  
        SELECT  p.ProductID,CategoryName,p.ProductType,p.ProductBrand,p.ProductSize,p.ProductColor,p.BarCode  FROM tblProduct as p  
		INNER JOIN tblCategory ON CategoryID = p.Category_ID
		ORDER BY ProductType ASC
		SET @Status = 1
		SET @StatusDetails = 'All Record Get'
END 
IF @Action = 'spSELECTbyID' 
BEGIN 
       SELECT  CategoryName,p.ProductType,p.ProductBrand,p.ProductSize,p.ProductColor  FROM tblProduct as p  
		INNER JOIN tblCategory ON CategoryID = p.Category_ID
        WHERE ProductID=@ProductID 
		ORDER BY ProductType ASC 
		SET @Status = 1
		SET @StatusDetails = 'Singal Record Get'

END     
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_CRUDSupplier]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CRUDSupplier]
(
  @SupplierID INT,
  @SupplierName VARCHAR(99),
  @SupplierPhoneNo VARCHAR(12),
  @SupplierMobileNo VARCHAR(12),
  @SupplierAddress varchar(150),
  @SupplierPicture varchar(MAX),
  @Action VARCHAR(20),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
 IF @Action = 'spINSERT'
BEGIN  
      INSERT INTO tblSupplier(SupplierName,SupplierPhoneNo,SupplierMobileNo,SupplierAddress,SupplierPicture)
	  VALUES(@SupplierName,@SupplierPhoneNo,@SupplierMobileNo,@SupplierAddress,@SupplierPicture)
	  SET @Status = 1
	  SET @StatusDetails = 'Record Save Successfully'
END
IF @Action = 'spUPDATE'  
BEGIN  
      UPDATE tblSupplier SET SupplierName=@SupplierName
							,SupplierPhoneNo = @SupplierPhoneNo
							,SupplierMobileNo = @SupplierMobileNo
							,SupplierAddress = @SupplierAddress
							,SupplierPicture =@SupplierPicture
	  WHERE SupplierID=@SupplierID  
	  SET @Status = 1
	  SET @StatusDetails = 'Record Update Successfully'
END    
IF @Action = 'spDELETE'  
BEGIN  
        DELETE tblSupplier WHERE SupplierID=@SupplierID  
		SET @Status = 1
		SET @StatusDetails = 'Record Delete Successfully'

END
IF @Action = 'spSELECTbyID' 
BEGIN 
        SELECT SupplierName,SupplierPhoneNo,SupplierMobileNo,SupplierAddress,SupplierPicture  FROM tblSupplier 
        WHERE SupplierID=@SupplierID  
		SET @Status = 1
		SET @StatusDetails = 'Singal Record Get'

END     
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_CRUDUser]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CRUDUser]
(
  @UserID INT,
  @UserName VARCHAR(99),
  @UserPassword VARCHAR(12),
  @UserDesignation VARCHAR(12),
  @CreatedByUser_ID INT,
  @UserPicture varchar(MAX),

  @Role_ID INT,

  @Action VARCHAR(20),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
 IF @Action = 'spINSERT'
BEGIN  
      INSERT INTO tblUser(UserName,UserPassword,UserDesignation,CreatedByUser_ID,UserPicture)
				VALUES(@UserName,@UserPassword,@UserDesignation,@CreatedByUser_ID,@UserPicture)

		DECLARE @User_ID INT
	    SET @User_ID = SCOPE_IDENTITY()

		INSERT INTO tblUserRoles([User_ID],Role_ID)
				VALUES(@User_ID,@Role_ID)

	  SET @Status = 1
	  SET @StatusDetails = 'Record Save Successfully'
END
IF @Action = 'spUPDATE'  
BEGIN  
      UPDATE tblUser SET UserName=@UserName
							,UserPassword = @UserPassword
							,UserDesignation = @UserDesignation
							,UserPicture = @UserPicture
	  WHERE UserID=@UserID  
	  UPDATE tblUserRoles SET Role_ID=@Role_ID
	  WHERE [User_ID]=@UserID  
	  
	  SET @Status = 1
	  SET @StatusDetails = 'Record Update Successfully'
END    
IF @Action = 'spDELETE'  
BEGIN  
        DELETE tblUser WHERE UserID=@UserID
		DELETE tblUserRoles WHERE [User_ID]=@UserID
		SET @Status = 1
		SET @StatusDetails = 'Record Delete Successfully'

END
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_DailyReport]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DailyReport]
(
  @Barcode VARCHAR(50),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
		SELECT so.SalesOrderInvoiceNo,so.SalesOrderCurrentDate,so.SalesOrderDueDate,
		c.CustomerName,c.CustomerContact,c.CustomerDetails,
		sp.SalesProductUnitPrice,sp.Qty,sp.SalesProductTotal,
		cc.CategoryName,p.ProductType,p.ProductBrand,p.ProductSize,p.ProductColor,
		so.TotalBill,so.Advance,so.Balance
		FROM tblSalesOrder so
		INNER JOIN tblCustomer c ON c.CustomerID = so.SalesCustomer_ID
		INNER JOIN tblSalesProduct sp ON sp.SalesOrder_ID = so.SalesOrderID
		INNER JOIN tblProduct p ON p.ProductID = sp.Product_ID
		INNER JOIN tblCategory cc ON cc.CategoryID = p.Category_ID

		 SET @Status = 1
		 SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_GetByBarcode]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetByBarcode]
(
  @Barcode  VARCHAR(200),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
	    
		SELECT p.ProductID,s.Barcode,c.CategoryName,p.ProductType,p.ProductBrand,p.ProductSize,p.ProductColor,s.UnitPrice as 'PurchasePrice',pp.PurchaseQty,s.UnitPrice,s.Qty as 'AvailableQty',s.ConsumeQty, p.ProductPicture from tblStock s 
		INNER JOIN tblProduct p ON p.ProductID = s.Product_ID
		INNER JOIN tblCategory c ON c.CategoryID = p.Category_ID
		INNER JOIN tblPurchase pp ON pp.PurchaseID = s.Purchase_Id 
		WHERE s.Barcode = @Barcode
		
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_GetCategory]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_GetCategory]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
	    
		SELECT C.CategoryID,C.CategoryName from tblCategory AS C 
		ORDER BY C.CategoryName ASC
		
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_GetProduct_withoutNwithImage]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProduct_withoutNwithImage]
(
  @ProductID INT,
  @BarCode VARCHAR(100),
  @ProductPicture VARCHAR(MAX),

  @Action VARCHAR(100),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY
IF @Action = 'spSELECTbyID' 
BEGIN 
        SELECT  p.ProductID,CategoryName,p.ProductType,p.ProductBrand,p.ProductSize,p.ProductColor,p.BarCode  FROM tblProduct as p  
		INNER JOIN tblCategory ON CategoryID = p.Category_ID
        WHERE BarCode=@BarCode 
		ORDER BY ProductType ASC 
		SET @Status = 1
		SET @StatusDetails = 'Singal Record Get'
END     
IF @Action = 'spSELECTbyIdNpicture' 
BEGIN 
        SELECT  p.ProductID,p.BarCode,p.ProductPicture  FROM tblProduct as p  
        WHERE ProductID=@ProductID 
		ORDER BY ProductType ASC 
		SET @Status = 1
		SET @StatusDetails = 'Singal Record Get With Picture'
END     
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[usp_GetPurchase]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetPurchase]
(
  --@Barcode  VARCHAR(200),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
	    
		SELECT pp.PurchaseID,p.ProductID,s.Barcode,c.CategoryName,p.ProductType,p.ProductBrand,p.ProductSize,p.ProductColor,
		ss.SupplierName,
		pp.ActualPrice as 'ActualPrice',
		s.UnitPrice as 'UnitPrice',
		pp.PurchaseQty as 'PurchaseQty'
		,s.ConsumeQty as 'SoldQty',
		pp.PurchaseTotal as 'PurchaseTotal',
		pp.PurchaseDate as 'PurchaseDate',
		p.ProductPicture		
		from tblPurchase pr
		
		INNER JOIN tblStock s ON  s.Purchase_Id = pr.PurchaseID
		INNER JOIN tblPurchase pp ON pp.PurchaseID = s.Purchase_Id
		INNER JOIN tblSupplier ss ON ss.SupplierID = pr.Supplier_ID
		INNER JOIN tblProduct p ON p.ProductID = s.Product_ID
		INNER JOIN tblCategory c ON c.CategoryID = p.Category_ID
		Where s.isActive = 1 --AND s.Barcode = @Barcode

		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_GetStock]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetStock]
(
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
	    
		SELECT p.ProductID,s.Barcode,c.CategoryName,p.ProductType,p.ProductBrand,p.ProductSize,p.ProductColor,pp.EntryDate as 'PurchaseDate',pp.ActualPrice as 'PurchasePrice',pp.PurchaseQty,s.UnitPrice,s.Qty as 'AvailableQty',s.ConsumeQty as 'SoldQty' from tblStock s 
		INNER JOIN tblProduct p ON p.ProductID = s.Product_ID
		INNER JOIN tblCategory c ON c.CategoryID = p.Category_ID
		INNER JOIN tblPurchase pp ON pp.PurchaseID = s.Purchase_Id 
		Where isActive = 1

		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_GetStockByProductID]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetStockByProductID]
(
  @ProductID  INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
		Select SUM(Qty-ConsumeQty) AS 'AvailableStockQty' FROM tblStock 
		WHERE Product_ID = @ProductID
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'

	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_GetTrying]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTrying]
(
  @Quantity INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
	    
		--DECLARE @StockID INT
		--SET @StockID =(	SELECT top 1* from tblStock where Product_ID = 3 AND  (Qty - ConsumeQty)>0 ) --GetStockID With Logic
		--DECLARE @AvailableQty INT
		--SET @AvailableQty =( SELECT Qty - ConsumeQty from tblStock WHERE StockID = 7 ) --Get AvailableQty With Logic

		--IF @Quantity <= @AvailableQty
		--	BEGIN
				
		--	END
		--ELSE
		--	BEGIN

		--	END

		
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCategory]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_InsertCategory]
(
  @CategoryName VARCHAR(100),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
	    INSERT INTO tblCategory (CategoryName)VALUES(@CategoryName)
		
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertPictureOrder]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertPictureOrder]
(
  --tblSalesPicture
  @SalesPictureNo VARCHAR(50),
  @SalesPictureImage VARCHAR(MAX),
  @SalesPictureUnitPrice INT,
  @SalesPictureTotal INT,
  @PictureQty INT,
  @CreatedByUser_ID INT,
  @SalesOrder_ID INT,
  @isStudio VARCHAR(50),
  @PicCategory VARCHAR(50),
  @PicType VARCHAR(50),
  @PicBrand VARCHAR(50),
  @PicSize VARCHAR(50),
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
	INSERT INTO tblSalesPicture 
		  (SalesPictureNo,SalesPictureImage,SalesPictureUnitPrice,SalesPictureTotal,CreatedByUser_ID,isStudio,SalesOrder_ID,PictureQty,PicCategory,PicType,PicBrand,PicSize)
	VALUES(@SalesPictureNo,@SalesPictureImage,@SalesPictureUnitPrice,@SalesPictureTotal,@CreatedByUser_ID,@isStudio,@SalesOrder_ID,@PictureQty,@PicCategory,@PicType,@PicBrand,@PicSize)
	

		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'

	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertProductOrder]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertProductOrder]
(
  --tblSalesOrder
  @SalesOrderID INT,
  @Product_ID INT,
  @SalesProductUnitPrice INT,
  @SalesProductTotal INT,
  @CreatedByUser_ID INT,
  @RealQty INT,
  @ChkQuantity int,

  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

		if @ChkQuantity >0
		   BEGIN
				declare @StockId int
				--	select * from tblStock
				set @StockId = (select top 1 stockid from tblStock where Product_ID = @Product_ID and Qty - ConsumeQty > 0 )  --Check_StockAvailable Get StockID
				declare @AvailableQty int = (select Qty - ConsumeQty from tblStock where StockID = @StockId)  --By StockID Get AvailableStock
		   		
				if @ChkQuantity  <= @AvailableQty
					begin
						update tblStock set ConsumeQty = ConsumeQty + @ChkQuantity  where stockid = @StockId  --Adding Value in ConsumeQty
						set @ChkQuantity  = @ChkQuantity - @ChkQuantity --After Adding in ConsumeQty @ChkQuantity Value Set = 0
					end
				else --IF @ChkQuantity is Greater then Stock Initial Row Qty //(@AvailableQty)//
					begin
						update tblStock set ConsumeQty = ConsumeQty + @AvailableQty where stockid = @StockId --Inser StockQty in ConsumeQty
						set @ChkQuantity = @ChkQuantity - @AvailableQty --StockQty  - InputQty
					end

					--Check Again @ChkQuantity Value Available
					while @ChkQuantity > 0
								begin
									set @StockId = (select top 1 stockid from tblStock where product_id = @product_id and Qty - ConsumeQty > 0 )
									set @AvailableQty = (select Qty-ConsumeQty from tblStock where stockid = @StockId)
								
									if @ChkQuantity  <= @AvailableQty
										begin
											update tblStock set ConsumeQty = ConsumeQty + @ChkQuantity  where stockid = @StockId
											set @ChkQuantity  = @ChkQuantity - @ChkQuantity --@ChkQuantity Value Set = 0
										end
									else
										begin
											update tblStock set ConsumeQty = ConsumeQty +@AvailableQty where stockid = @StockId
											set @ChkQuantity  = @ChkQuantity-@AvailableQty
										end
								end
		

				INSERT INTO tblSalesProduct (SalesOrder_ID,Product_ID,SalesProductUnitPrice,SalesProductTotal,CreatedByUser_ID,Qty)
				VALUES(@SalesOrderID,@Product_ID,@SalesProductUnitPrice,@SalesProductTotal,@CreatedByUser_ID,@RealQty)
		   	
				  declare @Consumed int
				  set @Consumed = (select ConsumeQty from tblStock where  stockid = @StockId )
				  
				  declare @qtys int
				  set @qtys = (select Qty from tblStock where  stockid = @StockId)
				  
				  if  @qtys = @Consumed
					begin
						UPDATE tblStock  set  isActive = 0 where  stockid = @StockId
					end
					--set @saledetail_ID=SCOPE_IDENTITY();

		   		SET @Status = 1
		   		SET @StatusDetails = 'SUCCESS'
		   END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertProductOrder2]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertProductOrder2]
(
  --tblSalesProduct
  @Product_ID INT,
  @SalesProductUnitPrice INT,
  @SalesProductTotal INT,
 
  --tblSalesOrder
  @SalesOrderCurrentDate datetime,
  @SalesOrderDueDate datetime,
  @SalesOrderInvoiceNo INT,
  @SalesCustomer_ID INT,
  @TotalBill decimal,
  @Advance decimal,
  @Balance decimal,
  
  --Common_Field
   @CreatedByUser_ID INT,

  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT

)
as
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO tblSalesOrder
				   (SalesOrderCurrentDate,SalesOrderDueDate,SalesOrderInvoiceNo,CreatedByUser_ID,SalesCustomer_ID,TotalBill,Advance,Balance)
			VALUES(@SalesOrderCurrentDate,@SalesOrderDueDate,@SalesOrderInvoiceNo,@CreatedByUser_ID,@SalesCustomer_ID,@TotalBill,@Advance,@Balance)
			
			DECLARE @SalesOrderID INT
			SET @SalesOrderID = SCOPE_IDENTITY()

			INSERT INTO tblSalesProduct (SalesOrder_ID,Product_ID,SalesProductUnitPrice,SalesProductTotal,CreatedByUser_ID)
			VALUES(@SalesOrderID,@Product_ID,@SalesProductUnitPrice,@SalesProductTotal,@CreatedByUser_ID)
			
				SET @Status = 1
				SET @StatusDetails = 'SUCCESS'
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertPurchaseWithStock]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertPurchaseWithStock]
(
  @PurchaseQty INT,
  @ActualPrice INT,
  @PurchaseTotalPrice INT,
  @BarCode VARCHAR(100),  --TwoTables
  @Supplier_ID INT,
  @Product_ID INT, --TwoTables
  @PurchaseDate datetime,
  --@Qty INT,
  --@ConsumeQty INT, --Initial 0Value
  @UnitPrice INT,
 --@Purchase_Id INT,
  @CreatedByUser_ID INT,  --TwoTables

  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRANSACTION
	    BEGIN TRY
		INSERT INTO tblPurchase(PurchaseQty,ActualPrice,PurchaseTotal,Supplier_ID,Product_ID,CreatedByUser_ID,PurchaseDate)
		VALUES(@PurchaseQty,@ActualPrice,@PurchaseTotalPrice,@Supplier_ID,@Product_ID,@CreatedByUser_ID,@PurchaseDate)

		DECLARE @PurchaseID INT
	    SET @PurchaseID = SCOPE_IDENTITY()

		
		INSERT INTO tblStock(Product_ID,Qty,ConsumeQty,UnitPrice,Barcode,Purchase_Id,CreatedByUser_ID)
		VALUES(@Product_ID,@PurchaseQty,0,@UnitPrice,@BarCode,@PurchaseID, @CreatedByUser_ID)			-- Default ConsumeQty SET on 0
		
		SET @Status = 1
		SET @StatusDetails = 'Record Saved Successfully'
		END TRY
	
		BEGIN CATCH
			SET @Status = 0
			SET @StatusDetails = ERROR_MESSAGE() 
		END CATCH
	COMMIT TRANSACTION
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertSales]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertSales]
(
  --CUSTOMERS--
  @CustomerName  VARCHAR(99),
  @CustomerContact  VARCHAR(12),
  @CustomerDetails  VARCHAR(200),
  
  --SALES_PRODUCTS--
  @Product_ID INT,
  @SalesProductUnitPrice INT,
  @SalesProductTotal INT,
  
   --SALES_PICTURE--
  @SalesPictureID INT OUT,
  @SalesPictureNo VARCHAR(200),
  @SalesPictureImage VARCHAR(MAX),
  @SalesPictureUnitPrice INT,
  @SalesPictureTotal INT,
  
  --SALES_ORDER--
  @SalesOrderCurrentDate  DATETIME,
  @SalesOrderDueDate  DATETIME,
  @SalesOrderInvoiceNo  VARCHAR(200),

  --MULT_TIME_ADD--
  @CreatedByUser_ID  INT, --TwoTables
  --GENERAL--
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
	--CUSTOMERS--
	INSERT INTO tblCustomer(CustomerName,CustomerContact,CustomerDetails)
					  VALUES(@CustomerName,@CustomerContact,@CustomerDetails)
					 DECLARE @CustomerID INT
				     SET @CustomerID = SCOPE_IDENTITY()
	--SALES_PRODUCTS--
	INSERT INTO tblSalesProduct (Product_ID,SalesProductUnitPrice,SalesProductTotal,CreatedByUser_ID)
					  VALUES(@Product_ID,@SalesProductUnitPrice,@SalesProductTotal,@CreatedByUser_ID)
					 DECLARE @SalesProductID INT
				     SET @SalesProductID = SCOPE_IDENTITY()
    --SALES_PICTURE--
	INSERT INTO tblSalesPicture(SalesPictureNo,SalesPictureImage,SalesPictureUnitPrice,SalesPictureTotal,CreatedByUser_ID)
					  VALUES(@SalesPictureNo,@SalesPictureImage,@SalesPictureUnitPrice,@SalesPictureTotal,@CreatedByUser_ID)
				     SET @SalesPictureID = SCOPE_IDENTITY()
    --SALES_ORDER--
	INSERT INTO tblSalesOrder (SalesOrderCurrentDate,SalesOrderDueDate,SalesOrderInvoiceNo,CreatedByUser_ID,SalesProduct_ID,SalesPicture_ID,SalesCustomer_ID)
				  VALUES(@SalesOrderCurrentDate,@SalesOrderDueDate,@SalesOrderInvoiceNo,@CreatedByUser_ID,@SalesProductID,@SalesPictureID,@CustomerID)
				  DECLARE @SalesOrderID INT
			      SET @SalesOrderID = SCOPE_IDENTITY()
		
		SET @Status = 1
		SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertSalesOrder]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_InsertSalesOrder]
(
  --tblSalesOrder
  @SalesOrderID INT OUTPUT,
  @SalesOrderCurrentDate datetime,
  @SalesOrderDueDate datetime,
  @SalesOrderInvoiceNo VARCHAR(99),
  @TotalBill decimal,
  @Advance decimal,
  @Balance decimal,
  @CreatedByUser_ID INT,
  --tblCustomer
  @CustomerName VARCHAR(99),
  @CustomerContact VARCHAR(99),
  @CustomerDetails VARCHAR(999),
  @CreatedByUser_IDForCustomer INT,

  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT

)
as
BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
			
			    INSERT INTO tblCustomer
			    (CustomerName,CustomerContact,CustomerDetails,CreatedByUser_ID)
			    VALUES(@CustomerName,@CustomerContact,@CustomerDetails,@CreatedByUser_IDForCustomer)
			    
			    DECLARE @CustomerID INT
			    SET @CustomerID = SCOPE_IDENTITY()
			    
			    INSERT INTO tblSalesOrder
			    	   (SalesOrderCurrentDate,SalesOrderDueDate,SalesOrderInvoiceNo,CreatedByUser_ID,SalesCustomer_ID,TotalBill,Advance,Balance)
			    VALUES(@SalesOrderCurrentDate,@SalesOrderDueDate,@SalesOrderInvoiceNo,@CreatedByUser_ID,@CustomerID,@TotalBill,@Advance,@Balance)
			    
			    SET @SalesOrderID = SCOPE_IDENTITY()
			    
			    	SET @Status = 1
			    	SET @StatusDetails = 'SUCCESS'
			    
			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			ROLLBACK;
			SET @Status = 0
			SET @StatusDetails = ERROR_MESSAGE() 
		END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertSalesOrder_Step1]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_InsertSalesOrder_Step1]
(
  --tblCustomer
  @CustomerID INT OUTPUT,
  @CustomerName VARCHAR(99),
  @CustomerContact VARCHAR(99),
  @CustomerDetails VARCHAR(999),
  @CreatedByUser_IDForCustomer INT,

  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT

)
as
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO tblCustomer
			(CustomerName,CustomerContact,CustomerDetails,CreatedByUser_ID)
			VALUES(@CustomerName,@CustomerContact,@CustomerDetails,@CreatedByUser_IDForCustomer)
			
			SET @CustomerID = SCOPE_IDENTITY()
			
				SET @Status = 1
				SET @StatusDetails = 'SUCCESS'
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertSalesOrder_Step2]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_InsertSalesOrder_Step2]
(
  --tblSalesOrder
  @SalesOrderID INT OUTPUT,
  @SalesOrderCurrentDate datetime,
  @SalesOrderDueDate datetime,
  @SalesOrderInvoiceNo VARCHAR(99),
  @TotalBill decimal,
  @Advance decimal,
  @Balance decimal,
  @CreatedByUser_ID INT,
  --tblCustomer
  @CustomerID INT ,
 
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT

)
as
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO tblSalesOrder
				   (SalesOrderCurrentDate,SalesOrderDueDate,SalesOrderInvoiceNo,CreatedByUser_ID,SalesCustomer_ID,TotalBill,Advance,Balance)
			VALUES(@SalesOrderCurrentDate,@SalesOrderDueDate,@SalesOrderInvoiceNo,@CreatedByUser_ID,@CustomerID,@TotalBill,@Advance,@Balance)
			
			SET @SalesOrderID = SCOPE_IDENTITY()
			
				SET @Status = 1
				SET @StatusDetails = 'SUCCESS'
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InvoiceReportSTEP2]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InvoiceReportSTEP2]
(
 -- @SalesOrder_ID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY

	SELECT sp.SalesOrder_ID,sp.SalesProductUnitPrice as 'UnitPrice',sp.Qty as 'Qty',sp.SalesProductTotal as 'TotalPrice',
		cc.CategoryName as 'Category',p.ProductType as 'Type',p.ProductBrand as 'Brand',p.ProductSize as 'Size',p.ProductColor as 'Color'
		,'' as 'SalesPictureNo','' as 'isStudio' ,so.SalesOrderInvoiceNo,
		 c.CustomerName , c.CustomerContact,c.CustomerDetails,
		 so.SalesOrderCurrentDate,so.SalesOrderDueDate,
		 so.TotalBill,so.Advance,so.Balance
		FROM tblSalesOrder so join tblSalesProduct sp on so.SalesOrderID = sp.SalesOrder_ID
		--INNER JOIN tblSalesPicture spp ON spp.SalesOrder_ID = so.SalesOrderID
		INNER JOIN tblProduct p ON p.ProductID = sp.Product_ID
		INNER JOIN tblCategory cc ON cc.CategoryID = p.Category_ID
		INNER JOIN tblCustomer c on c.customerid = so.SalesCustomer_ID
    	--WHERE sp.SalesOrder_ID = @SalesOrder_ID

		UNION ALL

		SELECT spp.SalesOrder_ID,spp.SalesPictureUnitPrice as 'UnitPrice',spp.PictureQty as 'Qty',
		spp.SalesPictureTotal as 'TotalPrice',
		spp.PicCategory as 'Category',spp.PicType as 'Type',spp.PicBrand as 'Brand',spp.PicSize as 'Size','Color',
		spp.SalesPictureNo,spp.isStudio ,so.SalesOrderInvoiceNo, c.CustomerName , c.CustomerContact,c.CustomerDetails,
		so.SalesOrderCurrentDate,so.SalesOrderDueDate,
		so.TotalBill,so.Advance,so.Balance
		FROM tblSalesOrder so join  tblSalesPicture spp on so.SalesOrderID  = spp.SalesOrder_ID
		INNER JOIN tblCustomer c on c.customerid = so.SalesCustomer_ID
		--WHERE spp.SalesOrder_ID = @SalesOrder_ID

		Order by SalesOrder_ID asc
		 SET @Status = 1
		 SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllTables]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SelectAllTables]
(
  @Action VARCHAR(200) OUTPUT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
BEGIN TRY

IF @Action = 'spSelectCategory'  
BEGIN  
        SELECT CategoryID ,CategoryName  FROM tblCategory  ORDER BY CategoryName ASC
		SET @Status = 1
		SET @StatusDetails = 'All Category'
END  
IF @Action = 'spSelectProduct'  
BEGIN  
        SELECT p.ProductID, c.CategoryName,p.ProductType,p.ProductBrand,p.ProductSize,ProductColor,p.BarCode,p.ProductPicture  FROM tblProduct p 
		INNER JOIN  tblCategory c ON c.CategoryID = p.Category_ID
		SET @Status = 1
		SET @StatusDetails = 'All Product'
END 
IF @Action = 'spSelectProductID_and_PictureOnly'  
BEGIN  
        SELECT p.ProductID,p.ProductPicture FROM tblProduct p 
		SET @Status = 1
		SET @StatusDetails = 'All ProductID_and_PictureOnly'
END 

IF @Action = 'spSelectSupplier'  
BEGIN  
        SELECT s.SupplierID,s.SupplierName,s.SupplierPhoneNo,s.SupplierMobileNo,s.SupplierAddress,SupplierPicture  FROM tblSupplier s 
		SET @Status = 1
		SET @StatusDetails = 'All Supplier'
END 
IF @Action = 'spSelectSupplierID_and_PictureOnly'  
BEGIN  
        SELECT s.SupplierID,s.SupplierPicture  FROM tblSupplier s 
		SET @Status = 1
		SET @StatusDetails = 'All SupplierID_and_PictureOnly'
END 
IF @Action = 'spSelectUser'  
BEGIN  
        SELECT U.UserName,U.UserPassword,U.UserDesignation,R.RoleName,R.RoleDetails  FROM tblUserRoles ur 
		INNER JOIN tblUser U ON u.UserID = UR.[User_ID]  
		INNER JOIN tblRoles R ON R.RoleID = UR.Role_ID 
		SET @Status = 1
		SET @StatusDetails = 'All User'
END 
IF @Action = 'spSelectUserID_and_PictureOnly'  
BEGIN  
		SELECT u.UserID,UserPicture  FROM tblUser u 
        
		SET @Status = 1
		SET @StatusDetails = 'All UserID_and_PictureOnly'
END 

  
END TRY
BEGIN CATCH
	SET @Status = 0
	SET @StatusDetails = ERROR_MESSAGE() 
END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_SummaryInvoiceReport]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SummaryInvoiceReport] --'29/07/2020','01/09/2020'
(
  @FromDate DateTime,
  @ToDate DateTime,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRY
		SELECT sp.SalesOrder_ID,sp.SalesProductUnitPrice as 'UnitPrice',sp.Qty as 'Qty',sp.SalesProductTotal as 'TotalPrice',
		cc.CategoryName as 'Category',p.ProductSize as 'Size'
		,'' as 'SalesPictureNo','' as 'isStudio' ,so.SalesOrderInvoiceNo,
		 c.CustomerName , c.CustomerContact,
		 so.SalesOrderCurrentDate,so.SalesOrderDueDate,
		 so.TotalBill,so.Advance,so.Balance
		FROM tblSalesOrder so join tblSalesProduct sp on so.SalesOrderID = sp.SalesOrder_ID
		--INNER JOIN tblSalesPicture spp ON spp.SalesOrder_ID = so.SalesOrderID
		INNER JOIN tblProduct p ON p.ProductID = sp.Product_ID
		INNER JOIN tblCategory cc ON cc.CategoryID = p.Category_ID
		INNER JOIN tblCustomer c on c.customerid = so.SalesCustomer_ID
		WHERE so.EntryDate BETWEEN @FromDate AND @ToDate
		--where so.EntryDate >= @FromDate and so.EntryDate <= @ToDate
    	

		UNION ALL

		SELECT spp.SalesOrder_ID,spp.SalesPictureUnitPrice as 'UnitPrice',spp.PictureQty as 'Qty',
		spp.SalesPictureTotal as 'TotalPrice',
		spp.PicCategory as 'Category',spp.PicSize as 'Size',
		spp.SalesPictureNo,spp.isStudio ,so.SalesOrderInvoiceNo, c.CustomerName , c.CustomerContact,
		so.SalesOrderCurrentDate,so.SalesOrderDueDate,
		so.TotalBill,so.Advance,so.Balance
		FROM tblSalesOrder so join  tblSalesPicture spp on so.SalesOrderID  = spp.SalesOrder_ID
		INNER JOIN tblCustomer c on c.customerid = so.SalesCustomer_ID
		--where so.EntryDate >= @FromDate and so.EntryDate <= @ToDate
		WHERE so.EntryDate BETWEEN @FromDate AND @ToDate

		Order by SalesOrder_ID asc
		 SET @Status = 1
		 SET @StatusDetails = 'SUCCESS'
	END TRY
	BEGIN CATCH
		SET @Status = 0
		SET @StatusDetails = ERROR_MESSAGE() 
	END CATCH
End




GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCustomer]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_UpdateCustomer]
(
  @CustomerID INT,
  @CustomerName Varchar(50),
  @CustomerContact Varchar(50),
  @CustomerDetails Varchar(500),
  @Status bit OUTPUT,
  @StatusDetails Varchar(50) OUTPUT
)
As 
Begin
 BEGIN TRY
	
	UPDATE tblCustomer SET CustomerName = @CustomerName,CustomerContact = @CustomerContact,CustomerDetails = @CustomerDetails
	Where CustomerID = @CustomerID
   	--SELECT so.SalesOrderID, c.CustomerID,c.CustomerName,c.CustomerContact,c.CustomerDetails,
   	--so.Advance,so.Balance,so.TotalBill,
	--so.SalesOrderCurrentDate,so.SalesOrderDueDate
    --from tblSalesOrder so
   	--INNER JOIN tblCustomer c ON c.CustomerID =  so.SalesCustomer_ID
   	--WHERE so.SalesOrderInvoiceNo = @InvoiceNo
   
     Set @Status=1
   	Set @StatusDetails= 'SUCCESS'
   	Return;
 END TRY
 BEGIN CATCH
 	SET @Status = 0
 	SET @StatusDetails = ERROR_MESSAGE() 
 END CATCH

End


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateProduct]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_UpdateProduct]
( 
	@ProductID INT,
	@Category_ID INT,
	@ProductType VARCHAR(50),
	@ProductBrand VARCHAR(50),
	@ProductSize VARCHAR(20),
	@ProductColor VARCHAR(20),
	@ProductPicture VARCHAR(MAX),
	@BarCode VARCHAR(50),
	@_Status BIT OUTPUT,
	@_StatusDetails VARCHAR(100) OUTPUT
)
AS
BEGIN 

BEGIN TRY 

	Update tblProduct SET Category_ID=@Category_ID,ProductType=@ProductType,ProductBrand=@ProductBrand,ProductSize=@ProductSize,ProductColor=@ProductColor,ProductPicture=@ProductPicture,BarCode=@BarCode
	WHERE ProductID=@ProductID
 
	SET @_Status = 1
	SET @_StatusDetails = 'DONE'
END TRY
BEGIN CATCH 
	SET @_Status = 0
	SET @_StatusDetails = ERROR_MESSAGE()
END CATCH
END
-----------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdatePurchaseWithStock]    Script Date: 22/10/2020 10:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdatePurchaseWithStock]
(
  @PurchaseQty INT,
  @PurchaseUnitPrice INT,
  @ActualPrice INT,
  @PurchaseTotalPrice INT,
  @BarCode VARCHAR(100),  --TwoTables
  @PurchaseDate datetime,
  @PurchaseID INT,
  @Supplier_ID INT,
  @Status BIT OUTPUT,
  @StatusDetails VARCHAR(200) OUTPUT
)
as
BEGIN
	BEGIN TRANSACTION
	    BEGIN TRY
		UPDATE tblPurchase SET 
		PurchaseDate=@PurchaseDate,
		ActualPrice=@ActualPrice,
		PurchaseQty = @PurchaseQty,
		PurchaseTotal=@PurchaseTotalPrice,
		Supplier_ID = @Supplier_ID
		Where PurchaseID = @PurchaseID
		
		UPDATE tblStock SET 
		Qty=@PurchaseQty,
		UnitPrice=@PurchaseUnitPrice
	    Where Purchase_Id = @PurchaseID

		

		SET @Status = 1
		SET @StatusDetails = 'Record Updated Successfully'
		END TRY
	
		BEGIN CATCH
			SET @Status = 0
			SET @StatusDetails = ERROR_MESSAGE() 
		END CATCH
	COMMIT TRANSACTION
End




GO
USE [master]
GO
ALTER DATABASE [NAQ_DB2020] SET  READ_WRITE 
GO
