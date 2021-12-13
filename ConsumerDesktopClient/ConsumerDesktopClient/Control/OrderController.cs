using ConsumerDesktopClient.DTOs;
using ConsumerDesktopClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktopClient.Control {
    public class OrderController {

        static OrderController _object;
        private readonly OrderService _orderService;

        public static OrderController GetInstance() {
            if (_object == null) {
                _object = new OrderController();
            }
            return _object;
        }

        private OrderController() {
            _orderService = new OrderService();
            JakkeNumre = new List<int>();
            TaskeNumre = new List<int>();
        }

        public List<int> JakkeNumre { get; set; }
        public List<int> TaskeNumre { get; set; }
        public int AntalJakker { get; set; }
        public int AntalTasker { get; set; }
        public GuestDTO Guest { get; set; }
        public IEnumerable<GuestDTO> AllGuests { get; set; }

        public async Task<IEnumerable<GuestDTO>> GetAllGuests() {
            AllGuests = await _orderService.GetAllGuests();
            return AllGuests;
        }

        public async Task CreateOrder() {

            var order = new OrderDTO();

            //Will be collected from some metadata eventually
            order.WardrobeID_FK = "guldhornene";
            order.GuestID_FK = Guest.GuestID;

            var orders = new List<OrderDTO>();

            foreach (var item in JakkeNumre) {
                order.TypeID_FK = 1;
                order.TicketNumber = item;
                orders.Add(order);
            }

            foreach (var item in TaskeNumre) {
                order.TypeID_FK = 2;
                order.TicketNumber = item;
                orders.Add(order);
            }


            try {

                foreach (OrderDTO item in orders) {
                    await _orderService.CreateOrder(item);
                }
            } catch (Exception e) {
                throw new Exception($"Fejl ved oprettelse af ordrer '{e.Message}'.", e);
            }
        }
    }
}
