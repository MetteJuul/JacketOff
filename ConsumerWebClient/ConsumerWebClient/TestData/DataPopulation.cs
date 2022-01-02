using APIClient.DTOs;

namespace ConsumerWebClient.TestData {
    public class DataPopulation {


        public DataPopulation() {
            Guest = new GuestDTO();

            Guest.GuestId = 13;
            Guest.Email = "line@dahlgaardstivoli.dk";
            WardrobeID = "guldhornene";

        }

        public GuestDTO Guest { get; set; }
        public string WardrobeID { get; set; }

    }
}
