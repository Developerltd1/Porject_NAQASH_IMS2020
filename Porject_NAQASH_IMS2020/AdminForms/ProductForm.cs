using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Porject_NAQASH_IMS2020.MngClass;
using AQDBFramwork.Messageboxes;
using Student_Management_System.Utilities.Lists;
using PAF_BOS;

namespace Porject_NAQASH_IMS2020.AdminForms
{
    public partial class ProductForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (comboBocCategory.Text == "" || textBoxProductType.Text == "" || textBoxBrand.Text == "" ||
                    textBoxSize.Text == "" || textBoxColour.Text == "" || textBoxBarcode.Text == "")
            { JIMessageBox.ExclamationMessage("Fill All Fields !"); return; }
            createProduct();
            displayProduct();
          
        }
        private void buttonClearTextBox_Click(object sender, EventArgs e)
        {
          clearTextBox();
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            displayComboBox();
            displayProduct();
        }
        private void buttonBrowseImageFile_Click(object sender, EventArgs e)
        {
            try
            {
                labelAfterHiddenImage.Visible = false;
                pictureBoxProduct.Visible = true;
                OpenFileDialog openFileDialogSelectPicture = new OpenFileDialog();
                openFileDialogSelectPicture.FileName = "";
                openFileDialogSelectPicture.Filter = "Image Files(*.JPG;*.PNG;*.BMP)|*.JPG;*.PNG;*.BMP";
                openFileDialogSelectPicture.FilterIndex = 2;
                openFileDialogSelectPicture.RestoreDirectory = true;
                if (openFileDialogSelectPicture.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxProduct.ImageLocation = openFileDialogSelectPicture.FileName;
                }
                    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void createProduct()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if (JIMessageBox.CheckisFieldsFill(textBoxBarcode.Text)) {
                    ModelClass.ModelPOS.ModelProduct mp = new ModelClass.ModelPOS.ModelProduct()
                    {
                        Category_ID = int.Parse(comboBocCategory.SelectedValue.ToString()),
                        ProductType = textBoxProductType.Text,
                        ProductBrand = textBoxBrand.Text,
                        ProductSize = textBoxSize.Text,
                        ProductColor = textBoxColour.Text,
                        CreatedByUser_ID = ModelClass._UserID, //UserID_Static
                        BarCode = textBoxBarcode.Text

                    };

                    string Photo = ImageClass.GetBase64StringFromImage(Imager.Resize(pictureBoxProduct.Image, 200, 200, true)); //Resize & Convert to String
                    mp.ProductPicture = Photo;

                    MainClass.POS.CRUDProductCreate(mp, out Status, out StatusDetails);
                    if (Status)
                    {
                        JIMessageBox.InformationMessage(StatusDetails);
                        
                    }
                    else
                    {
                        MessageBox.Show(StatusDetails, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    gridViewProduct.Rows.Clear();
                }else
                {
                    MessageBox.Show("Please Fill All Fields", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clearTextBox()
        {
            comboBocCategory.SelectedIndex = 0;
            textBoxProductType.Text = null;
            textBoxBrand.Text = null;
            textBoxSize.Text = null;
            textBoxColour.Text = null;
            textBoxBarcode.Text = null;
            pictureBoxProduct.Image = null;
            pictureBoxProduct.Visible = true;
            labelAfterHiddenImage.Visible = false;
        }
        private void displayComboBox()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable DTCategory = MainClass.POS.CategoryDisplayAll(out Status, out StatusDetails);
                if (Status)
                {
                    ListData.AutoSuggession_With_ComboBox(DTCategory, "CategoryID", comboBocCategory, "CategoryID", "CategoryName");
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
        private void displayProduct()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {

                DataTable DT = MainClass.POS.ProductDisplayAll(out Status, out StatusDetails);
                if (Status)
                {
                    gridViewProduct.Rows.Clear();
                    foreach (DataRow row in DT.Rows)
                    {
                        gridViewProduct.Rows.Add(row["ProductID"].ToString(),
                            row["BarCode"].ToString(),
                        row["CategoryName"].ToString(), row["ProductType"].ToString(),
                        row["ProductBrand"].ToString(), row["ProductSize"].ToString(),
                        row["ProductColor"].ToString(),
                        row["ProductPicture"].ToString()
                        );
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

        private void textBoxSearchCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewProduct.Rows)
                {
                    if (row.Cells["CategoryName"].Value.ToString().ToLower().Contains(textBoxSearchCategory.Text.ToLower()))
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

        private void textBoxSearchType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewProduct.Rows)
                {
                    if (row.Cells["ProductType"].Value.ToString().ToLower().Contains(textBoxSearchType.Text.ToLower()))
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

        private void textBoxSearchBrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewProduct.Rows)
                {
                    if (row.Cells["ProductBrand"].Value.ToString().ToLower().Contains(textBoxSearchBrand.Text.ToLower()))
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

        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
           bool Status = false;
           string StatusDetails = null;
           try
           {
                if(comboBocCategory.Text == "" || textBoxProductType.Text == "" || textBoxBrand.Text == "" ||
                    textBoxSize.Text == "" || textBoxColour.Text == "" || textBoxBarcode.Text == "" )
                { JIMessageBox.ExclamationMessage("Fill All Fields !");return; }
              string Photo = ImageClass.GetBase64StringFromImage(Imager.Resize(pictureBoxProduct.Image, 200, 200, true)); //Resize & Convert to String
               
              MainClass.POS.usp_UpdateProduct(Convert.ToInt32(labelProductID.Text), 
                  Convert.ToInt32(comboBocCategory.SelectedValue), textBoxProductType.Text, 
                  textBoxBrand.Text, textBoxSize.Text, textBoxColour.Text, Photo,textBoxBarcode.Text,
                  out Status, out StatusDetails);
               if (Status)
               {
                    JIMessageBox.InformationMessage("Record Updated Succesfully !");
                    displayProduct();
                  //  clearTextBox();
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

        private void gridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow Row = this.gridViewProduct.Rows[e.RowIndex];

                    labelProductID.Text = Row.Cells["ProductID"].Value.ToString();
                    comboBocCategory.Text = Row.Cells["CategoryName"].Value.ToString();
                    textBoxProductType.Text = Row.Cells["ProductType"].Value.ToString();
                    textBoxBrand.Text = Row.Cells["ProductBrand"].Value.ToString();
                    textBoxSize.Text = Row.Cells["ProductSize"].Value.ToString();
                    textBoxColour.Text = Row.Cells["ProductColor"].Value.ToString();
                    textBoxBarcode.Text = Row.Cells["Barcode"].Value.ToString();
                    string pImage = Row.Cells["ProductImage"].Value.ToString();
                    if (pImage == "ImageClass.GetImageFromBase64(Row.Cells[ProductImage].Value.ToString())' threw an exception of type 'System.FormatException" || pImage == "" || pImage == "NoImage")
                    {
                        pictureBoxProduct.Visible = false;
                        labelAfterHiddenImage.Visible = true;
                        labelAfterHiddenImage.Text = "NoImage";
                    }
                    else
                    {
                        pictureBoxProduct.Visible = true;
                        labelAfterHiddenImage.Visible = false;
                        pictureBoxProduct.Image = ImageClass.GetImageFromBase64(Row.Cells["ProductImage"].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.Message);
            }
        }

        private void gridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
           Random Global = new Random();
            int dice = Global.Next(1,9999);   // creates a number between 1 and 6    
            textBoxBarcode.Text = dice.ToString();
        }

        private void gridViewProduct_KeyDown(object sender, KeyEventArgs e)
        {
           try
           {
               if (e.KeyCode == Keys.Down)
               {
                    udmKeyPress();
               }
           }
           catch (Exception ex)
           {
               JIMessageBox.ErrorMessage(ex.Message);
           }
            
        }

       
        private void gridViewProduct_KeyUp(object sender, KeyEventArgs e)
        {
            udmKeyPress();
        }


        private void udmKeyPress()
        {
            // Getting Index of Current Row
            int index = gridViewProduct.CurrentRow.Index;

            DataGridViewRow Row = this.gridViewProduct.Rows[index];
            labelProductID.Text = Row.Cells["ProductID"].Value.ToString();
            comboBocCategory.Text = Row.Cells["CategoryName"].Value.ToString();
            textBoxProductType.Text = Row.Cells["ProductType"].Value.ToString();
            textBoxBrand.Text = Row.Cells["ProductBrand"].Value.ToString();
            textBoxSize.Text = Row.Cells["ProductSize"].Value.ToString();
            textBoxColour.Text = Row.Cells["ProductColor"].Value.ToString();
            textBoxBarcode.Text = Row.Cells["Barcode"].Value.ToString();
            string pImage = Row.Cells["ProductImage"].Value.ToString();
            if (pImage == "ImageClass.GetImageFromBase64(Row.Cells[ProductImage].Value.ToString())' threw an exception of type 'System.FormatException" || pImage == "" || pImage == "NoImage")
            {
                pictureBoxProduct.Visible = false;
                labelAfterHiddenImage.Visible = true;
                labelAfterHiddenImage.Text = "NoImage";
            }
            else
            {
                pictureBoxProduct.Visible = true;
                labelAfterHiddenImage.Visible = false;
                pictureBoxProduct.Image = ImageClass.GetImageFromBase64(Row.Cells["ProductImage"].Value.ToString());
            }
        }

        private void textBoxSearchSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewProduct.Rows)
                {
                    if (row.Cells["ProductSize"].Value.ToString().ToLower().Contains(textBoxSearchSize.Text.ToLower()))
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

        private void textBoxSearchColor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewProduct.Rows)
                {
                    if (row.Cells["ProductColor"].Value.ToString().ToLower().Contains(textBoxSearchColor.Text.ToLower()))
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
    }
}