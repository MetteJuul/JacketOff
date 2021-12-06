using Dapper;
using DataAccess.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using System.Data.SqlClient;

namespace DataAccess {
    public class ReservationRepository : BaseDB, IReservationRepository {
        public ReservationRepository(string connectionString) : base(connectionString) { }

        public async Task<int> CreateReservation(Reservation reservation, SqlConnection connection = null) {

            try {
                    //Before creating our query, we set the order time
                    //as the current time
                    reservation.OrderTime = DateTime.Now;

                    //Query is created and each property of the reservation object
                    //is mapped to the query using dapper
                    var query = "INSERT INTO Reservation(guestID_FK, orderTime, arrivalTime, amountOfJackets, amountOfBags, price)" +
                        "OUTPUT INSERTED.reservationID VALUES (@GuestID_FK, @OrderTime, @ArrivalTime, @AmountOfJackets, @AmountOfBags, @Price)";

                //Connection is created - ?? betyder "er connection object null, så laver den en ny"
                using var realConnection = connection?? CreateConnection();

                //TODO skriv forklaring
                return await realConnection.QuerySingleAsync<int>(query, reservation);

                } catch (Exception e) {

                    throw new Exception($"Error creating new reservation: '{e.Message}'.", e);
                }
            }

            public async Task<bool> DeleteByID(int ID, SqlConnection connection = null) {
                try {
                    //Query is created and the input parameter iD is inserted into it
                    var query = "DELETE FROM Reservation WHERE reservationID=@iD";

                //Connection is created
                using var realConnection = connection?? CreateConnection();
                //Using Async the query is executed only if the iD is larger than 0
                return await realConnection.ExecuteAsync(query, new { ID }) > 0;
                } catch (Exception e) {

                    throw new Exception($"Error deleting reservation with id {ID}: '{e.Message}'.", e);
                }
            }

            public async Task<IEnumerable<Reservation>> GetAllReservations(SqlConnection connection = null) {
                try {
                    //Query is created
                    var query = "SELECT * FROM Reservation";

                //Connection is made
                using var realConnection = connection?? CreateConnection();

                //We execute the query that retreives a list of all reservations
                return (await realConnection.QueryAsync<Reservation>(query)).ToList();
                } catch (Exception e) {
                    throw new Exception($"Error getting all reservations: '{e.Message}'.", e);
                }
            }

            public async Task<Reservation> GetByID(int ID, SqlConnection connection = null) {
                try {
                    //Query is created and the input parameter is assigned
                    var query = "SELECT * FROM Reservation WHERE reservationID=@iD";

                    //Connection is made
                    using var realConnection = CreateConnection();

                    //We execute the query that retrieves a reservation object based on ID
                    return await connection.QuerySingleAsync<Reservation>(query, new { ID });
                } catch (Exception e) {
                    throw new Exception($"Error getting reservation with id {ID}: '{e.Message}'.", e);
                }
            }

            public async Task<bool> UpdateReservation(Reservation reservation, SqlConnection connection = null) {
                try {
                    //Query is created and each reservation property is mapped using Dapper
                    var query = "UPDATE Reservation SET guestID_FK=@guestID_FK, orderTime=@orderTime, arrivalTime=@arrivalTime, amountOfJackets=@amountOfJackets, amountOfBags=@amountOfBags, price=@price WHERE reservationID=@reservationID";

                //Connection is made
                using var realConnection = connection?? CreateConnection();

                //Query is executed by passing the reservation object along with the query
                return await realConnection.ExecuteAsync(query, reservation) > 0;
                } catch (Exception e) {
                    throw new Exception($"Error updating reservation: '{e.Message}'.", e);
                }
            }

            public async Task<IEnumerable<Reservation>> GetByGuestEmail(string email, SqlConnection connection = null) {
                try {
                    //Query is created taking guestID as a variable
                    var query = "SELECT * FROM Reservation WHERE guestID_FK IN(SELECT guestID FROM Guest WHERE email = @email)";

                //Connection is made
                using var realConnection = connection?? CreateConnection();

                //Query is executed passing guestID to retrieve a list of all reservations
                //made by that guest
                return (await realConnection.QueryAsync<Reservation>(query, new { email })).ToList();
                } catch (Exception e) {
                    throw new Exception($"Error getting all reservation for guest with email {email} '{e.Message}'.", e);
                }
            }
        }
    }
