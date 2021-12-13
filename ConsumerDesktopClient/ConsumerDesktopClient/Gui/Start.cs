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
    public partial class Start : Form {

        //We create a static field of the classes
        //own type to enable singleton
        static Start _object;
        private OrderController orderController;


        //We create a static method to instantiate our
        //singleton class
        public static Start GetInstance() {
            //We check if the class has already been instantiated
            //If not, we instantiate it
            if (_object == null) {

                _object = new Start();
            }
                return _object;            
        }


        private Start() {
            InitializeComponent();
            orderController = OrderController.GetInstance();
        }

        //Our panel is made into a public property
        //So we will be able to set the value of it
        //Inside our user controllers
        public Panel PnlModtag {
            get { return panelModtag; }
            set { panelModtag = value; }
        }

        public Panel PnlUdlever {
            get { return panelUdlever; }
            set { panelUdlever = value; }
        }

        public Panel PnlRediger {
            get { return panelRediger; }
            set { panelRediger = value; }
        }
        
        private async void Start_Load(object sender, EventArgs e) {
            
            //We make sure our Singelton gets instantated
            _object = this;

            //We create a new usercontroller of all our Starting types
            ModtagStart ucModtagStart = new ModtagStart();
            ModtagVaelgGaest ucModtagVaelgGaest = new ModtagVaelgGaest();
            UdleverStart ucUdleverStart = new UdleverStart();
            RedigerStart ucRedigerStart = new RedigerStart();

            await PopulateListbox();
            ucModtagVaelgGaest.AllGuests = orderController.AllGuests.ToList();
            ucModtagVaelgGaest.populateListBox();

            //We set them to fill whatever they is docked into
            ucModtagStart.Dock = DockStyle.Fill;
            ucModtagVaelgGaest.Dock = DockStyle.Fill;
            ucUdleverStart.Dock = DockStyle.Fill;
            ucRedigerStart.Dock = DockStyle.Fill;

            //We add our starting usercontrollers to our panels   
            panelModtag.Controls.Add(ucModtagStart);
            panelModtag.Controls.Add(ucModtagVaelgGaest);
            panelUdlever.Controls.Add(ucUdleverStart);
            panelRediger.Controls.Add(ucRedigerStart);

            //We bring our Start user controllers to the front
            PnlModtag.Controls["ModtagStart"].BringToFront();
            PnlUdlever.Controls["UdleverStart"].BringToFront();
            PnlRediger.Controls["RedigerStart"].BringToFront();
        }

        private async Task PopulateListbox() {
            await orderController.GetAllGuests();
        }

        #region Udlever
        private void buttonUdlever_Click(object sender, EventArgs e) {

        }


        #endregion

        #region Rediger

        private void buttonRediger_Click(object sender, EventArgs e) {

        }


        #endregion

        private void modtagKvittering1_Load(object sender, EventArgs e) {

        }

    }
}
