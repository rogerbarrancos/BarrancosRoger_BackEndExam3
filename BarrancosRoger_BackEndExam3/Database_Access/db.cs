using System;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using BarrancosRoger_BackEndExam3.Models;

namespace BarrancosRoger_BackEndExam3.Database_Access
{
    public class db {
        static MySqlConnectionStringBuilder conn_settings = new MySqlConnectionStringBuilder
        {
            UserID = "qj75Nek5PO",
            Database = "qj75Nek5PO",
            Password = "uGllR8KITR",
            Server = "remotemysql.com",
            Port = 3306
        };
        MySqlConnection conn = new MySqlConnection(conn_settings.ConnectionString);


        public string[] dbQuery(string query){
            string[] result;
            conn.Open();
            MySqlCommand command = new MySqlCommand(query,conn);
            var dt = new DataTable();
            dt.Load(command.ExecuteReader());
            result = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
            conn.Close();
            return result;
        }

        public bool insertRebel(Rebel rebel)
        {
            conn.Open();

            //Inserto NULL en ID porque el Auto_Increment de la Base de datos rellena automaticamente
            MySqlCommand com = new MySqlCommand("INSERT INTO rebels VALUES (NULL,@name,@planet,@registered_date)");
            com.Parameters.AddWithValue("@name", rebel.name);
            com.Parameters.AddWithValue("@planet", rebel.planet);
            //Formato en YYYY-MM-dd para igualarlo con DB
            com.Parameters.AddWithValue("@registered_date",DateTime.Now.Date.ToString("yyyy-MM-dd"));
            com.Connection = conn;
            //Reviso que realmente ha afectado a alguna columna
            if (com.ExecuteNonQuery() != 0) {
                conn.Close();
                return true;
            }
            else {
                conn.Close();
                return false;
            }
        }
    }
}
