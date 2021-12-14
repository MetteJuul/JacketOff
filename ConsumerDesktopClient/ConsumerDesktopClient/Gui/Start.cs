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

        //Vi laver et static field af klassen selv
        //for at kunne lave den Singleton
        static Start _object;
        private OrderController orderController;

        //Denne statiske metode bruges til at enten instantiere
        //eller hente det allerede instantierede object af
        //klassen.
        public static Start GetInstance() {
            //We check if the class has already been instantiated
            //If not, we instantiate it
            if (_object == null) {

                _object = new Start();
            }
                return _object;            
        }

        //Constructoren er privat for at understøtte Singleton
        private Start() {
            InitializeComponent();
            orderController = OrderController.GetInstance();
        }

        //Vores paneler laves alle til public properties
        //så vi er i stand til at sætte deres værdier
        //og ændre rækkefælgen af user controllers
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
        
        private void Start_Load(object sender, EventArgs e) {
            
            //Vi sikrer os at vores Singleton bliver instantieret
            //hvis den ikke allerede er det.
            _object = this;

            //Vi instantiere vores usercontrollers som
            //skal ligge forrest i de 3 paneler når programmet startes
            //We create a new usercontroller of all our Starting types
            ModtagStart ucModtagStart = new ModtagStart();
            UdleverStart ucUdleverStart = new UdleverStart();
            RedigerStart ucRedigerStart = new RedigerStart();

            //Vi sætter dem til at fylde hvad end de er docket til
            ucModtagStart.Dock = DockStyle.Fill;
            ucUdleverStart.Dock = DockStyle.Fill;
            ucRedigerStart.Dock = DockStyle.Fill;

            //Vi tilføjer vores user controllers til deres
            //respektive paneler
            panelModtag.Controls.Add(ucModtagStart);
            panelUdlever.Controls.Add(ucUdleverStart);
            panelRediger.Controls.Add(ucRedigerStart);

            //Vi sikrer os at vores Start user controllers
            //ligger forrest i hver deres panel
            PnlModtag.Controls["ModtagStart"].BringToFront();
            PnlUdlever.Controls["UdleverStart"].BringToFront();
            PnlRediger.Controls["RedigerStart"].BringToFront();
        }

        #region Udlever
        private void buttonUdlever_Click(object sender, EventArgs e) {

        }


        #endregion

        #region Rediger

        private void buttonRediger_Click(object sender, EventArgs e) {

        }


        #endregion

    }
}
