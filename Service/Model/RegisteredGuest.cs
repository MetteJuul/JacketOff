using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class RegisteredGuest : Guest {
       //Constructor for retrieving and building RegisteredGuests from the database
        public RegisteredGuest(int iD, string email, string firstName, string lastName, 
            string phoneNumber) : base(iD, email){
            
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        //Constructor for creating and sending RegisteredGuests to the database
        public RegisteredGuest(string email, string firstName, string lastName,
            string phoneNumber) : base(email) {

            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
