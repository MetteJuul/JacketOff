using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Order {
        //Constructor for retrieving and building Orders from the database 
        public Order(int iD, int ticketNumber, string link, DateTime checkInTime, DateTime pickUpTime, bool paid) {
            ID = iD;
            TicketNumber = ticketNumber;
            Link = link;
            CheckInTime = checkInTime;
            PickUpTime = pickUpTime;
            Paid = paid;
        }
        //Constructor for creating new Orders in the database
        public Order(int ticketNumber, string link, DateTime checkInTime, DateTime pickUpTime, bool paid) {
            TicketNumber = ticketNumber;
            Link = link;
            CheckInTime = checkInTime;
            PickUpTime = pickUpTime;
            Paid = paid;
        }

        public int ID { get; set; }
        public int TicketNumber { get; set; }
        public string Link { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime PickUpTime { get; set; }
        public bool Paid { get; set; }


    }
}
