using proyectoGymBlazor.Model;
using System.Collections.Generic;

namespace proyectoGymBlazor.Models
{
    public class Clase
    {
        public int ClaseID { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public int Cupo { get; set; }
        public int EntrenadorID { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}

