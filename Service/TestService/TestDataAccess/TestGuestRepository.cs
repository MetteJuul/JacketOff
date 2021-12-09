using DataAccess;
using DataAccess.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService.TestDataAccess {
    public class TestGuestRepository {

        //Setup fields
        private GuestRepository _guestRepository;
        private Guest _newGuest;

        #region Setup and teardown
        [SetUp]
        public async Task SetupAsync() {
            _guestRepository = new GuestRepository(Configuration.CONNECTION_STRING);
            await CreateNewGuestAsync();
        }

        [TearDown]
        public async Task CleanUpAsync() {
            await new GuestRepository(Configuration.CONNECTION_STRING).DeleteByID(_newGuest.GuestID);
        }
        public async Task<Guest> CreateNewGuestAsync() {
            _newGuest = new Guest()
            {
                Email = "testemail@dethererentest.dk"
            };
            _newGuest.GuestID = await _guestRepository.CreateGuest(_newGuest);
            return _newGuest;
        }
        #endregion

        [Test]
        public async Task TestGetGuestByEmail() {
            // arrange & act is done in setup    
            string email = "Andreas@BigD.com";
            var foundGuest = await _guestRepository.GetByEmail(email);

            // assert
            Assert.IsTrue(foundGuest.Email.Equals("Andreas@BigD.com"), "Gæst ikke fundet");
        }

        [Test]
        public void TestCreateGuest() {
            // arrange

            // act
            
            // assert
            Assert.IsTrue(_newGuest.GuestID > 0, "Created order ID not returned");
        }
    }
}
