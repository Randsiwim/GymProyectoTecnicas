using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoGym
{
    public partial class FormClases : Form
    {
        public FormClases()
        {
            InitializeComponent();
        }

        private void btnReservarClase_Click(object sender, EventArgs e)
        {
            if (dgvClases.SelectedRows.Count > 0)
            {
                var claseSeleccionada = (Clase)dgvClases.SelectedRows[0].DataBoundItem;
                // Lógica para reservar la clase
                MessageBox.Show("Clase reservada correctamente.");
                CargarClases();
            }
            else
            {
                MessageBox.Show("Seleccione una clase para reservar.");
            }
        }

        private void CargarClases()
{
    dgvClases.DataSource = null;
    dgvClases.DataSource = listaClases; 
}


       
    }
}
