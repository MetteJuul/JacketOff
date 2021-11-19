using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class Item {
        //Constructor for building retrieved Items from the database
        public Item(int iD, Wardrobe wardrobe, ItemType itemType) {
            ID = iD;
            Wardrobe = wardrobe;
            ItemType = itemType;
        }

        //Constructor for creating Items to send to database
        public Item(Wardrobe wardrobe, ItemType itemType) {
            Wardrobe = wardrobe;
            ItemType = itemType;
        }

        public int ID { get; set; }
        public Wardrobe Wardrobe { get; set; }
        public ItemType ItemType { get; set; }

    }
}
