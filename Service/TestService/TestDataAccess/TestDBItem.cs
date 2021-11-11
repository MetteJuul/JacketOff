using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService.TestDataAccess {
    public class TestDBItem {
        
        private ItemDB _itemDB;
        private Item _item;
        private ItemType _itemType;

        [SetUp]
        public void Setup() {
            _itemDB = new ItemDB(Configuration.CONNECTION_STRING);
            
        }

        [Test]
        public void TestCreateItem() {
            Assert.Pass();
        }
    }
}