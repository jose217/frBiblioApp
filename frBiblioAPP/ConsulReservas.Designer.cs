namespace frBiblioAPP
{
    partial class frConsulReservas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSalir = new System.Windows.Forms.Button();
            this.ReservacionesConsult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ReservacionesConsult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSalir.Location = new System.Drawing.Point(864, 462);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ReservacionesConsult
            // 
            this.ReservacionesConsult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReservacionesConsult.Location = new System.Drawing.Point(113, 91);
            this.ReservacionesConsult.Name = "ReservacionesConsult";
            this.ReservacionesConsult.RowHeadersWidth = 51;
            this.ReservacionesConsult.RowTemplate.Height = 24;
            this.ReservacionesConsult.Size = new System.Drawing.Size(809, 341);
            this.ReservacionesConsult.TabIndex = 1;
            // 
            // frConsulReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::frBiblioAPP.Properties.Resources._448510;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ReservacionesConsult);
            this.Controls.Add(this.btnSalir);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frConsulReservas";
            this.Text = "Consulta Tus Reservaciones";
            ((System.ComponentModel.ISupportInitialize)(this.ReservacionesConsult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView ReservacionesConsult;
    }
}