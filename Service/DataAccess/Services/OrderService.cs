using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services {
    public class OrderService : BaseDB, IOrderService {

        private IGuestRepository guestRepo;
        private IOrderRepository orderRepo;
        private IItemRepository itemRepo;
        private IDbTransaction transaction;
        private SmtpClient mailClient;
        readonly string ourEmail = "jacketoffprojekt@gmail.com";

        public OrderService(string connectionString) : base(connectionString) {
            guestRepo = new GuestRepository(connectionString);
            orderRepo = new OrderRepository(connectionString);
            itemRepo = new ItemRepository(connectionString);

            //.NETs indbyggede mail client initieres og bruges
            mailClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(ourEmail, "JacketOffProjekt1!"),
                EnableSsl = true,
            };
        }

        public async Task<int> CreateOrder(Order newOrder) {

            //Start Transaktion
            using SqlConnection connection = CreateConnection();
            connection.Open();
            using var command = new SqlCommand();

            using SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            command.Transaction = transaction;

            //Tjek om ordren indeholder data
            if (newOrder == null) {
                return 0;
            } else {
                try {
                    //Find gæst baseret på ID
                    Guest foundGuest = await guestRepo.GetByID(newOrder.GuestID_FK);

                    //Vi sender dem en email med deres ticketnumber
                    mailClient.Send(ourEmail, foundGuest.Email, "Garderobenummer", writeEmail(newOrder));

                    //Så opretter vi ordren
                    await orderRepo.CreateOrder(newOrder);

                    //Comitter vores transaction
                    transaction.Commit();

                    //Returnere 1
                    return 1;
                } catch (Exception e) {
                    
                    //Vi laver rollback hvis noget som helst gå galt i vores try
                    transaction.Rollback();

                    throw new Exception($"Kunne ikke oprette reservation: '{e.Message}'.", e);
                }
            }
        }

        //Her tager vi imod vores ticketnumber og skriver indholdet til den email
        //der sendes til gæsten. Med tiden vil der istedet bliver sendt et link
        //men for at nå så meget som muligt, sender vi ind til videre ticketnumberet
        //direkte
        //TODO diskuter om det kun er gæsten, eller om det er ordren der skal sendes.
        private String writeEmail(Order order) {

            //Snak om hvorvidt vi skal hente mere data, for at tilføje item-type osv
            string email = $"Tak fordi du har tjekket ind i vores garderobe. Dit gardrobenummer er {order.TicketNumber}." +
                "Hav en god aften.";

            return email;
        }
    }
}
