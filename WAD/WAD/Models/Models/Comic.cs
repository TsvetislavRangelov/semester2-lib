using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Models.Models
{
   public class Comic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public Genre Genre { get; set; }

        public Comic()
        {

        }

        public Comic(int id, string title, DateTime releaseDate, string publisher, Genre genre)
        {
            this.Id = id;
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.Publisher = publisher;
            this.Genre = genre;
        }
    }
}
