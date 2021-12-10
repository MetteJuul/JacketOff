using APIClient.DTOs;

namespace ConsumerWebClient.TestData {
    public class DataPopulation {


        public DataPopulation() {
            Guest = new GuestDTO();

            Guest.GuestId = 2;
            Guest.Email = "Andreas@BigD.com";
            WardrobeID = "guldhornene";

        }

        public GuestDTO Guest { get; set; }
        public string WardrobeID { get; set; }

    }
}
