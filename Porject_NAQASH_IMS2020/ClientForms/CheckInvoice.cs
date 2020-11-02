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

namespace Porject_NAQASH_IMS2020.ClientForms
{
    public partial class CheckInvoice : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CheckInvoice()
        {
            InitializeComponent();
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void labelX28_Click(object sender, EventArgs e)
        {

        }

        private void tbSearchInvocie_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == (char)13)
           {
              bool Status = false;
              string StatusDetails = null;
              try
              {
                DataTable dt1 =  MainClass.POS.usp_CheckInvoiceNumberStep1(tbSearchInvocie.Text, out Status, out StatusDetails);
                    if (dt1.Rows.Count <=0) { JIMessageBox.ExclamationMessage("SaleOrderSETP_1: DataTableis Empty !"); return; }
                    if (Status == false) { JIMessageBox.WarningMessage("SaleOrderSETP_2: "+StatusDetails); return; }
                    int _SalesOrderID =Convert.ToInt32(dt1.Rows[0]["SalesOrderID"].ToString());
                    DataTable dt2 = MainClass.POS.usp_CheckInvoiceNumberStep2(_SalesOrderID, out Status, out StatusDetails);
                    if (Status == false) { JIMessageBox.ExclamationMessage("SaleOrderSETP_2: DataTable is Empty !"); return; }
                    if (Status == false) { JIMessageBox.WarningMessage("SaleOrderSETP_2: " + StatusDetails); return; }

                    labelSalesOrderID.Text = Convert.ToString(dt1.Rows[0]["SalesOrderID"]);
                    labelCustomerID.Text =  Convert.ToString(dt1.Rows[0]["CustomerID"]);
                    tbCustomerName.Text = Convert.ToString(dt1.Rows[0]["CustomerName"]);
                    tbContact.Text = Convert.ToString(dt1.Rows[0]["CustomerContact"]);
                    rtbDetails.Text = Convert.ToString(dt1.Rows[0]["CustomerDetails"]);
                    dtCurrentDate.Value = Convert.ToDateTime(dt1.Rows[0]["SalesOrderCurrentDate"]);
                    dtDueDate.Value = Convert.ToDateTime(dt1.Rows[0]["SalesOrderDueDate"]);

                    tbAdvance.Text = Convert.ToInt32(dt1.Rows[0]["Advance"]).ToString();
                    tbBalance.Text = Convert.ToInt32(dt1.Rows[0]["Balance"]).ToString();
                    tbGrandTotal.Text = Convert.ToInt32(dt1.Rows[0]["TotalBill"]).ToString();

                    gridViewCheckInvoice.Rows.Clear();
                    foreach (DataRow r in dt2.Rows)
                     {
                       r["Color"] = r["Color"].ToString() == "Color" ? "EMPTY" : r["Color"].ToString();
                       r["BarCode"] = r["BarCode"].ToString() == "BarCode" ? "EMPTY" : r["BarCode"].ToString();

                        gridViewCheckInvoice.Rows.Add(r["ID"].ToString(),
                       r["Category"].ToString(), r["Type"].ToString(),
                       r["Brand"].ToString(), r["Size"].ToString(), r["Color"].ToString(),
                       r["UnitPrice"].ToString(), r["Qty"].ToString(), r["UnitTotalPrice"].ToString(),
                       r["BarCode"].ToString());
                        dt2.AcceptChanges();
                     }
                }
              catch (Exception ex)
              {
                  JIMessageBox.WarningMessage(ex.ToString());
              }
              e.Handled = true;
           }
        }

        //________________UDM_METHODS___________________//
        public void udm_Clear()
        {
            //Customer_&_Coonting_Information
            tbCustomerName.Text = "";
            tbContact.Text = "";
            rtbDetails.Text = "";
            tbAdvance.Text = "";
            tbBalance.Text = "";
            tbGrandTotal.Text = "";

            
            gridViewCheckInvoice.Rows.Clear();
        }

        private void buttonUpdateInvoice_Click(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if (tbSearchInvocie.Text == "")
                {
                    JIMessageBox.ExclamationMessage("Please Enter Invoice Number"); return;
                }
                if (tbSearchInvocie.Text != "")
                { 
                    if (tbCustomerName.Text == "")
                    {
                        JIMessageBox.ExclamationMessage("Details Not Available !"); return;
                    }
                }


                MainClass.POS.usp_UpdateCustomer(Convert.ToInt32(labelCustomerID.Text), tbCustomerName.Text, tbContact.Text, rtbDetails.Text, out Status, out StatusDetails);
                if(Status == false) { JIMessageBox.WarningMessage(StatusDetails); }
                else
                {
                    //CODE
                }

                //dtCurrentDate.Value = dtCurrentDate.Value == null ? DateTime.Now : dtCurrentDate.Value;
                //dtDueDate.Value = dtDueDate.Value == null ? DateTime.Now : dtDueDate.Value;
                MainClass.POS.UpdateSalesOrder(
                    Convert.ToInt32(labelSalesOrderID.Text), dtCurrentDate.Value, dtDueDate.Value,
                    Convert.ToInt32(tbGrandTotal.Text), Convert.ToInt32(tbAdvance.Text), 
                    Convert.ToInt32(tbBalance.Text), tbSearchInvocie.Text,
                    out Status,out StatusDetails);
                if (Status == false) { JIMessageBox.WarningMessage(StatusDetails); }
                else
                {
                    JIMessageBox.InformationMessage("Record Updated Successfully !");
                }

            }
            catch (Exception ex)
            {
                JIMessageBox.WarningMessage(ex.ToString());
            }
        }

        private void tbAdvance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                    if (tbGrandTotal.Text != "" && tbAdvance.Text != "")
                    {
                        Double total = Convert.ToInt64(tbGrandTotal.Text) - Convert.ToInt64(tbAdvance.Text);
                        tbBalance.Text = total.ToString();
                    }
                    else
                    {
                        tbBalance.Text = "0";
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Digits!");
                tbAdvance.Focus();
            }
        }

        private void tbGrandTotal_TextChanged(object sender, EventArgs e)
        {
            if (tbGrandTotal.Text != "" && tbAdvance.Text != "")
            {
                Double total = Convert.ToInt64(tbGrandTotal.Text) - Convert.ToInt64(tbAdvance.Text);
                tbBalance.Text = total.ToString();
            }
            else
            {
                tbBalance.Text = "0";
            }
        }

        private void CheckInvoice_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            tbCustomerName.Text = "";
            tbContact.Text = "";
            rtbDetails.Text = "";
            tbAdvance.Text = "0";
            tbBalance.Text = "0";
            tbGrandTotal.Text = "0";
            tSearchContact.Text = "";
            dtCurrentDate.Value = DateTime.Now;
            dtDueDate.Value = DateTime.Now;
            gridViewCheckInvoice.Rows.Clear();
        }
    }
}