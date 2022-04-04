﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Models.Models;
using Models.Enums;
using JointInterfaces.Interfaces;

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
                    string q = "INSERT INTO users (Username, Email, Password, Role, PasswordSalt) VALUES (@Username, @Email, @Password, @Role, @PasswordSalt)";
                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", "USER");
                    cmd.Parameters.AddWithValue("@PasswordSalt", user.Salt);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (MySqlException)
                {

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
                            if (dr["Role"].GetType() != typeof(DBNull))
                            {
                                u.Role = (Role)Enum.Parse(typeof(Role), dr["Role"].ToString());
                            }
                            users.Add(u);

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
            using(MySqlConnection conn = new(connString))
            {
                try
                {
                    string q = "SELECT PasswordSalt FROM users WHERE ID = @ID";
                    conn.Open();
                    using(MySqlCommand cmd = new(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using(MySqlDataReader dr = cmd.ExecuteReader())
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
    }
}
