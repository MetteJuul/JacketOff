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
        public async Task<ActionResult> GetAllReservations() {

            IEnumerable<ReservationDTO> reservations = await _client.GetAllReservations();
            
            return View(reservations);
        }

        [HttpGet]
        public async Task<ActionResult> GetMyReservations() {

            IEnumerable<ReservationDTO> reservations = await _client.GetReservationsByGuestEmail("palle@dahlgaardstivoli.dk");

            return View(reservations);
        }
        
        //[HttpPost]
        //public async Task <ActionResult> Create (ReservationDTO newReservation) {
            
        //    var 
        //}


        

    }
}
