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

        public ModtagStart(OrderController orderController) {
            InitializeComponent();
        }

        private void buttonModtag_Click(object sender, EventArgs e) {

            //We retrieve the number of jackets and bags
            var antalJakker = Convert.ToInt32(textBoxJakkeNumre.Text);
            var antalTasker = Convert.ToInt32(textBoxTaskeNumre.Text);

            //We create the next UserController and pass our orderController,
            //number of jackets and bags
            var ucModtagAngivAntal = new ModtagAngivAntal(orderController, antalJakker, antalTasker);
            ucModtagAngivAntal.Dock = DockStyle.Fill;

            //We add our user controller to our Start form
            Start.GetInstance.PnlModtag.Controls.Add(ucModtagAngivAntal);

            //We bring it to the front of our start form
            Start.GetInstance.PnlModtag.Controls["ModtagAngivAntal"].BringToFront();
        }

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
