using APIClient.DTOs;

namespace ConsumerWebClient.TestData {
    public class DataPopulation {


        public DataPopulation() {
            Guest = new GuestDTO();

            Guest.GuestId = 38;
            Guest.Email = "park@seongwha.az";

            WardrobeID = "guldhornene";

        }

        public GuestDTO Guest { get; set; }
        public string WardrobeID { get; set; }

    }
}
