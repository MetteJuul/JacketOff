using DataAccess.Interfaces;
using DataAccess.Model;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services {
    public class ReservationService : BaseDB, IReservationService {

        private IWardrobeControlRepository wardrobeControlRepo;
        private IReservationRepository reservationRepo;
        private IWardrobeRepository wardrobeRepo;
        private IDbTransaction transaction;
        public ReservationService(string connectionString) : base(connectionString) {
            reservationRepo = new ReservationRepository(connectionString);
            wardrobeControlRepo = new WardrobeControlRepository(connectionString);
            wardrobeRepo = new WardrobeRepository(connectionString);
        }

        //Transaction
        //public System.Data.SqlClient.SqlTransaction BeginTransaction();
        public async Task<int> CreateReservation(Reservation newReservation) {

            //Start transaction

            using SqlConnection connection = CreateConnection();
            connection.Open();
            using var command = new SqlCommand();

            using SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            command.Transaction = transaction;

            try {

                //Tjek om newReservation indeholder data
                if (newReservation == null) {

                    return 0;

                } else {
                    //Lav wardrobeControl som kan genbruges
                    //TODO: Lav subtask til formatering af datetime
                    var wardrobeControl = await wardrobeControlRepo.GetWardrobeControlByIdAndDate(
                        newReservation.WardrobeID_FK,
                        newReservation.ArrivalTime);

                    //Tjek om WardrobeControl eksisterer
                    if (wardrobeControl == null) {

                        //Hvis den ikke eksisterer - laver vi en og gemmer vi den i wardrobeControl
                        wardrobeControl = new WardrobeControl
                        {
                            WardrobeID_FK = newReservation.WardrobeID_FK,
                            Date = newReservation.ArrivalTime, Count = 0
                        };
                        await wardrobeControlRepo.CreateWardrobeControl(wardrobeControl);
                    } else {

                        //Lav variabler med count, antal items der skal tilføjes og maxAmount som kan genbruges
                        var wardrobeCount = wardrobeControl.Count;
                        var addedAmountOfItems = newReservation.AmountOfJackets + newReservation.AmountOfBags;
                        var MaxAmount = (await wardrobeRepo.GetWardrobeById(newReservation.WardrobeID_FK)).MaxAmountOfItems;

                        //Tjek om der er plads i WardrobeControl til nyt count fra ny reservation
                        if (wardrobeCount + addedAmountOfItems <= MaxAmount) {

                            //Hvis der er plads opretter vi reservationen igennem reservationRepo
                            await reservationRepo.CreateReservation(newReservation);

                            //Så retter vi count i vores wardrobecontrol objekt, og sender
                            //det til vores updateCount metode i wardrobeControlRepo
                            wardrobeControl.Count = wardrobeCount + addedAmountOfItems;
                            await wardrobeControlRepo.UpdateCount(wardrobeControl);

                        }

                        transaction.Commit();
                        //må man smide en int tilbage her som et tegn på, at transaction er committed uden fejl.
                        return 1;
                    }

                }
                //End transaction

                return 0;
            } catch (Exception e) {

                transaction.Rollback();

                throw new Exception($"Kunne ikke oprette reservation: '{e.Message}'.", e);

            }
        }
    }
}

