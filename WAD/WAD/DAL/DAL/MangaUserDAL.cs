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
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                string q = "SET FOREIGN_KEY_CHECKS=0; INSERT INTO user_manga(user_ID, manga_ID) VALUES(@UserID, @MangaID)";
                conn.Open();
                using(MySqlCommand cmd = new MySqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", uid);
                    cmd.Parameters.AddWithValue("MangaID", mid);
                    cmd.ExecuteNonQuery();
                }
            }
            
        }
    }
}
