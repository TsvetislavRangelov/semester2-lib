using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Models.Models;
using JointInterfaces.Interfaces;
using Models.Enums;

namespace DAL.DAL
{

   public class ItemDAL : IItemDAL
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
        
        public List<LibraryItem> GetItems()
        {
            List<LibraryItem> items = new List<LibraryItem>();
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT * FROM libraryitems";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LibraryItem newItem = new LibraryItem();
                            newItem.Id = Convert.ToInt32(dr[0]);
                            newItem.Title = dr[1].ToString();
                            newItem.ReleaseDate = (DateTime)dr[2];
                            newItem.Author = dr[3].ToString();
                            if (dr[4].GetType() != typeof(DBNull))
                            {
                                newItem.Genre = (Genre)Enum.Parse(typeof(Genre), dr["Role"].ToString());
                            }
                            items.Add(newItem);
                        }
                    }
                }
                finally { conn.Close(); }
                return items;
            }
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

        public void AddItem(LibraryItem item)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "INSERT INTO libraryitems(Title, ReleaseDate, Author, Genre)" +
                        " VALUES(@Title, @ReleaseDate, @Author, @Genre);";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", item.Title);
                        cmd.Parameters.AddWithValue("@ReleaseDate", item.ReleaseDate);
                        cmd.Parameters.AddWithValue("@Author", item.Author);
                        cmd.Parameters.AddWithValue("@Genre", item.Genre);
                    }
                }
                finally { conn.Close(); }
            }
        }

        //public void EditItem(LibraryItem item)
        //{

        //}
    }
}
