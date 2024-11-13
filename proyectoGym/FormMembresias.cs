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
    public partial class FormMembresias : Form
    {
        public FormMembresias()
        {
            InitializeComponent();
        }

        private void btnRenovarMembresia_Click(object sender, EventArgs e)
        {
            if (dgvMembresias.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvMembresias.SelectedRows[0].DataBoundItem;
                
                MessageBox.Show("Membresía renovada correctamente.");
                CargarMembresias();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para renovar su membresía.");
            }
        }

        private void CargarMembresias()
        {
            dgvMembresias.DataSource = null;
            dgvMembresias.DataSource = listaClientes; 
        }

    }
}
