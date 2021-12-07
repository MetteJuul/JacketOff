using Dapper.Contrib.Extensions;
using System;

namespace API.DTOs {
    public class ReservationDTO {
        public int ReservationID { get; set; }
        public int GuestID_FK { get; set; }

        public DateTime OrderTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public int AmountOfJackets  { get; set; }

        public int AmountOfBags { get; set; }

        public decimal Price { get; set; }

        public string WardrobeID_FK { get; set; }

    }
}
