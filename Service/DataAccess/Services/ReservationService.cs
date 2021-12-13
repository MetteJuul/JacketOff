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


        public async Task<int> CreateReservation(Reservation newReservation) {
            using SqlConnection connection = CreateConnection();
            connection.Open();
            using var command = new SqlCommand();
            using SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            command.Transaction = transaction;

            try {

                //Check if newReservation contains data
                if (newReservation == null) {

                    return 0;

                } else {

                    DateTime dateToUse = newReservation.ArrivalTime.Date.Date;
                    DateTime arrivalDay = newReservation.ArrivalTime.Date;
                    //Check which day to update the count in WardrobeControl
                    if (newReservation.ArrivalTime > arrivalDay) {
                        dateToUse = newReservation.ArrivalTime.AddDays(-1).Date;
                    }

                    //Check that guest is not making a reservation more than 14 days into the future
                    DateTime legalReservationTime = DateTime.Now.AddDays(14);
                    if (dateToUse < legalReservationTime) {

                        //Get WardrobeControl object
                        var wardrobeControl = await wardrobeControlRepo.GetWardrobeControlByIdAndDate(newReservation.WardrobeID_FK, dateToUse.Date);

                        //if wardrobeControl is null we create a new with the data from newReservation
                        if (wardrobeControl == null) {
                            wardrobeControl = new WardrobeControl { WardrobeID_FK = newReservation.WardrobeID_FK, Date = dateToUse, Count = 0 };
                            await wardrobeControlRepo.CreateWardrobeControl(wardrobeControl);
                        } else {
                            //Set variables needed for count check
                            int wardrobeCount = wardrobeControl.Count;
                            int addedAmountOfItems = newReservation.AmountOfJackets + newReservation.AmountOfBags;
                            int MaxAmount = (await wardrobeRepo.GetWardrobeById(newReservation.WardrobeID_FK)).MaxAmountOfItems;

                            //Check if there's enough space to add count of items from newReservation
                            if (wardrobeCount + addedAmountOfItems <= MaxAmount) {

                                //If there is space in the wardrobe we create the reservation
                                await reservationRepo.CreateReservation(newReservation);

                                //Then we update the wardrobeCount in our WardrobeControl object 
                                //and send it to our updateCount method in wardrobeControlRepo
                                wardrobeControl.Count = wardrobeCount + addedAmountOfItems;
                                await wardrobeControlRepo.UpdateCount(wardrobeControl);

                            } else {
                                throw new Exception("Der er ikke plads i garderoben");
                            }
                        }

                    } else {
                        throw new Exception($"Du kan ikke oprette en reservation senere end {legalReservationTime}");
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


