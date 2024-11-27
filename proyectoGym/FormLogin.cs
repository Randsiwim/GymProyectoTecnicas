using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace proyectoGym
{
    public partial class FormLogin : Form
    {

        private List<Usuario> usuariosGuardados = new List<Usuario>();

        public FormLogin()
        {
            InitializeComponent();

            // Estilos del formulario
            this.Text = "Inicio de Sesión - Gimnasio";
            this.BackColor = Color.LightGray;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Estilo de TextBox de Contraseña
            txtPassword.UseSystemPasswordChar = true;

            // Estilo del Botón
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.BackColor = Color.SteelBlue;
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            // Validaciones y funcionalidad
            usuariosGuardados.Add(new Usuario { Username = "Admin", Password = "pass123" });

            PictureBox fondo = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = Image.FromFile("C:\\Users\\Rand\\Source\\Repos\\GymProyectoTecnicas\\proyectoGym\\imagesGym2.jpg"), 
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(fondo);
            fondo.SendToBack(); 

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, completa ambos campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuario = usuariosGuardados.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (usuario != null)
            {
                MessageBox.Show("Inicio de sesión exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FormMain mainForm = new FormMain();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public class Usuario
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}


