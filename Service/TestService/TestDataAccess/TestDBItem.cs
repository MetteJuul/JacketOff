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
        private Item _newItem;
        private ItemType _itemType;
        private Wardrobe _wardrobe;

        [SetUp]
        public async Task SetupAsync() {
            _itemDB = new ItemDB(Configuration.CONNECTION_STRING);
            _itemType = new ItemType(1, 50, "Jakke");
            _wardrobe = new Wardrobe("Guldhornene", 50);
            await CreateNewItemAsync();
        }

        [TearDown]
        public async Task CleanUpAsync() {
            await new ItemDB(Configuration.CONNECTION_STRING).DeleteAsync();
        }

        public async Task<Item> CreateNewItemAsync() {
            _newItem = new Item(_wardrobe, _itemType);
            _newItem.ID = await _itemDB.CreateAsync(_newItem);
            return _newItem;
        }

        [Test]
        public void TestCreateItem() {
            //ARRANGE & ACT is done in setup()

            //ASSERT
            Assert.IsTrue(_newItem.ID > 0, "Created item ID not returned");
        }

        [Test]
        public async Task TestGetAllItems() {
            //ARRANGE
            //ACT
            var items = await _itemDB.GetAllItems();
            //
            Assert.IsTrue(items.Count() > 0, "No items returned");
        }

        [Test]
        public async Task TestGetById() {
            //ARRANGE is done in Setup()

            //ACT
            var foundItem = await _itemDB.GetByID(_newItem.ID);

            //ASSERT
            Assert.IsTrue(_newItem.ID == foundItem.ID && _newItem.ItemType == foundItem.ItemType && _newItem.Wardrobe == foundItem.Wardrobe, "Item not found by id");
        }

        [Test]
        public async Task TestUpdateItem() {
            //ARRANGE
            Wardrobe updatedWardrobe = new Wardrobe("Den Nordjyske Ambassade", 5);
            _newItem.Wardrobe = updatedWardrobe;

            //ACT
            await _itemDB.UpdateItem(_newItem);

            //ASSERT
            var foundItem = await _itemDB.GetByID(_newItem.ID);
            Assert.IsTrue(foundItem.Wardrobe == _newItem.Wardrobe, "Item not updated");
        }

        [Test]
        public async Task TestDeleteByID() {
            //ARRANGE is done in Setup()

            //ACT
            bool deleted = await _itemDB.DeleteByID(_newItem.ID);

            //ASSERT
            Assert.IsTrue(deleted, "Item not deleted");
        }

    }
}