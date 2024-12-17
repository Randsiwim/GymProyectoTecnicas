namespace proyectoGymBlazor.Model
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Detalle { get; set; }

        // Relación con Usuario
        public Usuario Usuario { get; set; }
    }
}

