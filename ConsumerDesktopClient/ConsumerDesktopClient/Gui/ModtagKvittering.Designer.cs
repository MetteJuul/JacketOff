namespace ConsumerDesktopClient.Gui {
    partial class ModtagKvittering {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTasker = new System.Windows.Forms.Label();
            this.labelJakker = new System.Windows.Forms.Label();
            this.buttonAfslut = new System.Windows.Forms.Button();
            this.orderControllerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jakkeNumreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jakkeNumreBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ticketNumberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jakkeNumreBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.taskeNummerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewJakkeNumre = new System.Windows.Forms.DataGridView();
            this.MinusColumnJakker = new System.Windows.Forms.DataGridViewButtonColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusColumnJakker = new System.Windows.Forms.DataGridViewButtonColumn();
            this.jakkeNummerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTaskeNumre = new System.Windows.Forms.DataGridView();
            this.MinusColumnTasker = new System.Windows.Forms.DataGridViewButtonColumn();
            this.numberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusColumnTasker = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.orderControllerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jakkeNumreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jakkeNumreBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketNumberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jakkeNumreBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskeNummerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJakkeNumre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jakkeNummerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskeNumre)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTasker
            // 
            this.labelTasker.AutoSize = true;
            this.labelTasker.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTasker.Location = new System.Drawing.Point(149, 276);
            this.labelTasker.Name = "labelTasker";
            this.labelTasker.Size = new System.Drawing.Size(64, 25);
            this.labelTasker.TabIndex = 25;
            this.labelTasker.Text = "Tasker";
            this.labelTasker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelJakker
            // 
            this.labelJakker.AutoSize = true;
            this.labelJakker.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelJakker.Location = new System.Drawing.Point(149, 60);
            this.labelJakker.Name = "labelJakker";
            this.labelJakker.Size = new System.Drawing.Size(64, 25);
            this.labelJakker.TabIndex = 21;
            this.labelJakker.Text = "Jakker";
            this.labelJakker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAfslut
            // 
            this.buttonAfslut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAfslut.Location = new System.Drawing.Point(189, 496);
            this.buttonAfslut.Name = "buttonAfslut";
            this.buttonAfslut.Size = new System.Drawing.Size(92, 38);
            this.buttonAfslut.TabIndex = 38;
            this.buttonAfslut.Text = "Afslut";
            this.buttonAfslut.UseVisualStyleBackColor = true;
            this.buttonAfslut.Click += new System.EventHandler(this.buttonAfslut_Click);
            // 
            // orderControllerBindingSource
            // 
            this.orderControllerBindingSource.DataSource = typeof(ConsumerDesktopClient.Control.OrderController);
            // 
            // jakkeNumreBindingSource
            // 
            this.jakkeNumreBindingSource.DataMember = "JakkeNumre";
            this.jakkeNumreBindingSource.DataSource = this.orderControllerBindingSource;
            // 
            // jakkeNumreBindingSource1
            // 
            this.jakkeNumreBindingSource1.DataMember = "JakkeNumre";
            this.jakkeNumreBindingSource1.DataSource = this.orderControllerBindingSource;
            // 
            // ticketNumberBindingSource
            // 
            this.ticketNumberBindingSource.DataSource = typeof(ConsumerDesktopClient.Gui.Model.JakkeNummer);
            // 
            // jakkeNumreBindingSource2
            // 
            this.jakkeNumreBindingSource2.DataMember = "JakkeNumre";
            this.jakkeNumreBindingSource2.DataSource = this.orderControllerBindingSource;
            // 
            // taskeNummerBindingSource
            // 
            this.taskeNummerBindingSource.DataSource = typeof(ConsumerDesktopClient.Gui.Model.TaskeNummer);
            // 
            // dataGridViewJakkeNumre
            // 
            this.dataGridViewJakkeNumre.AllowUserToAddRows = false;
            this.dataGridViewJakkeNumre.AutoGenerateColumns = false;
            this.dataGridViewJakkeNumre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJakkeNumre.ColumnHeadersVisible = false;
            this.dataGridViewJakkeNumre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MinusColumnJakker,
            this.numberDataGridViewTextBoxColumn,
            this.PlusColumnJakker});
            this.dataGridViewJakkeNumre.DataSource = this.jakkeNummerBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewJakkeNumre.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewJakkeNumre.Location = new System.Drawing.Point(83, 100);
            this.dataGridViewJakkeNumre.Name = "dataGridViewJakkeNumre";
            this.dataGridViewJakkeNumre.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewJakkeNumre.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewJakkeNumre.RowTemplate.Height = 38;
            this.dataGridViewJakkeNumre.Size = new System.Drawing.Size(198, 158);
            this.dataGridViewJakkeNumre.TabIndex = 40;
            this.dataGridViewJakkeNumre.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewJakkeNumre_CellContentClick);
            // 
            // MinusColumnJakker
            // 
            this.MinusColumnJakker.HeaderText = "Minus";
            this.MinusColumnJakker.Name = "MinusColumnJakker";
            this.MinusColumnJakker.Text = "-";
            this.MinusColumnJakker.UseColumnTextForButtonValue = true;
            this.MinusColumnJakker.Width = 38;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.Width = 116;
            // 
            // PlusColumnJakker
            // 
            this.PlusColumnJakker.HeaderText = "Plus";
            this.PlusColumnJakker.Name = "PlusColumnJakker";
            this.PlusColumnJakker.Text = "+";
            this.PlusColumnJakker.UseColumnTextForButtonValue = true;
            this.PlusColumnJakker.Width = 38;
            // 
            // jakkeNummerBindingSource
            // 
            this.jakkeNummerBindingSource.DataSource = typeof(ConsumerDesktopClient.Gui.Model.JakkeNummer);
            // 
            // dataGridViewTaskeNumre
            // 
            this.dataGridViewTaskeNumre.AllowUserToAddRows = false;
            this.dataGridViewTaskeNumre.AutoGenerateColumns = false;
            this.dataGridViewTaskeNumre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaskeNumre.ColumnHeadersVisible = false;
            this.dataGridViewTaskeNumre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MinusColumnTasker,
            this.numberDataGridViewTextBoxColumn1,
            this.PlusColumnTasker});
            this.dataGridViewTaskeNumre.DataSource = this.taskeNummerBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTaskeNumre.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTaskeNumre.Location = new System.Drawing.Point(83, 317);
            this.dataGridViewTaskeNumre.Name = "dataGridViewTaskeNumre";
            this.dataGridViewTaskeNumre.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTaskeNumre.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTaskeNumre.RowTemplate.Height = 38;
            this.dataGridViewTaskeNumre.Size = new System.Drawing.Size(198, 145);
            this.dataGridViewTaskeNumre.TabIndex = 41;
            this.dataGridViewTaskeNumre.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskeNumre_CellContentClick);
            // 
            // MinusColumnTasker
            // 
            this.MinusColumnTasker.HeaderText = "MinusColumn";
            this.MinusColumnTasker.Name = "MinusColumnTasker";
            this.MinusColumnTasker.Text = "-";
            this.MinusColumnTasker.UseColumnTextForButtonValue = true;
            this.MinusColumnTasker.Width = 38;
            // 
            // numberDataGridViewTextBoxColumn1
            // 
            this.numberDataGridViewTextBoxColumn1.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn1.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn1.Name = "numberDataGridViewTextBoxColumn1";
            this.numberDataGridViewTextBoxColumn1.Width = 116;
            // 
            // PlusColumnTasker
            // 
            this.PlusColumnTasker.HeaderText = "Plus";
            this.PlusColumnTasker.Name = "PlusColumnTasker";
            this.PlusColumnTasker.Text = "+";
            this.PlusColumnTasker.UseColumnTextForButtonValue = true;
            this.PlusColumnTasker.Width = 38;
            // 
            // ModtagKvittering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.dataGridViewTaskeNumre);
            this.Controls.Add(this.dataGridViewJakkeNumre);
            this.Controls.Add(this.buttonAfslut);
            this.Controls.Add(this.labelTasker);
            this.Controls.Add(this.labelJakker);
            this.Name = "ModtagKvittering";
            this.Size = new System.Drawing.Size(389, 563);
            ((System.ComponentModel.ISupportInitialize)(this.orderControllerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jakkeNumreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jakkeNumreBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketNumberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jakkeNumreBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskeNummerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJakkeNumre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jakkeNummerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskeNumre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTasker;
        private System.Windows.Forms.Label labelJakker;
        private System.Windows.Forms.Button buttonAfslut;
        private System.Windows.Forms.BindingSource orderControllerBindingSource;
        private System.Windows.Forms.BindingSource jakkeNumreBindingSource;
        private System.Windows.Forms.BindingSource jakkeNumreBindingSource1;
        private System.Windows.Forms.BindingSource ticketNumberBindingSource;
        private System.Windows.Forms.BindingSource jakkeNumreBindingSource2;
        private System.Windows.Forms.BindingSource taskeNummerBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewJakkeNumre;
        private System.Windows.Forms.BindingSource jakkeNummerBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewTaskeNumre;
        private System.Windows.Forms.DataGridViewButtonColumn MinusColumnJakker;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn PlusColumnJakker;
        private System.Windows.Forms.DataGridViewButtonColumn MinusColumnTasker;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn PlusColumnTasker;
    }
}
