using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClassLibrary1.DAL
{

   public class ItemDAL
    {
        string connString = "Server = studmysql01.fhict.local; Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public DataTable ItemData()
        {
            DataTable dbData = new DataTable();
            try
            {
                using(MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MySqlDataAdapter cmd = new MySqlDataAdapter("SELECT * FROM libraryitems", conn);
                    cmd.Fill(dbData);
                    conn.Close();

                }
            }
            catch (MySqlException)
            {
                
            }
            return dbData;
        }

        public bool DeleteItem(int id)
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string query = "DELETE FROM libraryitems WHERE Id = @Id;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    if(cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e);
                }
                finally { conn.Close(); }
            }
            return false;


        }
    }
}
