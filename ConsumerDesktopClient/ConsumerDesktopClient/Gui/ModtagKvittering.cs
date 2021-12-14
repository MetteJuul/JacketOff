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
    public partial class ModtagKvittering : UserControl {

        private OrderController orderController;
        private int jakkeNummer;
        private int taskeNummer;

        public ModtagKvittering() {
            InitializeComponent();
            orderController = OrderController.GetInstance();

            if (orderController.JakkeNumre.Length > 0) {
                jakkeNummer = orderController.JakkeNumre[0];
            }
            if (orderController.TaskeNumre.Length > 0) {
                taskeNummer = orderController.TaskeNumre[0];
            }
            textBoxJakkeNumre1.Text = jakkeNummer.ToString();
            textBoxTaskeNumre1.Text = taskeNummer.ToString();

        }

        private void CheckAmount() {
            int antalJakker = orderController.JakkeNumre.Length;
            int antalTasker = orderController.TaskeNumre.Length;
        }

        private async void buttonAfslut_Click(object sender, EventArgs e) {
            
            //We call our async create order method, which
            // has been moved to a seperate method, to better
            //collaborate with winforms
            await buttonAfslutClickHandlerAsync();

            //We bring the start user panel back to the front
            Start.GetInstance().PnlModtag.Controls["ModtagStart"].BringToFront();
        }

        private async Task buttonAfslutClickHandlerAsync() {
            await orderController.CreateOrder();
        }

        #region Plus og Minus Knapper og deres tilhørende metoder
        private void buttonMinusJakker1_Click_1(object sender, EventArgs e) {
            Minus(textBoxJakkeNumre1, "jakke");
        }

        private void buttonPlusJakker1_Click(object sender, EventArgs e) {
            Plus(textBoxJakkeNumre1, "jakke");
        }

        private void buttonMinusJakker2_Click(object sender, EventArgs e) {
            Minus(textBoxJakkeNumre2, "jakke");
        }

        private void buttonPlusJakker2_Click(object sender, EventArgs e) {
            Plus(textBoxJakkeNumre2, "jakke");
        }

        private void buttonMinusJakker3_Click(object sender, EventArgs e) {
            Minus(textBoxJakkeNumre3, "jakke");
        }

        private void buttonPlusJakker3_Click(object sender, EventArgs e) {
            Plus(textBoxJakkeNumre3, "jakke");
        }

        private void buttonMinusTasker1_Click(object sender, EventArgs e) {
            Minus(textBoxTaskeNumre1, "taske");
        }

        private void buttonPlusTasker1_Click(object sender, EventArgs e) {
            Plus(textBoxTaskeNumre1, "taske");
        }

        private void buttonMinusTasker2_Click(object sender, EventArgs e) {
            Minus(textBoxTaskeNumre2, "taske");
        }

        private void buttonPlusTasker2_Click(object sender, EventArgs e) {
            Plus(textBoxTaskeNumre2, "taske");
        }

        private void buttonMinusTasker3_Click(object sender, EventArgs e) {
            Minus(textBoxTaskeNumre3, "taske");
        }

        private void buttonPlusTasker3_Click(object sender, EventArgs e) {
            Plus(textBoxTaskeNumre3, "taske");
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
