namespace ConsumerDesktopClient.Gui {
    partial class Start {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonRediger = new System.Windows.Forms.Button();
            this.modtagKvittering1 = new ConsumerDesktopClient.Gui.ModtagKvittering();
            this.modtagAngivAntal1 = new ConsumerDesktopClient.Gui.UdleverCheckUd();
            this.panelUdlever = new System.Windows.Forms.Panel();
            this.panelRediger = new System.Windows.Forms.Panel();
            this.labelModtagOverskrift = new System.Windows.Forms.Label();
            this.labelUdleverOverskrift = new System.Windows.Forms.Label();
            this.labelRedigerOverskrift = new System.Windows.Forms.Label();
            this.modtagStart1 = new ConsumerDesktopClient.Gui.ModtagStart();
            this.panelModtag = new System.Windows.Forms.Panel();
            this.panelRediger.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRediger
            // 
            this.buttonRediger.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRediger.Location = new System.Drawing.Point(104, 57);
            this.buttonRediger.Name = "buttonRediger";
            this.buttonRediger.Size = new System.Drawing.Size(198, 42);
            this.buttonRediger.TabIndex = 0;
            this.buttonRediger.Text = "Rediger";
            this.buttonRediger.UseVisualStyleBackColor = true;
            this.buttonRediger.Click += new System.EventHandler(this.buttonRediger_Click);
            // 
            // modtagKvittering1
            // 
            this.modtagKvittering1.BackColor = System.Drawing.Color.IndianRed;
            this.modtagKvittering1.Location = new System.Drawing.Point(10, 98);
            this.modtagKvittering1.Name = "modtagKvittering1";
            this.modtagKvittering1.Size = new System.Drawing.Size(389, 563);
            this.modtagKvittering1.TabIndex = 10;
            // 
            // modtagAngivAntal1
            // 
            this.modtagAngivAntal1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.modtagAngivAntal1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.modtagAngivAntal1.Cursor = System.Windows.Forms.Cursors.Default;
            this.modtagAngivAntal1.Location = new System.Drawing.Point(10, 98);
            this.modtagAngivAntal1.Name = "modtagAngivAntal1";
            this.modtagAngivAntal1.Size = new System.Drawing.Size(389, 564);
            this.modtagAngivAntal1.TabIndex = 9;
            // 
            // panelUdlever
            // 
            this.panelUdlever.Location = new System.Drawing.Point(420, 98);
            this.panelUdlever.Name = "panelUdlever";
            this.panelUdlever.Size = new System.Drawing.Size(388, 563);
            this.panelUdlever.TabIndex = 0;
            // 
            // panelRediger
            // 
            this.panelRediger.Controls.Add(this.buttonRediger);
            this.panelRediger.Location = new System.Drawing.Point(828, 98);
            this.panelRediger.Name = "panelRediger";
            this.panelRediger.Size = new System.Drawing.Size(389, 563);
            this.panelRediger.TabIndex = 0;
            // 
            // labelModtagOverskrift
            // 
            this.labelModtagOverskrift.AutoSize = true;
            this.labelModtagOverskrift.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelModtagOverskrift.Location = new System.Drawing.Point(144, 32);
            this.labelModtagOverskrift.Name = "labelModtagOverskrift";
            this.labelModtagOverskrift.Size = new System.Drawing.Size(114, 37);
            this.labelModtagOverskrift.TabIndex = 9;
            this.labelModtagOverskrift.Text = "Modtag";
            this.labelModtagOverskrift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUdleverOverskrift
            // 
            this.labelUdleverOverskrift.AutoSize = true;
            this.labelUdleverOverskrift.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelUdleverOverskrift.Location = new System.Drawing.Point(556, 32);
            this.labelUdleverOverskrift.Name = "labelUdleverOverskrift";
            this.labelUdleverOverskrift.Size = new System.Drawing.Size(111, 37);
            this.labelUdleverOverskrift.TabIndex = 10;
            this.labelUdleverOverskrift.Text = "Udlever";
            this.labelUdleverOverskrift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRedigerOverskrift
            // 
            this.labelRedigerOverskrift.AutoSize = true;
            this.labelRedigerOverskrift.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRedigerOverskrift.Location = new System.Drawing.Point(972, 32);
            this.labelRedigerOverskrift.Name = "labelRedigerOverskrift";
            this.labelRedigerOverskrift.Size = new System.Drawing.Size(110, 37);
            this.labelRedigerOverskrift.TabIndex = 11;
            this.labelRedigerOverskrift.Text = "Rediger";
            this.labelRedigerOverskrift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // modtagStart1
            // 
            this.modtagStart1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.modtagStart1.Location = new System.Drawing.Point(10, 98);
            this.modtagStart1.Name = "modtagStart1";
            this.modtagStart1.Size = new System.Drawing.Size(389, 563);
            this.modtagStart1.TabIndex = 1;
            // 
            // panelModtag
            // 
            this.panelModtag.Location = new System.Drawing.Point(10, 98);
            this.panelModtag.Name = "panelModtag";
            this.panelModtag.Size = new System.Drawing.Size(389, 564);
            this.panelModtag.TabIndex = 12;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 673);
            this.Controls.Add(this.panelModtag);
            this.Controls.Add(this.labelRedigerOverskrift);
            this.Controls.Add(this.labelUdleverOverskrift);
            this.Controls.Add(this.labelModtagOverskrift);
            this.Controls.Add(this.panelRediger);
            this.Controls.Add(this.panelUdlever);
            this.Controls.Add(this.modtagStart1);
            this.Controls.Add(this.modtagAngivAntal1);
            this.Controls.Add(this.modtagKvittering1);
            this.Name = "Start";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            this.Load += new System.EventHandler(this.Start_Load);
            this.panelRediger.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRediger;
        private System.Windows.Forms.Panel panelUdlever;
        private System.Windows.Forms.Panel panelRediger;
        private System.Windows.Forms.Label labelModtagOverskrift;
        private System.Windows.Forms.Label labelUdleverOverskrift;
        private System.Windows.Forms.Label labelRedigerOverskrift;
        private ModtagKvittering modtagKvittering1;
        private UdleverCheckUd modtagAngivAntal1;
        private ModtagStart modtagStart1;
        private System.Windows.Forms.Panel panelModtag;
    }
}