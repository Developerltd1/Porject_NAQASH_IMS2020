using System;
using System.Windows.Forms;
using Porject_NAQASH_IMS2020.MngClass;
using AQDBFramwork.Messageboxes;
using PAF_BOS;
using System.Drawing;
using System.Data;
using Student_Management_System.Utilities.Lists;

namespace Porject_NAQASH_IMS2020.AdminForms
{
    public partial class UsersForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
             createUser();
        }

        private void createUser()
        {
          bool Status = false;
          string StatusDetails = null;
          try
          {
            ModelClass.ModelPOS.ModelUser md = new ModelClass.ModelPOS.ModelUser();
            md.Role_ID = int.Parse(cbRoles.SelectedValue.ToString());
            md.UserName = tbName.Text.ToString();
            md.UserPassword = tbPassword.Text.ToString();
            md.ContactNo = tbphone.Text.ToString();
            md.UserDesignation = tbDesignation.Text.ToString();
            md.CreatedByUser_ID = ModelClass._UserID; //UserID_Static
            Bitmap img = ImageClass.Resize((Bitmap)pictureBoxUser.Image, new Size(200, 200), System.Drawing.Imaging.ImageFormat.Jpeg);
            string Photo = ImageClass.GetBase64StringFromImage(img); //Resize & Convert to String
            md.UserPicture = Photo;
            MainClass.POS.CRUDUserCreate(md, out Status, out StatusDetails);
            if (Status)
            {
                JIMessageBox.InformationMessage(StatusDetails);
                Clear();
            }
            else
            {
                MessageBox.Show(StatusDetails, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                gridViewUser.Rows.Clear();
                displayUser();
                
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
          }
        }

        private void Clear()
        {
          cbRoles.SelectedIndex = 0;
          tbName.Text = null;
          tbPassword.Text = null;
          tbphone.Text = null;
          tbDesignation.Text = null;
          pictureBoxUser.Image = null;
        }

        private void btnFromFile_Click(object sender, EventArgs e)
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
                    pictureBoxUser.ImageLocation = openFileDialogSelectPicture.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            displayComboBox();
            displayUser();
        }
        private void displayUser()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable DT = MainClass.POS.UserDisplayAll(out Status, out StatusDetails);
                if (Status)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        gridViewUser.Rows.Add(
                        row["UserName"].ToString(), row["UserPassword"].ToString(),
                        row["UserDesignation"].ToString(), row["RoleName"].ToString(),
                        row["RoleDetails"].ToString()
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
        private void displayComboBox()
        {
            try
            {
                DataTable DTCategory = MainClass.POS.GetRoles();
                if (DTCategory.Rows.Count>0)
                {
                    ListData.AutoSuggession_With_ComboBox(DTCategory, "RoleID", cbRoles, "RoleID", "RoleName");
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.Message);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}