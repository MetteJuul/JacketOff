using Dapper;
using DataAccess.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class ReservationDB : BaseDB, IReservationDB {
        public ReservationDB(string connectionString) : base(connectionString) {}

        public async Task<int> CreateReservation(Reservation reservation) {
            try {
                //Query is created and each property of the reservation object
                //is mapped to the query using dapper
                var query = "INSERT INTO Reservation(guestID_FK, orderTime, arrivalTime, amountOfJackets, amountOfBags, price)" +
                    "OUTPUT INSERTED.reservationID VALUES (@GuestID_FK, @OrderTime, @ArrivalTime, @AmountOfJackets, @AmountOfBags, @Price)";
                
                //Connection is created
                using var connection = CreateConnection();

                //TODO skriv forklaring
                return await connection.QuerySingleAsync<int>(query, reservation);

            } catch(Exception e) {

                throw new Exception($"Error creating new reservation: '{e.Message}'.", e);
            }
        }

        public async Task<bool> DeleteByID(int iD) {
            try {
                //Query is created and the input parameter iD is inserted into it
                var query = "DELETE FROM Reservation WHERE reservationID=@iD";
                
                //Connection is created
                using var connection = CreateConnection();

                //Using Async the query is executed only if the iD is larger than 0
                return await connection.ExecuteAsync(query, new {iD}) > 0;
            }
            catch (Exception e) {

                throw new Exception($"Error deleting reservation with id {iD}: '{e.Message}'.", e);
            } 
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations() {
            try {
                //Query is created
                var query = "SELECT * FROM Reservation";

                //Connection is made
                using var connection = CreateConnection();

                //We execute the query that retreives a list of all reservations
                return (await connection.QueryAsync<Reservation>(query)).ToList();
            } catch (Exception e){
                throw new Exception($"Error getting all reservations: '{e.Message}'.", e);
            }
        }

        public async Task<Reservation> GetByID(int iD) {
            try {
                //Query is created and the input parameter is assigned
                var query = "SELECT * FROM Reservation WHERE reservationID=@iD";

                //Connection is made
                using var connection = CreateConnection();

                //We execute the query that retrieves a reservation object based on ID
                return await connection.QuerySingleAsync<Reservation>(query, new { iD });
            }
            catch (Exception e) {
                throw new Exception($"Error getting reservation with id {iD}: '{e.Message}'.", e);
            }
        }

        public async Task<bool> UpdateReservation(Reservation reservation) {
            try {
                //Query is created and each reservation property is mapped using Dapper
                var query = "UPDATE Reservation SET guestID_FK=@guestID_FK, orderTime=@orderTime, arrivalTime=@arrivalTime, amountOfJackets=@amountOfJackets, amountOfBags=@amountOfBags, price=@price";

                //Connection is made
                using var connection = CreateConnection();

                //Query is executed by passing the reservation object along with the query
                return await connection.ExecuteAsync(query, reservation) > 0;
            } catch(Exception e) {
                throw new Exception($"Error updating reservation: '{e.Message}'.", e);
            }
        }

        public async Task<IEnumerable<Reservation>> GetByGuestID(int guestID) {
            try {
                //Query is created taking guestID as a variable
                var query = "SELECT * FROM Reservation WHERE guestID_FK=@guestID";

                //Connection is made
                using var connection = CreateConnection();

                //Query is executed passing guestID to retrieve a list of all reservations
                //made by that guest
                return (await connection.QueryAsync<Reservation>(query, new { guestID })).ToList();
            } catch (Exception e) {
                throw new Exception($"Error getting all reservation with guest Id {guestID} '{e.Message}'.", e);
            }
        }
    }
}
