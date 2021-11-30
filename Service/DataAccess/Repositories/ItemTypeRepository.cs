using Dapper;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories {
    public class ItemTypeRepository : BaseDB, IItemTypeRepository {
        public ItemTypeRepository(string connectionString) : base(connectionString) {
        }

        public async Task<IEnumerable<ItemType>> GetAllItemTypes() {
            try {
                var query = "SELECT * FROM Type";

                using var connection = CreateConnection();

                return await connection.QueryAsync<ItemType>(query);

            } catch (Exception e) {
                throw new Exception($"Error loading items: '{e.Message}'.", e);
            }
        }

        public async Task<ItemType> GetItemType(int id) {
            try {
                var query = "SELECT * FROM Type WHERE typeID=@id";

                using var connection = CreateConnection();

                return await connection.QuerySingleAsync<ItemType>(query, new { id });


            } catch (Exception e) {
                throw new Exception($"Error loading items: '{e.Message}'.", e);
            }
        }
    }
}
