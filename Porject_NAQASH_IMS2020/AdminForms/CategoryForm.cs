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

namespace Porject_NAQASH_IMS2020.AdminForms
{
    public partial class CategoryForm : DevComponents.DotNetBar.Office2007Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void btnCadetRegister_Click(object sender, EventArgs e)
        {
            
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if (textBoxCategoryName.Text == "" || textBoxCategoryName.Text == null) { JIMessageBox.ExclamationMessage("Please Fill Field! \n Thank You"); return; };
                string CategoryName = textBoxCategoryName.Text;
                MainClass.POS.CRUDCategoryCreate(CategoryName, out Status, out StatusDetails);
                if (Status)
                {
                    MessageBox.Show(StatusDetails,"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxCategoryName.Text = "";
                    displayCategory();
                    textBoxCategoryName.Focus();
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

        

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if (textBoxCategoryName.Text == "" || textBoxCategoryName.Text == null) { JIMessageBox.ExclamationMessage("Please Fill Field! \n Thank You"); return; };
                ModelClass.ModelPOS.ModelCategory mCategory = new ModelClass.ModelPOS.ModelCategory() { CategoryID = int.Parse(labelCategoryID.Text) ,CategoryName = textBoxCategoryName.Text } ;
               
                MainClass.POS.CRUDCategoryUpdate(mCategory, out Status, out StatusDetails);
                if (Status)
                {
                    MessageBox.Show(StatusDetails, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayCategory();
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if (textBoxCategoryName.Text == "" || textBoxCategoryName.Text == null) { JIMessageBox.ExclamationMessage("Please Fill Field! \n Thank You"); return; };
                ModelClass.ModelPOS.ModelCategory mCategory = new ModelClass.ModelPOS.ModelCategory() { CategoryID = int.Parse(labelCategoryID.Text), CategoryName = textBoxCategoryName.Text };
                MainClass.POS.CRUDCategoryDelete(mCategory, out Status, out StatusDetails);
                if (Status)
                {
                    MessageBox.Show(StatusDetails, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayCategory();
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

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            displayCategory();
        }

        private void displayCategory()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {

                DataTable DT = MainClass.POS.CategoryDisplayAll(out Status, out StatusDetails);
                if (Status)
                {
                    gridViewCategory.Rows.Clear();
                    foreach (DataRow row in DT.Rows)
                    {
                        gridViewCategory.Rows.Add(
                          row["CategoryID"].ToString(),
                          row["CategoryName"].ToString()
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
                foreach (DataGridViewRow row in gridViewCategory.Rows)
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
    }
}