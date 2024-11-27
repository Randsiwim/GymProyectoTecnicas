namespace proyectoGym
{
    partial class FormMembresias
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
            this.btnRenovarMembresia = new System.Windows.Forms.Button();
            this.dgvMembresias = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRenovarMembresia
            // 
            this.btnRenovarMembresia.Location = new System.Drawing.Point(633, 99);
            this.btnRenovarMembresia.Name = "btnRenovarMembresia";
            this.btnRenovarMembresia.Size = new System.Drawing.Size(126, 23);
            this.btnRenovarMembresia.TabIndex = 0;
            this.btnRenovarMembresia.Text = "Renovar";
            this.btnRenovarMembresia.UseVisualStyleBackColor = true;
            this.btnRenovarMembresia.Click += new System.EventHandler(this.btnRenovarMembresia_Click);
            // 
            // dgvMembresias
            // 
            this.dgvMembresias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembresias.Location = new System.Drawing.Point(24, 69);
            this.dgvMembresias.Name = "dgvMembresias";
            this.dgvMembresias.Size = new System.Drawing.Size(569, 356);
            this.dgvMembresias.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(666, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Membresias";
            // 
            // FormMembresias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMembresias);
            this.Controls.Add(this.btnRenovarMembresia);
            this.Name = "FormMembresias";
            this.Text = "FormMembresias";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRenovarMembresia;
        private System.Windows.Forms.DataGridView dgvMembresias;
        private System.Windows.Forms.Label label1;
    }
}