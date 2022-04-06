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

    public class MangaDAL : IMangaDAL
    {
        private string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public void AddManga(Manga manga)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "SET FOREIGN_KEY_CHECKS=0; INSERT INTO manga(Title, ReleaseDate, Author) VALUES(@Title, @ReleaseDate, @Author;";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", manga.Title);
                        cmd.Parameters.AddWithValue("@ReleaseDate", manga.ReleaseDate);
                        cmd.Parameters.AddWithValue("@Author", manga.Author);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {

                }
                finally { conn.Close(); }
            }
        }

        public List<Manga> GetMangaList()
        {
            List<Manga> list = new List<Manga>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "SELECT * FROM MANGA;";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Manga(Convert.ToInt32(reader[0]), reader[1].ToString(), (DateTime)reader[2], reader[3].ToString()));
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {

                }
                finally { conn.Close(); }
                return list;
            }
        }

        public Manga GetManga(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "SELECT * FROM manga WHERE ID = @ID;";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Manga m = new Manga();
                                m.Id = Convert.ToInt32(reader[0]);
                                m.Title = reader[1].ToString();
                                m.ReleaseDate = (DateTime)reader[2];
                                m.Author = reader[3].ToString();
                                return m;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {

                }
                finally { conn.Close(); }
                return null;
            }
        }
    }
}
