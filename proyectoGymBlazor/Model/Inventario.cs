using System;
using System.ComponentModel.DataAnnotations;

namespace proyectoGymBlazor.Model
{
    public class Inventario
    {
        public int EquipoID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public int VidaUtilMeses { get; set; }
        public string Estado { get; set; }
    }
}

