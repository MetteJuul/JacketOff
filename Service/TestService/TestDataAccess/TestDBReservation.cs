﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NUnit;
using NUnit.Framework;

namespace TestService.TestDataAccess {
    public class testDBReservation {
        private ReservationDB _reservationDB;
        private Reservation _newReservation;
        private ItemType _itemType;
        private Wardrobe _wardrobe;

        [SetUp]
        public async Task SetupAsync() {
            _reservationDB = new ReservationDB(Configuration.CONNECTION_STRING);
            await CreateNewReservationAsync();
        }

        [TearDown]
        public async Task CleanUpAsync() {
            await new ReservationDB(Configuration.CONNECTION_STRING).DeleteAsync();
        }

        public async Task<Reservation> CreateNewReservationAsync() {
            _newReservation = new Reservation(DateTime.Now, DateTime.Now, 1, 2, 50);
            _newReservation.ID = await _reservationDB.CreateAsync(_newReservation);
            return _newReservation;
        }

        [Test]
        public void TestCreateReservation() {
            //ARRANGE & ACT is done in setup()

            //ASSERT
            Assert.IsTrue(_newReservation.ID > 0, "Created reservation ID not returned");
        }

        [Test]
        public async Task TestGetAllReservations() {
            //ARRANGE
            //ACT
            var reservations = await _reservationDB.GetAllReservations();
            
            //ASSERT
            Assert.IsTrue(reservations.Count() > 0, "No reservations returned");
        }

        [Test]
        public async Task TestGetById() {
            //ARRANGE is done in Setup()

            //ACT
            var foundReservation = await _reservationDB.GetByID(_newReservation.ID);

            //ASSERT
            Assert.IsTrue(_newReservation.ID == foundReservation.ID && _newReservation.ArrivalTime == foundReservation.ArrivalTime && _newReservation.OrderTime == foundReservation.OrderTime && _newReservation.AmountOfJackets == foundReservation.AmountOfJackets && _newReservation.AmountOfBags == foundReservation.AmountOfBags && _newReservation.Price == foundReservation.Price, "Reservation not found by id");
        }

        [Test]
        public async Task TestUpdateReservation() {
            //ARRANGE
            decimal updatedPrice = 20;
            _newReservation.Price = updatedPrice;

            //ACT
            await _reservationDB.UpdateReservation(_newReservation);

            //ASSERT
            var foundReservation = await _reservationDB.GetByID(_newReservation.ID);
            Assert.IsTrue(foundReservation.Price == _newReservation.Price, "Reservation not updated");
        }

        [Test]
        public async Task TestDeleteByID() {
            //ARRANGE is done in Setup()

            //ACT
            bool deleted = await _reservationDB.DeleteByID(_newReservation.ID);

            //ASSERT
            Assert.IsTrue(deleted, "Reservation not deleted");
        }

    }
}
