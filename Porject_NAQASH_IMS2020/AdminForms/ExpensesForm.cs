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
    public partial class ExpensesForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ExpensesForm()
        {
            InitializeComponent();
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void btnExpensesInsert_Click(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if (comboBoxType.Text == "Select")
                { JIMessageBox.ExclamationMessage("Please Select Type! \n Thank You"); return; };
                if (comboBoxType.Text == "" || textBoxTitle.Text == "")
                { JIMessageBox.ExclamationMessage("Please Fill Field! \n Thank You"); return; };
                string _date = datePicker.Value.ToString("dd/MM/yyyy ");
                string _time = timePicker.Value.ToString("hh:mm:ss tt");
               string __datetime = _date + _time;
                MainClass.Expenses.InsertExpenses(Convert.ToInt32(textBoxAmount.Text),Convert.ToDateTime(_date+ _time), ModelClass._UserID, textBoxTitle.Text,comboBoxType.Text,richTextBoxDetails.Text, out Status, out StatusDetails);
                if (Status)
                {
                    MessageBox.Show("Record Save Succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearr();
                    displayExpenses();
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

        private void Clearr()
        {
            comboBoxType.Focus();
            comboBoxType.Text = "Select";
            textBoxTitle.Text = "";
            richTextBoxDetails.Text = "";
            textBoxAmount.Text = "";
            datePicker.Value = DateTime.Now;
            timePicker.Value = DateTime.Now;
        }

    

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void ExpensesForm_Load(object sender, EventArgs e)
        {
            comboBoxType.Text = "Select";
            displayExpenses();
        }

        private void gridViewExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow Row = this.gridViewExpenses.Rows[e.RowIndex];

                    labelExpensesID.Text = Row.Cells["ExpensesID"].Value.ToString();
                    datePicker.Value = Convert.ToDateTime(Row.Cells["Date"].Value.ToString());
                    timePicker.Value = Convert.ToDateTime(Row.Cells["Time"].Value.ToString());
                    comboBoxType.Text = Row.Cells["Type"].Value.ToString();
                    textBoxTitle.Text = Row.Cells["Title"].Value.ToString();
                    richTextBoxDetails.Text = Row.Cells["Details"].Value.ToString();
                    textBoxAmount.Text = Row.Cells["Amount"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.Message);
            }
        }


        private void displayExpenses()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable DT = MainClass.Expenses.getAllFromExpenses(out Status, out StatusDetails);
                if (Status)
                {
                    gridViewExpenses.Rows.Clear();
                    foreach (DataRow row in DT.Rows)
                    {
                        gridViewExpenses.Rows.Add(
                          row["ExpensesID"].ToString(),
                          row["Date"].ToString(),
                          row["Time"].ToString(),
                          row["ExpensesType"].ToString(),
                          row["ExpensesTitle"].ToString(),
                          row["ExpensesDetails"].ToString(),
                          row["Amount"].ToString()
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Clearr();
        }

        private void buttonExpensesUpdate_Click(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                string _date = datePicker.Value.ToString("dd/MM/yyyy ");
                string _time = timePicker.Value.ToString("hh:mm:ss tt");
                string __datetime = _date + _time;
                MainClass.Expenses.Expenses_UpdateByID(Convert.ToInt32(labelExpensesID.Text),Convert.ToInt32(textBoxAmount.Text), Convert.ToDateTime(_date + _time),  textBoxTitle.Text, comboBoxType.Text, richTextBoxDetails.Text, out Status, out StatusDetails);
                if (Status)
                {
                    MessageBox.Show("Record Updated Succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearr();
                    displayExpenses();
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

        private void buttonExpensesDelete_Click(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                MainClass.Expenses.Expenses_DeleteMeansIsActive(Convert.ToInt32(labelExpensesID.Text), out Status, out StatusDetails);
                if (Status)
                {
                    MessageBox.Show("Record Deleted Succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearr();
                    displayExpenses();
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

        private void textBoxSearchType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewExpenses.Rows)
                {
                    if (row.Cells["Type"].Value.ToString().ToLower().Contains(textBoxSearchType.Text.ToLower()))
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

        private void textBoxSearchTitle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewExpenses.Rows)
                {
                    if (row.Cells["Title"].Value.ToString().ToLower().Contains(textBoxSearchTitle.Text.ToLower()))
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewExpenses.Rows)
                {
                    if (row.Cells["Date"].Value.ToString().ToLower().Contains(dateTimePickerSearch.Text.ToLower()))
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

        private void labelX11_Click(object sender, EventArgs e)
        {
            gridViewExpenses.Visible = true;
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridViewExpenses.Rows)
                {
                        row.Visible = true;
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ErrorMessage(ex.ToString());
            }
        }
    }
}