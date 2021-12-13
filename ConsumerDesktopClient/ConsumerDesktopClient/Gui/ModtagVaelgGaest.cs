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

        private OrderController ordercontroller;
        private object foundGuest;

        public List<GuestDTO> AllGuests { get; set; }

        public ModtagVaelgGaest() {
            InitializeComponent();
            ordercontroller = OrderController.GetInstance();
        }

        public void populateListBox() {
            foreach(GuestDTO guest in AllGuests) {
                listBoxGuests.Items.Add(guest);
            }
            listBoxGuests.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e) {

        }

        private void buttonAfbryd_Click(object sender, EventArgs e) {
            Start.GetInstance().PnlModtag.Controls["ModtagStart"].BringToFront();
        }

        private void buttonNaeste_Click(object sender, EventArgs e) {

            //We create the next UserController and pass,
            //number of jackets and bags as well as the current
            //ticket numbers into our OrderController
            var ucModtagAngivAntal = new ModtagAngivAntal();

            ucModtagAngivAntal.Dock = DockStyle.Fill;

            //We add our user controller to our Start form
            Start.GetInstance().PnlModtag.Controls.Add(ucModtagAngivAntal);

            //We bring it to the front of our start form
            Start.GetInstance().PnlModtag.Controls["ModtagAngivAntal"].BringToFront();

            ordercontroller.Guest = (GuestDTO)foundGuest;
        }

        private void listBoxGuests_SelectedIndexChanged(object sender, EventArgs e) {
            foundGuest = listBoxGuests.SelectedItem;
        }

        private void SearchGuestByEmail(string email) {

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e) {

           
        }
    }
}
