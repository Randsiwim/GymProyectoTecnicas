namespace proyectoGym
{
    partial class FormInventario
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
            this.btnAgregarEquipo = new System.Windows.Forms.Button();
            this.btnEliminarEquipo = new System.Windows.Forms.Button();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.btnEditarEquipo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarEquipo
            // 
            this.btnAgregarEquipo.Location = new System.Drawing.Point(461, 72);
            this.btnAgregarEquipo.Name = "btnAgregarEquipo";
            this.btnAgregarEquipo.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarEquipo.TabIndex = 0;
            this.btnAgregarEquipo.Text = "Agregar";
            this.btnAgregarEquipo.UseVisualStyleBackColor = true;
            // 
            // btnEliminarEquipo
            // 
            this.btnEliminarEquipo.Location = new System.Drawing.Point(461, 162);
            this.btnEliminarEquipo.Name = "btnEliminarEquipo";
            this.btnEliminarEquipo.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarEquipo.TabIndex = 1;
            this.btnEliminarEquipo.Text = "Eliminar";
            this.btnEliminarEquipo.UseVisualStyleBackColor = true;
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(50, 127);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(240, 150);
            this.dgvInventario.TabIndex = 2;
            // 
            // btnEditarEquipo
            // 
            this.btnEditarEquipo.Location = new System.Drawing.Point(461, 113);
            this.btnEditarEquipo.Name = "btnEditarEquipo";
            this.btnEditarEquipo.Size = new System.Drawing.Size(75, 23);
            this.btnEditarEquipo.TabIndex = 3;
            this.btnEditarEquipo.Text = "Editar";
            this.btnEditarEquipo.UseVisualStyleBackColor = true;
            // 
            // FormInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditarEquipo);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.btnEliminarEquipo);
            this.Controls.Add(this.btnAgregarEquipo);
            this.Name = "FormInventario";
            this.Text = "FormInventario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarEquipo;
        private System.Windows.Forms.Button btnEliminarEquipo;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Button btnEditarEquipo;
    }
}