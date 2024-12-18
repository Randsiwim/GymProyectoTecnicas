using System.ComponentModel.DataAnnotations;

namespace Gimnasio.Models
{
    public class Inventario
    {
        [Key]
       public int EquipoID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public int VidaUtilMeses { get; set; }
        public string Estado { get; set; }
    }

}
