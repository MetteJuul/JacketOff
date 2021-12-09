using Dapper;
using DataAccess.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess.Repositories {
    public class ItemRepository : BaseDB, IItemRepository {
        public ItemRepository(string connectionString) : base(connectionString) { }

        #region Item
        public async Task<IEnumerable<Item>> GetAllItems(SqlConnection connection = null) {
            try {
                var query = "SELECT * FROM Item";

                using var realConnection = connection ?? CreateConnection();

                return await realConnection.QueryAsync<Item>(query);

            } catch (Exception e) {
                throw new Exception($"Error loading items: '{e.Message}'.", e);
            }
        }

        public async Task<Item> GetItemByID(int ID, SqlConnection connection = null) {
            try {
                var query = "SELECT * FROM Item WHERE itemID = @ID";

                using var realConnection = connection ?? CreateConnection();

                return await realConnection.QuerySingleAsync<Item>(query, new { ID });

            } catch (Exception e) {
                throw new Exception($"Error loading item: '{e.Message}'.", e);
            }
        }

        public async Task<int> CreateItem(Item item, SqlConnection connection = null) {
            try {
                //Query is created and each property of the Item object
                //is mapped to the query using dapper
                var query = "INSERT INTO Item(wardrobeID_FK, typeID_FK)" +
                    "OUTPUT INSERTED.itemID VALUES (@WardrobeID_FK, @TypeID_FK)";

                //Connection is created - ?? betyder "er connection object null, så laver den en ny"
                using var realConnection = connection ?? CreateConnection();

                //returnerer hvor mange rows der er skrevet i. Altså, hvis 0 = ikke succes, hvis større end 0 succes
                return await realConnection.QuerySingleAsync<int>(query, item);

            } catch (Exception e) {
                throw new Exception($"Error creating new reservation: '{e.Message}'.", e);
            }
        }

        public async Task<bool> DeleteByID(int ID, SqlConnection connection = null) {

            try {
                //Query is created and the input parameter ID is inserted into it
                var query = "DELETE FROM Item WHERE itemID=@ID";

                //Connection is created if it hasn't been passed to the method
                using var realConnection = connection ?? CreateConnection();

                //Using Async the query is executed only if the iD is larger than 0
                return await realConnection.ExecuteAsync(query, new { ID }) > 0;
            } catch (Exception e) {
                throw new Exception($"Fejl ved sletning af item med id {ID}: '{e.Message}'.", e);
            }
        }
        #endregion

        #region ItemType
        public async Task<IEnumerable<ItemType>> GetAllItemTypes(SqlConnection connection = null) {
            try {
                var query = "SELECT * FROM Type";

                using var realConnection = connection ?? CreateConnection();

                return await realConnection.QueryAsync<ItemType>(query);

            } catch (Exception e) {
                throw new Exception($"Error loading items: '{e.Message}'.", e);
            }
        }

        public async Task<ItemType> GetItemTypeByID(int ID, SqlConnection connection = null) {
            try {
                var query = "SELECT * FROM Type WHERE typeID=@ID";

                using var realConnection = connection ?? CreateConnection();

                return await realConnection.QuerySingleAsync<ItemType>(query, new { ID });


            } catch (Exception e) {
                throw new Exception($"Error loading items: '{e.Message}'.", e);
            }
        }

        public async Task<int> CreateItemType(ItemType itemType, SqlConnection connection = null) {
            try {
                //Query is created and each property of the ItemType object
                //is mapped to the query using dapper
                var query = "INSERT INTO Type(price, typeName)" +
                    "OUTPUT INSERTED.typeID VALUES (@Price, @TypeName)";

                //Connection is created - ?? betyder "er connection object null, så laver den en ny"
                using var realConnection = connection ?? CreateConnection();

                //returnerer hvor mange rows der er skrevet i. Altså, hvis 0 = ikke succes, hvis større end 0 succes
                return await realConnection.QuerySingleAsync<int>(query, itemType);

            } catch (Exception e) {
                throw new Exception($"Error creating new reservation: '{e.Message}'.", e);
            }
        }

        public async Task<bool> DeleteItemTypeByID(int ID, SqlConnection connection = null) {

            try {
                //Query is created and the input parameter ID is inserted into it
                var query = "DELETE FROM Type WHERE typeID=@ID";

                //Connection is created if it hasn't been passed to the method
                using var realConnection = connection ?? CreateConnection();

                //Using Async the query is executed only if the iD is larger than 0
                return await realConnection.ExecuteAsync(query, new { ID }) > 0;
            } catch (Exception e) {
                throw new Exception($"Fejl ved sletning af item med id {ID}: '{e.Message}'.", e);
            }
        }
        #endregion


    }
}


