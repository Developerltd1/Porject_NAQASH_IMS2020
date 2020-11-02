using Porject_NAQASH_IMS2020;
using Porject_NAQASH_IMS2020.AdminForms;
using Porject_NAQASH_IMS2020.ClientForms;
using Porject_NAQASH_IMS2020.ReportForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class Mainfrm : DevComponents.DotNetBar.Office2007Form//DevComponents.DotNetBar.Metro.MetroAppForm
    {
        public Mainfrm()
        {
            InitializeComponent();
        }
  
        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NAQASH STUDIO INVENTORY SYSTEM \nVersion : " + Application.ProductVersion,"Application",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Mainfrm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void udf_FormsButtonDisable()
        {
            btnItem_USER.Enabled = false; 
            btnItem_CADET_REGISTRATION.Enabled = false;
            btnItem_CADET_PUNSIHMENT.Enabled = false;
            btnItem_CADET_ATTANDANCE_PERMISSION.Enabled = false;
            btnItem_USER_.Enabled = false;
            btnItem_Supplier.Enabled = false;
        }

        //allow only single instance of form open
        public void CheckFormStatus(Form f)
        {
            bool found = false;
            foreach (Form frm in MdiChildren)
            {
                if (f.Text == frm.Text)
                {
                    found = true;
                    frm.Activate();
                    return;
                }
            }
            if (!found)
            {
                f.MdiParent = this;
                f.Show();
            }

        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnItemUSER_Click(object sender, EventArgs e)
        {
            CategoryForm frm = new CategoryForm();
            CheckFormStatus(frm);
        } 

        private void btnItemCADETREGISTRATION(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            CheckFormStatus(frm);
        }

        private void btnItemPUNISHMENT(object sender, EventArgs e)
        {
            StockForm frm = new StockForm();
            CheckFormStatus(frm);
        } 
         
        private void btnItem_CADET_ATTANDANCE_PERMISSION_Click(object sender, EventArgs e)
        {
            PurchaseForm frm = new PurchaseForm();
            CheckFormStatus(frm);
        }

        private void btnItem_Supplier_Click(object sender, EventArgs e)
        {
            SuppliertForm frm = new SuppliertForm();
            CheckFormStatus(frm);
        }

        private void btnItem_USER__Click(object sender, EventArgs e)
        {
            UsersForm frm = new UsersForm();
            CheckFormStatus(frm);
        }

        private void buttonItemAvailableStockFrontEnd_Click(object sender, EventArgs e)
        {
            AvailableStockForm frm = new AvailableStockForm();
            CheckFormStatus(frm);
        }

        private void buttonItemPOS_Click(object sender, EventArgs e)
        {
            POSForm frm = new POSForm();
            CheckFormStatus(frm);
        }

        private void buttonItemCheckInvoice_Click(object sender, EventArgs e)
        {
            CheckInvoice frm = new CheckInvoice();
            CheckFormStatus(frm);
        }

        private void btnDailyInvoiceReport_Click(object sender, EventArgs e)
        {
            DailyInvoiceFormR frm = new DailyInvoiceFormR();
            CheckFormStatus(frm);
        }

        private void buttonItemProductBarcode_Click(object sender, EventArgs e)
        {
            BarcodeFormR frm = new BarcodeFormR();
            CheckFormStatus(frm);
        }

        private void dbBackup_Click(object sender, EventArgs e)
        {
            Backup_path frm = new Backup_path();
            CheckFormStatus(frm);
        }

        private void dbRestore_Click(object sender, EventArgs e)
        {
            restore frm = new restore();
            CheckFormStatus(frm);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            InvoiceSummaryFormR frm = new InvoiceSummaryFormR();
            CheckFormStatus(frm);
        }

        private void buttonItemExpenses_Click(object sender, EventArgs e)
        {
            ExpensesForm frm = new ExpensesForm();
            CheckFormStatus(frm);
        }
    }
}
