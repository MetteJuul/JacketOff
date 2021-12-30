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
        [Display(Name = "Ankomst:")]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Vælg et antal mellem 0 og 10.")]
        [Display(Name = "Antal Jakker:")]
        public int AmountOfJackets { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Vælg et antal mellem 0 og 10")]
        [Display(Name = "Antal Tasker:")]
        public int AmountOfBags { get; set; }

        [Display(Name = "Pris:")]
        public decimal Price { get; set; }
        public string WardrobeID_FK { get; set; }

    }
}
