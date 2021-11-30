using Dapper;
using DataAccess.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories {
    public class ItemRepository : BaseDB, IItemRepository {
        public ItemRepository(string connectionString) : base(connectionString) { }

        public async Task<IEnumerable<Item>> GetAllItems() {
            try {
                var query = "SELECT * FROM Item";

                using var connection = CreateConnection();

                return await connection.QueryAsync<Item>(query);

            } catch (Exception e) {
                throw new Exception($"Error loading items: '{e.Message}'.", e);
            }
        }

        public async Task<Item> GetItem(int id) {
            try {
                var query = "SELECT * FROM Item WHERE itemID = @itemID";

                using var connection = CreateConnection();

                return await connection.QuerySingleAsync<Item>(query, new { id });

            } catch (Exception e) {
                throw new Exception($"Error loading item: '{e.Message}'.", e);
            }
        }

    }
}


