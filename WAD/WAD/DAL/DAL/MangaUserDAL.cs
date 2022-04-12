using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Models.Models;
using JointInterfaces.Interfaces;

namespace DAL.DAL
{
   public class MangaUserDAL
    {
        private string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public void AddMangaToProfile(int uid, int mid)
        {
            
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try {

                    string q = "SET FOREIGN_KEY_CHECKS=0; INSERT INTO user_manga(user_ID, manga_ID) VALUES(@UserID, @MangaID)";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", uid);
                        cmd.Parameters.AddWithValue("MangaID", mid);
                        
                        cmd.ExecuteNonQuery();
                        
                        
                    }
                }
                catch(MySqlException e)
                {
                    
                }
                finally { conn.Close(); }
            }
        }

        public bool UserOwnsManga(int uid, int mid)
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "SELECT COUNT(*) as owner FROM user_manga WHERE user_ID = @UID && manga_ID = @MID;";
                    using(MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@UID", uid);
                        cmd.Parameters.AddWithValue("@MID", mid);
                        using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int count = Int32.Parse(reader["owner"].ToString());
                                if(count == 1)
                                {
                                    return true;
                                }
                            }
                        }
                    }

                }
                catch(MySqlException e)
                {

                }
                finally { conn.Close(); }
                return false;
            }
        }
    }
}
