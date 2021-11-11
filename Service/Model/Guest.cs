using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Guest {
        //Constructor for building retrieved Guests from the database
        public Guest(int iD, string email) {
            ID = iD;
            Email = email;
        }

        //Constructor for creating and sending Guests to the database
        public Guest(string email) {
            Email = email;
        }

        public int ID { get; set; }
        public string Email { get; set; }
    }
}
