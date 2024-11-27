using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model; // Asegúrate de que 'Clase' esté en este namespace

namespace proyectoGym
{
    public partial class FormClase : Form
    {
        private List<Clase> listaClases; // Lista de clases

        public FormClase()
        {
            InitializeComponent();
            listaClases = new List<Clase>(); // Inicializa la lista
            InicializarClases(); // Cargar datos iniciales
            CargarClases(); // Actualiza el DataGridView
        }

        private void InicializarClases()
        {
            // Agregar clases de ejemplo a la lista
            listaClases.Add(new Clase
            {
                Nombre = "Yoga",
                Horario = DateTime.Parse("2024-11-11 09:00 AM"),
                EntrenadorAsignado = "Ana"
            });

            listaClases.Add(new Clase
            {
                Nombre = "Pilates",
                Horario = DateTime.Parse("2024-11-12 10:00 AM"),
                EntrenadorAsignado = "Carlos"
            });

            listaClases.Add(new Clase
            {
                Nombre = "Zumba",
                Horario = DateTime.Parse("2024-11-13 07:00 PM"),
                EntrenadorAsignado = "Luis"
            });
        }

        private void CargarClases()
        {
            dgvClases.DataSource = null; // Limpia el DataGridView
            dgvClases.DataSource = listaClases; // Vincula la lista al DataGridView
        }

        private void btnReservarClase_Click(object sender, EventArgs e)
        {
            if (dgvClases.SelectedRows.Count > 0)
            {
                var claseSeleccionada = (Clase)dgvClases.SelectedRows[0].DataBoundItem;
                MessageBox.Show($"Clase '{claseSeleccionada.Nombre}' reservada correctamente.");
            }
            else
            {
                MessageBox.Show("Seleccione una clase para reservar.");
            }
        }

        private void btnVerReservas_Click(object sender, EventArgs e)
        {
            
            FormReservas formReservas = new FormReservas();

            // Mostrar el formulario de reservas como una ventana modal
            formReservas.ShowDialog();
        }

    }
}
