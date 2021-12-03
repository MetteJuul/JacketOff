using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktopClient.DTOs {
    public class OrderDTO {
        public int ID { get; set; }
        public int ticketNumber { get; set; }
        public string link { get; set; }
        public DateTime checkInTime { get; set; }
        public DateTime oickUpTime { get; set; }

    }
}
