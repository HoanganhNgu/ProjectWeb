using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace project.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
