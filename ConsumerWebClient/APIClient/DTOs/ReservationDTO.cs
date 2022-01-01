using System;
using System.ComponentModel.DataAnnotations;

namespace APIClient.DTOs
{
    public class ReservationDTO{


        public int ReservationID { get; set; }

        [Required]
        public int GuestID_FK { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        //Tilføjet efter aflevering
        //Validering af tilladt range på input,
        //sikre at brugeren ikke kan give negative værdier
        [Required]
        [Range(0,100, ErrorMessage = "Vælg venligst et tal mellem 0 og 100")]
        public int AmountOfJackets { get; set; }

        //Tilføjet efter aflevering
        //Validering af tilladt range på input,
        //sikre at brugeren ikke kan give negative værdier
        [Required]
        [Range(0, 100, ErrorMessage = "Vælg venligst et tal mellem 0 og 100")]
        public int AmountOfBags { get; set; }
        public decimal Price { get; set; }
        public string WardrobeID_FK { get; set; }

        
    }
}
