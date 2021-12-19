using APIClient.DTOs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.Service {
    public class JacketOffApiClient : IJacketOffApiClient {
        readonly RestClient _restClient;

        public JacketOffApiClient(string uri = "https://localhost:44391/api") {
            _restClient = new RestClient(new Uri(uri));
        }

        public async Task CreateOrder(OrderDTO order) {

            //We create a response variable in which we call our API
            //method
            var response = await _restClient.RequestAsync(Method.POST, $"orders", order);

            if (!response.IsSuccessful) {
                throw new Exception($"Fejl ved oprettelse af ordre. Fejl besked: {response.Content}");
            }
        }

        public async Task<List<GuestDTO>> GetAllGuests() {

            var response = await _restClient.RequestAsync<IEnumerable<GuestDTO>>(Method.GET, $"guests");

            if (!response.IsSuccessful) {
                throw new Exception($"Fejl ved hentning af gæster. Fejl besked: {response.Content}");
            }
            return response.Data.ToList();
        }
    }
}
