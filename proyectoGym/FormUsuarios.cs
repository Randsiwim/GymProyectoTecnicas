using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Model.Model;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;

namespace proyectoGym
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
            ClienteManager.CargarClientes(); // Carga usuarios guardados desde el archivo JSON
            CargarUsuarios();                // Actualiza el DataGridView
            ConfigurarFormulario();          // Estilos y configuración
        }

        private const string archivoUsuarios = "usuarios.json";
        private System.Windows.Forms.TextBox txtId;

        // Método para guardar usuarios en un archivo JSON
        private void GuardarUsuariosEnArchivo()
        {
            try
            {
                string json = JsonConvert.SerializeObject(ClienteManager.ListaClientes, Formatting.Indented);
                File.WriteAllText(archivoUsuarios, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los usuarios: {ex.Message}");
            }
        }

        // Método para agregar un nuevo usuario
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (txtId == null || txtNombre == null)
            {
                MessageBox.Show("ID or Name text box is not initialized.");
                return;
            }

            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("ID or Name cannot be empty.");
                return;
            }

            var nuevoCliente = new Cliente
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Membresia = "Expirada"
            };

            if (ClienteManager.ListaClientes == null)
            {
                ClienteManager.ListaClientes = new List<Cliente>();
            }

            ClienteManager.ListaClientes.Add(nuevoCliente);
            GuardarUsuariosEnArchivo(); // Guarda los datos en JSON
            MessageBox.Show("Usuario agregado correctamente.");
            CargarUsuarios(); // Actualiza el DataGridView
        }

        // Método para eliminar un usuario
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvUsuarios.SelectedRows[0].DataBoundItem;
                ClienteManager.ListaClientes.Remove(clienteSeleccionado); // Elimina el cliente
                GuardarUsuariosEnArchivo(); // Guarda los datos actualizados
                MessageBox.Show("Usuario eliminado correctamente.");
                CargarUsuarios(); // Actualiza el DataGridView
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
            }
        }

        // Método para editar un usuario
        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvUsuarios.SelectedRows[0].DataBoundItem;

                // Carga los datos del cliente en los campos de texto
                txtNombre.Text = clienteSeleccionado.Nombre;
                txtCorreo.Text = clienteSeleccionado.Correo;
                txtTelefono.Text = clienteSeleccionado.Telefono;

                // Elimina el cliente de la lista y lo vuelve a agregar con los nuevos datos
                ClienteManager.ListaClientes.Remove(clienteSeleccionado);
                GuardarUsuariosEnArchivo(); // Guarda los datos actualizados
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para editar.");
            }
        }

        // Método para cargar los usuarios en el DataGridView
        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null; // Limpia el DataGridView
            dgvUsuarios.DataSource = ClienteManager.ListaClientes; // Asigna la lista al DataGridView
        }

        // Método para limpiar los campos de texto
        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        // Método para aplicar los estilos básicos y configuraciones del formulario
        private void ConfigurarFormulario()
        {
            // Estilo del formulario
            this.Text = "Gestión de Usuarios - Gimnasio";
            this.BackColor = Color.LightGray;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Estilo del DataGridView
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.ForeColor = Color.Black;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;

            // Estilo de los TextBoxes
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Arial", 10);
            txtNombre.BackColor = Color.WhiteSmoke;
            txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            txtCorreo.Font = new Font("Arial", 10);
            txtCorreo.BackColor = Color.WhiteSmoke;
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Arial", 10);
            txtTelefono.BackColor = Color.WhiteSmoke;

            // Estilo de los Botones
            btnAgregarUsuario.FlatStyle = FlatStyle.Flat;
            btnAgregarUsuario.BackColor = Color.SteelBlue;
            btnAgregarUsuario.ForeColor = Color.White;
            btnAgregarUsuario.FlatAppearance.BorderSize = 0;
            btnAgregarUsuario.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            btnEliminarUsuario.FlatStyle = FlatStyle.Flat;
            btnEliminarUsuario.BackColor = Color.Red;
            btnEliminarUsuario.ForeColor = Color.White;
            btnEliminarUsuario.FlatAppearance.BorderSize = 0;
            btnEliminarUsuario.FlatAppearance.MouseOverBackColor = Color.DarkRed;

            btnEditarUsuario.FlatStyle = FlatStyle.Flat;
            btnEditarUsuario.BackColor = Color.Orange;
            btnEditarUsuario.ForeColor = Color.White;
            btnEditarUsuario.FlatAppearance.BorderSize = 0;
            btnEditarUsuario.FlatAppearance.MouseOverBackColor = Color.DarkOrange;
        }
    }
}


