using System;

namespace API.DTOs {
    public class OrderDTO {
        public int ID { get; set; }
        public int ticketNumber { get; set; }
        public string link { get; set; }
        public DateTime checkInTime { get; set; }
        public DateTime dateTime { get; set; }
    }
}
