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
        readonly string ourEmail = "jacketoffprojekt@gmail.com";

        public OrderService(string connectionString) : base(connectionString) {
            guestRepo = new GuestRepository(connectionString);
            orderRepo = new OrderRepository(connectionString);
            itemRepo = new ItemRepository(connectionString);
        }

        public async Task<int> CreateOrder(Order newOrder) {

            //Start Transaktion
            using SqlConnection connection = CreateConnection();
            connection.Open();
            using var command = new SqlCommand();

            using SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;

            //Tjek om ordren indeholder data
            if (newOrder == null) {
                return 0;
            } else {
                try {
                    //Find gæst baseret på ID
                    Guest foundGuest = await guestRepo.GetByID(newOrder.GuestID_FK);

                    //Vi sender dem en email med deres ticketnumber
                    writeEmail(foundGuest, newOrder.TicketNumber);

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
        private void writeEmail(Guest guest, int ticketNumber) {
            //Snak om hvorvidt vi skal hente mere data, for at tilføje item-type osv
            string email = $"Tak fordi du har tjekket ind i vores garderobe. Dit gardrobenummer er {ticketNumber}." +
                " Hav en god aften.";

            try {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(ourEmail);
                message.To.Add(new MailAddress(guest.Email));
                message.Subject = "Garderobenummer";
                message.Body = email;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(ourEmail, "JacketOffProjekt1!");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            } catch (Exception e) {
                throw new Exception($"Fejl ved sending af Email til {guest.Email} '{e.Message}'.", e);
            }
        }
    }
}
