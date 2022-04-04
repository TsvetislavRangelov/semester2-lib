using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Models.Models
{
    public class Book
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime releaseDate { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public SubGenre SubGenre { get; set; }

        public Book()
        {

        }

        public Book(int id, string title, DateTime releaseDate, string author, Genre genre, SubGenre subGenre)
        {
            this.Id = id;
            this.Title = title;
            this.releaseDate = releaseDate;
            this.Author = author;
            this.Genre = genre;
            this.SubGenre = subGenre;
        }
    }
}
