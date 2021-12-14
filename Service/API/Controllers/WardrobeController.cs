using API.DTOs;
using API.DTOs.Converters;
using DataAccess.Model;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace API.Controllers {

    [Route("api/WardrobeControl")]
    [ApiController]
    public class WardrobeController : Controller {

        WardrobeControlRepository _wardrobeControlRepository;
        WardrobeRepository _wardrobeRepository;


        public WardrobeController(IConfiguration configuration) {
            _wardrobeControlRepository = new WardrobeControlRepository(configuration.GetConnectionString("JacketOff"));
            _wardrobeRepository = new WardrobeRepository(configuration.GetConnectionString("JacketOff"));
        }

        //GET api/WardrobeControl/id and date
        //virker ikke
        [HttpGet("{ID}/{date}")]
        public async Task<ActionResult<WardrobeControlDTO>> GetWardrobeControlByIdAndDate(string ID, DateTime date) {
            var WardrobeControlDTO = await _wardrobeControlRepository.GetWardrobeControlByIdAndDate(ID, date);
            if (WardrobeControlDTO == null) { return NotFound("Ingen garderobekontrol fundet"); } else { return Ok(WardrobeControlDTO); }
        }

        
    }
} 
