using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Model.Model;

namespace proyectoGym
{
    public partial class FormReservas : Form
    {
        private List<Reserva> listaReservas; // Lista de reservas

        public FormReservas()
        {
            InitializeComponent();
            listaReservas = new List<Reserva>(); // Inicializa la lista de reservas
            CargarReservas();
            CargarComboBoxes(); // Cargar las clases y clientes en los ComboBox
        }

        private void CargarReservas()
        {
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = listaReservas; // Muestra las reservas en el DataGridView
        }

        private void CargarComboBoxes()
        {
           
        }

        private List<Cliente> ObtenerClientes()
        {
            // Aquí deberías obtener la lista de clientes, por ahora la simulamos con una lista ficticia
            return new List<Cliente>
            {
                new Cliente { Id = 1, Nombre = "Cliente 1" },
                new Cliente { Id = 2, Nombre = "Cliente 2" }
            };
        }

       
        

        private void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            // Crear una nueva reserva con los datos ingresados
            Reserva nuevaReserva = new Reserva
            {
               
            };

            // Agregar la nueva reserva a la lista
            listaReservas.Add(nuevaReserva);
            CargarReservas(); // Actualizar el DataGridView
            MessageBox.Show("Reserva agregada correctamente.");
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                var reservaSeleccionada = (Reserva)dgvReservas.SelectedRows[0].DataBoundItem;
                // Lógica para cancelar la reserva
                listaReservas.Remove(reservaSeleccionada);
                MessageBox.Show("Reserva cancelada correctamente.");
                CargarReservas(); // Actualizar la lista
            }
            else
            {
                MessageBox.Show("Seleccione una reserva para cancelar.");
            }
        }
    }
}

