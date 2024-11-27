using System;
using System.Drawing;
using System.Windows.Forms;

namespace proyectoGym
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // Estilos del formulario
            this.Text = "Menú Principal - Gimnasio";
            this.BackColor = Color.LightGray;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Estilo de los botones
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.BackColor = Color.SteelBlue;
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            btnMembresias.FlatStyle = FlatStyle.Flat;
            btnMembresias.BackColor = Color.SteelBlue;
            btnMembresias.ForeColor = Color.White;
            btnMembresias.FlatAppearance.BorderSize = 0;
            btnMembresias.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            btnClases.FlatStyle = FlatStyle.Flat;
            btnClases.BackColor = Color.SteelBlue;
            btnClases.ForeColor = Color.White;
            btnClases.FlatAppearance.BorderSize = 0;
            btnClases.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            btnReservas.FlatStyle = FlatStyle.Flat;
            btnReservas.BackColor = Color.SteelBlue;
            btnReservas.ForeColor = Color.White;
            btnReservas.FlatAppearance.BorderSize = 0;
            btnReservas.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.BackColor = Color.SteelBlue;
            btnInventario.ForeColor = Color.White;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.BackColor = Color.SteelBlue;
            btnReportes.ForeColor = Color.White;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            btnFacturas.FlatStyle = FlatStyle.Flat;
            btnFacturas.BackColor = Color.SteelBlue;
            btnFacturas.ForeColor = Color.White;
            btnFacturas.FlatAppearance.BorderSize = 0;
            btnFacturas.FlatAppearance.MouseOverBackColor = Color.DarkSlateBlue;

            // Fondo del formulario
            PictureBox fondo = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = Image.FromFile("C:\\Users\\Rand\\Source\\Repos\\GymProyectoTecnicas\\proyectoGym\\imagesGym4.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(fondo);
            fondo.SendToBack();
        }

        // Abrir formularios
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.Show();
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            FormMembresias formMembresias = new FormMembresias();
            formMembresias.Show();
        }

        private void btnClases_Click(object sender, EventArgs e)
        {
            FormClase formClases = new FormClase();
            formClases.Show();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            FormReservas formReservas = new FormReservas();
            formReservas.Show();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FormInventario formInventario = new FormInventario();
            formInventario.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormReportes formReportes = new FormReportes();
            formReportes.Show();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            FormFacturacion formFactura = new FormFacturacion();
            formFactura.Show();
        }
    }
}

