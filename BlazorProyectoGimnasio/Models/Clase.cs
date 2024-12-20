using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Gimnasio.Models
{
    public class Clase
    {
        [Key]
        public int ClaseID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public TimeSpan Horario { get; set; } = TimeSpan.Zero;

        public int Cupo { get; set; } = 0;

        [Required]
        public int EntrenadorID { get; set; } // Relación con Usuarios
        public Usuario Entrenador { get; set; }

        public ICollection<Reserva> Reservas { get; set; } // Relación con Reservas
    }

}
