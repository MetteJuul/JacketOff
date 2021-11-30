using DataAccess.Interfaces;
using System;
using DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


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

        public async Task<Wardrobe> GetWardrobeById(string iD) {
            try {
                //Query is created and the input parameter is assigned
                var query = "SELECT * FROM Wardrobe WHERE WardrobeID=@iD";

                //Connection is made
                using var connection = CreateConnection();

                //We execute the query that retrieves a reservation object based on ID
                return await connection.QuerySingleAsync<Wardrobe>(query, new { iD });
            } catch (Exception e) {
                throw new Exception($"Error getting Wardrobe with id {iD}: '{e.Message}'.", e);
            }
        }

        public async Task<bool> UpdateCount(Wardrobe wardrobe, int amountOfTotalItems) {
            try {

                var query = "UPDATE Wardrobe SET count=@count WHERE wardrobeID@wardrobeID;";

                using var connection = CreateConnection();

                //return await connection.ExecuteAsync(query, new { wardrobe });
            } catch (Exception e) {
                throw new Exception($"Kan ikke opdatere Garderobe: '{e.Message}'.", e);
            }

        }
    }
}
