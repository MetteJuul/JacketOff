using System.Threading.Tasks;

namespace DataAccess.Services {
    public interface IReservationService {
        Task<int> CreateReservation(Reservation newReservation);
    }
}