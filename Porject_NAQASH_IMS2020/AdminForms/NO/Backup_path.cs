using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using AQDBFramwork.Messageboxes;

namespace Porject_NAQASH_IMS2020
{
    public partial class Backup_path : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString());
        public  string path = null;
        public Backup_path()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            browse.RootFolder = Environment.SpecialFolder.Desktop;
            browse.Description = "+++ Select Folder +++";
            if (browse.ShowDialog() == DialogResult.OK)
            {
               path = browse.SelectedPath;

                pathtext.Text = path;
                btnBackup.Enabled = true;
            }
            else
             {
                MessageBox.Show("Folder Not selected please try again");
             
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            try
            {
                if (pathtext.Text == string.Empty)
                {

                    MessageBox.Show("please select the path for backup");
                }
                else 
                {
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK='" + pathtext.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";                    
                        using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Database backup created Successfully");
                        btnBackup.Enabled = false;
                        pathtext.Clear();
                    }
                }
            }
            catch (Exception ex)
            {

                JIMessageBox.ExclamationMessage(ex.Message);
            }
        }

        private void Backup_path_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
