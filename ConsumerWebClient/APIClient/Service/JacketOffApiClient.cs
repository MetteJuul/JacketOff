using APIClient.DTOs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIClient {
    public class JacketOffApiClient : IJacketOffApiClient {

        //readonly string restUrl = "https://localhost:44391/api";
        readonly RestClient _restClient;

        //In our constructor we inject the restclient into the constructor and create a new RestClient object
        //and store it in our attribute
        public JacketOffApiClient(string uri = "https://localhost:44391/api") => _restClient = new RestClient(new Uri(uri));



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

        public async Task<int> CreateReservation(ReservationDTO entity) {
            var response = await _restClient.RequestAsync<int>(Method.POST, $"reservations", entity);
            if (!response.IsSuccessful) {
                throw new Exception($"Fejl i oprettelse af reservation. Fejl besked: {response.Content}");
            }
            return response.Data;
        }
        public async Task<bool> UpdateReservation(ReservationDTO entity) {
            
            bool updateSucceeded = false;
            var response = await _restClient.RequestAsync(Method.PUT, $"reservations/{entity.ReservationID}", entity);
            //Unlike previous methods, here we measure the status code,
            //to see if it matches HTTP status code OK.
            if (response.StatusCode == HttpStatusCode.OK) {
                updateSucceeded = true; 
            } else {
                throw new Exception($"Fejl ved opdatering af reservation. Fejl besked: {response.Content}");
            }
            return updateSucceeded;
        }

        public async Task<bool> DeleteReservation(int id) {
            
            bool deleteSucceeded = false;
            var response = await _restClient.RequestAsync(Method.DELETE, $"reservations/{id}");
            
            if (response.StatusCode == HttpStatusCode.OK) {
                deleteSucceeded = true;
            } else {
                throw new Exception($"Fejl i sletning af reservation. Fejl besked: {response.Content}");
            }
            
            return deleteSucceeded;
        } 

        public async Task<IEnumerable<ReservationDTO>> GetReservationsByGuestEmail(string email) {
            
            var response = await _restClient.RequestAsync<IEnumerable<ReservationDTO>>(Method.GET, $"reservations/{email}");

            if (!response.IsSuccessful) {
                throw new Exception($"Fejl ved hentning af reservationer for bruger med email{email}. Fejl besked: {response.Content}");
            }

            return response.Data;
        }

    }
}
