using ConsumerDesktopClient.DTOs;
using ConsumerDesktopClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktopClient.Control {
    public class ReservationController {

        private readonly ReservationService _reservationService;

        public ReservationController() {
            _reservationService = new ReservationService();
        }

        public async Task<IEnumerable<ReservationDTO>> GetAllReservations() {
            IEnumerable<ReservationDTO> foundReservations;
            try {
                foundReservations = await _reservationService.GetAllReservations();
            } catch {
                foundReservations = null;
            }
            return foundReservations;
        }
    }
}
