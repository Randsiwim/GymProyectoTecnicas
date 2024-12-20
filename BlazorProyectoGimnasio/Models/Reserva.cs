using System;
using System.ComponentModel.DataAnnotations;

namespace Gimnasio.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaID { get; set; }

        [Required]
        public int UsuarioID { get; set; } // Relación con Usuarios
        public Usuario Usuario { get; set; }

        [Required]
        public int ClaseID { get; set; } // Relación con Clases
        public Clase Clase { get; set; }

        [Required]
        public DateTime FechaReserva { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoReserva { get; set; }
    }

}
