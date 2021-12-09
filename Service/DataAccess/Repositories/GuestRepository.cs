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

        public async Task<Guest> GetByEmail(string email, SqlConnection connection = null)
        {
            try
            {
                //Query is created and the input parameter is assigned
                var query = "SELECT * FROM Guest WHERE email=@email";

                //Connection is made
                using var realConnection = connection ?? CreateConnection();

                //We execute the query that retrieves a reservation object based on ID
                return await realConnection.QuerySingleAsync<Guest>(query, new { email });
            } catch (Exception e)
            {
                throw new Exception($"Fejl ved hentning af gæst med email {email}: '{e.Message}'.", e);
            }
        }
    }
}
