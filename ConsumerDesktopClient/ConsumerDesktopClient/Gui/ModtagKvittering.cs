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

        public void Seppuku() {
            Start.GetInstance().PnlModtag.Controls.Remove(this);
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

            ////Vi clearer vores kilde til at loade dataen
            ////ind i vores view, så det kun er den nye
            ////data der ligger deri
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

            Seppuku();
        }

        private async Task buttonAfslutClickHandlerAsync() {
            await orderController.CreateOrder();
        }

        private void dataGridViewJakkeNumre_CellContentClick(object sender, DataGridViewCellEventArgs e) {

            if (dataGridViewJakkeNumre.Columns[e.ColumnIndex].Name == "MinusColumnJakker") {

                for (int i = 0; i < antalJakker; i++) {
                    jakkeNumre[i]--;
                }
                PopulateDataGridViewJakkeNumre();
            }

            if (dataGridViewJakkeNumre.Columns[e.ColumnIndex].Name == "PlusColumnJakker") {

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
