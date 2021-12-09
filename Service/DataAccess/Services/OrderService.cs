using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services {
    public class OrderService : BaseDB, IOrderService {

        private IGuestRepository guestRepo;
        private IOrderRepository orderRepo;
        private IItemRepository itemRepo;
        private IDbTransaction transaction;

        public OrderService(string connectionString) : base(connectionString) {
            guestRepo = new GuestRepository(connectionString);
            orderRepo = new OrderRepository(connectionString);
            itemRepo = new ItemRepository(connectionString);
        }

        public async Task<int> CreateOrder(Order newOrder) {

            //Start Transaktion
            //Tjek om ordren indeholder data
            //Find gæst og deres email
            //Opret ordre og send email til gæst




            return await orderRepo.CreateOrder(newOrder);
        }
    }
}
