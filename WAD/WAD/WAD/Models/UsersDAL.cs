using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace WAD.Models
{
    public class UsersDAL
    {
        private string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public void RegisterUser(User user)
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "INSERT INTO users (Username, Email, Password, Role) VALUES (@Username, @Email, @Password, @Role)";
                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    conn.Open();
                }
                catch (Exception)
                {

                }
                finally { conn.Close(); }
            }
        }
    }
}
