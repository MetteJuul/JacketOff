namespace ConsumerDesktopClient.Gui {
    partial class UdleverStart {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonUdlever = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonUdlever
            // 
            this.buttonUdlever.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUdlever.Location = new System.Drawing.Point(90, 60);
            this.buttonUdlever.Name = "buttonUdlever";
            this.buttonUdlever.Size = new System.Drawing.Size(198, 42);
            this.buttonUdlever.TabIndex = 1;
            this.buttonUdlever.Text = "Udlever";
            this.buttonUdlever.UseVisualStyleBackColor = true;
            this.buttonUdlever.Click += new System.EventHandler(this.buttonUdlever_Click);
            // 
            // UdleverStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonUdlever);
            this.Name = "UdleverStart";
            this.Size = new System.Drawing.Size(389, 563);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUdlever;
    }
}
