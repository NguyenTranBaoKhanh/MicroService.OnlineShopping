using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Mobile.Models
{
    public class MobileProduct
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
    }
}