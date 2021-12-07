using Dapper;
using DataAccess.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories {
    public class WardrobeControlRepository : BaseDB, IWardrobeControlRepository {
        public WardrobeControlRepository(string connectionString) : base(connectionString) { }

        public async Task<IEnumerable<WardrobeControl>> GetAllWardrobeControls(SqlConnection connection = null) {
            try {
                //Query is created and the input parameter is assigned
                var query = "SELECT * FROM wardrobeControl";


                //Connection is made
                using var realConnection = connection?? CreateConnection();

                //We execute the query that retrieves a reservation object based on ID
                return (await realConnection.QueryAsync<WardrobeControl>(query)).ToList();

            } catch (Exception e) {
                throw new Exception($"Fejl ved hentning af garderobekontrol: '{e.Message}'.", e);
            }
        }

        public async Task<WardrobeControl> GetWardrobeControlByIdAndDate(string ID, DateTime date, SqlConnection connection = null) {
            try {
                //Query is created and the input parameter is assigned
                var query = "SELECT wardrobeID_FK, date, count FROM wardrobeControl WHERE wardrobeID_FK=@ID AND date=@date";

                //Connection is made
                using var realConnection = connection?? CreateConnection();

                //We execute the query that retrieves a reservation object based on ID
                var result = await realConnection.QueryAsync<WardrobeControl>(query, new { ID, date.Date });
                return (WardrobeControl)result.FirstOrDefault();


            } catch (Exception e) {
                throw new Exception($"Fejl ved hentning af garderobekontrol {ID}: '{e.Message}'.", e);
            }
        }

        public async Task<bool> UpdateCount(WardrobeControl wardrobeControl, SqlConnection connection = null) {
            try {

                var query = "SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;" +
                    "UPDATE WardrobeControl SET count=@count WHERE wardrobeID_FK=@wardrobeID_FK";


                using var realConnection = connection?? CreateConnection();

                return await realConnection.ExecuteAsync(query, wardrobeControl) > 0;


            } catch (Exception e) {

                throw new Exception($"Kan ikke opdatere Garderobe: '{e.Message}'.", e);
            }
        }
        public async Task<bool> DeleteByWardrobeControlID(int ID, SqlConnection connection = null) {
            try {
                //Query is created and the input parameter iD is inserted into it
                var query = "DELETE FROM Wardrobe WHERE wardrobeID_FK=@ID";

                //Connection is created
                using var realConnection = connection ?? CreateConnection();

                //Using Async the query is executed only if the iD is larger than 0
                return await realConnection.ExecuteAsync(query, new { ID }) > 0;
            } catch (Exception e) {

                throw new Exception($"Error deleting reservation with id {ID}: '{e.Message}'.", e);
            }
        }

        public async Task<int> CreateWardrobeControl(WardrobeControl wardrobeControl, SqlConnection connection = null) {

            try {
                var query = "INSERT INTO WardrobeControl (WardrobeID_FK, Date, Count) OUTPUT INSERTED.WardrobeID_FK VALUES ('@WardrobeID_FK', @Date, @Count);";

                using var realConnection = connection ?? CreateConnection();

                return await realConnection.QuerySingleAsync<int>(
                    query,
                    new { wardrobeID_FK = wardrobeControl.WardrobeID_FK, date = wardrobeControl.Date.Date, count = wardrobeControl.Count });

            } catch (Exception e) {
                throw new Exception($"Fejl ved oprettelse af WardrobeControl: '{e.Message}'.", e);
            }



        }


        //public async Task<WardrobeControl> GetWardrobeControlById(string ID, SqlConnection connection = null) {
        //    try {
        //        //Query is created and the input parameter is assigned
        //        var query = "SELECT wardrobeID_FK, date, rowID, cast(rowID as bigint) as BigRowID, count FROM wardrobeControl WHERE wardrobeID_FK=@ID";

        //        //Connection is made
        //        using var realConnection = connection?? CreateConnection();

        //        //We execute the query that retrieves a reservation object based on ID

        //        var result = await realConnection.QuerySingleAsync<WardrobeControl>(query, new { ID });
        //        return (WardrobeControl)result;


        //    } catch (Exception e) {
        //        throw new Exception($"Fejl ved hentning af garderobekontrol {ID}: '{e.Message}'.", e);
        //    }

        //}
    }
}


