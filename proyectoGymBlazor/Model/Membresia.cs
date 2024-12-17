
namespace proyectoGymBlazor.Model
{
    public class Membresia
    {
        public int MembresiaID { get; set; }
        public int UsuarioID { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }

        public Usuario Usuario { get; set; }
    }
}
