using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService.TestDataAccess {
    public class TestDBGuest {

        //Setup fields
        private GuestDB _guestDB;
        private Guest _newGuest;

        [SetUp]
        public async Task AsyncSetup() {
            //Initiate fields
            _guestDB = new GuestDB(Configuration.CONNECTION_STRING);
            await CreateNewGuestAsync();
        }

        [TearDown]
        public async Task CleanUpAsync() {
            await new GuestDB(Configuration.CONNECTION_STRING).DeleteAsync(_newGuest.ID);
        }

        private async Task<Guest> CreateNewGuestAsync() {
            _newGuest = new Guest("testGuest@mail.com"); 
            _newGuest.ID = await _guestDB.CreateAsync(_newGuest);
            return _newGuest;
        }

        [Test]
        public void TestCreateGuest() { 
            // arrange & act is done in setup    

            // assert
            Assert.IsTrue(_newGuest.ID > 0, "Created guest ID not returned");
        }

        [Test]
        public async Task TestGetAllGuests() {
            // arrange

            // act
            var guests = await _guestDB.GetAllAsync();
            // assert
            Assert.IsTrue(guests.Count() > 0, "No guests returned");
        }

        [Test]
        public async Task TestGetByID() {
            // arrange

            // act
            var foundGuest = await _guestDB.GetByID(_newGuest.ID);
            // assert          
            Assert.IsTrue(_newGuest.ID == foundGuest.ID, "Guest not found");
        }

        [Test]
        public async Task TestUpdateGuestAsync() {
            // arrange
            string updatedEmail = "andreas@dahlgaard.dk";
            _newGuest.Email = updatedEmail;

            // act
            await _guestDB.UpdateGuest(_newGuest);

            // assert       
            var foundGuest = await _guestDB.GetByID(_newGuest.ID);
            Assert.IsTrue(foundGuest.Email == updatedEmail, "Guest not updated");
        }

        [Test]
        public async Task TestDeleteByIDAsync() {
            // arrange

            // act
            bool deleted = await _guestDB.deleteByID(_newGuest.ID);
            
            // assert
            Assert.IsTrue(deleted, "Guest not deleted");
        }  
    }
}
