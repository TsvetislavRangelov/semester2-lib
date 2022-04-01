using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Models.Models
{
   public class Manga : LibraryItem
    {
       readonly private int volumes;
       readonly  private int chapters;

        public Manga()
        {

        }

        public Manga(int id, string title, DateTime releaseDate, string author, Genre genre, int volumes, int chapters) : base(id, title, releaseDate, author, genre)
        {
            this.volumes = volumes;
            this.chapters = chapters;

        }

        public override string ToString()
        {
            string info = $"Manga: ID: {base.Id} - Title: {base.Title} - Release Date: {base.ReleaseDate} - Author: {base.Author} - Genre: {base.Genre} - Volumes: {this.volumes} - Chapters: {this.chapters}";
            return info;
        }
    }
}
