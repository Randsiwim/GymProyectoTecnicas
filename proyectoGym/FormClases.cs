using System;
using System.Collections.Generic;
using System.Drawing;
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

            // Configuración adicional del formulario
            ConfigurarFormulario();
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

        // Método para configurar el formulario con estilos y la imagen de fondo
        private void ConfigurarFormulario()
        {
            // Estilo del formulario
            this.Text = "Gestión de Clases - Gimnasio";
            this.BackColor = Color.LightGray;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Estilo de los controles
            dgvClases.Font = new Font("Arial", 10);
            dgvClases.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvClases.DefaultCellStyle.ForeColor = Color.DarkSlateGray;
            dgvClases.RowHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;

            // Estilo del botón
            btnReservarClase.FlatStyle = FlatStyle.Flat;
            btnReservarClase.BackColor = Color.SteelBlue;
            btnReservarClase.ForeColor = Color.White;
            btnReservarClase.FlatAppearance.BorderSize = 0;
            btnReservarClase.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            // Estilo del botón Ver Reservas
            btnVerReservas.FlatStyle = FlatStyle.Flat;
            btnVerReservas.BackColor = Color.SeaGreen;
            btnVerReservas.ForeColor = Color.White;
            btnVerReservas.FlatAppearance.BorderSize = 0;
            btnVerReservas.FlatAppearance.MouseOverBackColor = Color.DarkOliveGreen;

            // Imagen de fondo
            PictureBox fondo = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = Image.FromFile("C:\\Users\\Rand\\Source\\Repos\\GymProyectoTecnicas\\proyectoGym\\imagesGym5.jpg"), 
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(fondo);
            fondo.SendToBack(); // Asegura que la imagen quede de fondo
        }
    }

    // Clase Clase
    public class Clase
    {
        public string Nombre { get; set; }
        public DateTime Horario { get; set; }
        public string EntrenadorAsignado { get; set; }
    }
}

