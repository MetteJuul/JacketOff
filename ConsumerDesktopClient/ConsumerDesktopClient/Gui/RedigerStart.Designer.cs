namespace ConsumerDesktopClient.Gui {
    partial class RedigerStart {
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
            this.buttonRediger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRediger
            // 
            this.buttonRediger.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRediger.Location = new System.Drawing.Point(90, 60);
            this.buttonRediger.Name = "buttonRediger";
            this.buttonRediger.Size = new System.Drawing.Size(198, 42);
            this.buttonRediger.TabIndex = 2;
            this.buttonRediger.Text = "Rediger";
            this.buttonRediger.UseVisualStyleBackColor = true;
            // 
            // RedigerStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRediger);
            this.Name = "RedigerStart";
            this.Size = new System.Drawing.Size(389, 563);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRediger;
    }
}
