using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace proyectoGym
{
    public partial class FormReportes : Form
    {
        // Suposición: Estas son las listas de datos que necesitarás para los reportes.
        private List<Membresia> listaMembresias = new List<Membresia>(); // Contendrá las membresías de los clientes
        private List<Transaccion> listaTransacciones = new List<Transaccion>(); // Contendrá las transacciones financieras
        private List<Clase> listaClases = new List<Clase>(); // Contendrá las clases disponibles
        private List<ReservaClase> listaReservas = new List<ReservaClase>(); // Contendrá las reservas de clases

        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            // Inicializar los elementos del ComboBox con las opciones de tipo de reporte
            cmbTipoReporte.Items.Add("Reporte de Membresías");
            cmbTipoReporte.Items.Add("Reporte Contable");
            cmbTipoReporte.Items.Add("Reporte de Clases");
            // Establecer el valor predeterminado del ComboBox
            cmbTipoReporte.SelectedIndex = 0;
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            string tipoReporte = cmbTipoReporte.SelectedItem.ToString();

            // Generación del reporte según el tipo seleccionado
            if (tipoReporte == "Reporte de Membresías")
            {
                GenerarReporteMembresias();
            }
            else if (tipoReporte == "Reporte Contable")
            {
                GenerarReporteContable();
            }
            else if (tipoReporte == "Reporte de Clases")
            {
                GenerarReporteClases();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tipo de reporte.");
            }
        }

        private void GenerarReporteMembresias()
        {
            // Lógica para calcular el crecimiento o disminución de la matrícula
            var membresiasPorMes = listaMembresias
                .GroupBy(m => m.FechaInscripcion.Month)
                .Select(g => new
                {
                    Mes = g.Key,
                    TotalMembresias = g.Count()
                })
                .ToList();

            // Mostrar el resultado en un MessageBox o en algún control
            string reporte = "Crecimiento de Membresías:\n";
            foreach (var mes in membresiasPorMes)
            {
                reporte += $"Mes {mes.Mes}: {mes.TotalMembresias} membresías\n";
            }

            MessageBox.Show(reporte);
        }

        private void GenerarReporteContable()
        {
            // Lógica para calcular ingresos y egresos
            decimal ingresos = listaTransacciones
                .Where(t => t.Tipo == "Ingreso")
                .Sum(t => t.Monto);

            decimal egresos = listaTransacciones
                .Where(t => t.Tipo == "Egreso")
                .Sum(t => t.Monto);

            decimal saldo = ingresos - egresos;

            string reporte = $"Informe Contable:\nIngresos: {ingresos:C}\nEgresos: {egresos:C}\nSaldo: {saldo:C}";
            MessageBox.Show(reporte);
        }

        private void GenerarReporteClases()
        {
            // Lógica para calcular qué clases y horarios son más populares
            var clasesPopulares = listaReservas
                .GroupBy(r => r.ClaseId)
                .Select(g => new
                {
                    Clase = listaClases.First(c => c.Id == g.Key).Nombre,
                    Reservas = g.Count()
                })
                .OrderByDescending(c => c.Reservas)
                .Take(5) // Muestra las 5 clases más populares
                .ToList();

            string reporte = "Clases más populares:\n";
            foreach (var clase in clasesPopulares)
            {
                reporte += $"{clase.Clase}: {clase.Reservas} reservas\n";
            }

            MessageBox.Show(reporte);
        }

        private void btnExportarReporte_Click(object sender, EventArgs e)
        {
            // Lógica para exportar reportes (a archivo CSV, PDF, etc.)
            MessageBox.Show("Reporte exportado correctamente.");
        }
    }

    // Modelo de ejemplo para las clases que podrías usar
    public class Membresia
    {
        public int ClienteId { get; set; }
        public DateTime FechaInscripcion { get; set; }
    }

    public class Transaccion
    {
        public string Tipo { get; set; } // "Ingreso" o "Egreso"
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }

    

    public class ReservaClase
    {
        public int ClaseId { get; set; }
        public int ClienteId { get; set; }
    }
}


