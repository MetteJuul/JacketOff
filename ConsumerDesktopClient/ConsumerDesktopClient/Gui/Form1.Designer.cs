
namespace ConsumerDesktopClient {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBoxAllReservations = new System.Windows.Forms.ListBox();
            this.buttonGetAllReservations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxAllReservations
            // 
            this.listBoxAllReservations.FormattingEnabled = true;
            this.listBoxAllReservations.ItemHeight = 20;
            this.listBoxAllReservations.Location = new System.Drawing.Point(70, 134);
            this.listBoxAllReservations.Name = "listBoxAllReservations";
            this.listBoxAllReservations.Size = new System.Drawing.Size(333, 264);
            this.listBoxAllReservations.TabIndex = 0;
            this.listBoxAllReservations.SelectedIndexChanged += new System.EventHandler(this.listBoxAllReservations_SelectedIndexChanged);
            // 
            // buttonGetAllReservations
            // 
            this.buttonGetAllReservations.Location = new System.Drawing.Point(70, 74);
            this.buttonGetAllReservations.Name = "buttonGetAllReservations";
            this.buttonGetAllReservations.Size = new System.Drawing.Size(155, 29);
            this.buttonGetAllReservations.TabIndex = 1;
            this.buttonGetAllReservations.Text = "Get All Reservations";
            this.buttonGetAllReservations.UseVisualStyleBackColor = true;
            this.buttonGetAllReservations.Click += new System.EventHandler(this.buttonGetAllReservations_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonGetAllReservations);
            this.Controls.Add(this.listBoxAllReservations);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAllReservations;
        private System.Windows.Forms.Button buttonGetAllReservations;
    }
}

