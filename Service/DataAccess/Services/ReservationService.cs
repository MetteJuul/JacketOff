using DataAccess.Interfaces;
using DataAccess.Model;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services {
    public class ReservationService {

        private IWardrobeControlRepository _wardrobeControlRepo;
        private IReservationRepository _reservationRepo;


        public ReservationService(IWardrobeControlRepository wardrobeControlRepo, IReservationRepository reservationRepo) {
            _wardrobeControlRepo = wardrobeControlRepo;
            _reservationRepo = reservationRepo;

        }

        //transaction
        //public System.Data.SqlClient.SqlTransaction BeginTransaction();
        private static void ExecuteSqlTransaction(SqlConnection connection = null) {
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            SqlTransaction transaction = command.Transaction;

            transaction = connection.BeginTransaction("opret reservation");

            command.Connection = connection;
            command.Transaction = transaction;

            try {
                command.CommandText =
                    "Insert into Reservation (reservationID, guestID_FK, orderTime, arrivalTime, amountOfJackets, amountOfBags, price) VALUES (2, 7, DateTime, DateTime, 1, 1, 200.00)";
                command.ExecuteNonQuery();
                command.CommandText =
                    "Insert into Reservation (reservationID, guestID_FK, orderTime, arrivalTime, amountOfJackets, amountOfBags, price) VALUES (3, 8, DateTime, DateTime, 2, 2, 250.00)";
                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("Begge reservationer er oprettet");
            }
            catch (Exception e) {

                Console.WriteLine("Exception type: {0}", e.GetType());
                Console.WriteLine(" Message: {0}", e.Message);
            }

            //Roll back
            try {
                transaction.Rollback();
            }
            catch (Exception e2) {
                Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                Console.WriteLine("Message: {0}", e2.Message);
            }
            //lav en metode der hedder createReservation
            //Opret med repeatable read (en del af queryen)
            //tjek count, hvis ok ->
            //opret reservation
            //return bool på success/ikke success?

        }
    }
}
