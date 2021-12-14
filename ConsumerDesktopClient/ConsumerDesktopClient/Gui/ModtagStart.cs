using ConsumerDesktopClient.Control;
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
    public partial class ModtagStart : UserControl {

        private OrderController orderController;
        private int jakkeNummer;
        private int taskeNummer;

        public ModtagStart() {
            InitializeComponent();
            orderController = OrderController.GetInstance();
            textBoxJakkeNumre.Text = orderController.SidsteJakkeNummer.ToString();
            textBoxTaskeNumre.Text = orderController.SidsteTaskeNummer.ToString();
        }

        private async void buttonModtag_Click(object sender, EventArgs e) {

            //Vi initiere den næste UserController
            var ucModtagVaelgGaest = new ModtagVaelgGaest();

            //Vi kalder vores metode der opdatere
            //listen over alle gæster i OrderControlleren
            //så den er klar til at blive brugt i den næste
            //user controller. Se forklaring ved metoden
            await UpdateAllGuests();

            //Vi kalder metoden i vores User Controller
            //der henter den opdaterede liste af gæster
            //og repopulater vores listbox inde i user controlleren
            ucModtagVaelgGaest.PopulateListbox();

            //Vi gemmer vores nuværende jakkenummer og taskenummer i
            //propertiesne i controlleren, der holder styr på det sidst
            //indtastede af hvert nummer.
            orderController.SidsteJakkeNummer = jakkeNummer;
            orderController.SidsteTaskeNummer = taskeNummer;
            
            //Vi sikrer os at den næste user controller udfylder
            //hvad end den bliver docket ind i
            ucModtagVaelgGaest.Dock = DockStyle.Fill;

            //Vi tilføjer vores nye user controller til vores Modtag panel
            //i vores Start Form
            Start.GetInstance().PnlModtag.Controls.Add(ucModtagVaelgGaest);

            //Vi bringer den næste user controller frem til at stå forrest
            //i Modtag panelet.
            Start.GetInstance().PnlModtag.Controls["ModtagVaelgGaest"].BringToFront();

        }


        //TODO: find ud af hvor disse skal kaldes
        public void reloadNumre() {

            //Vi henter det sidste gemte jakkenummer putter det nye
            //i vores field
            var nytJakkeNummer = orderController.SidsteJakkeNummer;
            if (nytJakkeNummer < 999) { nytJakkeNummer++; } else { nytJakkeNummer = 1; }
            jakkeNummer = nytJakkeNummer;

            //Vi henter det sidste gemte taskenummer og putter det nye
            //i vores field
            var nytTaskeNummer = orderController.SidsteTaskeNummer;
            if (nytTaskeNummer < 999) { nytTaskeNummer++; } else { nytTaskeNummer = 1; }
            taskeNummer = nytTaskeNummer;
        }
       
        //Metode til asynkront at hente alle gæster fra
        //Ordercontrolleren. Dette ligger i en separat metode
        //da almene evenhandlere som buttonModtag_Click i Winform
        //ikke tillader at være af typen Task, der er nødvendig
        //for at kunne kalde metoden i OrderControlleren
        private async Task UpdateAllGuests() {
            await orderController.GetAllGuests();
        }

        //Sikre at når vi ændre nummeret i tekstboksen gemmes det
        //i vores jakkeNummer variabel
        private void textBoxJakkeNumre_TextChanged(object sender, EventArgs e) {
            jakkeNummer = Convert.ToInt32(textBoxJakkeNumre.Text);
        }

        //Sikre at når vi ændre nummeret i tekstboksen gemmes det
        //i vores taskeNummer variabel
        private void textBoxTaskeNumre_TextChanged(object sender, EventArgs e) {
            taskeNummer = Convert.ToInt32(textBoxTaskeNumre.Text);
        }

        #region Plus og Minus knapper og deres metoder

        private void buttonPlusJakker_Click(object sender, EventArgs e) {
            Plus(textBoxJakkeNumre, "jakke");            
        }

        private void buttonMinusJakker_Click(object sender, EventArgs e) {

            Minus(textBoxJakkeNumre, "jakke");
        }

        private void buttonPlusTasker_Click(object sender, EventArgs e) {
            Plus(textBoxTaskeNumre, "taske");
        }

        private void buttonMinusTasker_Click(object sender, EventArgs e) {
            Minus(textBoxTaskeNumre, "taske");
        }

        //Metode bruges til at trække 1 fra jakke- eller taskenummeret
        //når der trykkes på minus knapperne.
        private void Minus(TextBox textBox, string itemType) {
            
            //Vi tjekker om det er en jakke
            if (itemType.Equals("jakke")) {

                //Hvis jakkenummeret er større end 1 trækker vi bare 1 fra
                //hvis jakkenummeret er 1 så retter i stedet for nummeret til 999
                //så vi aldrig rammer 0
                if (jakkeNummer > 1) { jakkeNummer--; } else { jakkeNummer = 999; }

                //Vi sikre os at tekstboksen bliver opdateret med det nye jakkenummer
                textBox.Text = jakkeNummer.ToString();

            } else if (itemType.Equals("taske")) {
                //Hvis taskenummeret er større end 1 trækker vi bare 1 fra
                //hvis taskenummeret er 1 så retter i stedet for nummeret til 999
                //så vi aldrig rammer 0
                if (taskeNummer > 1) { taskeNummer--; } else { taskeNummer = 999; }

                //Vi sikre os at tekstboksen bliver opdateret med det nye taskenummer
                textBox.Text = taskeNummer.ToString();
            }
        }

        //Metode bruges til at lægge 1 til jakke- eller taskenummeret
        //når der trykkes på plus knapperne.
        private void Plus(TextBox textBox, string itemType) {

            if (itemType.Equals("jakke")) {

                //Hvis jakkenummeret er mindre end 999 lægger vi bare 1 til
                //hvis jakkenummeret er 999 så retter vi i stedet for nummeret til 1
                //så vi aldrig rammer 10000
                if (jakkeNummer < 999) { jakkeNummer++; } else { jakkeNummer = 1; }

                //Vi sikre os at tekstboksen bliver opdateret med det nye jakkenummer
                textBox.Text = jakkeNummer.ToString();

            } else if (itemType.Equals("taske")) {

                //Hvis taskenummeret er mindre end 999 lægger vi bare 1 til
                //hvis taskenummeret er 999 så retter vi i stedet for nummeret til 1
                //så vi aldrig rammer 10000
                if (taskeNummer < 999) { taskeNummer++; } else { taskeNummer = 1; }

                //Vi sikre os at tekstboksen bliver opdateret med det nye jakkenummer
                textBox.Text = taskeNummer.ToString();
            }
        }
        #endregion
        
    }
}
