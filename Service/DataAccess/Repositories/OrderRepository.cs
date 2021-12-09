using Dapper;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories {
    public class OrderRepository : BaseDB, IOrderRepository {
        public OrderRepository(string connectionString) : base(connectionString) {
        }

        public async Task<int> CreateOrder(Order order, SqlConnection connection = null) {
            try {
                //Before creating our query, we set the order time
                //as the current time
                order.CheckInTime = DateTime.Now;

                //Query is created and each property of the Order object
                //is mapped to the query using dapper
                var query = "INSERT INTO [Order](itemID_FK, guestID_FK, ticketNumber, link, checkInTime, paid)" +
                    "OUTPUT INSERTED.orderID VALUES (@ItemID_FK, @GuestID_FK, @TicketNumber, @Link, @CheckInTime, @Paid)";

                //Connection is created - ?? betyder "er connection object null, så laver den en ny"
                using var realConnection = connection ?? CreateConnection();

                //returnerer hvor mange rows der er skrevet i. Altså, hvis 0 = ikke succes, hvis større end 0 succes
                return await realConnection.QuerySingleAsync<int>(query, order);

            } catch (Exception e) {
                throw new Exception($"Error creating new reservation: '{e.Message}'.", e);
            }
        }

        public async Task<bool> DeleteByID(int ID, SqlConnection connection = null) {
 
            try {
                //Query is created and the input parameter ID is inserted into it
                var query = "DELETE FROM [Order] WHERE orderID=@ID";

                //Connection is created if it hasn't been passed to the method
                using var realConnection = connection ?? CreateConnection();

                //Using Async the query is executed only if the iD is larger than 0
                return await realConnection.ExecuteAsync(query, new { ID }) > 0;
            } catch (Exception e) {
                throw new Exception($"Fejl ved sletning af ordrer med id {ID}: '{e.Message}'.", e);
            }
        }
    }
}
