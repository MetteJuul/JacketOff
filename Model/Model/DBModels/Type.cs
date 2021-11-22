using System;
using System.Collections.Generic;

#nullable disable

namespace Libraries.Model
{
    public partial class Type
    {
        public Type()
        {
            Items = new HashSet<Item>();
        }

        public int TypeId { get; set; }
        public decimal Price { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
