using ConsumerDesktopClient.Control;
using ConsumerDesktopClient.DTOs;
using ConsumerDesktopClient.Gui.Model;
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
        private int[] jakkeNumre;
        private int[] taskeNumre;
        private int antalJakker;
        private int startNummerJakke;
        private int antalTasker;
        private int startNummerTaske;

        public ModtagKvittering() {
            InitializeComponent();
            orderController = OrderController.GetInstance();

            InitializeArrays();
            PopulateDataGridViewJakkeNumre();
            PopulateDataGridViewTaskeNumre();
        }

        private void InitializeArrays() {

            //Hvis Ordercontrollerens Array af JakkeNumre
            //ikke er null, bruger vi længden af Arrayen
            //til at angive antal jakker. Vi angiver så
            //startnummeret til at være gemte jakkeNummer
            if (orderController.JakkeNumre != null) {
                antalJakker = orderController.JakkeNumre.Length;
                startNummerJakke = orderController.SidsteJakkeNummer;
            }

            //Hvis der er flere end 0 jakker opretter vi en ny
            //int Array, på samme størrelse som antallet af jakker
            if (antalJakker > 0) {
                jakkeNumre = new int[antalJakker];

                //Vi laver et loop hvor vi starter med startnummeret
                //og tilføjer lige så mange numre til vores
                //array som der er antal jakker
                for (int i = 0; i < antalJakker; i++) {
                    jakkeNumre[i] = startNummerJakke + i;
                }
            }

            //Hvis Ordercontrollerens Array af TaskeNumre
            //ikke er null, bruger vi længden af Arrayen
            //til at angive antal tasker. Vi angiver så
            //startnummeret til at være gemte taskeNummer
            if (orderController.TaskeNumre != null) {
                antalTasker = orderController.TaskeNumre.Length;
                startNummerTaske = orderController.SidsteTaskeNummer;
            }

            //Hvis der er flere end 0 tasker opretter vi en ny
            //int Array, på samme størrelse som antallet af tasker
            if (antalTasker > 0) {
                taskeNumre = new int[antalTasker];

                //Vi laver et loop hvor vi starter med startnummeret
                //og tilføjer lige så mange numre til vores
                //array som der er antal tasker
                for (int i = 0; i < antalTasker; i++) {
                    taskeNumre[i] = startNummerTaske + i;
                }
            }
        }

        private void PopulateDataGridViewJakkeNumre() {

            //Vi clearer vores kilde til at loade dataen
            //ind i vores view, så det kun er den nye
            //data der ligger deri
            jakkeNummerBindingSource.Clear();

            //Vi opretter JakkeNummer objekter for hvert nummer
            //for at kunne tilføje dem til DataViewGrid
            //der kræver en model for at virke
            if (jakkeNumre != null) {
                foreach (var nummer in jakkeNumre) {
                    jakkeNummerBindingSource.Add(new JakkeNummer() { Number = nummer });
                }
            }

        }

        private void PopulateDataGridViewTaskeNumre() {

            //Vi clearer vores kilde til at loade dataen
            //ind i vores view, så det kun er den nye
            //data der ligger deri
            taskeNummerBindingSource.Clear();

            //Vi opretter TaskeNummer objekter for hvert nummer
            //for at kunne tilføje dem til DataViewGrid
            //der kræver en model for at virke
            if (taskeNumre != null) {
                foreach (var nummer in taskeNumre) {
                    taskeNummerBindingSource.Add(new TaskeNummer() { Number = nummer });
                }
            }
        }

        private async void buttonAfslut_Click(object sender, EventArgs e) {

            orderController.JakkeNumre = jakkeNumre;
            orderController.TaskeNumre = taskeNumre;

            //We call our async create order method, which
            // has been moved to a seperate method, to better
            //collaborate with winformsZ
            await buttonAfslutClickHandlerAsync();

            //We bring the start user panel back to the front
            Start.GetInstance().PnlModtag.Controls["ModtagStart"].BringToFront();
        }

        private async Task buttonAfslutClickHandlerAsync() {
            await orderController.CreateOrder();
        }

        #region Plus og Minus Knapper og deres tilhørende metoder
        //private void buttonMinusJakker1_Click_1(object sender, EventArgs e) {
        //    Minus(textBoxJakkeNumre1, "jakke");
        //}

        //private void buttonPlusJakker1_Click(object sender, EventArgs e) {
        //    Plus(textBoxJakkeNumre1, "jakke");
        //}

        //private void buttonMinusJakker2_Click(object sender, EventArgs e) {
        //    Minus(textBoxJakkeNumre2, "jakke");
        //}

        //private void buttonPlusJakker2_Click(object sender, EventArgs e) {
        //    Plus(textBoxJakkeNumre2, "jakke");
        //}

        //private void buttonMinusJakker3_Click(object sender, EventArgs e) {
        //    Minus(textBoxJakkeNumre3, "jakke");
        //}

        //private void buttonPlusJakker3_Click(object sender, EventArgs e) {
        //    Plus(textBoxJakkeNumre3, "jakke");
        //}

        //private void buttonMinusTasker1_Click(object sender, EventArgs e) {
        //    Minus(textBoxTaskeNumre1, "taske");
        //}

        //private void buttonPlusTasker1_Click(object sender, EventArgs e) {
        //    Plus(textBoxTaskeNumre1, "taske");
        //}

        //private void buttonMinusTasker2_Click(object sender, EventArgs e) {
        //    Minus(textBoxTaskeNumre2, "taske");
        //}

        //private void buttonPlusTasker2_Click(object sender, EventArgs e) {
        //    Plus(textBoxTaskeNumre2, "taske");
        //}

        //private void buttonMinusTasker3_Click(object sender, EventArgs e) {
        //    Minus(textBoxTaskeNumre3, "taske");
        //}

        //private void buttonPlusTasker3_Click(object sender, EventArgs e) {
        //    Plus(textBoxTaskeNumre3, "taske");
        //}

        //Metode bruges til at trække 1 fra jakke- eller taskenummeret
        //når der trykkes på minus knapperne.
        private void Minus(TextBox textBox, string itemType) {

            ////Vi tjekker om det er en jakke
            //if (itemType.Equals("jakke")) {

            //    //Hvis jakkenummeret er større end 1 trækker vi bare 1 fra
            //    //hvis jakkenummeret er 1 så retter i stedet for nummeret til 999
            //    //så vi aldrig rammer 0
            //    if (jakkeNumre > 1) { jakkeNumre--; } else { jakkeNumre = 999; }

            //    //Vi sikre os at tekstboksen bliver opdateret med det nye jakkenummer
            //    textBox.Text = jakkeNumre.ToString();

            //} else if (itemType.Equals("taske")) {
            //    //Hvis taskenummeret er større end 1 trækker vi bare 1 fra
            //    //hvis taskenummeret er 1 så retter i stedet for nummeret til 999
            //    //så vi aldrig rammer 0
            //    if (taskeNummer > 1) { taskeNummer--; } else { taskeNummer = 999; }

            //    //Vi sikre os at tekstboksen bliver opdateret med det nye taskenummer
            //    textBox.Text = taskeNummer.ToString();
            //}
        }

        //Metode bruges til at lægge 1 til jakke- eller taskenummeret
        //når der trykkes på plus knapperne.
        private void Plus(TextBox textBox, string itemType) {

            //if (itemType.Equals("jakke")) {

            //    //Hvis jakkenummeret er mindre end 999 lægger vi bare 1 til
            //    //hvis jakkenummeret er 999 så retter vi i stedet for nummeret til 1
            //    //så vi aldrig rammer 10000
            //    if (jakkeNumre < 999) { jakkeNumre++; } else { jakkeNumre = 1; }

            //    //Vi sikre os at tekstboksen bliver opdateret med det nye jakkenummer
            //    textBox.Text = jakkeNumre.ToString();

            //} else if (itemType.Equals("taske")) {

            //    //Hvis taskenummeret er mindre end 999 lægger vi bare 1 til
            //    //hvis taskenummeret er 999 så retter vi i stedet for nummeret til 1
            //    //så vi aldrig rammer 10000
            //    if (taskeNummer < 999) { taskeNummer++; } else { taskeNummer = 1; }

            //    //Vi sikre os at tekstboksen bliver opdateret med det nye jakkenummer
            //    textBox.Text = taskeNummer.ToString();
            //}
        }
        #endregion

        private void dataGridViewJakkeNumre_CellContentClick(object sender, DataGridViewCellEventArgs e) {

            var index = dataGridViewJakkeNumre.Rows[e.RowIndex];

            if (dataGridViewJakkeNumre.Columns[e.ColumnIndex].Name == "MinusColumnJakker") {

                for(int i = 0; i < antalJakker; i++) {
                    jakkeNumre[i]--;
                }
                PopulateDataGridViewJakkeNumre();
            }

            if(dataGridViewJakkeNumre.Columns[e.ColumnIndex].Name == "PlusColumnJakker") {

                //while (index < antalJakker) {
                //    jakkeNumre[index]++;
                //}

                for (int i = 0; i < antalJakker; i++) {
                    jakkeNumre[i]++;
                }
                PopulateDataGridViewJakkeNumre();
            }
        }

        private void dataGridViewTaskeNumre_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (dataGridViewTaskeNumre.Columns[e.ColumnIndex].Name == "MinusColumnTasker") {

                for (int i = 0; i < antalTasker; i++) {
                    taskeNumre[i]--;
                }
                PopulateDataGridViewTaskeNumre();
            }

            if (dataGridViewTaskeNumre.Columns[e.ColumnIndex].Name == "PlusColumnTasker") {
                for (int i = 0; i < antalTasker; i++) {
                    taskeNumre[i]++;
                }
                PopulateDataGridViewTaskeNumre();
            }
        }
    }
}
