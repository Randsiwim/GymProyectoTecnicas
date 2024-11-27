using Model;
using Newtonsoft.Json; // Agregar la referencia necesaria para JSON
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace proyectoGym
{
    public partial class FormFacturacion : Form
    {
        private List<Factura> listaFacturas = new List<Factura>();
        private readonly string rutaArchivo = "facturas.json"; // Ruta del archivo JSON

        public FormFacturacion()
        {
            InitializeComponent();
            CargarFacturas(); // Cargar las facturas existentes
            CargarFacturasEnGrid(); // Mostrar en el DataGridView
            ActualizarTotal(); // Mostrar el total general
        }

        private void GenerarFactura(int clienteId, decimal total, string descripcion)
        {
            // Verifica si ya existe una factura para el cliente este mes
            var facturaExistente = listaFacturas.FirstOrDefault(f =>
                f.ClienteId == clienteId && f.Fecha.Month == DateTime.Now.Month && f.Fecha.Year == DateTime.Now.Year);

            if (facturaExistente != null)
            {
                MessageBox.Show("Ya existe una factura para este cliente en el mes actual.");
                return;
            }

            // Genera una nueva factura
            Factura nuevaFactura = new Factura
            {
                Id = listaFacturas.Count + 1,
                ClienteId = clienteId,
                Fecha = DateTime.Now,
                Total = total,
                Descripcion = descripcion
            };

            listaFacturas.Add(nuevaFactura);
            MessageBox.Show("Factura generada correctamente.");

            CargarFacturasEnGrid(); // Actualiza el DataGridView
            ActualizarTotal(); // Actualiza el total general
        }

        private void ConsultarFacturas(int? clienteId = null)
        {
            var facturasFiltradas = listaFacturas;

            if (clienteId.HasValue)
            {
                facturasFiltradas = listaFacturas.Where(f => f.ClienteId == clienteId.Value).ToList();

                if (!facturasFiltradas.Any())
                {
                    MessageBox.Show("No se encontraron facturas para este cliente.");
                    return;
                }
            }

            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = facturasFiltradas.OrderByDescending(f => f.Fecha).ToList();
        }

        private void GuardarFacturas()
        {
            try
            {
                // Utilizando Newtonsoft.Json para serializar las facturas
                string json = JsonConvert.SerializeObject(listaFacturas, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(rutaArchivo, json);
                MessageBox.Show("Facturas guardadas correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar facturas: {ex.Message}");
            }
        }

        private void CargarFacturas()
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    string json = File.ReadAllText(rutaArchivo);
                    listaFacturas = JsonConvert.DeserializeObject<List<Factura>>(json) ?? new List<Factura>();
                }
                else
                {
                    listaFacturas = new List<Factura>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar facturas: {ex.Message}");
                listaFacturas = new List<Factura>();
            }
        }

        private void CargarFacturasEnGrid()
        {
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = listaFacturas.OrderByDescending(f => f.Fecha).ToList();
        }

        private void ActualizarTotal()
        {
            decimal totalGeneral = listaFacturas.Sum(f => f.Total);
            lblTotalGeneral.Text = $"Total General: {totalGeneral:C}";
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClienteId.Text) ||
                string.IsNullOrWhiteSpace(txtTotal.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!int.TryParse(txtClienteId.Text, out int clienteId))
            {
                MessageBox.Show("ID de cliente debe ser un número válido.");
                return;
            }

            if (!decimal.TryParse(txtTotal.Text, out decimal total))
            {
                MessageBox.Show("El total debe ser un número válido.");
                return;
            }

            string descripcion = txtDescripcion.Text.Trim();
            GenerarFactura(clienteId, total, descripcion);
        }

        private void btnConsultarFacturas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClienteId.Text))
            {
                CargarFacturasEnGrid(); // Carga todas las facturas si no se ingresa un cliente
            }
            else if (int.TryParse(txtClienteId.Text, out int clienteId))
            {
                ConsultarFacturas(clienteId);
            }
            else
            {
                MessageBox.Show("Ingrese un ID de cliente válido.");
            }
        }

        private void FormFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarFacturas(); // Guardar las facturas antes de salir
        }
    }
}

