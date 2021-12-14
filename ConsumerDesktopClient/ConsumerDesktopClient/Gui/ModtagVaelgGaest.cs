using ConsumerDesktopClient.Control;
using ConsumerDesktopClient.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumerDesktopClient.Gui {
    public partial class ModtagVaelgGaest : UserControl {

        //Vi laver et field for vores ordercontroller,
        //det valgte gæsteobjekt og en lokale liste over
        //alle gæster.
        private OrderController orderController;
        private object foundGuest;
        private List<GuestDTO> allGuests;

        public ModtagVaelgGaest() {
            InitializeComponent();
            orderController = OrderController.GetInstance();
        }

        //Denne metode kalder vi, ligesom vores property AllGuests
        //I den forrige user controller, så dataen er klar
        //når denne user controller bliver lagt forrest. 
        //Her sikre vi os at listbox først bliver clearet
        //og så repopulated med en opdateret liste af gæster,
        //sådan at ny-oprettede gæster hentes ind i vore listbox
        public void PopulateListbox() {
            //Vi henter listen over alle gæster ind fra vores
            //ordercontroller
            allGuests = orderController.AllGuests.ToList();

            //Vi clearer listboxen for tidligere items
            listBoxGuests.Items.Clear();

            //Vi tilføjer alle fundne gæster som items
            //til vores listbox
            foreach (GuestDTO guest in allGuests) {
                listBoxGuests.Items.Add(guest);
            }
        }
        
        private void buttonAfbryd_Click(object sender, EventArgs e) {
            //Dirrigerer os tilbage til Vores ModtagStart User Controller
            Start.GetInstance().PnlModtag.Controls["ModtagStart"].BringToFront();
        }

        private void buttonNaeste_Click(object sender, EventArgs e) {

            //Vi initiere den næste UserController
            var ucModtagAngivAntal = new ModtagAngivAntal();

            //Vi sikrer os at den næste user controller udfylder
            //hvad end den bliver docket ind i
            ucModtagAngivAntal.Dock = DockStyle.Fill;

            //Vi tilføjer vores nye user controller til vores Modtag panel
            //i vores Start Form
            Start.GetInstance().PnlModtag.Controls.Add(ucModtagAngivAntal);

            //Vi bringer den næste user controller frem til at stå forrest
            //i Modtag panelet.
            Start.GetInstance().PnlModtag.Controls["ModtagAngivAntal"].BringToFront();

            //Vi sender hvad end gæst, der var markeret
            //da der blev trykket næste til vores
            //OrderController, så den kan bruges
            //til at oprette ordren.
            orderController.Guest = (GuestDTO)foundGuest;
        }

        private void listBoxGuests_SelectedIndexChanged(object sender, EventArgs e) {
            //Hver gang en ny gæst bliver valgt
            //gemmer vi den i vores foundGuestField
            foundGuest = listBoxGuests.SelectedItem;
        }

        private void SearchGuestByEmail(string email) {

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e) {
           
        }
    }
}
