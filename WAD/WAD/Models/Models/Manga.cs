using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;
using System.Drawing;

namespace Models.Models
{
   public class Manga
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Author { get; set; }
        public byte[] Image { get; set; }

        public Manga()
        {

        }

        public Manga(int id, string title, DateTime releaseDate, string author)
        {
            this.Id = id;
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.Author = author;

        }

        public Manga(int id, string title, DateTime releaseDate, string author, byte[] image)
        {
            this.Id = id;
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.Author = author;
            this.Image = image;

        }
    }
}
