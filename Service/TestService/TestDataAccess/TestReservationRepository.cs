using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using NUnit;
using NUnit.Framework;

namespace TestService.TestDataAccess {
    public class TestReservationRepository {
        private ReservationRepository _reservationRepository;
        private Reservation _newReservation;
        private ItemType _itemType;
        private Wardrobe _wardrobe;

        [SetUp]
        public async Task SetupAsync() {
            _reservationRepository = new ReservationRepository(Configuration.CONNECTION_STRING);
            await CreateNewReservationAsync();
        }

        [TearDown]
        public async Task CleanUpAsync() {
            await new ReservationRepository(Configuration.CONNECTION_STRING).DeleteByID(_newReservation.ReservationID);
        }

        public async Task<Reservation> CreateNewReservationAsync() {
            _newReservation = new Reservation() {
                GuestID_FK = 2, OrderTime = DateTime.Now, ArrivalTime = DateTime.Now,
                AmountOfJackets = 2, AmountOfBags = 1, Price = 150
            };
            _newReservation.ReservationID = await _reservationRepository.CreateReservation(_newReservation);
            return _newReservation;
        }

        [Test]
        public void TestCreateReservation() {
            //ARRANGE & ACT is done in setup()

            //ASSERT
            Assert.IsTrue(_newReservation.ReservationID > 0, "Created reservation ID not returned");
        }

        [Test]
        public async Task TestGetAllReservations() {
            //ARRANGE
            //ACT
            var reservations = await _reservationRepository.GetAllReservations();

            //ASSERT
            Assert.IsTrue(reservations.Count() > 0, "No reservations returned");
        }

        [Test]
        public async Task TestGetById() {
            //ARRANGE is done in Setup()

            //ACT
            var foundReservation = await _reservationRepository.GetByID(_newReservation.ReservationID);

            //ASSERT
            //TODO specify why we are not comparing datetime
            Assert.IsTrue(_newReservation.ReservationID == foundReservation.ReservationID && _newReservation.GuestID_FK == foundReservation.GuestID_FK && _newReservation.AmountOfJackets == foundReservation.AmountOfJackets && _newReservation.AmountOfBags == foundReservation.AmountOfBags && _newReservation.Price == foundReservation.Price, "Reservation not found by ID");
        }

        [Test]
        public async Task TestUpdateReservation() {
            //ARRANGE
            decimal updatedPrice = 20;
            _newReservation.Price = updatedPrice;

            //ACT
            await _reservationRepository.UpdateReservation(_newReservation);

            //ASSERT
            var foundReservation = await _reservationRepository.GetByID(_newReservation.ReservationID);
            Assert.IsTrue(foundReservation.Price == _newReservation.Price, "Reservation not updated");
        }

        [Test]
        public async Task TestDeleteByID() {
            //ARRANGE is done in Setup()

            //ACT
            bool deleted = await _reservationRepository.DeleteByID(_newReservation.ReservationID);

            //ASSERT
            Assert.IsTrue(deleted, "Reservation not deleted");
        }

        [Test]
        public async Task TestGetByGuestEmail() {
            //ARRANGE 

            string email = "palle@dahlgaardstivoli.dk";


            //ACT
            var reservations = await _reservationRepository.GetByGuestEmail(email);

            //ASSERT
            Assert.IsTrue(reservations.Count() > 0, "No reservations returned");
        }

    }
}
