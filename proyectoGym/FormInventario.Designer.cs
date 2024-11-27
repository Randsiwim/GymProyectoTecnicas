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
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtNombreEquipo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.btnAgregarEquipo.Click += new System.EventHandler(this.btnAñadirEquipo_Click);
            // 
            // btnEliminarEquipo
            // 
            this.btnEliminarEquipo.Location = new System.Drawing.Point(461, 162);
            this.btnEliminarEquipo.Name = "btnEliminarEquipo";
            this.btnEliminarEquipo.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarEquipo.TabIndex = 1;
            this.btnEliminarEquipo.Text = "Eliminar";
            this.btnEliminarEquipo.UseVisualStyleBackColor = true;
            this.btnEliminarEquipo.Click += new System.EventHandler(this.btnEliminarEquipo_Click);
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
            this.btnEditarEquipo.Click += new System.EventHandler(this.btnEditarEquipo_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(652, 308);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 4;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(520, 308);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(100, 20);
            this.txtEstado.TabIndex = 5;
            // 
            // txtNombreEquipo
            // 
            this.txtNombreEquipo.Location = new System.Drawing.Point(386, 308);
            this.txtNombreEquipo.Name = "txtNombreEquipo";
            this.txtNombreEquipo.Size = new System.Drawing.Size(100, 20);
            this.txtNombreEquipo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(693, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cantidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(554, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Equipo";
            // 
            // FormInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreEquipo);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnEditarEquipo);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.btnEliminarEquipo);
            this.Controls.Add(this.btnAgregarEquipo);
            this.Name = "FormInventario";
            this.Text = "FormInventario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarEquipo;
        private System.Windows.Forms.Button btnEliminarEquipo;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Button btnEditarEquipo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtNombreEquipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}