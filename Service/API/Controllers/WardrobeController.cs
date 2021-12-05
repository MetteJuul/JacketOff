using API.DTOs;
using API.DTOs.Converters;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace API.Controllers {
    public class WardrobeController : Controller {
        IWardrobeControlRepository _wardrobeControlRepository;

        public WardrobeController(IConfiguration configuration) {
            _wardrobeControlRepository = new WardrobeControlRepository(configuration.GetConnectionString("JacketOff"));
        }


        //GET: api/WardrobeControl/Count 
        [HttpGet("id")]
        public async Task<ActionResult<WardrobeControlDTO>> GetCount(string id) {
            var wardrobeControl = await _wardrobeControlRepository.GetWardrobeControlById(id);

            if (wardrobeControl == null) {
                return NotFound("Ingen garderober fundet blev fundet");
            } else {
                return Ok(wardrobeControl.ToDTO());
            }
        }

    }
}
