using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Student_Management_System.Utilities.Lists;
using Porject_NAQASH_IMS2020.MngClass;
using AQDBFramwork.Messageboxes;
using PAF_BOS;
using System.Dynamic;
using System.Collections;
using System.Linq;

namespace Porject_NAQASH_IMS2020.AdminForms
{
    public partial class POSForm : DevComponents.DotNetBar.Office2007Form//DevComponents.DotNetBar.Metro.MetroForm
    {
        int _stockfiled = 0;

        ModelClass.ModelPOS.ModelCategory mc = new ModelClass.ModelPOS.ModelCategory();
        ModelClass.ModelPOS.ModelProduct mp = new ModelClass.ModelPOS.ModelProduct();
        ModelClass.ModelPOS.ModelSalesProduct msp = new ModelClass.ModelPOS.ModelSalesProduct();
        ModelClass.ModelPOS.ModelSalesPicture mpp = new ModelClass.ModelPOS.ModelSalesPicture();
        ModelClass.ModelPOS.ModelSalesOrder mo = new ModelClass.ModelPOS.ModelSalesOrder();
        public POSForm()
        {
            InitializeComponent();
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            displayComboBox();
        }
        private void displayComboBox()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable DTCategory = MainClass.POS.CategoryDisplayAll(out Status, out StatusDetails);
                DataTable DTType = MainClass.POS.ProductDisplayAll(out Status, out StatusDetails);
                DataTable DTBrand = MainClass.POS.ProductDisplayAll(out Status, out StatusDetails);
                DataTable DTSize = MainClass.POS.ProductDisplayAll(out Status, out StatusDetails);
                DataTable DTColor = MainClass.POS.ProductDisplayAll(out Status, out StatusDetails);
                if (Status)
                {
                  //** PRODUCT **//
                  #region
                   ListData.AutoSuggession_With_ComboBox(DTCategory, "CategoryID", cbProductCategory, "CategoryID", "CategoryName");
                   ListData.AutoSuggession_With_ComboBox(DTType, "ProductID", cbProductType, "ProductID", "ProductType");
                   ListData.AutoSuggession_With_ComboBox(DTBrand, "ProductID", cbProductBrand, "ProductID", "ProductBrand");
                   ListData.AutoSuggession_With_ComboBox(DTSize, "ProductID", cbProductSize, "ProductID", "ProductSize");
                   ListData.AutoSuggession_With_ComboBox(DTColor, "ProductID", cbProductColour, "ProductID", "ProductColor");
                    #endregion
                  
                  //** PICTURE **//
                  #region
                    //ListData.AutoSuggession_With_ComboBox(DTCategory, "CategoryID", cbPicCategory, "CategoryID", "CategoryName");
                   #endregion
                }
                else
                {
                    JIMessageBox.WarningMessage(StatusDetails);
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.Message);
            }
        }
        private void tbSearchBarcode_TextChanged(object sender, EventArgs e)
        {
          
        }
        private void tbSearchBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                bool Status = false;
                string StatusDetails = null;
                try
                {
                    DataTable dt = MainClass.POS.usp_GetByBarcode(tbSearchBarcode.Text.ToString(), out Status, out StatusDetails);
                    if (dt.Rows.Count >= 1)
                    { 
                       if (Status)
                       {
                         superTabControl1.SelectedTabIndex = 0;  //ProductTab

                         labelProduct_ID.Text = dt.Rows[0]["ProductID"].ToString();
                         cbProductCategory.Text = dt.Rows[0]["CategoryName"].ToString();
                         cbProductType.Text = dt.Rows[0]["ProductType"].ToString();
                         cbProductBrand.Text = dt.Rows[0]["ProductBrand"].ToString();
                         cbProductSize.Text = dt.Rows[0]["ProductSize"].ToString();
                         cbProductColour.Text = dt.Rows[0]["ProductColor"].ToString();
                         //tbProductUnitPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                         //tbProductAvailableQty.Text = dtt.Rows[0]["AvailableStockQty"].ToString();
                       
                         Status = false;
                         StatusDetails = null;
                         DataTable dtt = MainClass.POS.usp_GetStockByProductID(Convert.ToInt32(dt.Rows[0]["ProductID"].ToString()), out Status, out StatusDetails);
                         _stockfiled = Convert.ToInt32(dtt.Rows[0]["AvailableStockQty"].ToString());
                         udmStockFieldsManupoltion(_stockfiled);
                         
                         tbProductBarcode.Text = dt.Rows[0]["BarCode"].ToString();
                            string pImage = dt.Rows[0]["ProductPicture"].ToString();
                            if (pImage == "ImageClass.GetImageFromBase64(Row.Cells[ProductImage].Value.ToString())' threw an exception of type 'System.FormatException" || pImage == "" || pImage == "NoImage")
                            {
                                PictureBoxProduct.Visible = false;
                                labelAfterHiddenImage.Visible = true;
                                labelAfterHiddenImage.Text = "NoImage";
                            }
                            else
                            {
                                PictureBoxProduct.Visible = true;
                                labelAfterHiddenImage.Visible = false;
                                PictureBoxProduct.Image = ImageClass.GetImageFromBase64(dt.Rows[0]["ProductPicture"].ToString());
                            }
                        }
                       else
                       {
                           JIMessageBox.ErrorMessage(StatusDetails.ToString());
                       }
                    }
                    else
                    {
                        JIMessageBox.ErrorMessage(tbSearchBarcode.Text+" :  Incorrect Barcode Number");
                        udmResetFields();
                    }
                }
                catch (Exception ex)
                {
                    JIMessageBox.WarningMessage(ex.ToString());
                }
                e.Handled = true;

            }
        }
        private void tbProductUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
               if(tbProductUnitPrice.Text != "" && tbProductAvailableQty.Text != "")
               {
                 Double total = Convert.ToInt64(tbProductUnitPrice.Text) * Convert.ToInt64(tbProductQty.Text);
                 tbProductTotalPrice.Text = total.ToString();
               }
               else
               {
                 tbProductTotalPrice.Text = "0";
               }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Digits! : ");
                tbProductUnitPrice.Focus();
                return;
            }
        }
        private void tbProductQty_TextChanged(object sender, EventArgs e)
        {
           try
           {
               if (tbProductUnitPrice.Text != "" && tbProductQty.Text != "")
               {
                   Double total = Convert.ToInt64(tbProductUnitPrice.Text) * Convert.ToInt64(tbProductQty.Text);
                   tbProductTotalPrice.Text = total.ToString();
               }
               else
               {
                   tbProductTotalPrice.Text = "0";
               }
           }
           catch (Exception)
           {
               MessageBox.Show("Enter Digits!");
           }
        }
        private void tbGrandTotal_TextChanged(object sender, EventArgs e)
        {
            if (tbGrandTotal.Text != "" && tbAdvance.Text != "")
            {
                Double total = Convert.ToInt64(tbGrandTotal.Text) - Convert.ToInt64(tbAdvance.Text);
                tbBalance.Text = total.ToString();
            }
            else
            {
                tbBalance.Text = "0";
            }
        }
        private void tbProductQty_Leave(object sender, EventArgs e)
        {
            try
            {
                //tbProductAvailableQty
                if (tbProductAvailableQty.Text == null || tbProductAvailableQty.Text == "")
                {
                    JIMessageBox.ExclamationMessage("Available Stock Field is Empty !");
                    return;
                }
                {
                    try
                    {
                        if (Convert.ToInt32(tbProductQty.Text) > Convert.ToInt32(tbProductAvailableQty.Text))
                        {
                            JIMessageBox.AsteriskMessage("Available Stock is :  " + tbProductAvailableQty.Text + " !");
                            tbProductQty.Focus();
                        }
                    }
                    catch (Exception)
                    {
                        tbProductQty.Focus();
                        JIMessageBox.ErrorMessage("Please Enter Digit !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbAdvance.Focus();
            }


        }


        private void tbAdvance_TextChanged(object sender, EventArgs e)
        {
            try
            {
             if (tbGrandTotal.Text != "" && tbAdvance.Text != "")
             {
                 Double total = Convert.ToInt64(tbGrandTotal.Text) - Convert.ToInt64(tbAdvance.Text);
                 tbBalance.Text = total.ToString();
             }
             else
             {
                 tbBalance.Text = "0";
             }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Digits!");
                tbAdvance.Focus();
            }
        }
        private void tbBalance_TextChanged(object sender, EventArgs e)
        {
            if (tbGrandTotal.Text != "" && tbAdvance.Text != "")
            {
                Double total = Convert.ToInt64(tbGrandTotal.Text) - Convert.ToInt64(tbAdvance.Text);
                tbBalance.Text = total.ToString();
            }
            else
            {
                tbBalance.Text = "0";
            }
        }
        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
          try
          {
              if (superTabItem1.IsSelected) //Product
              {
                    if(labelProduct_ID.Text == "" || labelProduct_ID.Text == null)
                    { JIMessageBox.ExclamationMessage("Invalid Product !");return; }
                        udmPRODUCT_AddtoCart();
               }
              else
              if (superTabItem2.IsSelected) //Picture
              {
                    udmPicFieldValidation();
                    udmPICTURE_AddtoCart();
              }
          }
          catch (Exception ex)
          {
              JIMessageBox.ErrorMessage(ex.ToString());
          }
        }

        private void udmPicFieldValidation()
        {
            if (cbPicCategory.Text == "") { JIMessageBox.ExclamationMessage("Please Select " + cbPicCategory.Text + " !"); return; }
            if (cbPicType.Text == "") { JIMessageBox.ExclamationMessage("Please Select Type !"); return; }
            if (cbPicBrand.Text == "") { JIMessageBox.ExclamationMessage("Please Select Brand !"); return; }
            if (tbPicNumber.Text == "") { JIMessageBox.ExclamationMessage("Please Select Picture No !"); return; }
            if (tbPicUnitPrice.Text == "") { JIMessageBox.ExclamationMessage("Please Select UnitPrice !"); return; }
            if (tbPicQty.Text == "") { JIMessageBox.ExclamationMessage("Please Select Qty !"); return; }
            if (tbPicTotalPrice.Text == "") { JIMessageBox.ExclamationMessage("Please Select Total Price !"); return; }

        }

        private void gridViewPRODUCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.gridViewPRODUCT.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.

                labelProduct_ID.Text = row.Cells["Product_ID"].Value.ToString();
                cbProductCategory.Text = row.Cells["Cateogry"].Value.ToString();
                cbProductType.Text = row.Cells["Type"].Value.ToString();
                cbProductBrand.Text = row.Cells["Brand"].Value.ToString();
                cbProductSize.Text = row.Cells["Size"].Value.ToString();
                cbProductColour.Text = row.Cells["Colour"].Value.ToString();
                tbProductUnitPrice.Text = row.Cells["UnitPrice"].Value.ToString();
                tbProductQty.Text = row.Cells["Qty"].Value.ToString();
                tbProductTotalPrice.Text = row.Cells["ProductTotalPrice"].Value.ToString();
            }
        }
        private void buttonRemoveToCart_Click(object sender, EventArgs e)
        {
         try
           { 
              //Remove
              Int32 selectedRowCount = gridViewPRODUCT.Rows.GetRowCount(DataGridViewElementStates.Selected);
              Int32 selectedPictureRowCount = gridViewPICTURE.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0 || selectedPictureRowCount > 0)
                {
                    if (selectedRowCount > 0)
                    {
                        //Stock Plus_Minus
                        string QtyColumn = gridViewPRODUCT.Rows[gridViewPRODUCT.CurrentRow.Index].Cells["Qty"].Value.ToString();
                        tbProductAvailableQty.Text = Convert.ToString(Convert.ToInt32(tbProductAvailableQty.Text) + Convert.ToInt32(QtyColumn));

                        //Remove
                        for (int i = 0; i < selectedRowCount; i++)
                        {
                            gridViewPRODUCT.Rows.RemoveAt(gridViewPRODUCT.SelectedRows[0].Index);
                        }

                        int sum = 0;
                        for (int i = 0; i < gridViewPRODUCT.Rows.Count; i++)
                        {
                            sum += gridViewPRODUCT.Rows[i].Cells[8].Value == DBNull.Value ? 0 : Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells[8].Value);
                        }
                        for (int i = 0; i < gridViewPICTURE.Rows.Count; i++)
                        {
                            sum += gridViewPICTURE.Rows[i].Cells[8].Value == DBNull.Value ? 0 : Convert.ToInt32(gridViewPICTURE.Rows[i].Cells[8].Value);
                        }
                        tbGrandTotal.Text = sum.ToString();
                    }

                    //PICURE_AREA  
                    if (selectedPictureRowCount > 0)
                    {
                        for (int i = 0; i < selectedPictureRowCount; i++)
                        {
                            gridViewPICTURE.Rows.RemoveAt(gridViewPICTURE.SelectedRows[0].Index);
                        }

                        //Remove
                        int sum = 0;
                        for (int i = 0; i < gridViewPRODUCT.Rows.Count; i++)
                        {
                            sum += gridViewPRODUCT.Rows[i].Cells[8].Value == DBNull.Value ? 0 : Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells[8].Value);
                        }
                        for (int i = 0; i < gridViewPICTURE.Rows.Count; i++)
                        {
                            sum += gridViewPICTURE.Rows[i].Cells[8].Value == DBNull.Value ? 0 : Convert.ToInt32(gridViewPICTURE.Rows[i].Cells[8].Value);
                        }

                        tbGrandTotal.Text = sum.ToString();
                    }
                }
                else { JIMessageBox.ExclamationMessage("Please Select Row From Cart !"); }

            }
            catch (Exception ex)
          {
              JIMessageBox.ErrorMessage(ex.ToString());
          }
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            udmResetFields();
        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(tbInvoice.Text == "" || tbCustomerName.Text == "" )
                { JIMessageBox.ExclamationMessage("Please Fill Invoice No & Customer Name !");return; }
                bool Status = false;
                string StatusDetails = null;
                int SalesOrderID = 0;
                if (gridViewPRODUCT.Rows.Count > 0 && gridViewPICTURE.Rows.Count > 0) //Both
                {
                    udm_PictureANDProductAddToDatabaseBOTH(Status, StatusDetails, SalesOrderID);
                }
                else if (gridViewPRODUCT.Rows.Count >= 1 && gridViewPICTURE.Rows.Count <= 0) //Product
                {
                    udm_OnlyProductAddToDatabase(Status, StatusDetails, SalesOrderID);
                }
                else
                  if (gridViewPICTURE.Rows.Count >= 1 && gridViewPRODUCT.Rows.Count <= 0) //Picture
                {
                    udm_OnlyPicureAddToDatabase(Status, StatusDetails, SalesOrderID);
                }
                else { JIMessageBox.ExclamationMessage("Cart is Empty !"); }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.ToString());
            }
        }

        private void udm_OnlyPicureAddToDatabaseBOTH(bool status, string statusDetails, int salesOrderID)
        {
           bool Status = false;
           string StatusDetails = null;
           int SalesOrderID = 0;


                if (Status)
                {
                    
                }//usp_InsertSalesOrder
                else
                {
                    JIMessageBox.InformationMessage("ERROR Fom Database:  " + StatusDetails);
                    return;
                }
        }

        private void udm_PictureANDProductAddToDatabaseBOTH(bool status, string statusDetails, int salesOrderID)
        {
            bool Status = false;
            string StatusDetails = null;
            int SalesOrderID = 0;
            #region Model
            DateTime CurrentDate = DateTime.Parse(string.Format("{0}", dtCurrentDate.Value.ToString("dd-MMM-yyy")));
            DateTime DueDate = DateTime.Parse(string.Format("{0}", dtDueDate.Value.ToString("dd-MMM-yyy")));

            mc.CategoryName = tbCustomerName.Text;
            mc.CategoryContact = tbContact.Text;
            mc.CategoryDetails = tbDetails.Text;

            mo.SalesOrderCurrentDate = CurrentDate;
            mo.SalesOrderDueDate = DueDate;
            mo.GrandTotal = decimal.Parse(tbGrandTotal.Text);
            mo.Advance = decimal.Parse(tbAdvance.Text);
            mo.Balance = decimal.Parse(tbBalance.Text);
            mo.SalesOrderInvoiceNo = tbInvoice.Text;
            #endregion

          //  MainClass.POS.usp_CheckInvoiceNoIfExists(Convert.ToInt32(mo.SalesOrderInvoiceNo), out Status, out StatusDetails);
            if (true)
            {
                //InsertCustomer - Insert SaleOrder
                MainClass.POS.usp_InsertSalesOrder(mo.SalesOrderCurrentDate, mo.SalesOrderDueDate, mo.SalesOrderInvoiceNo,
                                                       mo.GrandTotal, mo.Advance, mo.Balance, ModelClass._UserID,
                                                       mc.CategoryName, mc.CategoryContact, mc.CategoryDetails,
                                                       ModelClass._UserID,
                                                       out Status, out StatusDetails, out SalesOrderID);
                if (Status)
                {
                    for (int i = 0; i < gridViewPRODUCT.Rows.Count; i++)
                    {
                        //ProductOrder
                        MainClass.POS.usp_InsertProductOrder(SalesOrderID,
                          Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["Product_ID"].Value),
                          Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["UnitPrice"].Value),
                          Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["ProductTotalPrice"].Value), ModelClass._UserID,
                          Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["Qty"].Value.ToString()),
                          Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["Qty"].Value.ToString()), out Status, out StatusDetails);
                    }

                    for (int i = 0; i < gridViewPICTURE.Rows.Count; i++)
                    {
                        //PictureOrder
                        MainClass.POS.usp_InsertPictureOrder(
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicNumber"].Value.ToString()),
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicImage"].Value.ToString()),
                          Convert.ToInt32(gridViewPICTURE.Rows[i].Cells["dtPicUnitPrice"].Value.ToString()),
                          Convert.ToInt32(gridViewPICTURE.Rows[i].Cells["dtPicTotalPrice"].Value.ToString()),
                          ModelClass._UserID, SalesOrderID,
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicRadioValue"].Value.ToString()),
                          Convert.ToInt32(gridViewPICTURE.Rows[i].Cells["dtPicQty"].Value.ToString()),
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicCategory"].Value.ToString()),
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicType"].Value.ToString()),
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicBrand"].Value.ToString()),
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicSize"].Value.ToString()),
                          out Status, out StatusDetails);
                    }
                    if (Status)
                    {
                        udmClearFields(); // ClearAllFields
                        udmClearPictureFields(); // ClearAllFields
                        gridViewPRODUCT.Rows.Clear();
                        gridViewPICTURE.Rows.Clear();
                        JIMessageBox.InformationMessage("Record Saved Sccessfully!");
                    }
                    else
                    {
                        JIMessageBox.InformationMessage("ERROR:  " + StatusDetails);
                        return;
                    }
                }//usp_InsertSalesOrder
                else
                {
                    JIMessageBox.InformationMessage("ERROR Fom Database:  " + StatusDetails);
                    return;
                }
            }//IfInvoiceExists
            else
            {
                JIMessageBox.InformationMessage(mo.SalesOrderInvoiceNo + ": Invoice Number is Already Existis");
                return;
            }

        }


        //___________USER_DEFINED_METHODS___________//



        #region PRODUCT_METHODS
        private void udmStockFieldsManupoltion(int _paramstockfiled)
        {
            try
            {
                if (gridViewPRODUCT.Rows.Count >= 1)
                {
                    //--Method_1
                    //  var SumValue = gridViewPRODUCT.Rows.Cast<DataGridViewRow>()
                    // .Where(r => r.Cells["Product_ID"].Value.ToString() == labelProduct_ID.Text)
                    // .Select(r => r.Cells["Qty"].Value);
                    int i;
                    for (i = 0; i < gridViewPRODUCT.Rows.Count; i++)
                    {
                        if (labelProduct_ID.Text != Convert.ToString(gridViewPRODUCT.Rows[i].Cells["Product_ID"].Value.ToString()))
                        {
                            tbProductAvailableQty.Text = Convert.ToString(_stockfiled);
                        }
                        else if (labelProduct_ID.Text == Convert.ToString(gridViewPRODUCT.Rows[i].Cells["Product_ID"].Value.ToString()))
                        {
                            _paramstockfiled = Convert.ToInt32(_paramstockfiled - Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["Qty"].Value.ToString()));
                            tbProductAvailableQty.Text = Convert.ToString(_paramstockfiled);
                        }
                    }
                }
                else if (gridViewPRODUCT.Rows.Count <= 0)
                {
                    tbProductAvailableQty.Text = _paramstockfiled.ToString();
                }
            }
            catch (Exception)
            {
            }
        }
             public DataTable TableHeadingName()
             {
                 DataTable HeadingName = new DataTable();
             
                 HeadingName.Columns.Add(new DataColumn("Product_ID", typeof(string)));
                 HeadingName.Columns.Add(new DataColumn("CategoryName", typeof(string)));
                 HeadingName.Columns.Add(new DataColumn("ProductType", typeof(string)));
                 HeadingName.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
                 HeadingName.Columns.Add(new DataColumn("ProductSize", typeof(string)));
                 HeadingName.Columns.Add(new DataColumn("ProductColor", typeof(string)));
                 HeadingName.Columns.Add(new DataColumn("SalesProductUnitPrice", typeof(int)));
                 HeadingName.Columns.Add(new DataColumn("SalesProductQty", typeof(int)));
                 HeadingName.Columns.Add(new DataColumn("SalesProductTotal", typeof(int)));
                 //saletable.Columns.Add(new DataColumn("saleprice", typeof(decimal)));
                 return HeadingName;
             }
        public DataTable TableHeadingNamePicture()
        {


            DataTable HeadingName = new DataTable();

            HeadingName.Columns.Add(new DataColumn("dtPicRadioValue", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("dtPicCategory", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("dtPicType", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("dtPicBrand", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("dtPicSize", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("dtPicNumber", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("dtPicUnitPrice", typeof(int)));
            HeadingName.Columns.Add(new DataColumn("dtPicQty", typeof(int)));
            HeadingName.Columns.Add(new DataColumn("dtPicTotalPrice", typeof(int)));
            HeadingName.Columns.Add(new DataColumn("dtPicImage", typeof(string)));
            //saletable.Columns.Add(new DataColumn("saleprice", typeof(decimal)));
            return HeadingName;
        }

        private void udmPRODUCT_AddtoCart()
             {
                DataTable dt = TableHeadingName();
              
                DataRow row = dt.NewRow(); //NewRow
                //Header_Names 
                row["Product_ID"] = Convert.ToString(labelProduct_ID.Text);
                row["CategoryName"] = Convert.ToString(cbProductCategory.Text);
                row["ProductType"] = Convert.ToString(cbProductType.Text);
                row["ProductBrand"] = Convert.ToString(cbProductBrand.Text);
                row["ProductSize"] = Convert.ToString(cbProductSize.Text);
                row["ProductColor"] = Convert.ToString(cbProductColour.Text);
                row["SalesProductUnitPrice"] = Convert.ToInt32(tbProductUnitPrice.Text);
                row["SalesProductQty"] = Convert.ToInt32(tbProductQty.Text);
                row["SalesProductTotal"] = Convert.ToInt32(tbProductTotalPrice.Text);

                //RealTime_From_Database
                // bool Status = false; string StatusDetails = null;
                // DataTable dtCheckStockQty = MainClass.POS.usp_GetByBarcode(tbSearchBarcode.Text.ToString(), out Status, out StatusDetails);

                dt.Rows.Add(row); //NewRow_AddInDataTable
          
                foreach (DataRow r in dt.Rows)
                { //Array ValueParams
                    gridViewPRODUCT.Rows.Add(r["Product_ID"].ToString(),
                    r["CategoryName"].ToString(), r["ProductType"].ToString(), r["ProductBrand"].ToString(),
                    r["ProductSize"].ToString(), r["ProductColor"].ToString(), r["SalesProductUnitPrice"].ToString(),
                    r["SalesProductQty"].ToString(), r["SalesProductTotal"].ToString());
                }
                dt.AcceptChanges();

                //Stock Plus_Minus
                int labelPID = Convert.ToInt32(labelProduct_ID.Text);
                if (gridViewPRODUCT.Rows.Count >= 1)
                {

                    //--Method_1
                    var SumValue = gridViewPRODUCT.Rows.Cast<DataGridViewRow>()
                       .Where(r => r.Cells["Product_ID"].Value.ToString() == labelPID.ToString())
                       .Select(r => r.Cells["Qty"].Value);

                    tbProductAvailableQty.Text = Convert.ToString(Convert.ToInt32(tbProductAvailableQty.Text) - Convert.ToInt32(SumValue.LastOrDefault()));
                    if (Convert.ToInt32(tbProductQty.Text) <= 0 || tbProductQty.Text == null)
                    {
                        //Stock Plus_Minus
                        gridViewPRODUCT.Rows.RemoveAt(gridViewPRODUCT.Rows[gridViewPRODUCT.RowCount - 1].Index);
                        JIMessageBox.ErrorMessage("Please Select Qty !");
                        tbProductQty.Focus();
                        return;
                    }
                    else
                    {
                        tbProductQty.Text = "0";
                    }
                }

                //__GrandTotal__
                udmGrandTotal();
        }
        private void udm_OnlyPicureAddToDatabase(bool Status, string StatusDetails, int SalesOrderID)
        {

            #region Model
            DateTime CurrentDate = DateTime.Parse(string.Format("{0}", dtCurrentDate.Value.ToString("dd-MMM-yyy")));
            DateTime DueDate = DateTime.Parse(string.Format("{0}", dtDueDate.Value.ToString("dd-MMM-yyy")));

            mc.CategoryName = tbCustomerName.Text;
            mc.CategoryContact = tbContact.Text;
            mc.CategoryDetails = tbDetails.Text;

            mo.SalesOrderCurrentDate = CurrentDate;
            mo.SalesOrderDueDate = DueDate;
            mo.GrandTotal = decimal.Parse(tbGrandTotal.Text);
            mo.Advance = decimal.Parse(tbAdvance.Text);
            mo.Balance = decimal.Parse(tbBalance.Text);
            mo.SalesOrderInvoiceNo = tbInvoice.Text;
            #endregion

            MainClass.POS.usp_CheckInvoiceNoIfExists(Convert.ToInt32(mo.SalesOrderInvoiceNo), out Status, out StatusDetails);
            if (Status)
            {
                //InsertCustomer - Insert SaleOrder
                MainClass.POS.usp_InsertSalesOrder(mo.SalesOrderCurrentDate, mo.SalesOrderDueDate, mo.SalesOrderInvoiceNo,
                                                       mo.GrandTotal, mo.Advance, mo.Balance, ModelClass._UserID,
                                                       mc.CategoryName, mc.CategoryContact, mc.CategoryDetails,
                                                       ModelClass._UserID,
                                                       out Status, out StatusDetails, out SalesOrderID);

                if (Status)
                {
                    for (int i = 0; i < gridViewPRODUCT.Rows.Count; i++)
                    {
                        //ProductOrder
                        MainClass.POS.usp_InsertPictureOrder(
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicNumber"].Value.ToString()),
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicImage"].Value.ToString()),
                          Convert.ToInt32(gridViewPICTURE.Rows[i].Cells["dtPicUnitPrice"].Value.ToString()),
                          Convert.ToInt32(gridViewPICTURE.Rows[i].Cells["dtPicTotalPrice"].Value.ToString()),
                          ModelClass._UserID, SalesOrderID,
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicRadioValue"].Value.ToString()),
                          Convert.ToInt32(gridViewPICTURE.Rows[i].Cells["dtPicQty"].Value.ToString()),
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicCategory"].Value.ToString()),
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicType"].Value.ToString()),
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicBrand"].Value.ToString()),
                          Convert.ToString(gridViewPICTURE.Rows[i].Cells["dtPicSize"].Value.ToString()),
                          out Status, out StatusDetails);
                    }
                    if (Status)
                    {
                        JIMessageBox.InformationMessage("Record Saved Sccessfully!");
                        udmClearPictureFields(); // ClearAllFields
                        gridViewPICTURE.Rows.Clear();
                    }//ForLoop
                    else
                    {
                        JIMessageBox.InformationMessage("ERROR:  " + StatusDetails);
                        return;
                    }
                }//usp_InsertSalesOrder
                else
                {
                    JIMessageBox.InformationMessage("ERROR Fom Database:  " + StatusDetails);
                    return;
                }
            }//IfInvoiceExists
            else
            {
                JIMessageBox.InformationMessage(mo.SalesOrderInvoiceNo + ": Invoice Number is Already Existis");
                return;
            }
        }

        
        private void udm_OnlyProductAddToDatabase(bool Status, string StatusDetails, int SalesOrderID)
            {
            
              #region Model
                 DateTime CurrentDate = DateTime.Parse(string.Format("{0}", dtCurrentDate.Value.ToString("dd-MMM-yyy")));
                 DateTime DueDate = DateTime.Parse(string.Format("{0}", dtDueDate.Value.ToString("dd-MMM-yyy")));

                 mc.CategoryName = tbCustomerName.Text;
                 mc.CategoryContact = tbContact.Text;
                 mc.CategoryDetails = tbDetails.Text;

                 mo.SalesOrderCurrentDate = CurrentDate;
                 mo.SalesOrderDueDate = DueDate;
                 mo.GrandTotal = decimal.Parse(tbGrandTotal.Text);
                 mo.Advance = decimal.Parse(tbAdvance.Text);
                 mo.Balance = decimal.Parse(tbBalance.Text);
                 mo.SalesOrderInvoiceNo = tbInvoice.Text;
                 #endregion
             
              MainClass.POS.usp_CheckInvoiceNoIfExists(Convert.ToInt32(mo.SalesOrderInvoiceNo), out Status, out StatusDetails);
              if (Status)
              {
                  //InsertCustomer - Insert SaleOrder
                  MainClass.POS.usp_InsertSalesOrder(mo.SalesOrderCurrentDate, mo.SalesOrderDueDate, mo.SalesOrderInvoiceNo,
                                                         mo.GrandTotal, mo.Advance, mo.Balance, ModelClass._UserID,
                                                         mc.CategoryName, mc.CategoryContact, mc.CategoryDetails,
                                                         ModelClass._UserID,
                                                         out Status, out StatusDetails, out SalesOrderID);
                  if (Status)
                  {
                    for (int i = 0; i < gridViewPRODUCT.Rows.Count; i++)
                    {
                      //ProductOrder
                      MainClass.POS.usp_InsertProductOrder(SalesOrderID,
                        Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["Product_ID"].Value),
                        Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["UnitPrice"].Value),
                        Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["ProductTotalPrice"].Value), ModelClass._UserID,
                        Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["Qty"].Value.ToString()),
                        Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells["Qty"].Value.ToString()), out Status, out StatusDetails);
                    }
                    if (Status)
                    {
                        JIMessageBox.InformationMessage("Record Saved Sccessfully!");
                        udmClearFields(); // ClearAllFields
                        gridViewPRODUCT.Rows.Clear();
                    }//ForLoop
                    else
                    {
                        JIMessageBox.InformationMessage("ERROR:  " + StatusDetails);
                        return;
                    }
                  }//usp_InsertSalesOrder
                  else
                  {
                      JIMessageBox.InformationMessage("ERROR Fom Database:  " + StatusDetails);
                      return;
                  }
              }//IfInvoiceExists
              else
              {
                  JIMessageBox.InformationMessage(mo.SalesOrderInvoiceNo + ": Invoice Number is Already Existis");
                  return;
              }
            }
             private void tbProductAvailableQty_Leave(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                bool Condition = MainClass.POS.usp_CheckAvalibleStock(Convert.ToInt32(tbProductQty.Text), Convert.ToInt32(labelProduct_ID.Text), out Status, out StatusDetails);
                if (Condition)
                {
                    JIMessageBox.InformationMessage(StatusDetails);
                    tbProductQty.Focus();
                }
                if (Convert.ToInt32(tbProductQty.Text) <= -1)
                {
                    JIMessageBox.WarningMessage("Please Select Correct Value! ");
                    tbProductQty.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter Digits! : "+ ex.Message);
            }
        }
             private void tbProductAvailableQty_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbProductAvailableQty.Text) == 0)
            {
                tbProductAvailableQty.Text = "0";
            }
            if (Convert.ToInt32(tbProductAvailableQty.Text) < -1)
            {
                tbProductAvailableQty.Text = "0";
                JIMessageBox.WarningMessage("More Stock Not Available");
                return;
            }
        }
        #endregion
        
        #region PICTURE_METHODS
        private void udmPICTURE_AddtoCart()
        {
            DataTable dt = TableHeadingNamePicture(); //Table
            DataRow row = dt.NewRow(); //NewRow
                                       //Header_Names
            string  RadioValue = null;
            if (radiobtnStudio.Checked){RadioValue = radiobtnStudio.Text;}
            if (radiobtnMedia.Checked) {RadioValue = radiobtnMedia.Text; }
            if (RadioValue == null) { JIMessageBox.ExclamationMessage("Please Select Studio/Media !"); return; }

            row["dtPicRadioValue"] = Convert.ToString(RadioValue);
            row["dtPicCategory"] = Convert.ToString(cbPicCategory.Text);
            row["dtPicType"] = Convert.ToString(cbPicType.Text);
            row["dtPicBrand"] = Convert.ToString(cbPicBrand.Text);
            if (cbPicSize.Text != null) { row["dtPicSize"] = Convert.ToString(cbPicSize.Text); }
            else if (cbPicSize.Text == null && tbPicSize.Text != null) { row["dtPicSize"] = Convert.ToString(tbPicSize.Text); }
            else if (cbPicSize.Text != null && tbPicSize.Text != null) { JIMessageBox.InformationMessage("Both Sizes Are Selected !"); return; }
            else { JIMessageBox.InformationMessage("Please Select Size !"); return; }      
            row["dtPicNumber"] = Convert.ToInt32(tbPicNumber.Text);
            row["dtPicUnitPrice"] = Convert.ToInt32(tbPicUnitPrice.Text);
            row["dtPicQty"] = Convert.ToInt32(tbPicQty.Text);
            row["dtPicTotalPrice"] = Convert.ToInt32(tbPicTotalPrice.Text);
            if (PicImage.Image == null) { row["dtPicImage"] = "ImageNotSelected"; }
            else { row["dtPicImage"] = ImageClass.GetBase64StringFromImage(Imager.Resize(PicImage.Image, 200, 200, true)); } //Resize & Convert to String

            dt.Rows.Add(row); //NewRow_AddInDataTable
            foreach (DataRow r in dt.Rows)
            { //Array ValueParams
                gridViewPICTURE.Rows.Add(r["dtPicRadioValue"].ToString(), r["dtPicNumber"].ToString(),
                r["dtPicCategory"].ToString(), r["dtPicType"].ToString(), r["dtPicBrand"].ToString(),
                r["dtPicSize"].ToString(), r["dtPicUnitPrice"].ToString(),
                r["dtPicQty"].ToString(), r["dtPicTotalPrice"].ToString(),r["dtPicImage"].ToString()
                );
            }
            dt.AcceptChanges();

            //__GrandTotal__
            udmGrandTotal();
        }
        #endregion

        private void udmGrandTotal()
        {
            int sum = 0;
           // if (superTabItem1.IsSelected)
           // {
                for (int i = 0; i < gridViewPRODUCT.Rows.Count; i++)
                {
                    sum += gridViewPRODUCT.Rows[i].Cells[8].Value == DBNull.Value ? 0 : Convert.ToInt32(gridViewPRODUCT.Rows[i].Cells[8].Value);
                }
                for (int i = 0; i < gridViewPICTURE.Rows.Count; i++)
                {
                    sum += gridViewPICTURE.Rows[i].Cells[8].Value == DBNull.Value ? 0 : Convert.ToInt32(gridViewPICTURE.Rows[i].Cells[8].Value);
                }

            tbGrandTotal.Text = sum.ToString();
           // }
           // if (superTabItem2.IsSelected)
           // {
           //    
           //     for (int i = 0; i < gridViewPICTURE.Rows.Count; i++)
           //     {
           //         sum += Convert.ToInt32(gridViewPICTURE.Rows[i].Cells[8].Value);
           //     }
           //     tbGrandTotal.Text = sum.ToString();
           // }
            
        }
        private void udmResetFields()
        {
            labelProduct_ID.Text = null;
            cbProductCategory.SelectedIndex = 0;
            cbProductType.SelectedIndex = 0;
            cbProductBrand.SelectedIndex = 0;
            cbProductSize.SelectedIndex = 0;
            cbProductColour.SelectedIndex = 0;
            tbProductUnitPrice.Text = "0";
            tbProductQty.Text = "0";
            tbProductTotalPrice.Text = "0";
            tbProductAvailableQty.Text = "0";
            //cbProductCategory.SelectedItem = null;
            //cbProductCategory.SelectedText = "--select--";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            udmClearFields();
        }
        private void udmClearFields()
        {
            udmResetFields();
            tbCustomerName.Text = null;
            tbInvoice.Text = null;
            tbSearchBarcode.Text = null;
            tbContact.Text = null;
            dtCurrentDate.Text = null;
            dtDueDate.Text = null;
            tbDetails.Text = null;
            tbGrandTotal.Text = "0";
            tbAdvance.Text = "0";
            tbBalance.Text = "0";
            PictureBoxProduct.Image = null;
        }
        private void udmClearPictureFields()
        {

            tbPicNumber.Text = null;
            tbPicQty.Text = null;
            tbPicSize.Text = null;
            tbPicUnitPrice.Text = null;
            tbPicTotalPrice.Text = null;
            tbInvoice.Text = null;
            PicImage.Image = null;
            tbAdvance.Text = null;
            tbBalance.Text = null;
            tbGrandTotal.Text = null;
        }

        private void tbInvoice_Leave(object sender, EventArgs e)
        {
           DataTable dt =  MainClass.POS.usp_CheckInvoiceNoIfExists();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (tbInvoice.Text == dt.Rows[i][0].ToString())
                {
                    JIMessageBox.ErrorMessage("Invoice Number is Already Exists !");
                    tbInvoice.Focus();
                }
            }
        }

        private void btnSlectImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialogSelectPicture = new OpenFileDialog();
                openFileDialogSelectPicture.FileName = "";
                openFileDialogSelectPicture.Filter = "Image Files(*.JPG;*.PNG;*.BMP)|*.JPG;*.PNG;*.BMP";
                openFileDialogSelectPicture.FilterIndex = 2;
                openFileDialogSelectPicture.RestoreDirectory = true;

                if (openFileDialogSelectPicture.ShowDialog() == DialogResult.OK)
                {
                    PicImage.ImageLocation = openFileDialogSelectPicture.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbPicUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbPicUnitPrice.Text != "" && tbPicQty.Text != "")
                {
                    Double total = Convert.ToInt64(tbPicUnitPrice.Text) * Convert.ToInt64(tbPicQty.Text);
                    tbPicTotalPrice.Text = total.ToString();
                }
                else
                {
                    tbPicTotalPrice.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Digits! : ");
                tbPicTotalPrice.Focus();
                return;
            }
        }

        private void tbPicQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbPicUnitPrice.Text != "" && tbPicQty.Text != "")
                {
                    Double total = Convert.ToInt64(tbPicUnitPrice.Text) * Convert.ToInt64(tbPicQty.Text);
                    tbPicTotalPrice.Text = total.ToString();
                }
                else
                {
                    tbPicTotalPrice.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Digits!");
            }
        }
    }
}
    
