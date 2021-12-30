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

                // Vi tjekker om newReservation indeholder data
                if (newReservation == null) {

                    return 0;

                } else {

                    // Vi gemmer hvilket tidspunkt gæsten ankommer
                    DateTime arrivalTime = newReservation.ArrivalTime.Date;

                    // Vi gemmer hvilken dato, der skal tælles på i WardrobeControl
                    // vi gemmer en værdi på dagen til kl 00.00.00
                    DateTime dateToUse = newReservation.ArrivalTime.Date.Date;

                    // Vi skal tjekke, om gæsten ankommer efter midnat men før lukketid
                    // egentligt er det det samme som dateToUse, men for forståelsens skyld gemmer
                    // gemmer vi en værdi på datoen til kl 00.00.00
                    DateTime midnight = newReservation.ArrivalTime.Date.Date;

                    //Vi gemmer også en værdi med lukketid på datoen
                    DateTime closingTime = midnight.AddHours(5);

                    // Vi tjekker hvilken dato, vi skal tælle på i WardrobeControl
                    if (arrivalTime < closingTime) {

                        // hvis arrivalTime er før closingTime (05.00.00)
                        // gemmer vi en ny værdi i dateToUse med dagen før
                        dateToUse = newReservation.ArrivalTime.AddDays(-1).Date;
                    }

                    // Vi gemmer variabler, der er nødvendige for at tjekke,
                    // om gæsten har reserveret længere ud i fremtiden end 30 dage
                    // eller tidligere end nu
                    DateTime legalReservationTime = DateTime.Now.AddDays(30);
                    DateTime now = DateTime.Now;
                    String arrivalDay = arrivalTime.ToShortDateString();
                    // Tjek at gæsten ikke reserverer længere ud i fremtiden end 30 dage
                    // eller tidligere end nu.
                    if ((arrivalTime < now) || (arrivalTime > legalReservationTime)) {
                        throw new Exception($"Er datoen {arrivalDay} for din reservation rigtigt? " +
                            $"Husk, du kan ikke oprette en reservation tidligere end i dag " +
                            $"eller senere end {legalReservationTime.Date}.");
                    } else {

                        // Vi henter WardrobeControl objekt
                        var wardrobeControl = await wardrobeControlRepo.GetWardrobeControlByIdAndDate(newReservation.WardrobeID_FK, dateToUse);

                        // Vi gemmer variabler, der er nødvendige for tælle-tjek 
                        int wardrobeCount = wardrobeControl.Count;
                        int addedAmountOfItems = newReservation.AmountOfJackets + newReservation.AmountOfBags;
                        int MaxAmount = (await wardrobeRepo.GetWardrobeById(newReservation.WardrobeID_FK)).MaxAmountOfItems;

                        // Vi tjekker, om der er plads nok til at tilføje genstandende fra reservationen
                        if (addedAmountOfItems + wardrobeCount > MaxAmount) {
                            throw new Exception("Der er ikke plads i garderoben");
                        } else {

                            // Siden der er plads, kalder vi på metoden til at oprette en reservation 
                            await reservationRepo.CreateReservation(newReservation);

                            // Vi opdaterer wardrobeCount i WardrobeControl objektet wardrobeControl
                            wardrobeControl.Count = wardrobeCount + addedAmountOfItems;

                            // Vi kalder på metoden updateCount med det opdaterede objekt af wardrobeControl
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



