using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Laptop.Models
{
    public class LaptopProduct
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
    }
}