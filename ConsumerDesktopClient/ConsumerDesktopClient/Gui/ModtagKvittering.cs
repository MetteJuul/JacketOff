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
        public ModtagKvittering() {
            InitializeComponent();
        }

        private void buttonAfslut_Click(object sender, EventArgs e) {
            //We bring the start user panel back to the front
            Start.GetInstance.PnlModtag.Controls["ModtagStart"].BringToFront();
        }
    }
}
