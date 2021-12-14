using APIClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient {
    public interface IJacketOffApiClient {
        Task<IEnumerable<ReservationDTO>> GetAllReservations();
        Task<int> CreateReservation(ReservationDTO entity);
        Task<bool> UpdateReservation(ReservationDTO entity);
        Task<bool> DeleteReservation(int id);
        Task<IEnumerable<ReservationDTO>> GetReservationsByGuestEmail(string email);
        Task<IEnumerable<ItemTypeDTO>> GetAllItemTypes();
        Task<GuestDTO> GetByGuestEmail(string email);
        Task<int> CreateSimpleGuest(GuestDTO guestDTO);

    }
}
