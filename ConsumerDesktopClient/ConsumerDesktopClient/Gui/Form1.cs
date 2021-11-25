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

namespace ConsumerDesktopClient {
    public partial class Form1 : Form {

        ReservationController _reservationController;

        public Form1() {
            InitializeComponent();

            _reservationController = new ReservationController();
        }

        private async void buttonGetAllReservations_Click(object sender, EventArgs e) {
            IEnumerable<ReservationDTO> foundReservations = await _reservationController.GetAllReservations();
            List<ReservationDTO> reservationsAsList = foundReservations.ToList();
            listBoxAllReservations.DataSource = reservationsAsList;
        }

        private void listBoxAllReservations_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
