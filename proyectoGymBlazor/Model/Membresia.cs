using System;
using System.ComponentModel.DataAnnotations;

namespace proyectoGymBlazor.Model
{
    public class Membresia
    {
        public int MembresiaId { get; set; }

        [Required]
        [MaxLength(100)]
        public int UsuarioID { get; set; }

        public String Tipo { get; set; } // Mensual, Trimestral, Semestral, Anual

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        [MaxLength(500)]
        public string Estado { get; set; }
    }
}
