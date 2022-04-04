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
        public DateTime releaseDate { get; set; }
        public string Producer { get; set; }

        public int EpisodesPerSeason { get; set; }

        public Series()
        {

        }

        public Series(int id, string title, DateTime releaseDate, string producer, int episodesPerSeason)
        {
            this.Id = id;
            this.Title = title;
            this.releaseDate = releaseDate;
            this.Producer = producer;
            this.EpisodesPerSeason = episodesPerSeason;
        }
    }
}
