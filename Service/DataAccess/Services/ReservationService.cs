using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services {
    public class ReservationService {

        private WardrobeControlRepository _wardrobeControlRepo;
        private ReservationRepository _reservationRepo;

        public ReservationService(WardrobeControlRepository wardrobeControlRepo, ReservationRepository reservationRepo) {
            _wardrobeControlRepo = wardrobeControlRepo;
            _reservationRepo = reservationRepo;
        }

        //hente en liste af wardrobeControl objekter og sige når vi ved, hvilken dato der er valgt
        //-> vi tjekker om rowID på den dato har ændret sig
        //mens brugeren har indtastet reservationsdetaljerne

        public void GetRowID() {

        }


        // 1. hente sætte nyeste rowID
        // 2. hente count og maxAmount
        // 3. hente amount of items fra reservation og lave ny variabel med totalCountInReservation
        // 4. check om count + (hvad der kommer fra reservationen) >= maxAmount
        // 5. kalde opret reservation (CreateReservation i repository)
        // 6. kalde opdater count (UpdateCount i repository)
        // 7. returner om succes

        public Task<Reservation> CreateReservation(Reservation reservation) {

            var wardrobeID = "guldhornene";
            

        }

    }
}
