using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD
{
    public class Book : LibraryItem
    {
        private SubGenre subGenre;
        private int pages;

        public Book()
        {

        }

        public Book(int id, string title, DateTime releaseDate, string author, Genre genre, SubGenre subGenre, int pages) : base(id, title, releaseDate, author, genre)
        {
            this.subGenre = subGenre;
            this.pages = pages;
        }

        public override string ToString()
        {
            string info = $"Book: ID: {base.Id} - Title: {base.Title} - Release Date: {base.ReleaseDate} - Author: {base.Author} - Genre: {base.Genre} - Sub Genre: {this.subGenre} - Pages: {this.pages}";
            return info;
        }
    }
}
