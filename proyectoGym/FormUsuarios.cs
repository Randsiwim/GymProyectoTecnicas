using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Model.Model;

namespace proyectoGym
{
    public partial class FormUsuarios : Form
    {
        private List<Cliente> listaUsuarios; // Lista de usuarios

        public FormUsuarios()
        {
            InitializeComponent();
            listaUsuarios = new List<Cliente>(); // Inicializa la lista
            InicializarUsuarios(); // Agrega datos de prueba
            CargarUsuarios(); // Actualiza el DataGridView
        }

        private void InicializarUsuarios()
        {
            // Agregar datos de ejemplo
            listaUsuarios.Add(new Cliente { Id = 1, Nombre = "Juan Pérez", Correo = "juan@gmail.com", Telefono = "45435" });
            listaUsuarios.Add(new Cliente { Id = 2, Nombre = "Ana López", Correo = "ana@gmail.com", Telefono = "1243214" });
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            // Solicitar datos directamente en el formulario
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string telefono = txtTelefono.Text.Trim(); // Si tienes un campo de teléfono

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(telefono))
            {
                listaUsuarios.Add(new Cliente { Id = listaUsuarios.Count + 1, Nombre = nombre, Correo = correo, Telefono = telefono });
                MessageBox.Show("Usuario agregado correctamente.");
                CargarUsuarios();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvUsuarios.SelectedRows[0].DataBoundItem;

                // Editar datos directamente en el formulario
                txtNombre.Text = clienteSeleccionado.Nombre;
                txtCorreo.Text = clienteSeleccionado.Correo;
                txtTelefono.Text = clienteSeleccionado.Telefono;

                // Eliminar el cliente de la lista para reemplazarlo después de la edición
                listaUsuarios.Remove(clienteSeleccionado);

         
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para editar.");
            }
        }

        

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvUsuarios.SelectedRows[0].DataBoundItem;
                listaUsuarios.Remove(clienteSeleccionado);
                MessageBox.Show("Usuario eliminado correctamente.");
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
            }
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = listaUsuarios; // Asigna la lista al DataGridView
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }
    }
}


