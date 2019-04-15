using System;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using BarrancosRoger_BackEndExam3.Models;
using BarrancosRoger_BackEndExam3.Logging;
using System.Collections.Generic;

namespace BarrancosRoger_BackEndExam3.Database_Access
{
    public class db {
        Log log = new Log();
        static MySqlConnectionStringBuilder conn_settings = new MySqlConnectionStringBuilder
        {
            UserID = "qj75Nek5PO",
            Database = "qj75Nek5PO",
            Password = "uGllR8KITR",
            Server = "remotemysql.com",
            Port = 3306
        };
        MySqlConnection conn = new MySqlConnection(conn_settings.ConnectionString);

        public DataSet dbQuery(string query){
            conn.Open();
            MySqlCommand command = new MySqlCommand(query,conn);
            DataSet dsData = new DataSet();
            var dt = new DataTable();
            dt.Load(command.ExecuteReader());
            string[] result = new string[dt.Rows.Count];
            dsData.Tables.Add(dt);
            //foreach (DataRow row in dt.Rows){
            //result = dt.Rows.OfType<DataRow>().Select(k => k[i].ToString()).ToArray();                
            //    result[i] = row.ItemArray.ToString();
            //}
            List<string> lst = new List<string>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    result[i] = dsData.Tables[0].Rows[i]["name"].ToString();
            //}
            //lst = dsData;
            conn.Close();
            return dsData;
        }

        public bool insertRebel(Rebel rebel)
        {
            try
            {
                conn.Open();

                //Inserto NULL en ID porque el Auto_Increment de la Base de datos rellena automaticamente el campo
                MySqlCommand com = new MySqlCommand("INSERT INTO rebels VALUES (NULL,@name,@planet,@registered_date)");
                com.Parameters.AddWithValue("@name", rebel.name.Trim());
                com.Parameters.AddWithValue("@planet", rebel.planet.Trim());
                //Formato en YYYY-MM-dd para igualarlo con DB
                com.Parameters.AddWithValue("@registered_date", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                com.Connection = conn;

                //Verifico que realmente hay datos a insertar
                if (rebel.name.Trim() != "" && rebel.planet.Trim() != "")
                {
                    //Reviso que realmente ha afectado a alguna columna
                    if (com.ExecuteNonQuery() != 0)
                    {
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }
                }
                else { return false; }
            }
            catch (MySqlException ex) {
                log.logToFile(ex.Data.ToString());
                return false;
            }
        }
    }
}
