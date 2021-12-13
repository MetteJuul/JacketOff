namespace ConsumerDesktopClient.Gui {
    partial class ModtagVaelgGaest {
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
            this.buttonNaeste = new System.Windows.Forms.Button();
            this.buttonAfbryd = new System.Windows.Forms.Button();
            this.listBoxGuests = new System.Windows.Forms.ListBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelGuests = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonNaeste
            // 
            this.buttonNaeste.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonNaeste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonNaeste.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonNaeste.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNaeste.Location = new System.Drawing.Point(194, 490);
            this.buttonNaeste.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNaeste.Name = "buttonNaeste";
            this.buttonNaeste.Size = new System.Drawing.Size(92, 38);
            this.buttonNaeste.TabIndex = 29;
            this.buttonNaeste.Text = "Næste";
            this.buttonNaeste.UseVisualStyleBackColor = false;
            this.buttonNaeste.Click += new System.EventHandler(this.buttonNaeste_Click);
            // 
            // buttonAfbryd
            // 
            this.buttonAfbryd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAfbryd.Location = new System.Drawing.Point(88, 490);
            this.buttonAfbryd.Name = "buttonAfbryd";
            this.buttonAfbryd.Size = new System.Drawing.Size(92, 38);
            this.buttonAfbryd.TabIndex = 28;
            this.buttonAfbryd.Text = "Afbryd";
            this.buttonAfbryd.UseVisualStyleBackColor = true;
            this.buttonAfbryd.Click += new System.EventHandler(this.buttonAfbryd_Click);
            // 
            // listBoxGuests
            // 
            this.listBoxGuests.FormattingEnabled = true;
            this.listBoxGuests.ItemHeight = 15;
            this.listBoxGuests.Location = new System.Drawing.Point(56, 182);
            this.listBoxGuests.Name = "listBoxGuests";
            this.listBoxGuests.Size = new System.Drawing.Size(263, 289);
            this.listBoxGuests.TabIndex = 30;
            this.listBoxGuests.SelectedIndexChanged += new System.EventHandler(this.listBoxGuests_SelectedIndexChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.Location = new System.Drawing.Point(56, 135);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(263, 29);
            this.textBoxSearch.TabIndex = 31;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // labelGuests
            // 
            this.labelGuests.AutoSize = true;
            this.labelGuests.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGuests.Location = new System.Drawing.Point(137, 59);
            this.labelGuests.Name = "labelGuests";
            this.labelGuests.Size = new System.Drawing.Size(96, 25);
            this.labelGuests.TabIndex = 33;
            this.labelGuests.Text = "Find Gæst";
            // 
            // ModtagVaelgGaest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelGuests);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.listBoxGuests);
            this.Controls.Add(this.buttonNaeste);
            this.Controls.Add(this.buttonAfbryd);
            this.Name = "ModtagVaelgGaest";
            this.Size = new System.Drawing.Size(389, 564);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNaeste;
        private System.Windows.Forms.Button buttonAfbryd;
        private System.Windows.Forms.ListBox listBoxGuests;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelGuests;
    }
}
