using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Model
{
    public partial class Wardrobe
    {
        public Wardrobe()
        {
            Items = new HashSet<Item>();
        }

        public string WardrobeId { get; set; }
        public int MaxAmountOfItems { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
