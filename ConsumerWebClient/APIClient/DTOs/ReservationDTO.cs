using System;
using System.ComponentModel.DataAnnotations;

namespace APIClient.DTOs
{
    public class ReservationDTO
    {

        public int ReservationID { get; set; } 

        [Required]
        public int GuestID_FK { get; set; } 
        
        public DateTime OrderTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public int AmountOfJackets { get; set; }

        [Required]
        public int AmountOfBags { get; set; }

        public decimal Price { get; set; }

        public string WardrobeID_FK { get; set; }

    }
}
