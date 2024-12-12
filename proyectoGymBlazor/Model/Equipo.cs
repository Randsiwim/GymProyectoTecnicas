using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoGymBlazor.Model
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCompra { get; set; }
        public int VidaUtilMeses { get; set; }
        public bool EnUso { get; set; }
        public string Estado { get; set; } // Nuevo: Estado del equipo (e.g., "Bueno", "Malo", etc.)
        public int Cantidad { get; set; } // Nuevo: Cantidad disponible del equipo
    }
}

