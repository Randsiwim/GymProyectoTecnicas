using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimnasio.Models
{
    public class Clase
    {
        [Key]
        public int ClaseID { get; set; }

        [Required(ErrorMessage = "El nombre de la clase es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El horario es obligatorio")]
        public TimeSpan? Horario { get; set; }

        [Required(ErrorMessage = "El cupo máximo es obligatorio")]
        [Range(1, 100, ErrorMessage = "El cupo debe estar entre 1 y 100")]
        public int? Cupo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un entrenador")]
        public int? EntrenadorID { get; set; }

        [ForeignKey("EntrenadorID")]
        public virtual Usuario Entrenador { get; set; }
    }
}
