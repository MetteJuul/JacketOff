using APIClient.DTOs;
using System.Collections.Generic;

namespace ConsumerWebClient.Models {
    public class ReservationViewModel {

        public IEnumerable<ReservationDTO> Reservations { get; set; }

    }
}
