using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using proyectoGym; 


namespace proyectoGym
{
    
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        //Abrir formularios
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
