using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConsumerDesktopClient.DTOs;

namespace ConsumerDesktopClient.Service{
    public class ReservationService{

        readonly RestClient _restClient;

        public ReservationService(string uri = "https://localhost:44391/api") {
            _restClient = new RestClient(new Uri(uri));
        }

        public async Task<IEnumerable<ReservationDTO>> GetAllReservations() {

            //We create a response variable in which we call our api/reservations
            //in order to store our list of all reservations
            var response = await _restClient.RequestAsync<IEnumerable<ReservationDTO>>(Method.GET, $"reservations");

            //We then test if the response is unsuccesful, if that is the case
            //we throw an exception with a custom error message, as well as a 
            //display of the error message recieved by the method
            if (!response.IsSuccessful) {
                throw new Exception($"Fejl ved hentning af alle reservationer. Fejl besked: {response.Content}");
            }

            //We then return the response, which should contain the list
            // of all reservations
            return response.Data;
        }
    }
}
