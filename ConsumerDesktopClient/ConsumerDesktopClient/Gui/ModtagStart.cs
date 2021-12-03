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
        public ModtagStart() {
            InitializeComponent();
        }

        private void buttonModtag_Click(object sender, EventArgs e) {

            //We check whether our Start form does no contain an instantiated version
            //of our user controller, we create one and add it to our Start form
            if (!Start.GetInstance.PnlModtag.Controls.ContainsKey("ModtagAngivAntal")) {

                UdleverCheckUd ucModtagAngivAntal = new UdleverCheckUd();
                ucModtagAngivAntal.Dock = DockStyle.Fill;
                Start.GetInstance.PnlModtag.Controls.Add(ucModtagAngivAntal);
            }
            
            //We bring the next user controller to the front of our panel
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
