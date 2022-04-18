using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
   public class UpdatedManga
    {
        [Required(ErrorMessage = "The Title field must be not empty.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Release Date must not be empty.")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "The Author field must not be empty")]
        public string Author { get; set; }

        public UpdatedManga() { }
    }
}
