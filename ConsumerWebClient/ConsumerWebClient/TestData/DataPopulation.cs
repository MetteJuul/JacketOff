using APIClient.DTOs;

namespace ConsumerWebClient.TestData {
    public class DataPopulation {

        public DataPopulation() {
            Guest = new RegisteredGuestDTO();

            Guest.GuestId = 2;
            Guest.Email = "Andreas@BigD.com";
            Guest.FirstName = "Andreas";
            Guest.LastName = "Zeberg";
            Guest.PhoneNumber = "69696969";
            Guest.PasswordHash = "jjjjjj";
        }

        public RegisteredGuestDTO Guest { get; set; }

    }
}
