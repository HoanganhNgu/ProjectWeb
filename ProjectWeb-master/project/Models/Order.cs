using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Customer { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int OrderStock { get; set; }
        [Required]

        public int BookId { get; set; }

        [Required]
        public char IsAccepted { get; set; }

        public Book Book { get; set; }
    }
}

