using System;
using System.ComponentModel.DataAnnotations;

namespace proyectoGymBlazor.Models
{
    public class Clase
    {
        [Key]
        public int ClaseID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El horario es obligatorio.")]
        public DateTime Horario { get; set; }

        [Required]
        public int EntrenadorID { get; set; }

        [Range(1, 100, ErrorMessage = "El cupo debe estar entre 1 y 100.")]
        public int Cupo { get; set; }
    }
}


