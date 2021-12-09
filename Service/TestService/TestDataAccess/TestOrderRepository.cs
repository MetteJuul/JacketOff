using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Repositories;
using NUnit;
using NUnit.Framework;

namespace TestService.TestDataAccess {
    public class TestDBOrder {
        //Setup fields
        private OrderRepository _orderRepository;
        private Order _newOrder;

        [SetUp]
        public async Task SetupAsync() {
            _orderRepository = new OrderRepository(Configuration.CONNECTION_STRING);
            await CreateNewOrderAsync();
        }

        [TearDown]
        public async Task CleanUpAsync() {
            await new OrderRepository(Configuration.CONNECTION_STRING).DeleteByID(_newOrder.OrderID);
        }

        public async Task<Order> CreateNewOrderAsync() {
            _newOrder = new Order()
            {
                ItemID_FK = 9, GuestID_FK = 2, TicketNumber = 157, Link = "somethingsomething.com", Paid = true
            };
            _newOrder.OrderID = await _orderRepository.CreateOrder(_newOrder);
            return _newOrder;
        }

        [Test]
        public async Task TestCreateOrder() {
            // arrange

            // act
            await CreateNewOrderAsync();
            // assert
            Assert.IsTrue(_newOrder.OrderID > 0, "Created order ID not returned");
        }

        [Test]
        public async Task DeleteByID() {
            // arrange

            // act
            bool deleted = await _orderRepository.DeleteByID(_newOrder.OrderID);

            // assert
            Assert.IsTrue(deleted, "Order not deleted");
        }
    }
}
