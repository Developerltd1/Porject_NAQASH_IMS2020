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
using static Porject_NAQASH_IMS2020.MngClass.ModelClass.ModelPOS;
using PAF_BOS;
using System.Linq;

namespace Porject_NAQASH_IMS2020.AdminForms
{
    public partial class AvailableStockForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AvailableStockForm()
        {
            InitializeComponent();
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void tabFormItem2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX7_TextChanged(object sender, EventArgs e)
        {

        }

        private void AvailableStockForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            displayStock();
        }
        private void displayStock()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable DT = MainClass.POS.GetStock(out Status, out StatusDetails);
                if (Status)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        gridViewAvailableStock.Rows.Add(
                         row["Barcode"].ToString(), row["CategoryName"].ToString(),
                         row["ProductType"].ToString(), row["ProductBrand"].ToString(),
                         row["ProductSize"].ToString(), row["ProductColor"].ToString(),
                           row["PurchasePrice"].ToString(), row["UnitPrice"].ToString(),
                           row["AvailableQty"].ToString(), row["SoldQty"].ToString(),
                          row["PurchaseDate"].ToString(), row["ProductID"].ToString()
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

        private void gridViewAvailableStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool Status = false;
                string StatusDetails = null;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow Row = this.gridViewAvailableStock.Rows[e.RowIndex];
                    labelBarcode.Text = Row.Cells["Barcode"].Value.ToString();
                    labelCategory.Text = Row.Cells["CategoryName"].Value.ToString();
                    labelType.Text = Row.Cells["ProductType"].Value.ToString();
                    labelBrand.Text = Row.Cells["ProductBrand"].Value.ToString();
                    labelSize.Text = Row.Cells["ProductSize"].Value.ToString();
                    labelColor.Text = Row.Cells["ProductColor"].Value.ToString();
                    labelDate.Text = Row.Cells["PurchaseDate"].Value.ToString();
                    labelAvailableStock.Text = Row.Cells["AvailableQty"].Value.ToString();
                    labelCousumeStock.Text = Row.Cells["SoldQty"].Value.ToString();

                    ModelProduct mp = new ModelProduct();
                    mp.ProductID = Convert.ToInt32(Row.Cells["ProductID"].Value.ToString());
                    DataTable ddt = MainClass.POS.usp_GetProduct_withImage(mp, out Status, out StatusDetails);
                    if (Status)
                    {
                        string pImage = ddt.Rows[0]["ProductPicture"].ToString();
                        if (pImage == "ImageClass.GetImageFromBase64(Row.Cells[ProductImage].Value.ToString())' threw an exception of type 'System.FormatException" || pImage == "" || pImage == "NoImage")
                        {
                            labelAfterHiddenImage.Visible = true;
                            labelAfterHiddenImage.Text = "NoImage";
                            pictureBoxAvailable.Visible = false;
                        }
                        else
                        {
                            pictureBoxAvailable.Visible = true;
                            labelAfterHiddenImage.Visible = false;
                            pictureBoxAvailable.Image = ImageClass.GetImageFromBase64(ddt.Rows[0]["ProductPicture"].ToString());
                        }
                        udmGetQtySumFromGridViewDown();

                    }
                    else
                    {
                        MessageBox.Show(StatusDetails, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.Message);
            }
        }


        private void udmGetQtySumFromGridViewDown()
        {
            int _AvQty = 0;
            int _TConsumeQty = 0;

            for (int i = 0; i < gridViewAvailableStock.Rows.Count; i++)
            {
                if (labelBarcode.Text != gridViewAvailableStock.Rows[i].Cells["Barcode"].Value.ToString())
                {/*Empty */}
                if (labelBarcode.Text == gridViewAvailableStock.Rows[i].Cells["Barcode"].Value.ToString())
                { _AvQty += Convert.ToInt32(gridViewAvailableStock.Rows[i].Cells["AvailableQty"].Value);
                  _TConsumeQty += Convert.ToInt32(gridViewAvailableStock.Rows[i].Cells["SoldQty"].Value);
                }
            }
            //--_RowsCount
            var _Rows = gridViewAvailableStock.Rows.Cast<DataGridViewRow>()
               .Where(r => r.Cells["Barcode"].Value.ToString() == labelBarcode.Text)
               .Select(r => r.Cells["AvailableQty"].Value);
            labelTotalRows.Text = _Rows.Count().ToString();
            labelTotalAvStock.Text = _AvQty.ToString();
            labelTotalConsumeStock.Text = _TConsumeQty.ToString();
            labelAvQty.Text = Convert.ToString(_AvQty - _TConsumeQty);
        }






