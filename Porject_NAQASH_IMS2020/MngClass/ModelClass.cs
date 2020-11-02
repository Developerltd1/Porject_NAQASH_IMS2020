using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porject_NAQASH_IMS2020.MngClass
{
    public class ModelClass
    {
        public static int _UserID = 1;//{ get; set ; }
        
        public static int _RoleID { get; set; }
        public static string _UserName { get; set; }

        public class ModelPOS
        {
            #region tblBill Class

            public class ModelBill
            {
                public int BillID { get; set; }
                public int BillGrandTotal { get; set; }
                public int BillAdvance { get; set; }
                public int BillBalance { get; set; }
                public int SalesProduct_ID { get; set; }
                public int SalesPicture_ID { get; set; }
            }

            #endregion

            #region tblCategory Class

            public class ModelCategory
            {
                public int CategoryID { get; set; }
                public string CategoryName { get; set; }
                public string CategoryContact { get; set; }
                public string CategoryDetails { get; set; }
                public int CreatedByUSerID { get; set; }
                public string Actions { get; set; }
            }

            #endregion

            #region tblCustomer Class

            public class ModelCustomer
            {
                public int CustomerID { get; set; }
                public int CreatedByUser_ID { get; set; }
                public DateTime EntryDate { get; set; }
                public string CustomerName { get; set; }
                public string CustomerContact { get; set; }
                public string CustomerDetails { get; set; }
            }

            #endregion

            #region tblExpenses Class

            public class ModelExpenses
            {
                public int ExpensesID { get; set; }
                public int CreatedByUser_ID { get; set; }
                public DateTime EntryDate { get; set; }
                public string ExpensesTitle { get; set; }
                public string ExpensesDetails { get; set; }
            }

            #endregion

            #region tblForm Class

            public class ModelForm
            {
                public int FormID { get; set; }
                public int CreatedByUser_ID { get; set; }
                public DateTime EntryDate { get; set; }
                public string FormActualName { get; set; }
                public string FormDisplayName { get; set; }
                public string FormDetails { get; set; }
            }

            #endregion

            #region tblProduct Class
            public class ModelProduct
            {
                public int ProductID { get; set; }
                public int Category_ID { get; set; }
                public int CreatedByUser_ID { get; set; }
                public DateTime EntryDate { get; set; }
                public string BarCode { get; set; }
                public string ProductType { get; set; }
                public string ProductBrand { get; set; }
                public string ProductSize { get; set; }
                public string ProductColor { get; set; }
                public string ProductPicture { get; set; }
            }

            #endregion

            #region tblRolePermission Class

            public class ModelRolePermission
            {
                public int RolePermissionID { get; set; }
                public int Role_ID { get; set; }
                public int Form_ID { get; set; }
            }

            #endregion

            #region tblRoles Class

            public class ModelRoles
            {
                public int RoleID { get; set; }
                public int CreatedByUser_ID { get; set; }
                public DateTime EntryDate { get; set; }
                public string RoleName { get; set; }
                public string RoleDetails { get; set; }
            }

            #endregion

            #region tblSalesOrder Class

            public class ModelSalesOrder
            {
                public int SalesOrderID { get; set; }
                public int CreatedByUser_ID { get; set; }
                public DateTime SalesOrderCurrentDate { get; set; }
                public DateTime SalesOrderDueDate { get; set; }
                public DateTime EntryDate { get; set; }
                public string SalesOrderInvoiceNo { get; set; }
                public decimal GrandTotal { get; set; }
                public decimal Advance { get; set; }
                public decimal Balance { get; set; }
               

            }
            #endregion

            #region tblSalesPicture Class

            public class ModelSalesPicture
            {
                public int SalesPictureID { get; set; }
                public int SalesOrder_ID { get; set; }
                public int Product_ID { get; set; }
                public int SalesPictureUnitPrice { get; set; }
                public int SalesPictureTotal { get; set; }
                public int CreatedByUser_ID { get; set; }
                public DateTime EntryDate { get; set; }
                public string SalesPictureNo { get; set; }
                public string SalesPictureImage { get; set; }
            }

            #endregion

            #region tblSalesProduct Class

            public class ModelSalesProduct
            {
                public int SalesProductID { get; set; }
                public int SalesOrder_ID { get; set; }
                public int Product_ID { get; set; }
                public int SalesProductUnitPrice { get; set; }
                public int SalesProductTotal { get; set; }
                public int CreatedByUser_ID { get; set; }
                public DateTime EntryDate { get; set; }

                public int SalesProductQty { get; set; }
            }

            #endregion

            #region tblStock Class

            public class ModelStock
            {
                public int StockID { get; set; }
                public int StockQty { get; set; }
                public int PurchasePrice { get; set; }
                public int Supplier_ID { get; set; }
                public int Product_ID { get; set; }
                public int CreatedByUser_ID { get; set; }
                public DateTime EntryDate { get; set; }
                public string BarCode { get; set; }
            }

            #endregion

            #region tblSupplier Class

            public class ModelSupplier
            {
                public int SupplierID { get; set; }
                public string SupplierName { get; set; }
                public string SupplierPhoneNo { get; set; }
                public string SupplierMobileNo { get; set; }
                public string SupplierAddress { get; set; }
                public string SupplierPicture { get; set; }
            }

            #endregion

            #region tblUser Class

            public class ModelUser
            {
                public int UserID { get; set; }
                public int Role_ID { get; set; }
                public int CreatedByUser_ID { get; set; }
                public DateTime EntryDate { get; set; }
                public string UserName { get; set; }
                public string UserPassword { get; set; }
                public string ContactNo { get; set; }
                public string UserDesignation { get; set; }
                public string UserPicture { get; set; }
            }

            #endregion

            #region tblUserRoles Class

            public class ModelUserRoles
            {
                public int UserRoleID { get; set; }
                public int User_ID { get; set; }
                public int Role_ID { get; set; }
            }

            #endregion
            #region Purchase&Stock Class

            public class ModelPurchaseNStock
            {
                public int PurchaseQty { get; set; }
                public int PurchaseUnitPrice { get; set; }
                public int ActualPrice { get; set; }
                public int PurchaseTotalPrice { get; set; }
                public string BarCode { get; set; }
                public DateTime PurchaseDate { get; set; }
                public int Supplier_ID { get; set; }
                public int Product_ID { get; set; }
                public int Qty { get; set; }
                public int UnitPrice { get; set; }
                public int Purchase_Id { get; set; }
                public int CreatedByUser_ID { get; set; }
            }

            #endregion
        }


        public class ModelReporting
        {
            public string SalesOrderInvoiceNo  { get; set; }
           public DateTime  SalesOrderCurrentDate{ get; set; }
           public DateTime SalesOrderDueDate    { get; set; }
           public string CustomerName         { get; set; }
           public string  CustomerContact      { get; set; }
           public string  CustomerDetails      { get; set; }
           public int  TotalBill            { get; set; }
           public int  Advance              { get; set; }
           public int  Balance              { get; set; }
           public int  SalesOrder_ID        { get; set; }
           public int  UnitPrice            { get; set; }
           public int  Qty                  { get; set; }
           public int  TotalPrice           { get; set; }
           public string Category             { get; set; }
           public string  Type                 { get; set; }
           public string  Brand                { get; set; }
           public string  Size                 { get; set; }
           public string  Color                { get; set; }
           public string  SalesPictureNo       { get; set; }
           public string isStudio             { get; set; }
           
        }

    }
}
