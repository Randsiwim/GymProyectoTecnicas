using System;
using System.Collections.Generic;
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

            
            txtPassword.UseSystemPasswordChar = true;  

            // Simulación de carga de usuarios guardados
            // Normalmente, estos usuarios podrían estar guardados en una base de datos o en una lista.
            usuariosGuardados.Add(new Usuario { Username = "cliente", Password = "pass1234" });
            usuariosGuardados.Add(new Usuario { Username = "entrenador", Password = "entrenador123" });
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validar si el usuario existe en la lista de usuarios guardados
            var usuario = usuariosGuardados.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (usuario != null)
            {
                MessageBox.Show("Inicio de sesión exitoso!");
                this.Hide(); // Oculta el formulario de login
                FormMain mainForm = new FormMain();
                mainForm.Show(); // Muestra el formulario principal
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }

   
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}


