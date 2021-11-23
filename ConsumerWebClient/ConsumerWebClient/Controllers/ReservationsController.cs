using APIClient;
using APIClient.DTOs;
using ConsumerWebClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsumerWebClient.Controllers {

    public class ReservationsController : Controller {

        private IJacketOffApiClient _client;
        private string baseURL = "https://localhost:44391/api/reservations";

        public ReservationsController(IJacketOffApiClient client) {
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult> GetReservations() {

            IEnumerable<ReservationDTO> reservations = await _client.GetAllReservations();
            var reservationViewModel = new ReservationViewModel();
            reservationViewModel.Reservations = reservations;

            return View(reservationViewModel);
        }
        
        //[HttpPost]
        //public async Task <ActionResult> Create (ReservationDTO newReservation) {
            
        //    var 
        //}


        

    }
}
