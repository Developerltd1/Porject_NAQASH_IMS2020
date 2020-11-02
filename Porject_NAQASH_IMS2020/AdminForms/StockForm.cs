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
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PAF_BOS;

namespace Porject_NAQASH_IMS2020.AdminForms
{
    public partial class StockForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public StockForm()
        {
            InitializeComponent();
        }


        private void StockForm_Load(object sender, EventArgs e)
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
                        gridViewStock.Rows.Add(
                        row["Barcode"].ToString(), row["CategoryName"].ToString(),
                        row["ProductType"].ToString(), row["ProductBrand"].ToString(),
                        row["ProductSize"].ToString(), row["ProductColor"].ToString(),
                        row["PurchaseDate"].ToString(), row["PurchasePrice"].ToString(),
                        row["PurchaseQty"].ToString(), row["UnitPrice"].ToString(),
                        row["AvailableQty"].ToString(), row["SoldQty"].ToString(),
                        ImageClass.GetImageFromBase64(row["ProductPicture"].ToString())
                        );
                    }
                    //int i;
                    //for (i = 0; i < gridViewStock.Rows.Count; i++)
                    //{
                    //   // gridViewStock.Rows[i].Cells["Status"].Value = Convert.ToInt32(gridViewStock.Rows[i].Cells["AvailableQty"].Value) == Convert.ToInt32(gridViewStock.Rows[i].Cells["SoldQty"].Value) ? "Finished" : "Available";
                    //}
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
                foreach (DataGridViewRow row in gridViewStock.Rows)
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
                foreach (DataGridViewRow row in gridViewStock.Rows)
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
                foreach (DataGridViewRow row in gridViewStock.Rows)
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
                foreach (DataGridViewRow row in gridViewStock.Rows)
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
                foreach (DataGridViewRow row in gridViewStock.Rows)
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

        private void gridViewStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxSearchBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewStock.Rows)
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

        private void textBoxSearchBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    int sum1 = 0;
                    int sum2 = 0;
                    bool value = true;

                    //--Method_1
                    var _Rows = gridViewStock.Rows.Cast<DataGridViewRow>()
                      .Where(r => r.Cells["Barcode"].Value.ToString() == textBoxSearchBarcode.Text)
                      .Select(r => r.Cells["AvailableQty"].Value);

                   
                    for (int i = 0; i < gridViewStock.Rows.Count; i++)
                    {
                        if (textBoxSearchBarcode.Text != gridViewStock.Rows[i].Cells["Barcode"].Value.ToString())
                        {
                           // JIMessageBox.ErrorMessage(textBoxSearchBarcode.Text+" is not Correct \n Please Enter Correct Barcode !");
                           // value = false;
                           // break;
                        }
                        if (textBoxSearchBarcode.Text == gridViewStock.Rows[i].Cells["Barcode"].Value.ToString())
                        {
                            sum1 += Convert.ToInt32(gridViewStock.Rows[i].Cells["AvailableQty"].Value);
                            sum2 += Convert.ToInt32(gridViewStock.Rows[i].Cells["SoldQty"].Value);
                            value = true;
                        }
                    }
                    if (value == true)
                    { JIMessageBox.InformationMessage("Total Rows: " + _Rows.Count() + "\n Available Stock : " + sum1.ToString() + "\n Sold Stock : " + sum2.ToString()); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                e.Handled = true;
            }
        }

    }
}
