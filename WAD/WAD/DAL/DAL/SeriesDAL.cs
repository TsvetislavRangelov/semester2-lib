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
   public class SeriesDAL: ISeriesDAL
    {
        private readonly string connString = "Server = studmysql01.fhict.local; Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public List<Series> GetSeries()
        {
            List<Series> series = new List<Series>();
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                string q = "SELECT * FROM series";
                conn.Open();
                using(MySqlCommand cmd = new MySqlCommand(q, conn))
                {
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Series s = new Series();
                            s.Id = Int32.Parse(reader[0].ToString());
                            s.Title = reader[1].ToString();
                            s.Episodes = Int32.Parse(reader[2].ToString());
                            s.Seasons = Int32.Parse(reader[3].ToString());
                            s.Image = (byte[])reader[4];
                            series.Add(s);

                        }
                    }
                }
                conn.Close();
            }
            return series;
            
        }

        public int AddSeries(Series s)
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                string q = "INSERT INTO series (Title, Episodes, Seasons) VALUES(@Title, @Episodes, @Seasons)";
                conn.Open();
                using(MySqlCommand cmd = new MySqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", s.Title);
                    cmd.Parameters.AddWithValue("@Episodes", s.Episodes);
                    cmd.Parameters.AddWithValue("@Seasons", s.Seasons);
                    if (cmd.ExecuteNonQuery() == 1)
                        return 1;

                }
                conn.Close();
                return 0;

            }
        }

        public DataTable SeriesDataSource()
        {
            DataTable table = new DataTable();
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                string q = "SELECT * FROM series";
                conn.Open();
                using(MySqlDataAdapter cmd = new MySqlDataAdapter(q, conn))
                {
                    cmd.Fill(table);
                }
                conn.Close();
            }
            return table;
            
        }

        public bool DeleteSeries(int id)
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                string q = "DELETE FROM series WHERE ID = @ID";
                conn.Open();
                using(MySqlCommand cmd = new MySqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    if(cmd.ExecuteNonQuery() == 1)
                    {
                        conn.Close();
                        return true;

                    }
                }
                conn.Close();
                return false;
            }
        }

        public void UpdateSeries(Series s)
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                string q = "UPDATE series SET Title = @Title, Seasons = @Seasons, Episodes = @Episodes, CoverImage = @CoverImage";
                conn.Open();
                using(MySqlCommand cmd = new MySqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", s.Title);
                    cmd.Parameters.AddWithValue("@Seasons", s.Seasons);
                    cmd.Parameters.AddWithValue("@Episodes", s.Episodes);
                    cmd.Parameters.AddWithValue("@CoverImage", s.Image);
                }
            }
        }
    }
}
