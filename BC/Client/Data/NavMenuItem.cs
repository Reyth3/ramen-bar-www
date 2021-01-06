using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Client.Data
{
    [AddINotifyPropertyChangedInterface]
    public class NavMenuItem
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }
        [AlsoNotifyFor("ListItemClass")]
        public bool IsActive { get; set; }
        public string ListItemClass => IsActive ? "active" : "";

        public NavMenuItem(string name, string icon, string route)
        {
            Name = name;
            Icon = icon;
            Route = route;
        }
    }
}
