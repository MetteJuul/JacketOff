using DataAccess.Interfaces;
using System;
using DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace DataAccess.Repositories {
    public class WardrobeRepository : BaseDB, IWardrobeRepository {
        public WardrobeRepository(string connectionString) : base(connectionString) { }
        public async Task<IEnumerable<Wardrobe>> GetAllWardrobes() {
            try {
                var query = "SELECT * FROM Wardrobe";
                using var connection = CreateConnection();
                return (await connection.QueryAsync<Wardrobe>(query)).ToList();
            } catch (Exception e) {
                throw new Exception($"Error getting all Wardrobes: '{e.Message}'", e);
            }
        }

        public async Task<Wardrobe> GetWardrobeById(string ID, SqlConnection connection = null) {
            try {
                //Query is created and the input parameter is assigned
                var query = "SELECT * FROM Wardrobe WHERE WardrobeID=@iD";

                //Connection is created
                using var realConnection = connection ?? CreateConnection();

                //We execute the query that retrieves a reservation object based on ID
                return await realConnection.QuerySingleAsync<Wardrobe>(query, new { ID });
            } catch (Exception e) {
                throw new Exception($"Error getting Wardrobe with id {ID}: '{e.Message}'.", e);
            }
        }
    }
}
