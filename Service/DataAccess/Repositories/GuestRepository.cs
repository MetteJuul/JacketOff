using Dapper;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GuestRepository : BaseDB, IGuestRepository
    {
        public GuestRepository(string connectionString) : base(connectionString) { }

        public async Task<int> CreateGuest(Guest guest, SqlConnection connection = null) {
            try {
                //Query is created and each property of the Item object
                //is mapped to the query using dapper
                var query = "INSERT INTO Guest(email)" +
                    "OUTPUT INSERTED.guestID VALUES (@Email)";

                //Connection is created - ?? betyder "er connection object null, så laver den en ny"
                using var realConnection = connection ?? CreateConnection();

                //returnerer hvor mange rows der er skrevet i. Altså, hvis 0 = ikke succes, hvis større end 0 succes
                return await realConnection.QuerySingleAsync<int>(query, guest);

            } catch (Exception e) {
                throw new Exception($"Fejl ved oprettelse af Gæst: '{e.Message}'.", e);
            }
        }

        public async Task<Guest> GetByEmail(string email, SqlConnection connection = null)
        {
            try
            {
                //Query is created and the input parameter is assigned
                var query = "SELECT * FROM Guest WHERE email=@email";

                //Connection is made
                using var realConnection = connection ?? CreateConnection();

                //We execute the query that retrieves a guest object based on ID
                return await realConnection.QuerySingleAsync<Guest>(query, new { email });
            } catch (Exception e)
            {
                throw new Exception($"Fejl ved hentning af gæst med email {email}: '{e.Message}'.", e);
            }
        }

        public async Task<bool> DeleteByID(int ID, SqlConnection connection = null) {

            try {
                //Query is created and the input parameter ID is inserted into it
                var query = "DELETE FROM Guest WHERE guestID=@ID";

                //Connection is created if it hasn't been passed to the method
                using var realConnection = connection ?? CreateConnection();

                //Using Async the query is executed only if the iD is larger than 0
                return await realConnection.ExecuteAsync(query, new { ID }) > 0;
            } catch (Exception e) {
                throw new Exception($"Fejl ved sletning af gæst med id {ID}: '{e.Message}'.", e);
            }
        }
    }
}
