using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktopClient.DTOs
{
    internal class ReservationDTO
    {
        public int ReservationID { get; set; }
        [Required]
        public int GuestID_FK { get; set; }

        public DateTime OrderTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Required]
        public int AmountOfJackets { get; set; }
        public decimal Price { get; set; }
    }
}
