using APIClient;
using APIClient.DTOs;
using ConsumerWebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ConsumerWebClient.Controllers {
    public class SimpleGuestController : Controller {

        private IJacketOffApiClient _client;

        public SimpleGuestController(IJacketOffApiClient client) {
            _client = client;

        }

        public IActionResult Index() {
            return View();
        }

        // GET
        public ActionResult Create() {
            GuestViewModel guestViewModel = new();
            return View(guestViewModel);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Create(GuestViewModel guestViewModel) {
            GuestDTO guestDTO = guestViewModel.Guest;
            try {
                if (await _client.CreateSimpleGuest(guestDTO) > 0) {
                    TempData.Keep("notice");
                    TempData["Message"] = $"{guestDTO.Email}";
                    return View("GuestDetail");
                } else {
                    ViewBag.ErrorMessage = "Gæsten blev ikke oprettet!";
                }
            } catch (Exception e) {
                ViewBag.ErrorMessage = e.Message;
            }

            return View();
        }
    }
}
