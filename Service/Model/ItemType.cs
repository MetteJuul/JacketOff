using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class ItemType {
        //Constructor for retrieving and building ItemTypes from the database
        public ItemType(int iD, decimal price, string name) {
            ID = iD;
            Price = price;
            Name = name;
        }
        //Constructor for creating new ItemTypes in the database
        public ItemType(decimal price, string name) {
            Price = price;
            Name = name;
        }

        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
