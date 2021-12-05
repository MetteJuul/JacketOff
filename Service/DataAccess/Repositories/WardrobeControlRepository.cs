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

        public async Task<IEnumerable<WardrobeControl>> GetWardrobeControlsById(string ID) {
            try {
                //Query is created and the input parameter is assigned
                var query = "SELECT * FROM wardrobeControl WHERE wardrobeID_FK=@ID";

                //Connection is made
                using var connection = CreateConnection();

                //We execute the query that retrieves a reservation object based on ID
                return (await connection.QueryAsync<WardrobeControl>(query, new { ID })).ToList();

            } catch (Exception e) {
                throw new Exception($"Fejl ved hentning af garderobekontrol {ID}: '{e.Message}'.", e);
            }
        }

        public async Task<WardrobeControl> GetWardrobeControlById(string ID) {
            try {
                //Query is created and the input parameter is assigned
                var query = "SELECT * FROM wardrobeControl WHERE wardrobeID_FK=@ID";

                //Connection is made
                using var connection = CreateConnection();

                //We execute the query that retrieves a reservation object based on ID

                var result = await connection.QuerySingleAsync<WardrobeControl>(query, new { ID });
                return (WardrobeControl)result;


            } catch (Exception e) {
                throw new Exception($"Fejl ved hentning af garderobekontrol {ID}: '{e.Message}'.", e);
            }

        }
        public Task<int> GetWardrobeControlCount(string ID) {
            throw new NotImplementedException();
        }

        //public async Task<int> GetWardrobeControlCount(string ID) {
        //    WardrobeControl wardrobeControl = null;

        //    var query = "SELECT wardrobeID_FK,date, rowID, cast(rowID as bigint) as BigRowID, count FROM wardrobeControl WHERE wardrobeID_FK=@ID";

        //    using var connection = CreateConnection();
        //    wardrobeControl = await connection.QuerySingleAsync<WardrobeControl>(query, new { ID });
        //    return wardrobeControl.SpaceCount;

        //}

        public async Task<bool> AddCount(Int64 bigRowID, int count) {

            try {
                var query = "UPDATE Wardrobe SET count=@(count + 1) WHERE wardrobeID=@wardrobeID;";

                using var connection = CreateConnection();

                return await connection.ExecuteAsync(query, count) > 0;

            } catch (Exception e) {
                throw new Exception($"Error updating reservation: '{e.Message}'.", e);
            }
        }

        public async Task<bool> SubtractCount(Int64 bigRowID, int count) {

            try {
                var query = "UPDATE Wardrobe SET count=@(count - 1) WHERE wardrobeID=@wardrobeID;";

                using var connection = CreateConnection();

                return await connection.ExecuteAsync(query, count) > 0;

            } catch (Exception e) {
                throw new Exception($"Error updating reservation: '{e.Message}'.", e);
            }
        }

        




        //public async Task<bool> UpdateCount(WardrobeControl wardrobeControl) {

        //    return await Task.Run(() => {
        //        try {

        //            var selectQuery = "SELECT * FROM wardrobeControl WHERE wardrobeID_FK=@ID"; 
        //            var query = "UPDATE Wardrobe SET count=@count WHERE wardrobeID=@wardrobeID;";

        //            using var connection = CreateConnection();

        //            // Pass the original values to the WHERE clause parameters.  
        //            //https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/optimistic-concurrency#optimistic-concurrency-example

        //            var adapter = new SqlDataAdapter(selectQuery, connection);

        //            //UpdateCommand er en specifik måde at opdatere på, og den kan håndtere optimistic concurrency
        //            adapter.UpdateCommand = new SqlCommand(query, connection);

        //            //adapteren kalder UpdateCommand og her sætter vi en binder til parameteret count, og fortæller at det er en int i databasen
        //            SqlParameter sqlParam = adapter.UpdateCommand.Parameters.Add("@count", SqlDbType.Int);

        //            //Vi kalder den indbyggede metode til at checke, om vi har den rigtige DataRowVersion (fra selectQuery)
        //            //og ikke en state, der har ændret sig efter at vi har hentet 

        //            sqlParam.SourceVersion = DataRowVersion.Original;

        //            //Vi laver en tom DataTable 
        //            var dataTable = new DataTable();

        //            //Vi fylder i DataTable med adapteren fra vores query-streng
        //            adapter.Fill(dataTable);

        //            //adapteren skriver til databasen 
        //            adapter.Update(dataTable);



        //            return true;


        //        } catch (Exception e) {

        //            throw new Exception($"Kan ikke opdatere Garderobe: '{e.Message}'.", e);
        //        }
        //    });
        //}
    }
}
