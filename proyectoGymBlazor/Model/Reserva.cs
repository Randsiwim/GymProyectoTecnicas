

namespace proyectoGymBlazor.Model
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public int UsuarioID { get; set; }
        public int ClaseID { get; set; }
        public DateTime FechaReserva { get; set; }
        public string TipoReserva { get; set; }

        public Usuario Usuario { get; set; }
        public Clase Clase { get; set; }
    }

}
