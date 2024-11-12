using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoGym
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;  
            string password = txtPassword.Text;  

            // Autenticacion basica 
            if (username == "cliente" && password == "pass1234")
            {
                MessageBox.Show("Inicio de sesión exitoso!");
                this.Hide(); // Oculta el formulario de login
                FormMain mainForm = new FormMain(); // Crea una instancia del formulario principal
                mainForm.Show(); // Muestra el formulario principal
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}

