using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD
{
    public class LibraryItem
    {
        private int id;
        private string title;
        private DateTime releaseDate;
        private string author;
        private Genre genre;
        private decimal price;

        protected int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        protected string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        protected DateTime ReleaseDate
        {
            get { return this.releaseDate; }
            set { this.releaseDate = value; }
        }

        protected string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        protected Genre Genre
        {
            get { return this.genre; }
            set { this.genre = value; }
        }

        protected decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

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