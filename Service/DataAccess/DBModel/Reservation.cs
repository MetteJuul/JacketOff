using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Model
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int GuestIdFk { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AmountOfJackets { get; set; }
        public int AmountOfBags { get; set; }
        public decimal Price { get; set; }

        public virtual RegisteredGuest GuestIdFkNavigation { get; set; }
    }
}
