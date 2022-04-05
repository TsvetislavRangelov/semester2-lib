using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Models.Models
{
   public class Manga
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime releaseDate { get; set; }
        public string Author { get; set; }
        public int Volumes { get; set; }
        public int Chapters { get; set; }

        public Manga()
        {

        }

        public Manga(int id, string title, DateTime releaseDate, string author, int volumes, int chapters)
        {
            this.Id = id;
            this.Title = title;
            this.releaseDate = releaseDate;
            this.Author = author;
            this.Volumes = volumes;
            this.Chapters = chapters;
        }
    }
}
