using System;
using System.Windows.Forms;
using Model;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace proyectoGym
{
    public partial class FormMembresias : Form
    {
        public FormMembresias()
        {
            InitializeComponent();

            // Cargar clientes al iniciar
            ClienteManager.CargarClientes();

            // Si no hay datos en el archivo, inicializa con datos de ejemplo
            if (ClienteManager.ListaClientes.Count == 0)
            {
                InicializarClientes();
                ClienteManager.GuardarClientes(); // Guarda los datos iniciales
            }

            // Muestra los datos en el DataGridView
            CargarMembresias();

            // Configuración adicional del formulario
            ConfigurarFormulario();
        }

        // Inicializa clientes de ejemplo
        private void InicializarClientes()
        {
            ClienteManager.ListaClientes.Add(new Cliente { Id = 1, Nombre = "Juan", Membresia = "Activa" });
            ClienteManager.ListaClientes.Add(new Cliente { Id = 2, Nombre = "Ana", Membresia = "Expirada" });
        }

        // Evento al hacer clic en "Renovar Membresía"
        private void btnRenovarMembresia_Click(object sender, EventArgs e)
        {
            if (dgvMembresias.SelectedRows.Count > 0)
            {
                // Obtiene el cliente seleccionado
                var clienteSeleccionado = (Cliente)dgvMembresias.SelectedRows[0].DataBoundItem;

                // Actualiza el estado de la membresía
                clienteSeleccionado.Membresia = "Activa";

                // Guarda los cambios y actualiza el DataGridView
                ClienteManager.GuardarClientes();
                CargarMembresias();

                MessageBox.Show("Membresía renovada correctamente.");
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para renovar su membresía.");
            }
        }

        // Carga los clientes en el DataGridView
        private void CargarMembresias()
        {
            dgvMembresias.DataSource = null;
            dgvMembresias.DataSource = ClienteManager.ListaClientes;
        }

        // Método para configurar el formulario con estilos y la imagen de fondo
        private void ConfigurarFormulario()
        {
            // Estilo del formulario
            this.Text = "Gestión de Membresías - Gimnasio";
            this.BackColor = Color.LightGray;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Estilo de los controles
            dgvMembresias.Font = new Font("Arial", 10);
            dgvMembresias.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvMembresias.DefaultCellStyle.ForeColor = Color.DarkSlateGray;
            dgvMembresias.RowHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;

            // Estilo del botón
            btnRenovarMembresia.FlatStyle = FlatStyle.Flat;
            btnRenovarMembresia.BackColor = Color.SteelBlue;
            btnRenovarMembresia.ForeColor = Color.White;
            btnRenovarMembresia.FlatAppearance.BorderSize = 0;
            btnRenovarMembresia.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            // Imagen de fondo
            PictureBox fondo = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = Image.FromFile("C:\\Users\\Rand\\Source\\Repos\\GymProyectoTecnicas\\proyectoGym\\imagesGym5.jpg"), 
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(fondo);
            fondo.SendToBack(); 
        }
    }

    // Clase estática para gestionar los clientes
    public static class ClienteManager
    {
        public static List<Cliente> ListaClientes { get; set; } = new List<Cliente>();
        private const string archivoClientes = "clientes.json";

        public static void GuardarClientes()
        {
            try
            {
                string json = JsonConvert.SerializeObject(ListaClientes, Formatting.Indented);
                File.WriteAllText(archivoClientes, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los clientes: {ex.Message}");
            }
        }

        public static void CargarClientes()
        {
            try
            {
                if (File.Exists(archivoClientes))
                {
                    string json = File.ReadAllText(archivoClientes);
                    ListaClientes = JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}");
            }
        }
    }

    // Clase Cliente
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Membresia { get; set; }
    }
}




