namespace Gimnasio.Models
{
    public class Membresia
    {
        public int MembresiaID { get; set; }
        public int UsuarioID { get; set; }
        public string Tipo { get; set; } = "Mensual"; // Valor predeterminado
        public DateTime FechaInicio { get; set; } = DateTime.Now; // Valor predeterminado
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = "Activa"; // Valor predeterminado

        // Relación
        public Usuario Usuario { get; set; }
    }
}
