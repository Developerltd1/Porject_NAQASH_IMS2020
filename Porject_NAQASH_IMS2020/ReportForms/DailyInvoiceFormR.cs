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
    public partial class DailyInvoiceFormR : DevComponents.DotNetBar.Metro.MetroForm
    {
        public DailyInvoiceFormR()
        {
            InitializeComponent();
        }

        private void DailyInvoiceFormR_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            // reportViewer1.Reset();

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "Reports/ReportDailyInvoices.rdlc";
            DataTable dd = uStep2();
            

            ReportDataSource Rds = new ReportDataSource();
            Rds.Name = "DataSetMerge";
            Rds.Value = dd;
            reportViewer1.LocalReport.DataSources.Add(Rds);
            reportViewer1.RefreshReport();
        }

       

        public DataTable TableHeadingName()
        {
            DataTable HeadingName = new DataTable();

            HeadingName.Columns.Add(new DataColumn("SalesOrder_ID", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("SalesOrderInvoiceNo", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("SalesOrderCurrentDate", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("SalesOrderDueDate", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("CustomerName", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("CustomerContact", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("CustomerDetails", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("TotalBill", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("Advance", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("Balance", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("UnitPrice", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("Qty", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("TotalPrice", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("Category", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("Type", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("Brand", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("Size", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("Color", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("SalesPictureNo", typeof(string)));
            HeadingName.Columns.Add(new DataColumn("isStudio", typeof(string)));
            //saletable.Columns.Add(new DataColumn("saleprice", typeof(decimal)));

            return HeadingName;
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
        public DataTable uStep2()
        {
            DataTable dts2 = new DataTable();
            bool Status = false;
            string StatusDetails = null;
            try
            {
                dts2 = MainClass.Reporting.usp_InvoiceReportSTEP2( out Status, out StatusDetails);
                return dts2;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}