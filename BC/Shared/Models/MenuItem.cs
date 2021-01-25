using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        [MaxLength(96)]
        public string ItemName { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
