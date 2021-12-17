using APIClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.Service {
    public interface IJacketOffApiClient {
        Task CreateOrder(OrderDTO order);
        Task<List<GuestDTO>> GetAllGuests();
    }
}
