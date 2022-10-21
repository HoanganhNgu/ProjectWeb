using System;
using System.Collections;
using System.Collections.Generic;

namespace project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStock { get; set; }
        public double OrderPrice { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}

