using APIClient;
using APIClient.DTOs;
using ConsumerWebClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsumerWebClient.TestData;

namespace ConsumerWebClient.Controllers {

    public class ReservationsController : Controller {

        readonly DataPopulation _data;
        private IJacketOffApiClient _client;
        private string baseURL = "https://localhost:44391/api/reservations";

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

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task <ActionResult> Create(ReservationDTO newReservation) {

            //Placeholder until we can retrieve the data
            newReservation.GuestID_FK = 2;

            //We set the order time, as the time the order is created
            newReservation.OrderTime = DateTime.Now;

            try {
               await _client.CreateReservation(newReservation);
               return RedirectToAction(nameof(GetAllReservations));
            } catch {
                return View();
            }
        }

    }
}
