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
        private Guest _guest;

        [SetUp]
        public void Setup() {
            //Initiate fields
            _guestDB = new GuestDB(Configuration.CONNECTION_STRING);
            _newGuest = new Guest();
            _guest.ID = await _authorRepository.CreateAsync(_newGuest, "test1234");

        }

        [TearDown]
        public async Task CleanUpAsync() {
            await new GuestDB(Configuration.CONNECTION_STRING).DeleteAsync(_guest.ID);
        }

        //Write tests for each method from class diagram
        [Test]
        public async Task Test1() {
        // arrange

        // act

        // assert

            Assert.Pass();
        }
    }
}
