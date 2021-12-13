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

        public ModtagStart() {
            InitializeComponent();
            orderController = OrderController.GetInstance();
        }

        private async void buttonModtag_Click(object sender, EventArgs e) {

            //We create the next UserController and pass,
            //number of jackets and bags as well as the current
            //ticket numbers into our OrderController
            var ucVaelgGaest = new ModtagVaelgGaest();

            //We prepare for the next user controller by repopulating
            //the list of guests in the controller, so that they are ready
            //await ButtonModtagHandlerAsync();

            //We ensure that new lists are made, so that old wardrobenumbers
            //are not still stored.
            orderController.JakkeNumre = new List<int>();
            orderController.TaskeNumre = new List<int>();
            orderController.JakkeNumre.Add(Convert.ToInt32(textBoxJakkeNumre.Text));
            orderController.TaskeNumre.Add(Convert.ToInt32(textBoxTaskeNumre.Text));
            
            ucVaelgGaest.Dock = DockStyle.Fill;

            //We add our user controller to our Start form
            Start.GetInstance().PnlModtag.Controls.Add(ucVaelgGaest);

            //We bring it to the front of our start form
            Start.GetInstance().PnlModtag.Controls["ModtagVaelgGaest"].BringToFront();
        }

        //private async Task ButtonModtagHandlerAsync() {
        //    await orderController.GetAllGuests();
        //}

        private void buttonPlusJakker_Click(object sender, EventArgs e) {
            var antalJakker = Convert.ToInt32(textBoxJakkeNumre.Text);
            textBoxJakkeNumre.Text = (antalJakker + 1).ToString();
        }

        private void buttonMinusJakker_Click(object sender, EventArgs e) {
            var antalJakker = Convert.ToInt32(textBoxJakkeNumre.Text);

            if (antalJakker > 0) {
                textBoxJakkeNumre.Text = (antalJakker - 1).ToString();
            }
        }

        private void buttonPlusTasker_Click(object sender, EventArgs e) {
            var antalTasker = Convert.ToInt32(textBoxTaskeNumre.Text);
            textBoxTaskeNumre.Text = (antalTasker + 1).ToString();
        }

        private void buttonMinusTasker_Click(object sender, EventArgs e) {
            var antalTasker = Convert.ToInt32(textBoxTaskeNumre.Text);

            if (antalTasker > 0) {
                textBoxTaskeNumre.Text = (antalTasker - 1).ToString();
            }
        }
    }
}
