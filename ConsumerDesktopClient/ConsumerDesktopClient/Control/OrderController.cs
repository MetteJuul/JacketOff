using ConsumerDesktopClient.DTOs;
using ConsumerDesktopClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktopClient.Control {
    public class OrderController {

        private readonly OrderService _orderService;

        public OrderController() {
            _orderService = new OrderService();
        }

        public async Task CreateOrder(OrderDTO order) {

            try {
                await _orderService.CreateOrder(order);
            } catch (Exception e) {
                throw new Exception($"Fejl ved oprettelse af ordrer '{e.Message}'.", e);
            }
        }      
    }
}
