using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace DataAccess.Interfaces {
    public interface IReservationRepository {
        Task<int> CreateReservation(Reservation reservation, SqlConnection connection = null);
        Task<IEnumerable<Reservation>> GetAllReservations(SqlConnection connection = null);
        Task<Reservation> GetByID(int ID, SqlConnection connection = null);
        Task<bool> UpdateReservation(Reservation reservation, SqlConnection connection = null);
        Task<bool> DeleteByID(int ID, SqlConnection connection = null);
        Task<IEnumerable<Reservation>> GetByGuestEmail(string guestEmail, SqlConnection connection = null);
    }
}
