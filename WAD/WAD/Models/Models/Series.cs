using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
   public class Series
    {
        private int episodesPerSeason;
        private int seasons;
        private string studio;

        public int EpisodesPerSeason
        {
            get { return this.episodesPerSeason; }
            set { this.episodesPerSeason = value; }
        }

        public string Producer
        {
            get { return this.studio; }
            set { this.studio = value; }
        }

        public int Seasons
        {
            get { return this.seasons; }
            set { this.seasons = value; }
        }

        public Series()
        {

        }

        public Series(int episodes, string producer, int seasons)
        {
            this.episodesPerSeason = episodes;
            this.seasons = seasons;
            this.studio = producer;
        }
    }
}
