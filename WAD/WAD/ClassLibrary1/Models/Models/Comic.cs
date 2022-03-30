using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD
{
   public class Comic : LibraryItem
    {
        private string publisher;

        public Comic()
        {

        }

        public Comic(int id, string title, DateTime releaseDate, string author, Genre genre, string publisher) : base(id, title, releaseDate, author, genre)
        {
            this.publisher = publisher;
        }

        public override string ToString()
        {
            string info = $"Comic: ID: {base.Id} - Title: {base.Title} - Release Date: {base.ReleaseDate} - Author: {base.Author} - Genre: {base.Genre} - Publisher: {this.publisher}";
            return info;
        }
    }
}
