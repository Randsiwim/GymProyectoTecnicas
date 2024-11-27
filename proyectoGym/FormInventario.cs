using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace proyectoGym
{
    public partial class FormInventario : Form
    {
        private List<Equipo> listaEquipos; // Lista de equipos en el inventario

        public FormInventario()
        {
            InitializeComponent();
            listaEquipos = new List<Equipo>();
            ConfigurarImagenDeFondo(); // Agregar imagen de fondo
            CargarInventario();
        }

        private void btnAñadirEquipo_Click(object sender, EventArgs e)
        {
            // Validar los datos ingresados en los TextBox
            if (string.IsNullOrWhiteSpace(txtNombreEquipo.Text) ||
                string.IsNullOrWhiteSpace(txtEstado.Text) ||
                !int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("Por favor, complete todos los campos con información válida.");
                return;
            }

            // Crear un nuevo objeto Equipo y agregarlo a la lista
            listaEquipos.Add(new Equipo
            {
                Id = listaEquipos.Count + 1,
                Nombre = txtNombreEquipo.Text,
                Estado = txtEstado.Text,
                Cantidad = cantidad
            });

            // Limpiar los TextBox
            txtNombreEquipo.Clear();
            txtEstado.Clear();
            txtCantidad.Clear();

            // Actualizar el DataGridView
            CargarInventario();
            MessageBox.Show("Equipo añadido correctamente.");
        }

        private void btnEditarEquipo_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count > 0)
            {
                var equipoSeleccionado = (Equipo)dgvInventario.SelectedRows[0].DataBoundItem;

                // Validar los datos ingresados
                if (string.IsNullOrWhiteSpace(txtNombreEquipo.Text) ||
                    string.IsNullOrWhiteSpace(txtEstado.Text) ||
                    !int.TryParse(txtCantidad.Text, out int cantidad))
                {
                    MessageBox.Show("Por favor, complete todos los campos con información válida.");
                    return;
                }

                // Actualizar las propiedades del equipo seleccionado
                equipoSeleccionado.Nombre = txtNombreEquipo.Text;
                equipoSeleccionado.Estado = txtEstado.Text;
                equipoSeleccionado.Cantidad = cantidad;

                // Limpiar los TextBox
                txtNombreEquipo.Clear();
                txtEstado.Clear();
                txtCantidad.Clear();

                // Actualizar el DataGridView
                CargarInventario();
                MessageBox.Show("Equipo editado correctamente.");
            }
            else
            {
                MessageBox.Show("Seleccione un equipo para editar.");
            }
        }

        private void btnEliminarEquipo_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count > 0)
            {
                var equipoSeleccionado = (Equipo)dgvInventario.SelectedRows[0].DataBoundItem;

                // Eliminar el equipo de la lista
                listaEquipos.Remove(equipoSeleccionado);

                // Actualizar el DataGridView
                CargarInventario();
                MessageBox.Show("Equipo eliminado correctamente.");
            }
            else
            {
                MessageBox.Show("Seleccione un equipo para eliminar.");
            }
        }

        private void CargarInventario()
        {
            dgvInventario.DataSource = null;
            dgvInventario.DataSource = listaEquipos;
        }

        private void dgvInventario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count > 0)
            {
                var equipoSeleccionado = (Equipo)dgvInventario.SelectedRows[0].DataBoundItem;

                // Mostrar los datos del equipo seleccionado en los TextBox
                txtNombreEquipo.Text = equipoSeleccionado.Nombre;
                txtEstado.Text = equipoSeleccionado.Estado;
                txtCantidad.Text = equipoSeleccionado.Cantidad.ToString();
            }
        }

        // Método para configurar la imagen de fondo
        private void ConfigurarImagenDeFondo()
        {
            PictureBox fondo = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = Image.FromFile("C:\\Users\\Rand\\Source\\Repos\\GymProyectoTecnicas\\proyectoGym\\imagesGym5.jpg"), 
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(fondo);
            fondo.SendToBack(); // Mueve la imagen al fondo
        }
    }

    // Clase Equipo (Modelo)
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public int Cantidad { get; set; }
    }
}



