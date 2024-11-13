namespace proyectoGym
{
    partial class FormClases
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
            this.btnReservarClase = new System.Windows.Forms.Button();
            this.dgvClases = new System.Windows.Forms.DataGridView();
            this.btnVerReservas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReservarClase
            // 
            this.btnReservarClase.Location = new System.Drawing.Point(361, 108);
            this.btnReservarClase.Name = "btnReservarClase";
            this.btnReservarClase.Size = new System.Drawing.Size(75, 23);
            this.btnReservarClase.TabIndex = 2;
            this.btnReservarClase.Text = "Reservar";
            this.btnReservarClase.UseVisualStyleBackColor = true;
            this.btnReservarClase.Click += new System.EventHandler(this.btnReservarClase_Click);
            // 
            // dgvClases
            // 
            this.dgvClases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClases.Location = new System.Drawing.Point(53, 51);
            this.dgvClases.Name = "dgvClases";
            this.dgvClases.Size = new System.Drawing.Size(240, 328);
            this.dgvClases.TabIndex = 3;
            // 
            // btnVerReservas
            // 
            this.btnVerReservas.Location = new System.Drawing.Point(361, 176);
            this.btnVerReservas.Name = "btnVerReservas";
            this.btnVerReservas.Size = new System.Drawing.Size(75, 23);
            this.btnVerReservas.TabIndex = 4;
            this.btnVerReservas.Text = "Ver Reservas";
            this.btnVerReservas.UseVisualStyleBackColor = true;
            // 
            // FormClases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerReservas);
            this.Controls.Add(this.dgvClases);
            this.Controls.Add(this.btnReservarClase);
            this.Name = "FormClases";
            this.Text = "FormClases";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReservarClase;
        private System.Windows.Forms.DataGridView dgvClases;
        private System.Windows.Forms.Button btnVerReservas;
    }
}