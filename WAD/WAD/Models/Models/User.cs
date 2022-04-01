using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Models.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a username")]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        public string DbUsername { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Your email address is invalid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Incorrect password")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public Role Role { get; set; }

        public User()
        {

        }

        public User(int id, string username, string email, string password, Role role)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }

    }
}
