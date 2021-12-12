using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktopClient.DTOs {
    public class OrderDTO {
        public int OrderID { get; set; }
        public int TypeID_FK { get; set; }
        public int GuestID_FK { get; set; }
        public string WardrobeID_FK { get; set; }
        public int TicketNumber { get; set; }
        public string Link { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime PickUpTime { get; set; }
        public bool Paid { get; set; }

    }
}
