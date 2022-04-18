using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Models.Models;
using Models.Enums;
using JointInterfaces.Interfaces;
using System.Data;

namespace DAL.DAL
{
    public class UsersDAL : IUsersDAL
    {

        private string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public void RegisterUser(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "INSERT INTO users (Username, Email, Password, Role, PasswordSalt, RegisterDate) VALUES (@Username, @Email, @Password, @Role, @PasswordSalt, @RegisterDate)";
                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", "USER");
                    cmd.Parameters.AddWithValue("@PasswordSalt", user.Salt);
                    cmd.Parameters.AddWithValue("@RegisterDate", DateTime.Now);
                    cmd.ExecuteNonQuery();

                }
                catch (MySqlException)
                {
                    conn.Close();
                }
                finally { conn.Close(); }
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT * FROM users;";
                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    conn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            User u = new User();
                            u.Id = Convert.ToInt32(dr["ID"]);
                            u.Username = dr["Username"].ToString();
                            u.Email = dr["Email"].ToString();
                            u.Password = dr["Password"].ToString();
                            u.Salt = dr["PasswordSalt"].ToString();
                            if (dr["ProfileImage"].GetType() != typeof(DBNull))
                            {
                                u.Image = (byte[])dr["ProfileImage"];
                            }
                            if (dr["Role"].GetType() != typeof(DBNull))
                            {
                                u.Role = (Role)Enum.Parse(typeof(Role), dr["Role"].ToString());
                            }
                            users.Add(u);
                            u.RegistrationDate = (DateTime)dr["RegisterDate"];
                        }
                    }
                }
                catch (MySqlException e)
                {
                    return null;
                }
                finally { conn.Close(); }
            }
            return users;
        }

        public string GetPasswordSalt(int id)
        {
            string salt = String.Empty;
            using (MySqlConnection conn = new(connString))
            {
                try
                {
                    string q = "SELECT PasswordSalt FROM users WHERE ID = @ID";
                    conn.Open();
                    using (MySqlCommand cmd = new(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                salt = dr[0].ToString();
                            }
                        }
                    }
                }
                finally { conn.Close(); }
            }
            return salt;
        }

        public DataTable FillUserTable()
        {
            DataTable dbData = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "SELECT DISTINCT ID, Username, Email, Role FROM users;";
                    using (MySqlDataAdapter cmd = new MySqlDataAdapter(q, conn))
                    {
                        cmd.Fill(dbData);
                    }
                }
                catch (System.AggregateException)
                {

                }
                finally { conn.Close(); }
                return dbData;

            }
        }

        public bool DeleteUser(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "DELETE FROM users WHERE @ID = ID";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            return true;
                        }
                    }
                }
                catch (MySqlException)
                {
                    return false;
                }
                finally { conn.Close(); }
            }
            return false;
        }

        public void ChangeRole(int id, string role)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "UPDATE users SET Role = @Role WHERE ID = @ID;";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", (Role)Enum.Parse(typeof(Role), role));
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {

                }
                finally { conn.Close(); }
            }
        }

        public void UploadImage(byte[] img, int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "UPDATE users SET ProfileImage=@ProfileImage WHERE ID = @id";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProfileImage", img);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch(MySqlException ex)
                {

                }
                finally { conn.Close(); }
            }

        }
    }
}
