using System;
using System.Data;
using System.Data.SqlClient;
using static Porject_NAQASH_IMS2020.MngClass.ModelClass.ModelPOS;

namespace Porject_NAQASH_IMS2020.MngClass
{
   public class MainClass
    {
        public class POS
        {

            #region CheckInvoice

            public static void UpdateSalesOrder(int SalesOrderID, DateTime SalesOrderCurrentDate, DateTime SalesOrderDueDate, decimal TotalBill, decimal Advance, decimal Balance, string SalesOrderInvoiceNo, out bool _Status, out string _StatusDetails)
            {
                _Status = false;
                _StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("UpdateSalesOrder", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SalesOrderID", SalesOrderID);
                    cmd.Parameters.AddWithValue("@SalesOrderCurrentDate", SalesOrderCurrentDate);
                    cmd.Parameters.AddWithValue("@SalesOrderDueDate", SalesOrderDueDate);
                    cmd.Parameters.AddWithValue("@TotalBill", TotalBill);
                    cmd.Parameters.AddWithValue("@Advance", Advance);
                    cmd.Parameters.AddWithValue("@Balance", Balance);
                    cmd.Parameters.AddWithValue("@SalesOrderInvoiceNo", SalesOrderInvoiceNo);

                    SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                    _StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusParm);

                    SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                    _StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    _Status = (bool)_StatusParm.Value;
                    _StatusDetails = (string)_StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    _Status = false;
                    _StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static void usp_UpdateCustomer(int CustomerID, string CustomerName, string CustomerContact, string CustomerDetails, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_UpdateCustomer", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerContact", CustomerContact);
                    cmd.Parameters.AddWithValue("@CustomerDetails", CustomerDetails);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 50);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable usp_CheckInvoiceNumberStep1(string InvoiceNo, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;


                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CheckInvoiceNumberStep1", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 50);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable usp_CheckInvoiceNumberStep2(int SalesOrder_ID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;


                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CheckInvoiceNumberStep2", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@SalesOrder_ID", SalesOrder_ID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 50);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            #endregion
            // POS
            #region

            public static void usp_CheckInvoiceNoIfExists(int SalesOrderInvoiceNo, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CheckInvoiceNoIfExists", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SalesOrderInvoiceNo", SalesOrderInvoiceNo);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void usp_InsertPictureOrder(string SalesPictureNo, string SalesPictureImage, int SalesPictureUnitPrice, 
                int SalesPictureTotal, int CreatedByUser_ID, int SalesOrder_ID, string isStudio,int PictureQty,
                string PicCategory, string PicType, string PicBrand, string PicSize, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertPictureOrder", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SalesPictureNo", SalesPictureNo);
                    cmd.Parameters.AddWithValue("@SalesPictureImage", SalesPictureImage);
                    cmd.Parameters.AddWithValue("@SalesPictureUnitPrice", SalesPictureUnitPrice);
                    cmd.Parameters.AddWithValue("@SalesPictureTotal", SalesPictureTotal);
                    cmd.Parameters.AddWithValue("@CreatedByUser_ID", CreatedByUser_ID);
                    cmd.Parameters.AddWithValue("@SalesOrder_ID", SalesOrder_ID);
                    cmd.Parameters.AddWithValue("@isStudio", isStudio);
                    cmd.Parameters.AddWithValue("@PictureQty", PictureQty);
                    cmd.Parameters.AddWithValue("@PicCategory", PicCategory);
                    cmd.Parameters.AddWithValue("@PicType", PicType);
                    cmd.Parameters.AddWithValue("@PicBrand", PicBrand);
                    cmd.Parameters.AddWithValue("@PicSize", PicSize);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void usp_InsertProductOrder(int SalesOrderID, int Product_ID, int SalesProductUnitPrice, int SalesProductTotal, int CreatedByUser_ID, int RealQty, int ChkQuantity, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertProductOrder", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SalesOrderID", SalesOrderID);
                    cmd.Parameters.AddWithValue("@Product_ID", Product_ID);
                    cmd.Parameters.AddWithValue("@SalesProductUnitPrice", SalesProductUnitPrice);
                    cmd.Parameters.AddWithValue("@SalesProductTotal", SalesProductTotal);
                    cmd.Parameters.AddWithValue("@CreatedByUser_ID", CreatedByUser_ID);
                    cmd.Parameters.AddWithValue("@RealQty", RealQty);
                    cmd.Parameters.AddWithValue("@ChkQuantity", ChkQuantity);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void usp_InsertProductOrder(int SalesOrderID, int Product_ID, int SalesProductUnitPrice, int SalesProductTotal, int CreatedByUser_ID, out bool Status, out string StatusDetails, int Qty)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertProductOrder", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SalesOrderID", SalesOrderID);
                    cmd.Parameters.AddWithValue("@Product_ID", Product_ID);
                    cmd.Parameters.AddWithValue("@SalesProductUnitPrice", SalesProductUnitPrice);
                    cmd.Parameters.AddWithValue("@SalesProductTotal", SalesProductTotal);
                    cmd.Parameters.AddWithValue("@CreatedByUser_ID", CreatedByUser_ID);
                    cmd.Parameters.AddWithValue("@Qty", Qty);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static bool usp_CheckAvalibleStock(int ConsumeQty, int Product_id, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CheckAvalibleStock", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ConsumeQty", ConsumeQty);
                    cmd.Parameters.AddWithValue("@Product_id", Product_id);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 50);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    int EffectedRows = 0;

