using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQDBFramwork.Messageboxes
{
    public class JIMessageBox
    {
       // public static void YesNo(string message, string HeadTitle,)
       // {
       //     
       // }
        
        public static void ErrorMessage(string message)
        {
         MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void InformationMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void AsteriskMessage(string message)
        {
            MessageBox.Show(message, "Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        public static void ExclamationMessage(string message)
        {
            MessageBox.Show(message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void HandMessage(string message)
        {
            MessageBox.Show(message, "Hand", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        public static void QuestionMessage(string message)
        {
            MessageBox.Show(message, "Question", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        public static void StopMessage(string message)
        {
            MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static void WarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void NoneMessage(string message)
        {
            MessageBox.Show(message, "None", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        public static void CustomMessage(string title,string message )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK);
        }

        public static void CheckFieldsFill(params string[] Fields)
        {
            int i;
            for (i = 0; i < Fields.Length; i++)
            {
                if (Fields.GetValue(i) == null || Fields.GetValue(i) == "")
                {
                    MessageBox.Show("Please Fill All Fields", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
        }
        public static bool CheckisFieldsFill(params string[] Fields)
        {
            int i;
            bool check = false;
            for (i = 0; i < Fields.Length; i++)
            {
                if (Fields.GetValue(i) == null || Fields.GetValue(i) == "")
                {
                    check = false;
                    break;

                }
                else
                {
                    check = true;
                }
            }
            return check;
        }


        public static bool ChechDatabaseExist()
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NAQ_DB2020ConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void GenerateDatabase()
        {
            List<string> cmds = new List<string>();
            //Here we are Reading Our Script from the installed Application Folder
            string scriptPath = System.Configuration.ConfigurationManager.AppSettings["ScriptLocation"].ToString();  //Application.StartupPath + "\\NaqashSQLScript.sql";// + System.Configuration.ConfigurationManager.AppSettings["ScriptFileName"].ToString();
            if (File.Exists(scriptPath))
            {
                TextReader tr = new StreamReader(scriptPath);
                string line = "";
                string cmd = "";
                while ((line = tr.ReadLine()) != null)
                {
                    if (line.Trim().ToUpper() == "GO")
                    {
                        cmds.Add(cmd);
                        cmd = "";
                    }
                    else
                    {
                        cmd += line + " \r\n";
                    }
                }
                if (cmd.Length > 0)
                {
                    cmds.Add(cmd);
                    cmd = "";
                }
                tr.Close();
            }
            if (cmds.Count > 0)
            {
                SqlCommand command = new SqlCommand();
                //Sql COnnecion ofr Master Database
                //This Sql Connection for master databse it is used to geenrate database
                string MasterDbConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MasterDbConnectionString"].ToString();
                command.Connection = new SqlConnection(MasterDbConnectionString);
                command.CommandType = System.Data.CommandType.Text;
                command.Connection.Open();

                for (int i = 0; i < cmds.Count; i++)
                {
                    command.CommandText = cmds[i];
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Database Deployed Successfully! \n Now Open Again Application \n Thank You. ");
            }
            if (!File.Exists(scriptPath))
            {
                MessageBox.Show("Script Not Available !");
            }

        }
    }
}
