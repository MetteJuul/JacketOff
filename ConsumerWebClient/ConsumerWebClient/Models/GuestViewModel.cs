using APIClient.DTOs;
using System.Collections.Generic;

namespace ConsumerWebClient.Models {
    public class GuestViewModel {

        public GuestDTO Guest { get; set; }
        
        public IEnumerable<GuestDTO> Guests { get; set; }
    }
}
