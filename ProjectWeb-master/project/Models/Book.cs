using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace project.Models
{
    public class Book
    {
        public int Id { get; set; }


        [Required]

        [MinLength(1, ErrorMessage = "Book's name length must be at least 1 characters")]
        [MaxLength(100, ErrorMessage = "Max name length is 100 characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "range is from 1 to 9999")]
        public int Price { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Book's name length must be at least 1 characters")]
        [MaxLength(1000, ErrorMessage = "Max name length is 100 characters")]
        public string Description { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "range is from 1 to 9999")]
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
