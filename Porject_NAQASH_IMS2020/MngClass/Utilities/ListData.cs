using AQDBFramwork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Hum DatagridView + ComboBox & ListBox sy Related sara Data is Class mian daly gay

namespace Student_Management_System.Utilities.Lists
{
   
    public class ListData
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RFID_db"].ConnectionString);

        public static void gridViewFilter(DataGridView gdv, string Tablevalue,TextBox SearchTextbox)
        {
            foreach (DataGridViewRow row in gdv.Rows)
            {
                if (row.Cells[Tablevalue.ToString()].Value.ToString().ToLower().Contains(SearchTextbox.Text.ToLower()))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        public static void udm_AssignGridview(DataGridView GridView, DataTable dt)
        {
            GridView.DataSource = dt;
            ListData.GridViewColumnFix(GridView);
        }
        public static void LoadDataIntoDataGridView(DataGridView dgv, string StoreProcedureName) //Funcation
        {
            //DbSQLServer db = new DbSQLServer(AppSetting.ConnectionString());
            //dgv.DataSource = db.GetDataList(StoreProcedureName);    //Get Procedure Name
            dgv.MultiSelect = false; //Default Set False
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // For Fill the Columns
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //For Select Full Row
           
        }
       public static void AutoSuggession(DataTable dataTable,int ColnumNo, TextBox txtBox )
        {
            txtBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            DataTable dt = new DataTable();
            dt = dataTable;

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                string data = dt.Rows[i][ColnumNo].ToString();
                col.Add(data);
            }
            txtBox.AutoCompleteCustomSource = col;
        }
        public static void AutoSuggession_With_ComboBox(DataTable dataTable, int dtColum, ComboBox comboBox,string ValueM, string DisplayM)
        {
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            DataTable dt = new DataTable();
            dt = dataTable;
            comboBox.AutoCompleteCustomSource = col;
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = ValueM;
            comboBox.DisplayMember = DisplayM;

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                string data = dt.Rows[i][dtColum].ToString();
                col.Add(data);
            }

        }
        public static void AutoSuggession_With_ComboBox(DataTable dataTable, string dtColum, ComboBox comboBox, string ValueM, string DisplayM)
        {
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            DataTable dt = new DataTable();
            dt = dataTable;
            comboBox.AutoCompleteCustomSource = col;
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = ValueM;
            comboBox.DisplayMember = DisplayM;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                string data = dt.Rows[i][dtColum].ToString();
                col.Add(data);
            }

        }
        public static void GridViewColumnFix(DataGridView dataGridView){
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public static void GridViewCustomHeaderText(DataGridView dataGridView,int columnIndex,String headerName){
            dataGridView.Columns[columnIndex].HeaderText = headerName;
        }
        public static void setGridviewColHideORShow(DataGridView dataGridView, int colIndex, bool value)
        {
            dataGridView.Columns[colIndex].Visible = value; 
        }
        public static void setGridviewColHideORShow(DataGridView dataGridView, string colName, bool value)
        {
            dataGridView.Columns[colName].Visible = value;
        }

        public static void LoadDataintoComboBox(ComboBox comboBox, object funcation, string DisplayMember, string ValueMember)     //COMBO
        {
            try
            {

                comboBox.DataSource = funcation;
                comboBox.DisplayMember = DisplayMember;
                comboBox.ValueMember = ValueMember;

                comboBox.SelectedIndex = -1; //Default Set Null Or Empty
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList; //Style
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }
    }
}
