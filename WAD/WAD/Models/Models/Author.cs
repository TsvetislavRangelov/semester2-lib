using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
   public class Author
    {
        private string name;
        private DateTime birthDate;
        private List<LibraryItem> works;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public DateTime BirthDate
        {
            get { return this.birthDate; }
            set { this.birthDate = value; }
        }

        public Author()
        {
            this.works = new List<LibraryItem>();
        }

        public Author(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.works = new List<LibraryItem>();
        }
    }
}
