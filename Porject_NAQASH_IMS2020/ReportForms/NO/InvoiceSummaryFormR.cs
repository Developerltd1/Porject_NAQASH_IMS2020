using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Porject_NAQASH_IMS2020.MngClass;
using AQDBFramwork.Messageboxes;
using Microsoft.Reporting.WinForms;
using System.Collections;

namespace Porject_NAQASH_IMS2020.ClientForms
{
    public partial class InvoiceSummaryFormR : DevComponents.DotNetBar.Metro.MetroForm
    {
        public InvoiceSummaryFormR()
        {
            InitializeComponent();
        }

        private void DailyInvoiceFormR_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
        }

        public DataTable udmTable()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable dt = MainClass.Reporting.usp_SummaryInvoiceReport(dateTimeFrom.Value, dateTimeTo.Value,out Status, out StatusDetails);
                if (Status)
                {
                    return dt;
                }
                else {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // reportViewer1.Reset();

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "Reports/NO/ReportDailySummaryInvoices.rdlc";

            ReportDataSource Rds = new ReportDataSource();
            Rds.Name = "DataSetMerge";
            DataTable dt = udmTable();
            Rds.Value = dt;
            reportViewer1.LocalReport.DataSources.Add(Rds);
            reportViewer1.RefreshReport();
        }
    }
}