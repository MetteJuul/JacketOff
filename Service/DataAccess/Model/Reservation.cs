using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class Reservation {

        public int ReservationID { get; set; }
        public int GuestID_FK { get; set; }
        public DateTime OrderTime { get; set; } 
        public DateTime ArrivalTime { get; set; }
        public int AmountOfJackets { get; set; }
        public int AmountOfBags { get; set; }
        public decimal Price { get; set; }
        public string WardrobeID_FK { get; set; }

    }
}
