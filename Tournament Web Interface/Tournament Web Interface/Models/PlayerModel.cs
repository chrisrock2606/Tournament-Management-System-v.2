using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament_Web_Interface.Models
{
    public class PlayerModel
    {
        [Required(ErrorMessage = "The ID is required.")]
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "The firstname is required.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "The lastname is required.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "The username is required.")]
        public string Username { get; set; }

        [RegularExpression(@"\d{8}",
            ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

    }
}
