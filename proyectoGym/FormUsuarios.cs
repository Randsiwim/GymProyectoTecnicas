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

    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            FormAgregarUsuario formAgregar = new FormAgregarUsuario();
            if (formAgregar.ShowDialog() == DialogResult.OK)
            {
                
                CargarUsuarios();
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                
                var usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;

                FormEditarUsuario formEditar = new FormEditarUsuario(usuarioSeleccionado);
                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    // Actualiza la lista
                    CargarUsuarios();
                }
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
                var usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
                // Lógica para eliminar el usuario
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
            
            dgvUsuarios.DataSource = listaUsuarios; 
        }


    }
}
