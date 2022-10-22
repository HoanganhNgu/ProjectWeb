using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace project.Models
{
    public class Account : IndetityUser
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        
    }
}
