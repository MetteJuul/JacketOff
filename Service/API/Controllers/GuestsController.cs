﻿using API.DTOs;
using API.DTOs.Converters;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase {
        IGuestRepository _guestRepository;

        public GuestsController(IConfiguration configuration) {
            _guestRepository = new GuestRepository(configuration.GetConnectionString("JacketOff"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuests() {
            //We create a variable to store our list of reservations
            var guests = await _guestRepository.GetAllGuests();

            //If no reservations are found we return NotFound
            if (guests == null) {
                return NotFound("Ingen Gæster blev fundet");
            } else {
                //Else we return 200 OK and the list of reservations
                return Ok(guests.ToDTOs());
            }
        }

        //POST: api/guests
        [HttpPost]
        public async Task<ActionResult<int>> CreateGuest([FromBody] GuestDTO newGuestDTO) {

            return Ok(await _guestRepository.CreateGuest(newGuestDTO.FromDTO()));
        }

        //GET api/guests/email
        [HttpGet("{email}")]
        public async Task<ActionResult<GuestDTO>> GetByGuestEmail(string email) {
            
            var foundGuest = await _guestRepository.GetByEmail(email);
            if (foundGuest == null) {
                return NotFound("Ingen gæst fundet");
            } else {
                return Ok(foundGuest.ToDTO());
            }
        }
    }
}
