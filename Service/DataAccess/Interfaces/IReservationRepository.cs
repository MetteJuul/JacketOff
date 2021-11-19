using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace DataAccess.Interfaces {
    public interface IReservationRepository {
        Task<int> CreateReservation(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation> GetByID(int iD);
        Task<bool> UpdateReservation(Reservation reservation);
        Task<bool> DeleteByID(int iD);
        Task<IEnumerable<Reservation>> GetByGuestEmail(string guestEmail);
    }
}
