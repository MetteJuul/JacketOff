using APIClient;
using APIClient.DTOs;
using ConsumerWebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ConsumerWebClient.Controllers {
    public class GuestController : Controller {

        private IJacketOffApiClient _client;
        //private readonly ILogger<HomeController> _logger;
        public GuestController(IJacketOffApiClient client) {
            _client = client;

        }
        // GET: GuestController
        public ActionResult Index() {
            return View();
        }

        // GET: GuestController/Guest
        // Vi opretter et view med vores GuestViewModel til vores POST-metode nedenfor.
        public ActionResult Guest() {
            GuestViewModel guestViewModel = new();
            return View(guestViewModel);
        }

        // POST: GuestController/Create
        // Vi modtager GuestViewModel fra GET ovenfor og sætter indholdet ind i GuestDTO 
        [HttpPost]
        public async Task<IActionResult> Guest(GuestViewModel guestViewModel) {
            GuestDTO guestDTO = guestViewModel.Guest; 
            try {
                if (await _client.CreateSimpleGuest(guestDTO) > 0) {
                    TempData["Message"] = $"Gæst {guestDTO} oprettet!";
                    return RedirectToAction(nameof(Index), "Home");
                } else {
                    ViewBag.ErrorMessage = "Gæsten blev ikke oprettet!";
                }
            } catch (Exception ex) {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
    }
}