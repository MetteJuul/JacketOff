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
    public partial class ModtagAngivAntal : UserControl {

        private OrderController orderController;
        private int antalJakker;
        private int antalTasker;

        public ModtagAngivAntal() {
            orderController = OrderController.GetInstance();
            InitializeComponent();
        }

        public void Seppuku() {
            Start.GetInstance().PnlModtag.Controls.Remove(this);
        }

        private void buttonAfbryd_Click(object sender, EventArgs e) {
            //Dirrigerer os tilbage til Vores ModtagStart User Controller
            Start.GetInstance().PnlModtag.Controls["ModtagStart"].BringToFront();
        }

        private void buttonNaeste_Click(object sender, EventArgs e) {

            antalJakker = Convert.ToInt32(textBoxAntalJakker.Text);
            antalTasker = Convert.ToInt32(textBoxAntalTasker.Text);

            //Vi gemmer antallet af Tasker og Jakker
            //til OrderControlleren ved at initiere arrays'ne
            //med jakkenumre og taskenumre, til at have en længde
            //tilsvarende til antallet af jakker og tasker.
            if (antalJakker > 0) {
                orderController.JakkeNumre = new int[antalJakker];
                orderController.JakkeNumre[0] = orderController.SidsteJakkeNummer;
            }
            if (antalTasker > 0) {
                orderController.TaskeNumre = new int[antalTasker];
                orderController.TaskeNumre[0] = orderController.SidsteTaskeNummer;
            }

            //Vi initiere den næste UserController
            ModtagKvittering ucModtagKvittering = new ModtagKvittering();

            //Vi sikrer os at den næste user controller udfylder
            //hvad end den bliver docket ind i
            ucModtagKvittering.Dock = DockStyle.Fill;

            //Vi tilføjer vores nye user controller til vores Modtag panel
            //i vores Start Form
            Start.GetInstance().PnlModtag.Controls.Add(ucModtagKvittering);

            //Vi bringer den næste user controller frem til at stå forrest
            //i Modtag panelet
            Start.GetInstance().PnlModtag.Controls["ModtagKvittering"].BringToFront();




            //Vi resetter så antallet af jakker og tasker
            //så de er klar til næste gang vi rammer samme
            //user controller
            Seppuku();
        }

        private void buttonPlusJakker_Click(object sender, EventArgs e) {
            
            //Vi opdaterer antallet af jakker og viser derefter det nye antal
            //i vores tekstboks for antal jakker
            antalJakker = Convert.ToInt32(textBoxAntalJakker.Text) + 1;
            textBoxAntalJakker.Text = (antalJakker).ToString();
        }

        private void buttonMinusJakker_Click(object sender, EventArgs e) {

            //Vi opdaterer antallet af jakker medmindre det vil blive
            //mindre end 0, og viser derefter det nye antal
            //i vores tekstboks for antal jakker
            antalJakker = Convert.ToInt32(textBoxAntalJakker.Text);
            if (antalJakker > 0) {
                antalJakker = antalJakker - 1;
                
            }
            textBoxAntalJakker.Text = antalJakker.ToString();
        }

        private void buttonPlusTasker_Click(object sender, EventArgs e) {

            //Vi opdaterer antallet af tasker og viser derefter det nye antal
            //i vores tekstboks for antal tasker
            antalTasker = Convert.ToInt32(textBoxAntalTasker.Text) + 1;
            textBoxAntalTasker.Text = (antalTasker).ToString();
        }

        private void buttonMinusTasker_Click(object sender, EventArgs e) {

            //Vi opdaterer antallet af tasker medmindre det vil blive
            //mindre end 0, og viser derefter det nye antal
            //i vores tekstboks for antal tasker
            antalTasker = Convert.ToInt32(textBoxAntalTasker.Text);
            if (antalTasker > 0) {
                antalTasker = antalTasker - 1;
            }
            textBoxAntalTasker.Text = (antalTasker).ToString();
        }
    }
}
