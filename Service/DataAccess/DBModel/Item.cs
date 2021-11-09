using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Model
{
    public partial class Item
    {
        public Item()
        {
            Orders = new HashSet<Order>();
        }

        public int ItemId { get; set; }
        public string WardrobeIdFk { get; set; }
        public int TypeIdFk { get; set; }

        public virtual Type TypeIdFkNavigation { get; set; }
        public virtual Wardrobe WardrobeIdFkNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
