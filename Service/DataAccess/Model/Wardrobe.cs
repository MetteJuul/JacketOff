using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class Wardrobe {
        //Constructor for retrieving and building Wardrobes from the database
        public Wardrobe(string iD, int maxAmountOfItems) {
            ID = iD;
            MaxAmountOfItems = maxAmountOfItems;
        }

        //Constructor for creating and sending Wardrobes to the database
        public Wardrobe(int maxAmountOfItems) {
            MaxAmountOfItems = maxAmountOfItems;
        }


        public string ID { get; set; }
        public int MaxAmountOfItems { get; set; }
    }
}
