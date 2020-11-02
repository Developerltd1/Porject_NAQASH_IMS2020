using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Porject_NAQASH_IMS2020.MngClass;
using Student_Management_System.Utilities.Lists;
using AQDBFramwork.Messageboxes;
using PAF_BOS;
using System.Linq;

namespace Porject_NAQASH_IMS2020.AdminForms
{
    public partial class PurchaseForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        ModelClass.ModelPOS.ModelProduct mp = new ModelClass.ModelPOS.ModelProduct();
        public PurchaseForm()
        {
            InitializeComponent();
        }
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            displayComboBox();
            displayPurchase();
        }

        private void displayPurchase()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable DT = MainClass.POS.usp_GetPurchase(out Status, out StatusDetails);
                if (Status)
                {
                   
                    foreach (DataRow row in DT.Rows)
                    {
                        gridViewPurchase.Rows.Add(
                        row["PurchaseID"].ToString(), row["ProductID"].ToString(),
                        row["Barcode"].ToString(), row["CategoryName"].ToString(),
                        row["ProductType"].ToString(), row["ProductBrand"].ToString(),
                        row["ProductSize"].ToString(), row["ProductColor"].ToString(),
                        row["SupplierName"].ToString(),
                        row["UnitPrice"].ToString(), row["ActualPrice"].ToString(),
                        row["PurchaseQty"].ToString(), row["SoldQty"].ToString(),
                        row["PurchaseTotal"].ToString(), row["PurchaseDate"].ToString(),
                        row["ProductPicture"].ToString()
                        );

                       // gridViewPurchase.Rows[13].DefaultCellStyle.Format = "dddd, dd MMMM yyyy";

                    }
                }
                else
                {
                    MessageBox.Show(StatusDetails, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void displayComboBox()
        {
            try
            {
                
                DataTable DTCategory = MainClass.POS.GetCategoryDISTINCT();
                if (DTCategory.Rows.Count > 0)
                    ListData.AutoSuggession_With_ComboBox(DTCategory, "CategoryName", cbCategory, "CategoryName", "CategoryName");

                DataTable DTType = MainClass.POS.GetProductTypeDISTINCT();
                if (DTType.Rows.Count > 0)
                    ListData.AutoSuggession_With_ComboBox(DTType, "ProductType", cbType, "ProductType", "ProductType");

                DataTable DTBrand = MainClass.POS.GetProductBrandDISTINCT();
                if (DTBrand.Rows.Count > 0)
                    ListData.AutoSuggession_With_ComboBox(DTBrand, "ProductBrand", cbBrand, "ProductBrand", "ProductBrand");

                DataTable DTSize = MainClass.POS.GetProductSizeDISTINCT();
                if (DTSize.Rows.Count > 0)
                    ListData.AutoSuggession_With_ComboBox(DTSize, "ProductSize", cbSize, "ProductSize", "ProductSize");

                DataTable DTColor = MainClass.POS.GetProductColorDISTINCT();
                if (DTColor.Rows.Count > 0)
                    ListData.AutoSuggession_With_ComboBox(DTColor, "ProductColor", cbColor, "ProductColor", "ProductColor");

                DataTable DTSupplier = MainClass.POS.GetSupplier();
                if (DTColor.Rows.Count > 0)
                    ListData.AutoSuggession_With_ComboBox(DTSupplier, "SupplierID", cbSupplier, "SupplierID", "SupplierName");
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnCadetRegister_Click(object sender, EventArgs e)
        {
            if (textBoxBarcode.Text == "" || textBoxBarcode.Text == null) 
            {
                JIMessageBox.ExclamationMessage("Enter Barcode First!");
                return;
            }
            if (textBoxPurchaseUnitPrice.Text == "" || textBoxQty.Text == "" || cbSupplier.Text == "")
            {
                JIMessageBox.ExclamationMessage("Please Fill All Fields !");
                return;
            }

            createPurchase();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            udmSearchFromBarcode();
        }



        private void buttonReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void createPurchase()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                ModelClass.ModelPOS.ModelPurchaseNStock md = new ModelClass.ModelPOS.ModelPurchaseNStock();
                md.Product_ID = mp.ProductID; //From_GridView_Row
                md.ActualPrice = int.Parse(textBoxActualPrice.Text.ToString());
                md.PurchaseUnitPrice = int.Parse(textBoxPurchaseUnitPrice.Text.ToString());
                md.PurchaseQty = int.Parse(textBoxQty.Text.ToString());
                md.PurchaseTotalPrice = int.Parse(textBoxPurchaseTotalPrice.Text.ToString());
                //Category_ID = int.Parse(comboBocCategory.SelectedValue.ToString()),
                md.Supplier_ID = Convert.ToInt32(cbSupplier.SelectedValue.ToString());
                md.CreatedByUser_ID = ModelClass._UserID;
                md.BarCode = textBoxBarcode.Text;
                md.PurchaseDate = DateTime.Parse(dtPurchase.Value.ToString());//string.Format("{0}", dtPurchase.Value.ToString("dddd, dd MMMM yyyy")));
                MainClass.POS.PurchaseCreate(md, out Status, out StatusDetails);
                if (Status)
                {
                    JIMessageBox.InformationMessage(StatusDetails);
                    Clear();
                    gridViewPurchase.Rows.Clear();
                    displayPurchase();
                }
                else
                {
                    MessageBox.Show(StatusDetails, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updatePurchase()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                ModelClass.ModelPOS.ModelPurchaseNStock md = new ModelClass.ModelPOS.ModelPurchaseNStock();
                
                MainClass.POS.usp_UpdatePurchaseWithStock(Convert.ToInt32(textBoxQty.Text),Convert.ToInt32(textBoxActualPrice.Text), Convert.ToInt32(textBoxPurchaseUnitPrice.Text),
                    Convert.ToInt32(textBoxPurchaseTotalPrice.Text),textBoxBarcode.Text,dtPurchase.Value,Convert.ToInt32(cbSupplier.SelectedValue.ToString()), Convert.ToInt32(labelPurchaseID.Text), out Status, out StatusDetails);
                if (Status)
                {
                    JIMessageBox.InformationMessage(StatusDetails);
                    Clear();
                    gridViewPurchase.Rows.Clear();
                    displayPurchase();
                }
                else
                {
                    MessageBox.Show(StatusDetails, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clear()
        {
            labelinStock.Text = "";
            labelPurchaseID.Text = "";
            cbCategory.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
            cbBrand.SelectedIndex = 0;
            cbBrand.SelectedIndex = 0;
            cbSize.SelectedIndex = 0;
            cbColor.SelectedIndex = 0;
            textBoxActualPrice.Text = null;
            textBoxBarcode.Text = null;
            textBoxPurchaseTotalPrice.Text = null;
            textBoxPurchaseUnitPrice.Text = null;
            textBoxQty.Text = null;
            pictureBoxPurchase.Image = null;
            pictureBoxPurchase.Visible = true;
            labelAfterHiddenImage.Visible = false;
        }


        private void textBoxSearchBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                labelPurchaseID.Text = "";
                udmSearchFromBarcode();
                e.Handled = true;     
            }
        }
        private void udmSearchFromBarcode()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                mp.BarCode = textBoxSearchBarcode.Text.ToString();

                DataTable dt = MainClass.POS.usp_GetProduct_withoutImage(mp, out Status, out StatusDetails);
                if (Status && dt.Rows.Count >0)
                {
                    mp.ProductID = int.Parse(dt.Rows[0]["ProductID"].ToString());
                    cbCategory.Text = dt.Rows[0]["CategoryName"].ToString();
                    cbType.Text = dt.Rows[0]["ProductType"].ToString();
                    cbBrand.Text = dt.Rows[0]["ProductBrand"].ToString();
                    cbSize.Text = dt.Rows[0]["ProductSize"].ToString();
                    cbColor.Text = dt.Rows[0]["ProductColor"].ToString();
                    textBoxBarcode.Text = dt.Rows[0]["BarCode"].ToString();
                    textBoxActualPrice.Text = "";
                    textBoxPurchaseUnitPrice.Text = "";
                    textBoxQty.Text = "";
                    textBoxPurchaseTotalPrice.Text = "";
                    DataTable ddt = MainClass.POS.usp_GetProduct_withImage(mp, out Status, out StatusDetails);
                    if (Status)
                    {
                        string pImage = ddt.Rows[0]["ProductPicture"].ToString();
                        if (pImage == "ImageClass.GetImageFromBase64(Row.Cells[ProductPicture].Value.ToString())' threw an exception of type 'System.FormatException" || pImage == "" || pImage == "NoImage")
                        {
                            pictureBoxPurchase.Visible = false;
                            labelAfterHiddenImage.Visible = true;
                            labelAfterHiddenImage.Text = "NoImage";
                        }
                        else
                        {
                            pictureBoxPurchase.Visible = true;
                            labelAfterHiddenImage.Visible = false;
                            pictureBoxPurchase.Image = ImageClass.GetImageFromBase64(ddt.Rows[0]["ProductPicture"].ToString());
                        }
                        udmGetQtySumFromGridViewDown();
                    }
                    else
                    {
                        MessageBox.Show(StatusDetails, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    JIMessageBox.InformationMessage("Invalid Barcode !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void udmGetQtySumFromGridViewDown()
        {
            int _AvQty = 0; int _TConsumeQty = 0;
            for (int i = 0; i < gridViewPurchase.Rows.Count; i++)
            {
                if (textBoxBarcode.Text != gridViewPurchase.Rows[i].Cells["Barcode"].Value.ToString())
                {/*Empty */}
                if (textBoxBarcode.Text == gridViewPurchase.Rows[i].Cells["Barcode"].Value.ToString())
                {
                  _AvQty += Convert.ToInt32(gridViewPurchase.Rows[i].Cells["PurchaseQty"].Value);
                  _TConsumeQty += Convert.ToInt32(gridViewPurchase.Rows[i].Cells["SoldQty"].Value);
                }
            }
            //--_RowsCount
            var _Rows = gridViewPurchase.Rows.Cast<DataGridViewRow>()
               .Where(r => r.Cells["Barcode"].Value.ToString() == textBoxBarcode.Text)
               .Select(r => r.Cells["PurchaseQty"].Value);
            labelinStock.ForeColor = Color.Red;
            labelinStock.Text = "Barcode : " + textBoxBarcode.Text+" \nTotal Rows: " + _Rows.Count().ToString() + "   | inStock : " + (_AvQty- _TConsumeQty).ToString();
        }

        private void udmGetQtySumFromGridView()
        {
            int sum = 0;
            for (int i = 0; i < gridViewPurchase.Rows.Count; i++)
            {
              if (textBoxSearchBarcode.Text != gridViewPurchase.Rows[i].Cells["Barcode"].Value.ToString())
              {/*Empty */}
              if (textBoxSearchBarcode.Text == gridViewPurchase.Rows[i].Cells["Barcode"].Value.ToString())
              { sum += Convert.ToInt32(gridViewPurchase.Rows[i].Cells["PurchaseQty"].Value); }
            }
            //--_RowsCount
            var _Rows = gridViewPurchase.Rows.Cast<DataGridViewRow>()
               .Where(r => r.Cells["Barcode"].Value.ToString() == textBoxSearchBarcode.Text)
               .Select(r => r.Cells["PurchaseQty"].Value);
            labelinStock.ForeColor = Color.Red;
            labelinStock.Text = "Barcode : " + textBoxBarcode.Text + " \nTotal Rows: " + _Rows.Count() + "   | inStock : " + sum.ToString();
        }

        private void textBoxPurchaseUnitPrice_TextChanged(object sender, EventArgs e)
        {
            udm_Price_And_Qty_Manupulation();
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            udm_Price_And_Qty_Manupulation();
        }
        private void udm_Price_And_Qty_Manupulation()
        {
            try
            {

                if (textBoxActualPrice.Text != "" && textBoxQty.Text != "")
                {
                    Double total = Convert.ToInt32(textBoxActualPrice.Text) * Convert.ToInt32(textBoxQty.Text);
                    textBoxPurchaseTotalPrice.Text = total.ToString();
                }
                else
                {
                    textBoxPurchaseTotalPrice.Text = "0";
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Enter Digits! : ");
                textBoxPurchaseUnitPrice.Focus();
                return;
            }
        }

        private void groupPanel5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPurchaseUnitPrice_Leave(object sender, EventArgs e)
        {
         try
           { 
             if (Convert.ToInt32(textBoxPurchaseUnitPrice.Text) <= 0)
             {
                 JIMessageBox.ExclamationMessage("Purchase Unit Price Field is less then 1 !");
                 textBoxPurchaseUnitPrice.Focus();
                 return;
             }
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
              textBoxPurchaseUnitPrice.Focus();
              return;
          }



    //public bool checkValidation()
    //{
    //   if( cbCategory.Text == null &&
    //    cbType.Text == null &&
    //    cbBrand.Text == null &&
    //    cbSize.Text == null &&
    //    cbColor.Text == null &&
    //    textBoxBarcode.Text = null
    //    ) { }
    //}
}

        private void textBoxQty_Leave(object sender, EventArgs e)
        {
            try
            { 
            if (Convert.ToInt32(textBoxQty.Text) <= 0)
            {
                JIMessageBox.ExclamationMessage("Purchase Qty Field is less then 1 !");
                textBoxQty.Focus();
                return;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBoxPurchaseUnitPrice.Focus();
                return;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (labelPurchaseID.Text == "" || labelPurchaseID.Text == "PurchaseID")
            {
                JIMessageBox.ExclamationMessage("Please Select Row From Table !");
                return;
            }
            if (textBoxBarcode.Text == "" || textBoxBarcode.Text == null)
            {
                JIMessageBox.ExclamationMessage("Enter Barcode First!");
                return;
            }
            if (textBoxPurchaseUnitPrice.Text == "" || textBoxQty.Text == "")
            {
                JIMessageBox.ExclamationMessage("Please Fill All Fields !");
                return;
            }
            updatePurchase();
        }

        private void gridViewPurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow Row = this.gridViewPurchase.Rows[e.RowIndex];

                    labelPurchaseID.Text = Row.Cells["PurchaseID"].Value.ToString();
                    textBoxBarcode.Text = Row.Cells["Barcode"].Value.ToString();
                    cbCategory.Text = Row.Cells["CategoryName"].Value.ToString();
                    cbType.Text = Row.Cells["ProductType"].Value.ToString();
                    cbBrand.Text = Row.Cells["ProductBrand"].Value.ToString();
                    cbSize.Text = Row.Cells["ProductSize"].Value.ToString();
                    cbColor.Text = Row.Cells["ProductColor"].Value.ToString();
                    cbSupplier.Text = Row.Cells["Supplier"].Value.ToString();
                    textBoxPurchaseUnitPrice.Text = Row.Cells["ActualPrice"].Value.ToString();
                    textBoxActualPrice.Text = Row.Cells["PurchaseUPrice"].Value.ToString();
                    textBoxQty.Text = Row.Cells["PurchaseQty"].Value.ToString();
                    textBoxPurchaseTotalPrice.Text = Row.Cells["PurchasePrice"].Value.ToString();
                    dtPurchase.Value = Convert.ToDateTime(Row.Cells["PurchaseDate"].Value.ToString());
                    string pImage = Row.Cells["ProductPicture"].Value.ToString();
                    if (pImage == "ImageClass.GetImageFromBase64(Row.Cells[ProductImage].Value.ToString())' threw an exception of type 'System.FormatException" || pImage == "" || pImage == "NoImage")
                    {
                        pictureBoxPurchase.Visible = false;
                        labelAfterHiddenImage.Visible = true;
                        labelAfterHiddenImage.Text = "NoImage";
                    }
                    else
                    {
                        pictureBoxPurchase.Visible = true;
                        labelAfterHiddenImage.Visible = false;
                        pictureBoxPurchase.Image = ImageClass.GetImageFromBase64(Row.Cells["ProductPicture"].Value.ToString());
                    }
                    udmGetQtySumFromGridViewDown();
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.Message);
            }
        }

        private void textBoxCadetName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewPurchase.Rows)
                {
                    if (row.Cells["CategoryName"].Value.ToString().ToLower().Contains(textBoxCadetName.Text.ToLower()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.ToString());
            }
        }

        private void textBoxType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewPurchase.Rows)
                {
                    if (row.Cells["ProductType"].Value.ToString().ToLower().Contains(textBoxType.Text.ToLower()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.ToString());
            }
        }

        private void textBoxBrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
               foreach (DataGridViewRow row in gridViewPurchase.Rows)
               {
                   if (row.Cells["ProductBrand"].Value.ToString().ToLower().Contains(textBoxBrand.Text.ToLower()))
                       row.Visible = true;
                   else
                       row.Visible = false;
               }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.ToString());
            }
        }

        private void gridViewPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            udmKeyPress();
        }





        private void udmKeyPress()
        {
            // Getting Index of Current Row
            int index = gridViewPurchase.CurrentRow.Index;

            DataGridViewRow Row = this.gridViewPurchase.Rows[index];

            labelPurchaseID.Text = Row.Cells["PurchaseID"].Value.ToString();
            textBoxBarcode.Text = Row.Cells["Barcode"].Value.ToString();
            cbCategory.Text = Row.Cells["CategoryName"].Value.ToString();
            cbType.Text = Row.Cells["ProductType"].Value.ToString();
            cbBrand.Text = Row.Cells["ProductBrand"].Value.ToString();
            cbSize.Text = Row.Cells["ProductSize"].Value.ToString();
            cbColor.Text = Row.Cells["ProductColor"].Value.ToString();
            cbSupplier.Text = Row.Cells["Supplier"].Value.ToString();
            textBoxPurchaseUnitPrice.Text = Row.Cells["ActualPrice"].Value.ToString();
            textBoxActualPrice.Text = Row.Cells["PurchaseUPrice"].Value.ToString();
            textBoxQty.Text = Row.Cells["PurchaseQty"].Value.ToString();
            textBoxPurchaseTotalPrice.Text = Row.Cells["PurchasePrice"].Value.ToString();
            dtPurchase.Value = Convert.ToDateTime(Row.Cells["PurchaseDate"].Value.ToString());
            string pImage = Row.Cells["ProductPicture"].Value.ToString();
            if (pImage == "ImageClass.GetImageFromBase64(Row.Cells[ProductImage].Value.ToString())' threw an exception of type 'System.FormatException" || pImage == "" || pImage == "NoImage")
            {
                pictureBoxPurchase.Visible = false;
                labelAfterHiddenImage.Visible = true;
                labelAfterHiddenImage.Text = "NoImage";
            }
            else
            {
                pictureBoxPurchase.Visible = true;
                labelAfterHiddenImage.Visible = false;
                pictureBoxPurchase.Image = ImageClass.GetImageFromBase64(Row.Cells["ProductPicture"].Value.ToString());
            }
            udmGetQtySumFromGridViewDown();
        }

        private void gridViewPurchase_KeyUp(object sender, KeyEventArgs e)
        {
            udmKeyPress();
        }
    }
}