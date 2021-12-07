using API.DTOs;
using API.DTOs.Converters;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class WardrobeController : Controller {
        private IWardrobeControlRepository _wardrobeControlRepository;

        public WardrobeController(IConfiguration configuration) {
            _wardrobeControlRepository = new WardrobeControlRepository(configuration.GetConnectionString("JacketOff"));
        }


        //GET: api/WardrobeControl/{id} 
        [HttpGet("id")]
        public async Task<ActionResult<WardrobeControlDTO>> GetCount(string id, DateTime date) {
            var wardrobeControl = await _wardrobeControlRepository.GetWardrobeControlByIdAndDate(id, date);

            if (wardrobeControl == null) {
                return NotFound("Ingen garderober fundet blev fundet");
            } else {
                return Ok(wardrobeControl.ToDTO());
            }
        }

        //PUT: /api/WardrobeControl/{id}

        [HttpPut("id")]

        public async Task<IActionResult> UpdateCount([FromBody] WardrobeControlDTO wardrobeControlDTOUpdate) {
            if (!await _wardrobeControlRepository.UpdateCount(wardrobeControlDTOUpdate.FromDTO())) {
                return NotFound("Kunne ikke opdatere antal ledige pladser");
            } else {
                return Ok();
            }
        }

}

}

