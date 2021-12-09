using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class Item {
        public int ID { get; set; }
        public Wardrobe Wardrobe { get; set; }
        public ItemType ItemType { get; set; }

    }
}
