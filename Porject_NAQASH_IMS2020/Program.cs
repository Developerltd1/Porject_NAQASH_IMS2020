
using PAF_BOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Porject_NAQASH_IMS2020
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mainfrm());
           // if (!ChechDatabaseExist())
           // {
           //     GenerateDatabase();
           // }else
           // {
           //     Application.Run(new Mainfrm());
           // }
        }
        
        #region MyRegion
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
        #endregion

    }
}
