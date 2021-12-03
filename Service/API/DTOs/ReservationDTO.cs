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


        //Dapper is a microORM, it doesn't offer the mapping features found in full ORMs like EF or NHibernate.
        //Dapper.Contrib adds some helper methods and very basic mapping
        //I have installed the Dapper.Contrib nuget (Line)
        //[Write(false)]
        //public Int64 RowID { get; set; }

    }
}
