using BC.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared
{
    public class MenuItemVM
    {

        public int MenuItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public static implicit operator MenuItemVM (MenuItem mi) {
            if (mi == null)
                return null;
            return new MenuItemVM()
            {
                Description = mi.Description,
                ItemName = mi.ItemName,
                MenuItemId = mi.MenuItemId,
                Price = mi.Price
            };
        }
    }
}
