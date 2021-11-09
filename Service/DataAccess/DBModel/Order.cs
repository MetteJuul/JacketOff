using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Model
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int ItemIdFk { get; set; }
        public int GuestIdFk { get; set; }
        public int TicketNumber { get; set; }
        public string Link { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? PickUpTime { get; set; }
        public bool Paid { get; set; }

        public virtual RegisteredGuest GuestIdFkNavigation { get; set; }
        public virtual Item ItemIdFkNavigation { get; set; }
    }
}
