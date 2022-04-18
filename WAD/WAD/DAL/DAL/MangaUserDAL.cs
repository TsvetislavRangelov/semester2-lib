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
                try
                {
                    string q = "SET FOREIGN_KEY_CHECKS=0; INSERT INTO user_manga(user_ID, manga_ID) VALUES(@UserID, @MangaID)";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", uid);
                        cmd.Parameters.AddWithValue("MangaID", mid);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException e)
                {

                }
                finally { conn.Close(); }
            }
        }

        public bool UserOwnsManga(int uid, int mid)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string q = "SELECT COUNT(*) AS owner FROM user_manga WHERE user_ID = @UID && manga_ID = @MID;";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@UID", uid);
                        cmd.Parameters.AddWithValue("@MID", mid);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int count = Int32.Parse(reader["owner"].ToString());
                                if (count == 1)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                catch (MySqlException e)
                {

                }
                finally { conn.Close(); }
                return false;
            }
        }

        public List<Manga> GetOwnedManga(int uid)
        {
            List<Manga> mangas = new List<Manga>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT m.ID, m.Title, m.ReleaseDate, m.Author, m.CoverImage FROM manga AS m"
                        + " inner join user_manga AS um on m.ID = um.Manga_ID INNER JOIN users AS u on um.user_ID = u.ID" +
                        " WHERE u.ID = @UID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@UID", uid);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Manga m = new Manga();
                                m.Id = int.Parse(reader[0].ToString());
                                m.Title = reader[1].ToString();
                                m.ReleaseDate = (DateTime)reader[2];
                                m.Author = reader[3].ToString();
                                m.Image = (byte[])reader[4];
                                mangas.Add(m);
                            }
                        }
                    }
                }
                catch(MySqlException ex)
                {

                }
                finally { conn.Close(); }
            }

            return mangas;
        }

        public void RemoveOwnedManga(int uid, int mid)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "DELETE FROM user_manga WHERE user_ID = @UID AND manga_ID = @MID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        //database table is set to cascade on delete so all relations are deleted as well
                        cmd.Parameters.AddWithValue("@UID", uid);
                        cmd.Parameters.AddWithValue("@MID", mid);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {

                }
                finally { conn.Close(); }
            }
        }
    }
}
