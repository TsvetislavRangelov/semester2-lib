using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Episodes { get; set; }
        public int Seasons { get; set; }
        public byte[] Image { get; set; }

        public Series()
        {

        }

        public Series(int id, string title, int seasons, int episodes)
        {
            this.Id = id;
            this.Title = title;
            this.Seasons = seasons;
            this.Episodes = episodes;
        }
    }
}
