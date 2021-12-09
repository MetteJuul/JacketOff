using API.DTOs;
using API.DTOs.Converters;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase {
        IOrderRepository _orderRepository;
        IOrderService _service;

        public OrdersController(IConfiguration configuration) {
            _orderRepository = new OrderRepository(configuration.GetConnectionString("JacketOff"));
            _service = new OrderService(configuration.GetConnectionString("JacketOff"));
        }

        //POST: api/orders
        [HttpPost]
        public async Task<ActionResult<int>> CreateReservation([FromBody] OrderDTO newOrderDTO) {

            return Ok(await _service.CreateOrder(newOrderDTO.FromDTO()));
        }

    }
}
