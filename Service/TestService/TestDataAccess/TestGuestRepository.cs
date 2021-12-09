using DataAccess;
using DataAccess.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService.TestDataAccess
{
    public class TestDBGuest
    {

        //Setup fields
        private GuestRepository _guestRepository;
        private Guest _newGuest;

        [SetUp]
        public async Task SetupAsync()
        {
            _guestRepository = new GuestRepository(Configuration.CONNECTION_STRING);     
        }

        [Test]
        public async Task TestGetGuestByEmail()
        {
            // arrange & act is done in setup    
            string email = "Andreas@BigD.com";
            var foundGuest = await _guestRepository.GetByEmail(email);

            // assert
            Assert.IsTrue(foundGuest.Email.Equals("Andreas@BigD.com"), "Gæst ikke fundet");
        }
    }
}
