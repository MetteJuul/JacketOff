using DataAccess.Interfaces;
using DataAccess.Model;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
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
        //lav en metode der hedder createReservation
        //Opret med repeatable read (en del af queryen)
        //tjek count, hvis ok ->
        //opret reservation
        //return bool på success/ikke success?

    }
}
