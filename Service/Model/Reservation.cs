using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Reservation {
        //Constructor for retrieving and building Reservations from the database
        public Reservation(int iD, DateTime orderTime, DateTime arrivalTime, int amountOfJackets, int amountOfBags, decimal price) {
            ID = iD;
            OrderTime = orderTime;
            ArrivalTime = arrivalTime;
            AmountOfJackets = amountOfJackets;
            AmountOfBags = amountOfBags;
            Price = price;
        }

        //Constructor for creating and sending Reservations to the database
        public Reservation(DateTime orderTime, DateTime arrivalTime, int amountOfJackets, int amountOfBags, decimal price) {
            OrderTime = orderTime;
            ArrivalTime = arrivalTime;
            AmountOfJackets = amountOfJackets;
            AmountOfBags = amountOfBags;
            Price = price;
        }
        public int ID { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AmountOfJackets { get; set; }
        public int AmountOfBags { get; set; }
        public decimal Price { get; set; }

    }
}
