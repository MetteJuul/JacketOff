using API.DTOs;
using API.DTOs.Converters;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ItemTypesController : Controller {

        IItemTypeRepository _itemTypeRepository;

        public ItemTypesController(IConfiguration configuration) {
            _itemTypeRepository = new ItemTypeRepository(configuration.GetConnectionString("JacketOff"));
        }

        //GET: api/itemTypes        
        [HttpGet]
        public async Task<ActionResult<List<ItemTypeDTO>>> GetAllItemTypes() {

            var itemTypes = await _itemTypeRepository.GetAllItemTypes();

            if (itemTypes == null) {
                return NotFound("Ingen reservationer blev fundet");
            } else {
                return Ok(itemTypes.ItemTypesToDTOs());
            }
        }

        //GET api/itemTypes/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemTypeDTO>> GetByTypeID(int id) {
            var itemTypeDTO = await _itemTypeRepository.GetItemType(id);
            if (itemTypeDTO == null) { return NotFound("Ingen type fundet"); } else { return Ok(itemTypeDTO); }
        }

    }

}
