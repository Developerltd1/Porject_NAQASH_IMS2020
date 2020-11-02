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
using PAF_BOS;

namespace Porject_NAQASH_IMS2020.AdminForms
{
    public partial class SuppliertForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SuppliertForm()
        {
            InitializeComponent();
        }
        private void btnCadetRegister_Click(object sender, EventArgs e)
        {
            try
             {
                if (textBoxName.Text == "" ||
                    textBoxPhone.Text == "" ||
                    textBoxMobile.Text == "" ||
                    textBoxAddress.Text == ""
                    ) { JIMessageBox.ExclamationMessage("Please Fill All Fields !");return; }
                createSupplier();
                displaySupplier();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonBrowsrFile_Click(object sender, EventArgs e)
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
                    pictureBoxSupplier.ImageLocation = openFileDialogSelectPicture.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SuppliertForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            displaySupplier();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearTextbox();
        }
        private void createSupplier()
        {
            bool Status = false;
            string StatusDetails = null;
            ModelClass.ModelPOS.ModelSupplier mp = new ModelClass.ModelPOS.ModelSupplier()
            {
                SupplierName = textBoxName.Text,
                SupplierPhoneNo = textBoxPhone.Text,
                SupplierMobileNo = textBoxMobile.Text,
                SupplierAddress = textBoxAddress.Text,
            };
           
            string Photo = ImageClass.GetBase64StringFromImage(Imager.Resize(pictureBoxSupplier.Image, 200, 200, true)); //Resize & Convert to String
            mp.SupplierPicture = Photo;
            MainClass.POS.CRUDSuppierCreate(mp, out Status, out StatusDetails);
            if (Status)
            {
                JIMessageBox.InformationMessage(StatusDetails);
                clearTextbox();
            }
            else
            {
                MessageBox.Show(StatusDetails, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            gridViewSupplier.Rows.Clear();
        }
        private void updateSupplier()
        {
            bool Status = false;
            string StatusDetails = null;
         
            string Photo = ImageClass.GetBase64StringFromImage(Imager.Resize(pictureBoxSupplier.Image, 200, 200, true)); //Resize & Convert to String
            MainClass.POS._UpdateSupplier(Convert.ToInt32(labelSupplierID.Text), textBoxName.Text,
                textBoxPhone.Text, textBoxMobile.Text, textBoxAddress.Text, Photo, out Status, out StatusDetails);
            if (Status)
            {
                JIMessageBox.InformationMessage(StatusDetails);
                clearTextbox();
            }
            else
            {
                MessageBox.Show(StatusDetails, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            gridViewSupplier.Rows.Clear();
        }
        private void displaySupplier()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable DT = MainClass.POS.SuppierDisplayAll(out Status, out StatusDetails);
                if (Status)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        gridViewSupplier.Rows.Add(
                        row["SupplierID"].ToString(), row["SupplierName"].ToString(),
                        row["SupplierPhoneNo"].ToString(), row["SupplierMobileNo"].ToString(),
                        row["SupplierAddress"].ToString(), row["SupplierPicture"].ToString()
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
        private void clearTextbox()
        {
            textBoxName.Text = "";
            textBoxPhone.Text = "";
            textBoxMobile.Text = "";
            textBoxAddress.Text = "";
            pictureBoxSupplier.Image = null;
        }

        private void textBoxSearchName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewSupplier.Rows)
                {
                    if (row.Cells["Supplier"].Value.ToString().ToLower().Contains(textBoxSearchName.Text.ToLower()))
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

        private void textBoxSearchContact_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewSupplier.Rows)
                {
                    if (row.Cells["Phone"].Value.ToString().ToLower().Contains(textBoxSearchContact.Text.ToLower()))
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

        private void textBoxSearchMobile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewSupplier.Rows)
                {
                    if (row.Cells["Mobile"].Value.ToString().ToLower().Contains(textBoxSearchMobile.Text.ToLower()))
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

        private void buttonUpdateSupplier_Click(object sender, EventArgs e)
        {
            try
            { 
             if (textBoxName.Text == "" ||
                     textBoxPhone.Text == "" ||
                     textBoxMobile.Text == "" ||
                     textBoxAddress.Text == ""
                     ) { JIMessageBox.ExclamationMessage("Please Fill All Fields !"); return; }
                 updateSupplier();
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.Message);
            }
        }

        private void gridViewSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow Row = this.gridViewSupplier.Rows[e.RowIndex];

                    labelSupplierID.Text = Row.Cells["SupplierID"].Value.ToString();
                    textBoxName.Text = Row.Cells["Supplier"].Value.ToString();
                    textBoxPhone.Text = Row.Cells["Phone"].Value.ToString();
                    textBoxMobile.Text = Row.Cells["Mobile"].Value.ToString();
                    textBoxAddress.Text = Row.Cells["Address"].Value.ToString();
                    pictureBoxSupplier.Image = ImageClass.GetImageFromBase64(Row.Cells["SupplierPicture"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}