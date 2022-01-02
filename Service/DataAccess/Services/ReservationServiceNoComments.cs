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
    public class ReservationServiceNoComments : BaseDB, IReservationService {

        private IWardrobeControlRepository wardrobeControlRepo;
        private IReservationRepository reservationRepo;
        private IWardrobeRepository wardrobeRepo;

        public ReservationServiceNoComments(string connectionString) : base(connectionString) {
            reservationRepo = new ReservationRepository(connectionString);
            wardrobeControlRepo = new WardrobeControlRepository(connectionString);
            wardrobeRepo = new WardrobeRepository(connectionString);
        }
        public async Task<int> CreateReservation(Reservation newReservation) {
            using SqlConnection connection = CreateConnection();
            connection.Open();
            using var command = new SqlCommand();
            using SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            command.Transaction = transaction;

            try {

                if (newReservation == null) {

                    return 0;

                } else {

                    DateTime arrivalTime = newReservation.ArrivalTime;
                    DateTime dateToUse = newReservation.ArrivalTime.Date;
                    DateTime closingTime = dateToUse.AddHours(5);

                    if (arrivalTime < closingTime) {

                        dateToUse = newReservation.ArrivalTime.AddDays(-1).Date;

                    }

                    DateTime legalReservationTime = DateTime.Now.AddDays(30);
                    DateTime now = DateTime.Now;
                    String arrivalDay = arrivalTime.ToShortDateString();

                    if ((arrivalTime < now) || (arrivalTime > legalReservationTime)) {

                        throw new Exception($"Er datoen {arrivalDay} for din reservation rigtigt? " +
                            $"Husk, du kan ikke oprette en reservation tidligere end i dag " +
                            $"eller senere end {legalReservationTime.Date}.");

                    } else {
                        var wardrobeControl = await wardrobeControlRepo.GetWardrobeControlByIdAndDate(newReservation.WardrobeID_FK, dateToUse);
                        int wardrobeCount = wardrobeControl.Count;
                        int addedAmountOfItems = newReservation.AmountOfJackets + newReservation.AmountOfBags;
                        int MaxAmount = (await wardrobeRepo.GetWardrobeById(newReservation.WardrobeID_FK)).MaxAmountOfItems;
                        
                        if (addedAmountOfItems + wardrobeCount > MaxAmount) {
                        
                            throw new Exception("Der er ikke plads i garderoben");
                        
                        } else {
                        
                            await reservationRepo.CreateReservation(newReservation);
                            wardrobeControl.Count = wardrobeCount + addedAmountOfItems;
                            await wardrobeControlRepo.UpdateCount(wardrobeControl);

                        }
                    }

                    transaction.Commit();
                    return 1;
                }

            } catch (Exception e) {

                transaction.Rollback();
                throw new Exception($"Kunne ikke oprette reservation: '{e.Message}'.", e);

            }
        }

    }
}



