
using DataAccess;
using DataAccess.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService.TestDataAccess {
    public class TestItemRepository {

        private ItemRepository _itemRepository;
        private Item _newItem;
        private ItemType _newItemType;

        #region Setup and Teardown
        [SetUp]
        public async Task SetupAsync() {
            _itemRepository = new ItemRepository(Configuration.CONNECTION_STRING);
            await CreateNewItemAsync();
            await CreateNewItemTypeAsync();
        }

        [TearDown]
        public async Task CleanUpAsync() {
            await new ItemRepository(Configuration.CONNECTION_STRING).DeleteByID(_newItem.ItemID);
            await new ItemRepository(Configuration.CONNECTION_STRING).DeleteItemTypeByID(_newItemType.TypeID);
        }
        #endregion

        #region Setup help methods
        public async Task<Item> CreateNewItemAsync() {
            _newItem = new Item()
            {
                WardrobeID_FK = "Guldhornene",
                TypeID_FK = 1,
            };
            _newItem.ItemID = await _itemRepository.CreateItem(_newItem);
            return _newItem;
        }

        public async Task<ItemType> CreateNewItemTypeAsync() {
            _newItemType = new ItemType()
            {
                Price = 50,
                TypeName = "Test Type"
            };
            _newItemType.TypeID = await _itemRepository.CreateItemType(_newItemType);
            return _newItemType;
        }
        #endregion

        #region ItemType tests
        [Test]
        public async Task TestGetAllItemTypes() {
            //ARRANGE

            //ACT
            var items = await _itemRepository.GetAllItemTypes();
            
            //ASSERT
            Assert.IsTrue(items.Count() > 0, "No items returned");
        }

        [Test]
        public async Task TestGetItemTypeById() {
            //ARRANGE

            //ACT
            var foundItemType = await _itemRepository.GetItemTypeByID(_newItemType.TypeID);

            //ASSERT
            Assert.IsTrue(_newItemType.TypeID == foundItemType.TypeID && _newItemType.Price == foundItemType.Price && _newItemType.TypeName == foundItemType.TypeName, "Item not found by id");
        }
        #endregion
    }
}