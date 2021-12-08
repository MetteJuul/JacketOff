using APIClient.DTOs;
using System.Collections.Generic;

namespace ConsumerWebClient.Models
{
    public class ReservationViewModel
    {
        public ReservationDTO Reservation { get; set; }
        public IEnumerable<ItemTypeDTO> ItemTypes { get; set; }

    }
}