        private void textBoxSearchCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewAvailableStock.Rows)
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

        private void textBoxSerachType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewAvailableStock.Rows)
                {
                    if (row.Cells["ProductType"].Value.ToString().ToLower().Contains(textBoxSerachType.Text.ToLower()))
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
                foreach (DataGridViewRow row in gridViewAvailableStock.Rows)
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

        private void textBoxSearchSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewAvailableStock.Rows)
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
                foreach (DataGridViewRow row in gridViewAvailableStock.Rows)
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            labelBarcode.Text = null;
            labelCategory.Text = null;
            labelType.Text = null;
            labelBrand.Text = null;
            labelSize.Text = null;
            labelColor.Text = null;
            labelDate.Text = null;
            labelAvailableStock.Text = null;
            labelCousumeStock.Text = null;
            pictureBoxAvailable.Image = null;
            pictureBoxAvailable.Visible = true;
            labelAfterHiddenImage.Visible = false;
        }

        private void gridViewAvailableStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxSearchBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewAvailableStock.Rows)
                {
                    if (row.Cells["Barcode"].Value.ToString().ToLower().Contains(textBoxSearchBarcode.Text.ToLower()))
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

        private void gridViewAvailableStock_KeyDown(object sender, KeyEventArgs e)
        {
            udmKeyPress();
        }


        private void udmKeyPress()
        {
            try
            {
                bool Status = false;
                string StatusDetails = null;
                
                    // Getting Index of Current Row
                    int index = gridViewAvailableStock.CurrentRow.Index;
                    DataGridViewRow Row = this.gridViewAvailableStock.Rows[index];

                    labelBarcode.Text = Row.Cells["Barcode"].Value.ToString();
                    labelCategory.Text = Row.Cells["CategoryName"].Value.ToString();
                    labelType.Text = Row.Cells["ProductType"].Value.ToString();
                    labelBrand.Text = Row.Cells["ProductBrand"].Value.ToString();
                    labelSize.Text = Row.Cells["ProductSize"].Value.ToString();
                    labelColor.Text = Row.Cells["ProductColor"].Value.ToString();
                    labelDate.Text = Row.Cells["PurchaseDate"].Value.ToString();
                    labelAvailableStock.Text = Row.Cells["AvailableQty"].Value.ToString();
                    labelCousumeStock.Text = Row.Cells["SoldQty"].Value.ToString();

                    ModelProduct mp = new ModelProduct();
                    mp.ProductID = Convert.ToInt32(Row.Cells["ProductID"].Value.ToString());
                    DataTable ddt = MainClass.POS.usp_GetProduct_withImage(mp, out Status, out StatusDetails);
                    if (Status)
                    {
                        string pImage = ddt.Rows[0]["ProductPicture"].ToString();
                        if (pImage == "ImageClass.GetImageFromBase64(Row.Cells[ProductImage].Value.ToString())' threw an exception of type 'System.FormatException" || pImage == "" || pImage == "NoImage")
                        {
                            labelAfterHiddenImage.Visible = true;
                            labelAfterHiddenImage.Text = "NoImage";
                            pictureBoxAvailable.Visible = false;
                        }
                        else
                        {
                            pictureBoxAvailable.Visible = true;
                            labelAfterHiddenImage.Visible = false;
                            pictureBoxAvailable.Image = ImageClass.GetImageFromBase64(ddt.Rows[0]["ProductPicture"].ToString());
                        }
                        udmGetQtySumFromGridViewDown();
                        
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.Message);
            }

        }

        private void gridViewAvailableStock_KeyUp(object sender, KeyEventArgs e)
        {
            udmKeyPress();
        }

        private void gridViewAvailableStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                udmKeyPress();
            }
        }
    }
}