using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Model.Model;

namespace proyectoGym
{
    public partial class FormMembresias : Form
    {
        private List<Cliente> listaClientes; // Lista de clientes

        public FormMembresias()
        {
            InitializeComponent();
            listaClientes = new List<Cliente>(); // Inicializa la lista
            InicializarClientes(); // Cargar datos iniciales
            CargarMembresias(); // Actualizar DataGridView
        }

        private void InicializarClientes()
        {
            listaClientes.Add(new Cliente
            {
                Id = 1,
                Nombre = "Juan",
                Membresia = "Activa"
            });

            listaClientes.Add(new Cliente
            {
                Id = 2,
                Nombre = "Ana",
                Membresia = "Expirada"
            });
        }

        private void btnRenovarMembresia_Click(object sender, EventArgs e)
        {
            if (dgvMembresias.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvMembresias.SelectedRows[0].DataBoundItem;

                // Actualizar el estado de la membresía
                clienteSeleccionado.Membresia = "Activa"; // Renovar membresía

                MessageBox.Show("Membresía renovada correctamente.");
                CargarMembresias(); // Recargar los datos del DataGridView
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para renovar su membresía.");
            }
        }

        private void CargarMembresias()
        {
            dgvMembresias.DataSource = null;  // Limpiar DataGridView
            dgvMembresias.DataSource = listaClientes;  // Volver a asignar la lista actualizada
        }

      
    }
}
