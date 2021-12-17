using APIClient.DTOs;
using APIClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktopClient.Control {
    public class OrderController {

        static OrderController _object;
        private readonly JacketOffApiClient _client;

        //Metode der bruges af andre klasser til at interagere med
        //singleton controlleren, der har en privat constructor
        public static OrderController GetInstance() {
            if (_object == null) {
                _object = new OrderController();
            }
            return _object;
        }

        //Privat constructoren for singleton klassen
        private OrderController() {
            _client = new JacketOffApiClient();
        }

        //Vi laver en del public properties, så vi kan
        //sende data ind i controlleren fra de forskellige
        //user controllers der bruges i GUI'en
        public int[] JakkeNumre { get; set; }
        public int[] TaskeNumre { get; set; }
        public int SidsteJakkeNummer { get; set; }
        public int SidsteTaskeNummer { get; set; }
        public GuestDTO Guest { get; set; }
        public List<GuestDTO> AllGuests { get; set; }

        //Metoden bruges til at hente alle gæster op og opbevarer den
        //i vores AllGuests Property
        public async Task<List<GuestDTO>> GetAllGuests() {
            AllGuests = await _client.GetAllGuests();
            return AllGuests;
        }

        public async Task CreateOrder() {

            //Vi laver en liste af ordrer, som vi kan tilføje
            //ordrer til efterhånden som de laves i de føljende
            //foreach løkker.
            var orders = new List<OrderDTO>();


            //Vi tjekker der er nogle jakker i ordren
            if (JakkeNumre != null) {

                //Vi går nu igennem alle de opbevarede jakkenumre
                //og oprette ordre for hver og tilføjer dem.
                foreach (var item in JakkeNumre) {

                    //Vi laver et nyt order object vi kan 
                    //tilføje vores info til
                    OrderDTO orderToAdd = new OrderDTO();

                    orderToAdd.TypeID_FK = 1;
                    orderToAdd.TicketNumber = item;
                    orders.Add(orderToAdd);

                    //Vi gemmer det sidste jakkenummer i vores property
                    //Så vi kan hente det i vores User Controllers
                    SidsteJakkeNummer = item;
                }
            }

            //Vi tjekker om der er nogle tasker i ordren
            if (TaskeNumre != null) {

                //Vi går nu igennem alle de opbevarede taskenumre
                //og oprette ordre for hver og tilføjer dem.
                foreach (var item in TaskeNumre) {

                    //Vi laver et nyt order object vi kan 
                    //tilføje vores info til
                    OrderDTO orderToAdd = new OrderDTO();

                    orderToAdd.TypeID_FK = 2;
                    orderToAdd.TicketNumber = item;
                    orders.Add(orderToAdd);

                    //Vi gemmer det sidste taskenummer i vores property
                    //Så vi kan hente det i vores User Controllers
                    SidsteTaskeNummer = item;
                }
            }

            //Nu tilføjes det andet data til vores ordre objekter
            //før vi sender dem til oprettelse i databasen
            foreach (var order in orders) {

                //Vi tilføjer WardrobeID_FK
                //På sigt ville dette blive hentet fra noget data,
                //men eftersom vi kun arbejder med en garderobe,
                //er det hardcodet her ind til videre.
                order.WardrobeID_FK = "guldhornene";

                //Vi tilføjer guestID baseret på den guest
                //Vi har fundet og opbevarer i controlleren
                order.GuestID_FK = Guest.GuestID;
            }

            //Til sidst bruger vi en try catch til at forsøge og sende
            //vores ordrer til API'en gennem vores service klasse
            try {
                foreach (OrderDTO item in orders) {
                    await _client.CreateOrder(item);
                }
            } catch (Exception e) {
                throw new Exception($"Fejl ved oprettelse af ordrer '{e.Message}'.", e);
            }
        }
    }
}
