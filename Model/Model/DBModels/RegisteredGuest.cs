using System;
using System.Collections.Generic;

#nullable disable

namespace Libraries.Model
{
    public partial class RegisteredGuest
    {
        public RegisteredGuest()
        {
            Orders = new HashSet<Order>();
            Reservations = new HashSet<Reservation>();
        }

        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        public virtual Guest Guest { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
