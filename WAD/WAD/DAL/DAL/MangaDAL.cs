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
        private readonly string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public int AddManga(Manga manga)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "SET FOREIGN_KEY_CHECKS=0; INSERT INTO manga(Title, ReleaseDate, Author, CoverImage) VALUES(@Title, @ReleaseDate, @Author, @CoverImage);";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", manga.Title);
                        cmd.Parameters.AddWithValue("@ReleaseDate", manga.ReleaseDate);
                        cmd.Parameters.AddWithValue("@Author", manga.Author);
                        cmd.Parameters.AddWithValue("@CoverImage", manga.Image);
                        int result = cmd.ExecuteNonQuery();
                        if(result == 1)
                        {
                            return 1;
                        }
                    }
                    conn.Close();
                }
                catch(MySqlException ex)
                {
                    conn.Close();
                    return 0;

                }
                finally { conn.Close(); }
                return 0;
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
                                Manga m = new Manga();
                                m.Id = Convert.ToInt32(reader[0]);
                                m.Title = reader[1].ToString();
                                m.ReleaseDate = (DateTime)reader[2];
                                m.Author = reader[3].ToString();
                                if (reader[4] != null)
                                {
                                    m.Image = (byte[])reader[4];
                                }
                                list.Add(m);
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
        public bool DeleteMangaById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "DELETE FROM manga WHERE @ID = ID";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            return true;
                        }
                    }
                }
                catch(MySqlException ex)
                {

                }
                finally { conn.Close(); }
            }
            return false;
        }
    }
}
