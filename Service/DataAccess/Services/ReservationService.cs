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
    public class ReservationService : BaseDB {

        private IWardrobeControlRepository wardrobeControlRepo;
        private IReservationRepository reservationRepo;
        private IWardrobeRepository wardrobeRepo;


        public ReservationService(string connectionString) : base(connectionString) {
            reservationRepo = new ReservationRepository(connectionString);
            wardrobeControlRepo = new WardrobeControlRepository(connectionString);
            wardrobeRepo = new WardrobeRepository(connectionString);
        }

        //transaction
        public System.Data.SqlClient.SqlTransaction BeginTransaction();
        private async Task<int> CreateReservation(Reservation newReservation)
        {

            using SqlConnection connection = CreateConnection();

            connection.Open();

            SqlCommand command = connection.CreateCommand();
            SqlTransaction transaction = command.Transaction;

            transaction = connection.BeginTransaction("opret reservation");

            command.Connection = connection;
            command.Transaction = transaction;

            try
            {
                //find WardrobeControl for reservationens dato
                //hvis datoen for reservationen ikke eksisterer CreateWardrobeControl(); ellers GetWardrobeControl();
                //hvis objektet vi modtager ikke er null OG count ikke er større end maxAmountOfItems

                //tjek at newReservation indeholder data
                if (newReservation != null)
                {
                    //
                    var foundWardrobeControl = wardrobeControlRepo.GetWardrobeControlByIdAndDate("guldhornene", newReservation.ArrivalTime);

                    //hvis ikke null GetWardrobeControl()
                    if () {

                    //CreateWardrobeControl()
                    } else {

                    }
                    List<WardrobeControl> wardrobeControls = (await wardrobeControlRepo.GetAllWardrobeControls()).ToList();

                    //om dato i reservation eksisterer i WardrobeControl - skal iterere igennem liste af WardrobeControls
                    



                        ExecuteNonQuery();
                        command.CommandText =
                            "Insert into Reservation (reservationID, guestID_FK, orderTime, arrivalTime, amountOfJackets, amountOfBags, price) VALUES (3, 8, DateTime, DateTime, 2, 2, 250.00)";
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        Console.WriteLine("Begge reservationer er oprettet");
                    } catch (Exception e)
            {

                Console.WriteLine("Exception type: {0}", e.GetType());
                Console.WriteLine(" Message: {0}", e.Message);
            }

            //Roll back
            try
            {
                transaction.Rollback();
            } catch (Exception e2)
            {
                Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                Console.WriteLine("Message: {0}", e2.Message);
            }
            //lav en metode der hedder createReservation
            //Opret med repeatable read(en del af queryen)
            //tjek count, hvis ok->
            //opret reservation
            //return bool på success/ ikke success ?

        }
    }
}
