using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NUnit;
using NUnit.Framework;

namespace TestService.TestDataAccess {
    public class TestDBOrder {
        //Setup fields
        private OrderDB _orderDB;
        private Order _newOrder;
       
        [SetUp]
        public async Task AsyncSetup() {
            //Initiate fields
            _orderDB = new OrderDB(Configuration.CONNECTION_STRING);
            await CreateNewOrderAsync();
        }

        [TearDown]
        public async Task CleanUpAsync() {
            await new OrderDB(Configuration.CONNECTION_STRING).DeleteAsync(_newOrder.ID);
        }

        private async Task<Order> CreateNewOrderAsync() {
            _newOrder = new Order(876, "JegErEtLink.Com", DateTime.Now, DateTime.Now, true);
            _newOrder.ID = await _orderDB.CreateAsync(_newOrder);
            return _newOrder;
        }

        [Test]
        public void TestCreateOrder() {
            // arrange

            // act

            // assert
            Assert.IsTrue(_newOrder.ID > 0, "Created order ID not returned");
        }

        [Test]
        public async Task TestGetAllOrders() {
            // arrange

            // act
            var orders = await _orderDB.GetAllAsync();
            // assert
            Assert.IsTrue(orders.Count() > 0, "No orders returned");
        }

        [Test]
        public async Task TestGetByID() {
            // arrange

            // act
            var foundOrder = await _orderDB.GetByID(_newOrder.ID);
            // assert          
            Assert.IsTrue(_newOrder.ID == foundOrder.ID && _newOrder.TicketNumber == foundOrder.TicketNumber && _newOrder.Link == foundOrder.Link && _newOrder.CheckInTime == foundOrder.CheckInTime && _newOrder.PickUpTime == foundOrder.PickUpTime && _newOrder.Paid == foundOrder.Paid, "Order not found");
        }

        [Test]
        public async Task TestUpdateOrderAsync() {
            // arrange
            int updatedTicketNumber = 420;
            _newOrder.TicketNumber = updatedTicketNumber;

            // act
            await _orderDB.UpdateOrder(_newOrder);

            // assert       
            var foundOrder = await _orderDB.GetByID(_newOrder.ID);
            Assert.IsTrue(foundOrder.TicketNumber == updatedTicketNumber, "Order not updated");
        }

        [Test]
        public async Task DeleteByID() {
            // arrange

            // act
            bool deleted = await _orderDB.deleteByID(_newOrder.ID);

            // assert
            Assert.IsTrue(deleted, "Order not deleted");
        }
    }
}
