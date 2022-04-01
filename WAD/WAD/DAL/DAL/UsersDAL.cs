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
    public class UsersDAL: IUsersDAL
    {
        
        private string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public void RegisterUser(User user)
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "INSERT INTO users (Username, Email, Password, Role) VALUES (@Username, @Email, @Password, @Role)";
                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", "USER");
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
            //query
        }
        
    }
}
