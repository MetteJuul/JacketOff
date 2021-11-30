using APIClient;
using APIClient.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsumerWebClient.TestData;


namespace ConsumerWebClient.Controllers {

    public class ReservationsController : Controller {

        readonly DataPopulation _data;
        private IJacketOffApiClient _client;

        public ReservationsController(IJacketOffApiClient client) {
            _client = client;
            _data = new DataPopulation();
            
        }

        //Retrieves all the user's reservations
        [HttpGet]
        public async Task<ActionResult> MyReservations() {

            IEnumerable<ReservationDTO> reservations = await _client.GetReservationsByGuestEmail(_data.Guest.Email);

            return View(reservations);
        }

        //This method is purely used to generate the view
        //for creating a reservation. The data from
        //the view is not utilised before our Post method.
        //Therefore, nothing is added to this method.
        public ActionResult Reservation() {
            return View();
        }

        [HttpPost]
        public async Task <ActionResult> Reservation(ReservationDTO newReservation) {

            //Placeholder for retrieving guestID
            //from logged in user 
            newReservation.GuestID_FK = _data.Guest.GuestId;

            //We attempt to pass our reservation to
            //the CreateReservation method in our APIClient
            //If we fail, we show the error.
            try {
               await _client.CreateReservation(newReservation);
               return RedirectToAction(nameof(MyReservations));
            } catch {
                return View();
            }
        }

        
    }
}
