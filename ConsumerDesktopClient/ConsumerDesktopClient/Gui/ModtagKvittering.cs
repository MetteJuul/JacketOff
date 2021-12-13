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
    public partial class ModtagKvittering : UserControl {

        private OrderController orderController;
        private int jakkeNummer;
        private int taskeNummer;

        public ModtagKvittering() {
            InitializeComponent();
            orderController = OrderController.GetInstance();

            if (orderController.JakkeNumre.Count > 0) {
                jakkeNummer = orderController.JakkeNumre.First();
            }
            if (orderController.TaskeNumre.Count > 0) {
                taskeNummer = orderController.TaskeNumre.First();
            }

            textBoxJakkeNumre1.Text = jakkeNummer.ToString();
            textBoxTaskeNumre1.Text = taskeNummer.ToString();


        }

        private async void buttonAfslut_Click(object sender, EventArgs e) {
            
            //We call our async create order method, which
            // has been moved to a seperate method, to better
            //collaborate with winforms
            await buttonAfslutClickHandlerAsync();

            //We bring the start user panel back to the front
            Start.GetInstance().PnlModtag.Controls["ModtagStart"].BringToFront();
        }

        private async Task buttonAfslutClickHandlerAsync() {
            await orderController.CreateOrder();
        }

        private void buttonMinusJakker1_Click_1(object sender, EventArgs e) {
            Subtract1FromNumber(textBoxJakkeNumre1, "jakke");
        }

        private void buttonPlusJakker1_Click(object sender, EventArgs e) {
            Add1ToNumber(textBoxJakkeNumre1, "jakke");
        }

        private void buttonMinusJakker2_Click(object sender, EventArgs e) {
            Subtract1FromNumber(textBoxJakkeNumre2, "jakke");
        }

        private void buttonPlusJakker2_Click(object sender, EventArgs e) {
            Add1ToNumber(textBoxJakkeNumre2, "jakke");
        }

        private void buttonMinusJakker3_Click(object sender, EventArgs e) {
            Subtract1FromNumber(textBoxJakkeNumre3, "jakke");
        }

        private void buttonPlusJakker3_Click(object sender, EventArgs e) {
            Add1ToNumber(textBoxJakkeNumre3, "jakke");
        }

        private void buttonMinusTasker1_Click(object sender, EventArgs e) {
            Subtract1FromNumber(textBoxTaskeNumre1, "taske");
        }

        private void buttonPlusTasker1_Click(object sender, EventArgs e) {
            Add1ToNumber(textBoxTaskeNumre1, "taske");
        }

        private void buttonMinusTasker2_Click(object sender, EventArgs e) {
            Subtract1FromNumber(textBoxTaskeNumre2, "taske");
        }

        private void buttonPlusTasker2_Click(object sender, EventArgs e) {
            Add1ToNumber(textBoxTaskeNumre2, "taske");
        }

        private void buttonMinusTasker3_Click(object sender, EventArgs e) {
            Subtract1FromNumber(textBoxTaskeNumre3, "taske");
        }

        private void buttonPlusTasker3_Click(object sender, EventArgs e) {
            Add1ToNumber(textBoxTaskeNumre3, "taske");
        }

        private void Subtract1FromNumber(TextBox textBox, string type) {

            if (type.Equals("jakke")) {
                var jakkeNummer = Convert.ToInt32(textBox.Text);
                if (jakkeNummer > 0) {
                    textBox.Text = (jakkeNummer - 1).ToString();
                } else if (jakkeNummer == 0) {
                    textBox.Text = "999";
                }
            } else if (type.Equals("taske")) {
                var taskeNummer = Convert.ToInt32(textBox.Text);
                if (taskeNummer > 0) {
                    textBox.Text = (taskeNummer - 1).ToString();
                } else if (taskeNummer == 0) {
                    textBox.Text = "999";
                }
            }
        }
        private void Add1ToNumber(TextBox textBox, string type) {

            if (type.Equals("jakke")) {
                var jakkeNummer = Convert.ToInt32(textBox.Text);
                if (jakkeNummer < 999) {
                    textBox.Text = (jakkeNummer - 1).ToString();
                } else if (jakkeNummer == 999) {
                    textBox.Text = "1";
                }
            } else if (type.Equals("taske")) {
                var taskeNummer = Convert.ToInt32(textBox.Text);
                if (taskeNummer < 999) {
                    textBox.Text = (taskeNummer - 1).ToString();
                } else if (taskeNummer == 999) {
                    textBox.Text = "1";
                }
            }
        }
    }
}
