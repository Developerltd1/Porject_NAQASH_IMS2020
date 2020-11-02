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
using Porject_NAQASH_IMS2020.MngClass.Utilities;
using Microsoft.Reporting.WinForms;

namespace Porject_NAQASH_IMS2020.ReportForms
{
    public partial class BarcodeFormR : DevComponents.DotNetBar.Metro.MetroForm
    {
        public BarcodeFormR()
        {
            InitializeComponent();
        }

        private void DailyInvoiceFormR_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
         
            reportViewerBarcode.LocalReport.DataSources.Clear();
            reportViewerBarcode.LocalReport.ReportPath = "Reports/ReportBarcode.rdlc";
            //Tables
            DataTable d = uStep1();
            ReportDataSource Rds1 = new ReportDataSource();
            Rds1.Name = "DataSetBarcode";
            Rds1.Value = d;
            reportViewerBarcode.LocalReport.DataSources.Add(Rds1);
            //--------------//
           
            reportViewerBarcode.RefreshReport();

        }

        public DataTable uStep1()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable dts1 = MainClass.Reporting.usp_InvoiceReportSTEP1(out Status, out StatusDetails);
                return dts1;

            }
            catch (Exception)
            {
                return null;
            }
        }
    
        private void tbSearchBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
              bool Status = false;
              string StatusDetails = null;
              try
              {
                if (tbSearchBarcode.Text == "") {JIMessageBox.ExclamationMessage("Please Enter Barcode !"); return; };

                    DataTable dt = MainClass.Reporting.usp_BarcodeReport(tbSearchBarcode.Text, out Status, out StatusDetails);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["pDate"] = Convert.ToString(dtPurchaseDateReport.Value.ToString("dddd, dd MMMM yyyy"));
                    }
                   
                    reportViewerBarcode.LocalReport.DataSources.Clear();
                    reportViewerBarcode.LocalReport.ReportPath = "Reports/ReportBarcode.rdlc";
                    //Table
                    ReportDataSource Rds = new ReportDataSource();
                    Rds.Name = "DataSetBarcode";
                    Rds.Value = dt;
                    reportViewerBarcode.LocalReport.DataSources.Add(Rds);
                    //--------------//

                    reportViewerBarcode.RefreshReport();
                    e.Handled = true;
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
            }
            
        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }
    }
}