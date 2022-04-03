using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Models.Models
{
    public class LibraryItem
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Author { get; set; }

        public Genre Genre { get; set; }


        public LibraryItem()
        {

        }

        public LibraryItem(int id, string title, DateTime releaseDate, string author, Genre genre)
        {
            this.Id = id;
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.Author = author;
            this.Genre = genre;
        }

        public override string ToString()
        {

            string info = $"Item: ID: {this.Id} - Title: {this.Author} - Release Date: {this.Author} - Author: {this.Author} - Genre: {this.Genre}";
            return info;

        }
    }
}