                    conn.Open();
                    EffectedRows = (int)cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                    EffectedRows = Convert.ToInt32(Status);
                    if (EffectedRows == 1)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return false;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void usp_InsertSalesOrder_Step1(string CustomerName, string CustomerContact, string CustomerDetails, int CreatedByUser_IDForCustomer, out bool Status, out string StatusDetails, out int CustomerID)
            {
                Status = false;
                StatusDetails = null;
                CustomerID = 0;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertSalesOrder_Step1", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerContact", CustomerContact);
                    cmd.Parameters.AddWithValue("@CustomerDetails", CustomerDetails);
                    cmd.Parameters.AddWithValue("@CreatedByUser_IDForCustomer", CreatedByUser_IDForCustomer);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    SqlParameter CustomerIDParm = new SqlParameter("@CustomerID", SqlDbType.Int);
                    CustomerIDParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(CustomerIDParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                    CustomerID = (int)CustomerIDParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    CustomerID = 0;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void usp_InsertSalesOrder_Step2(DateTime SalesOrderCurrentDate, DateTime SalesOrderDueDate, string SalesOrderInvoiceNo, decimal TotalBill, decimal Advance, decimal Balance, int CreatedByUser_ID, int CustomerID, out bool Status, out string StatusDetails, out int SalesOrderID)
            {
                Status = false;
                StatusDetails = null;
                SalesOrderID = 0;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertSalesOrder_Step2", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SalesOrderCurrentDate", SalesOrderCurrentDate);
                    cmd.Parameters.AddWithValue("@SalesOrderDueDate", SalesOrderDueDate);
                    cmd.Parameters.AddWithValue("@SalesOrderInvoiceNo", SalesOrderInvoiceNo);
                    cmd.Parameters.AddWithValue("@TotalBill", TotalBill);
                    cmd.Parameters.AddWithValue("@Advance", Advance);
                    cmd.Parameters.AddWithValue("@Balance", Balance);
                    cmd.Parameters.AddWithValue("@CreatedByUser_ID", CreatedByUser_ID);
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    SqlParameter SalesOrderIDParm = new SqlParameter("@SalesOrderID", SqlDbType.Int);
                    SalesOrderIDParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(SalesOrderIDParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                    SalesOrderID = (int)SalesOrderIDParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    SalesOrderID = 0;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable usp_CheckInvoiceNoIfExists()
            {


                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CheckInvoiceNoIfExists", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();


                    return dt;
                }
                catch (Exception ex)
                {

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void usp_InsertSalesOrder(DateTime SalesOrderCurrentDate, DateTime SalesOrderDueDate, string SalesOrderInvoiceNo, decimal TotalBill, decimal Advance, decimal Balance, int CreatedByUser_ID, string CustomerName, string CustomerContact, string CustomerDetails, int CreatedByUser_IDForCustomer, out bool Status, out string StatusDetails, out int SalesOrderID)
            {
                Status = false;
                StatusDetails = null;
                SalesOrderID = 0;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertSalesOrder", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SalesOrderCurrentDate", SalesOrderCurrentDate);
                    cmd.Parameters.AddWithValue("@SalesOrderDueDate", SalesOrderDueDate);
                    cmd.Parameters.AddWithValue("@SalesOrderInvoiceNo", SalesOrderInvoiceNo);
                    cmd.Parameters.AddWithValue("@TotalBill", TotalBill);
                    cmd.Parameters.AddWithValue("@Advance", Advance);
                    cmd.Parameters.AddWithValue("@Balance", Balance);
                    cmd.Parameters.AddWithValue("@CreatedByUser_ID", CreatedByUser_ID);
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerContact", CustomerContact);
                    cmd.Parameters.AddWithValue("@CustomerDetails", CustomerDetails);
                    cmd.Parameters.AddWithValue("@CreatedByUser_IDForCustomer", CreatedByUser_IDForCustomer);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    SqlParameter SalesOrderIDParm = new SqlParameter("@SalesOrderID", SqlDbType.Int);
                    SalesOrderIDParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(SalesOrderIDParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                    SalesOrderID = (int)SalesOrderIDParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    SalesOrderID = 0;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void usp_InserttblSalesOrder(DateTime SalesOrderCurrentDate, DateTime SalesOrderDueDate, string SalesOrderInvoiceNo, decimal TotalBill, decimal Advance, decimal Balance, int CreatedByUser_ID,string CustomerName, string CustomerContact, string CustomerDetails,int CreatedByUser_IDForCustomer, out bool Status, out string StatusDetails, out int SalesOrderID)
            {
                Status = false;
                StatusDetails = null;
                SalesOrderID = 0;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertSalesOrder", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerContact", CustomerContact);
                    cmd.Parameters.AddWithValue("@CustomerDetails", CustomerDetails);
                    cmd.Parameters.AddWithValue("@CreatedByUser_IDForCustomer", CreatedByUser_IDForCustomer);
                    
                    cmd.Parameters.AddWithValue("@SalesOrderCurrentDate", SalesOrderCurrentDate);   
                    cmd.Parameters.AddWithValue("@SalesOrderDueDate", SalesOrderDueDate);
                    cmd.Parameters.AddWithValue("@SalesOrderInvoiceNo", SalesOrderInvoiceNo);
                    cmd.Parameters.AddWithValue("@TotalBill", TotalBill);
                    cmd.Parameters.AddWithValue("@Advance", Advance);
                    cmd.Parameters.AddWithValue("@Balance", Balance);
                    cmd.Parameters.AddWithValue("@CreatedByUser_ID", CreatedByUser_IDForCustomer);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    SqlParameter SalesOrderIDParm = new SqlParameter("@SalesOrderID", SqlDbType.Int);
                    SalesOrderIDParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(SalesOrderIDParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                    SalesOrderID = (int)SalesOrderIDParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    SalesOrderID = 0;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable usp_GetByBarcode(string Barcode, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                // DataTable Declaration
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_GetByBarcode", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@Barcode", Barcode);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable usp_GetStockByProductID(int ProductID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;


                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_GetStockByProductID", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@ProductID", ProductID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            #endregion



            // PurchaseOperations
            #region

            public static void usp_UpdatePurchaseWithStock(int PurchaseQty,int ActualPrice, int PurchaseUnitPrice, int PurchaseTotalPrice, string BarCode, DateTime PurchaseDate,int Supplier_ID, int PurchaseID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_UpdatePurchaseWithStock", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PurchaseQty", PurchaseQty);
                    cmd.Parameters.AddWithValue("@PurchaseUnitPrice", PurchaseUnitPrice);
                    cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice);
                    cmd.Parameters.AddWithValue("@PurchaseTotalPrice", PurchaseTotalPrice);
                    cmd.Parameters.AddWithValue("@BarCode", BarCode);
                    cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
                    cmd.Parameters.AddWithValue("@PurchaseID", PurchaseID);
                    cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID);
                    

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static DataTable usp_GetPurchase(out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;


                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_GetPurchase", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void PurchaseCreate(ModelPurchaseNStock m, out bool Status, out string StatusDetails)
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InsertPurchaseWithStock", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PurchaseQty", m.PurchaseQty);
                    cmd.Parameters.AddWithValue("@ActualPrice", m.ActualPrice);
                    cmd.Parameters.AddWithValue("@UnitPrice", m.PurchaseUnitPrice);
                    cmd.Parameters.AddWithValue("@PurchaseTotalPrice", m.PurchaseTotalPrice);
                    cmd.Parameters.AddWithValue("@Supplier_ID", m.Supplier_ID);
                    cmd.Parameters.AddWithValue("@BarCode", m.BarCode);
                    cmd.Parameters.AddWithValue("@Product_ID", m.Product_ID);
                    cmd.Parameters.AddWithValue("@PurchaseDate", m.PurchaseDate);
                    cmd.Parameters.AddWithValue("@CreatedByUser_ID", m.CreatedByUser_ID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable PurchaseDisplayAll(out bool Status, out string StatusDetails)
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {

                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_SelectAllTables", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spSelectSupplier");

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable usp_GetProduct_withoutImage(ModelProduct mp, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;


                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_GetProduct_withoutNwithImage", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@ProductID", "");
                    cmd.Parameters.AddWithValue("@BarCode", mp.BarCode);
                    cmd.Parameters.AddWithValue("@ProductPicture", "");
                    cmd.Parameters.AddWithValue("@Action", "spSELECTbyID"); // Missing Mapping

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static DataTable usp_GetProduct_withImage(ModelProduct mp, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;


                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_GetProduct_withoutNwithImage", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@ProductID", mp.ProductID);
                    cmd.Parameters.AddWithValue("@BarCode", "");
                    cmd.Parameters.AddWithValue("@ProductPicture", "");
                    cmd.Parameters.AddWithValue("@Action", "spSELECTbyIdNpicture"); // Missing Mapping

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            #endregion
            // UserOperations
            #region
            public static void CRUDUserCreate(ModelUser ClstblUserObj, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDUser", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CreatedByUser_ID", ClstblUserObj.CreatedByUser_ID);
                    cmd.Parameters.AddWithValue("@UserID", "");
                    cmd.Parameters.AddWithValue("@UserName", ClstblUserObj.UserName);
                    cmd.Parameters.AddWithValue("@UserPassword", ClstblUserObj.UserPassword);
                    cmd.Parameters.AddWithValue("@UserDesignation", ClstblUserObj.UserDesignation);
                    cmd.Parameters.AddWithValue("@UserPicture", ClstblUserObj.UserPicture);
                    cmd.Parameters.AddWithValue("@Role_ID", ClstblUserObj.Role_ID); 
                    cmd.Parameters.AddWithValue("@Action", "spINSERT"); 

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void CRUDUserUpdate(ModelSupplier m, out bool Status, out string StatusDetails)
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDSupplier", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spUPDATE");
                    cmd.Parameters.AddWithValue("@SupplierID", m.SupplierID);
                    cmd.Parameters.AddWithValue("@SupplierName", m.SupplierName);
                    cmd.Parameters.AddWithValue("@SupplierPhoneNo", m.SupplierPhoneNo);
                    cmd.Parameters.AddWithValue("@SupplierMobileNo", m.SupplierMobileNo);
                    cmd.Parameters.AddWithValue("@SupplierAddress", m.SupplierAddress);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void CRUDUserDelete(ModelSupplier m, out bool Status, out string StatusDetails)
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDSupplier", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spDELETE");
                    cmd.Parameters.AddWithValue("@SupplierID", m.SupplierID);
                    cmd.Parameters.AddWithValue("@SupplierName", null);
                    cmd.Parameters.AddWithValue("@SupplierPhoneNo", null);
                    cmd.Parameters.AddWithValue("@SupplierMobileNo", null);
                    cmd.Parameters.AddWithValue("@SupplierAddress", null);

                    SqlParameter StatusParm1 = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm1);

                    SqlParameter StatusParm2 = new SqlParameter(" @StatusDetails", SqlDbType.VarChar, 200);
                    StatusParm2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm2);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm1.Value;
                    StatusDetails = (string)StatusParm2.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable CRUDUserDisplayByID(ModelSupplier m, out bool Status, out string StatusDetails)
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDSupplier", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Action", "spSELECTbyID");
                    cmd.Parameters.AddWithValue("@SupplierID", m.SupplierID);
                    cmd.Parameters.AddWithValue("@SupplierName", null);
                    cmd.Parameters.AddWithValue("@SupplierPhoneNo", null);
                    cmd.Parameters.AddWithValue("@SupplierMobileNo", null);
                    cmd.Parameters.AddWithValue("@SupplierAddress", null);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter(" @StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable UserDisplayAll(out bool Status, out string StatusDetails)
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {

                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_SelectAllTables", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spSelectUser");

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static DataTable UserIDnPicture(out bool Status, out string StatusDetails)
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {

                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_SelectAllTables", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spSelectSupplierID_and_PictureOnly");

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            #endregion
            // SuppierOperations
            #region
            public static void _UpdateSupplier(int SupplierID, string SupplierName, string SupplierPhoneNo, string SupplierMobileNo, string SupplierAddress, string SupplierPicture, out bool _Status, out string _StatusDetails)
            {
                _Status = false;
                _StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("_UpdateSupplier", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                    cmd.Parameters.AddWithValue("@SupplierName", SupplierName);
                    cmd.Parameters.AddWithValue("@SupplierPhoneNo", SupplierPhoneNo);
                    cmd.Parameters.AddWithValue("@SupplierMobileNo", SupplierMobileNo);
                    cmd.Parameters.AddWithValue("@SupplierAddress", SupplierAddress);
                    cmd.Parameters.AddWithValue("@SupplierPicture", SupplierPicture);

                    SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                    _StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusParm);

                    SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                    _StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    _Status = (bool)_StatusParm.Value;
                    _StatusDetails = (string)_StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    _Status = false;
                    _StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static void CRUDSuppierCreate(ModelSupplier m, out bool Status, out string StatusDetails)
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDSupplier", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spINSERT");
                    cmd.Parameters.AddWithValue("@SupplierID", "");
                    cmd.Parameters.AddWithValue("@SupplierName", m.SupplierName);
                    cmd.Parameters.AddWithValue("@SupplierPhoneNo", m.SupplierPhoneNo);
                    cmd.Parameters.AddWithValue("@SupplierMobileNo", m.SupplierMobileNo);
                    cmd.Parameters.AddWithValue("@SupplierAddress", m.SupplierAddress);
                    cmd.Parameters.AddWithValue("@SupplierPicture", m.SupplierPicture);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void CRUDSuppierUpdate(ModelSupplier m, out bool Status, out string StatusDetails)
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDSupplier", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spUPDATE");
                    cmd.Parameters.AddWithValue("@SupplierID", m.SupplierID);
                    cmd.Parameters.AddWithValue("@SupplierName", m.SupplierName);
                    cmd.Parameters.AddWithValue("@SupplierPhoneNo", m.SupplierPhoneNo);
                    cmd.Parameters.AddWithValue("@SupplierMobileNo", m.SupplierMobileNo);
                    cmd.Parameters.AddWithValue("@SupplierAddress", m.SupplierAddress);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void CRUDSuppierDelete(ModelSupplier m, out bool Status, out string StatusDetails)
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDSupplier", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spDELETE");
                    cmd.Parameters.AddWithValue("@SupplierID", m.SupplierID);
                    cmd.Parameters.AddWithValue("@SupplierName", null);
                    cmd.Parameters.AddWithValue("@SupplierPhoneNo", null);
                    cmd.Parameters.AddWithValue("@SupplierMobileNo", null);
                    cmd.Parameters.AddWithValue("@SupplierAddress", null);

                    SqlParameter StatusParm1 = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm1);

                    SqlParameter StatusParm2 = new SqlParameter(" @StatusDetails", SqlDbType.VarChar, 200);
                    StatusParm2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm2);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm1.Value;
                    StatusDetails = (string)StatusParm2.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable CRUDSuppierDisplayByID(ModelSupplier m, out bool Status, out string StatusDetails)
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDSupplier", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Action", "spSELECTbyID");
                    cmd.Parameters.AddWithValue("@SupplierID", m.SupplierID);
                    cmd.Parameters.AddWithValue("@SupplierName", null);
                    cmd.Parameters.AddWithValue("@SupplierPhoneNo", null);
                    cmd.Parameters.AddWithValue("@SupplierMobileNo", null);
                    cmd.Parameters.AddWithValue("@SupplierAddress", null);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter(" @StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable SuppierDisplayAll(out bool Status, out string StatusDetails)
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {

                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_SelectAllTables", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spSelectSupplier");

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static DataTable SuppierIDnPicture(out bool Status, out string StatusDetails)
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {

                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_SelectAllTables", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spSelectSupplierID_and_PictureOnly");

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            #endregion
            // CategoryOperations
            #region
            public static void CRUDCategoryCreate(string CategoryName, out bool  Status, out string StatusDetails )
            {
                Status = false;
                StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spINSERT");
                    cmd.Parameters.AddWithValue("@CategoryID", "");
                    cmd.Parameters.AddWithValue("@CategoryName", CategoryName);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void CRUDCategoryUpdate(ModelCategory mCategory, out bool Status, out string StatusDetails)
            {
               Status = false;
               StatusDetails = null;
                mCategory.Actions = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spUPDATE");
                    cmd.Parameters.AddWithValue("@CategoryID", mCategory.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", mCategory.CategoryName);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void CRUDCategoryDelete(ModelCategory mCategory, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;
               
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spDELETE");
                    cmd.Parameters.AddWithValue("@CategoryID", mCategory.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", "");

                    SqlParameter StatusParm1 = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm1);

                    SqlParameter StatusParm2 = new SqlParameter(" @StatusDetails", SqlDbType.VarChar, 200);
                    StatusParm2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm2);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm1.Value;
                    StatusDetails = (string)StatusParm2.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable CRUDCategoryDisplayByID(int CategoryID, out bool Status, out string StatusDetails)
            {
                 Status = false;
                 StatusDetails = null;
               
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Action", "spSELECTbyID");
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", "");

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter(" @StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                     Status = false;
                     StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable CategoryDisplayAll(out bool Status, out string StatusDetails)
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {

                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_SelectAllTables", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spSelectCategory");

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            #endregion
            // ProductOperations
            #region
            public static void usp_UpdateProduct(int ProductID, int Category_ID, string ProductType, string ProductBrand, string ProductSize, string ProductColor, string ProductPicture, string BarCode, out bool _Status, out string _StatusDetails)
            {
                _Status = false;
                _StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_UpdateProduct", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
                    cmd.Parameters.AddWithValue("@ProductType", ProductType);
                    cmd.Parameters.AddWithValue("@ProductBrand", ProductBrand);
                    cmd.Parameters.AddWithValue("@ProductSize", ProductSize);
                    cmd.Parameters.AddWithValue("@ProductColor", ProductColor);
                    cmd.Parameters.AddWithValue("@ProductPicture", ProductPicture);
                    cmd.Parameters.AddWithValue("@BarCode", BarCode);

                    SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                    _StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusParm);

                    SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                    _StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    _Status = (bool)_StatusParm.Value;
                    _StatusDetails = (string)_StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    _Status = false;
                    _StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static void CRUDProductCreate(ModelProduct mProduct, out bool Status, out string StatusDetails)
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spINSERT");
                    cmd.Parameters.AddWithValue("@ProductID", "");
                    cmd.Parameters.AddWithValue("@Category_ID", mProduct.Category_ID);
                    cmd.Parameters.AddWithValue("@CreatedByUser_ID", mProduct.CreatedByUser_ID);
                    cmd.Parameters.AddWithValue("@ProductType", mProduct.ProductType);
                    cmd.Parameters.AddWithValue("@ProductBrand", mProduct.ProductBrand);
                    cmd.Parameters.AddWithValue("@ProductSize", mProduct.ProductSize);
                    cmd.Parameters.AddWithValue("@ProductColor", mProduct.ProductColor);
                    cmd.Parameters.AddWithValue("@ProductPicture", mProduct.ProductPicture);
                    cmd.Parameters.AddWithValue("@BarCode", mProduct.BarCode);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void CRUDProductUpdate(ModelCategory mCategory, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;
                mCategory.Actions = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spUPDATE");
                    cmd.Parameters.AddWithValue("@CategoryID", mCategory.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", mCategory.CategoryName);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void CRUDProductDelete(ModelCategory mCategory, out bool Status, out string StatusDetails)
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spDELETE");
                    cmd.Parameters.AddWithValue("@CategoryID", mCategory.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", "");

                    SqlParameter StatusParm1 = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm1);

                    SqlParameter StatusParm2 = new SqlParameter(" @StatusDetails", SqlDbType.VarChar, 200);
                    StatusParm2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm2);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Status = (bool)StatusParm1.Value;
                    StatusDetails = (string)StatusParm2.Value;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
     
            public static DataTable CRUDProductDisplayByID(int CategoryID, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_CRUDCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Action", "spSELECTbyID");
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", "");

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter(" @StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable ProductDisplayAll(out bool Status, out string StatusDetails)
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_SelectAllTables", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spSelectProduct");

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable ProductIDnPicture(out bool Status, out string StatusDetails)
            {
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_SelectAllTables", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "spSelectProductID_and_PictureOnly");

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            #endregion
            // StockOperations
            #region
            public static DataTable GetStock(out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                // DataTable Declaration
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_GetStock", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            #endregion


            // DISTINCT ComboBox [Category,Type,Brand,Size,Color]
            #region
            public static DataTable GetCategoryDISTINCT()
            {
                // DataTable Declaration
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("SELECT  DISTINCT(CategoryName) FROM tblCategory", conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable GetProductTypeDISTINCT()
            {
                // DataTable Declaration
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("SELECT  DISTINCT(ProductType) FROM tblProduct", conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable GetProductBrandDISTINCT()
            {
                // DataTable Declaration
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("SELECT  DISTINCT(ProductBrand) FROM tblProduct", conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable GetProductSizeDISTINCT()
            {
                // DataTable Declaration
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("SELECT  DISTINCT(ProductSize) FROM tblProduct", conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable GetProductColorDISTINCT()
            {
                // DataTable Declaration
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("SELECT  DISTINCT(ProductColor) FROM tblProduct", conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }


            #endregion
            
            // All ComboBox [Supplier,Roles]
            #region
            public static DataTable GetSupplier()
            {
                // DataTable Declaration
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("SELECT  SupplierID,SupplierName FROM tblSupplier", conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable GetRoles()
            {
                // DataTable Declaration
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("SELECT  RoleID,RoleName FROM tblRoles", conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }


            #endregion

        }

        public class Expenses
        {
            public static void Expenses_DeleteMeansIsActive(int ExpensesID, out bool _Status, out string _StatusDetails)
            {
                _Status = false;
                _StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("Expenses_DeleteMeansIsActive", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ExpensesID", ExpensesID);

                    SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                    _StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusParm);

                    SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                    _StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    _Status = (bool)_StatusParm.Value;
                    _StatusDetails = (string)_StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    _Status = false;
                    _StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void Expenses_UpdateByID(int ExpensesID, int Amount, DateTime ActivityDate, string ExpensesTitle, string ExpensesType, string ExpensesDetails, out bool _Status, out string _StatusDetails)
            {
                _Status = false;
                _StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("Expenses_UpdateByID", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ExpensesID", ExpensesID);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@ActivityDate", ActivityDate);
                    cmd.Parameters.AddWithValue("@ExpensesTitle", ExpensesTitle);
                    cmd.Parameters.AddWithValue("@ExpensesType", ExpensesType);
                    cmd.Parameters.AddWithValue("@ExpensesDetails", ExpensesDetails);

                    SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                    _StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusParm);

                    SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                    _StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    _Status = (bool)_StatusParm.Value;
                    _StatusDetails = (string)_StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    _Status = false;
                    _StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static DataTable getAllFromExpenses(out bool _Status, out string _StatusDetails)
            {
                _Status = false;
                _StatusDetails = null;

                // DataTable Declaration
                DataTable dt = new DataTable();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("getAllFromExpenses", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                    _StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusParm);
                    SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                    _StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    _Status = (bool)_StatusParm.Value;
                    _StatusDetails = (string)_StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    _Status = false;
                    _StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static void InsertExpenses(int Amount,DateTime ActivityDate, int CreatedByUser_ID, string ExpensesTitle, string ExpensesType, string ExpensesDetails, out bool _Status, out string _StatusDetails)
            {
                _Status = false;
                _StatusDetails = null;

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("CRUDExpenses", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@ActivityDate", ActivityDate);
                    cmd.Parameters.AddWithValue("@CreatedByUser_ID", CreatedByUser_ID);
                    cmd.Parameters.AddWithValue("@ExpensesTitle", ExpensesTitle);
                    cmd.Parameters.AddWithValue("@ExpensesType", ExpensesType);
                    cmd.Parameters.AddWithValue("@ExpensesDetails", ExpensesDetails);

                    SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                    _StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusParm);

                    SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                    _StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(_StatusDetailsParm);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    _Status = (bool)_StatusParm.Value;
                    _StatusDetails = (string)_StatusDetailsParm.Value;
                }
                catch (Exception ex)
                {
                    _Status = false;
                    _StatusDetails = ex.Message;
                    return;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        public class Reporting
        {

            public static DataTable usp_SummaryInvoiceReport(DateTime FromDate, DateTime ToDate, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_SummaryInvoiceReport", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static DataTable usp_InvoiceReportSTEP1(out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;


                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InvoiceReportSTEP1", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            public static DataTable usp_InvoiceReportSTEP2(out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;

                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_InvoiceReportSTEP2", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    //cmd.Parameters.AddWithValue("@SalesOrder_ID", SalesOrder_ID);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

            public static DataTable usp_BarcodeReport(string Barcode, out bool Status, out string StatusDetails)
            {
                Status = false;
                StatusDetails = null;


                // DataTable Declaration
                DataTable dt = new DataTable();

                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
                    conn = new SqlConnection(ConnectionString);
                    cmd = new SqlCommand("usp_BarcodeReport", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@Barcode", Barcode);

                    SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                    StatusParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParm);

                    SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                    StatusDetailsParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusDetailsParm);

                    conn.Open();
                    Adapter.Fill(dt);
                    conn.Close();

                    Status = (bool)StatusParm.Value;
                    StatusDetails = (string)StatusDetailsParm.Value;

                    return dt;
                }
                catch (Exception ex)
                {
                    Status = false;
                    StatusDetails = ex.Message;

                    //Return Value
                    return dt;
                }
                finally
                {
                    conn.Dispose();
                    cmd.Dispose();
                }
            }

        }
    }
}
