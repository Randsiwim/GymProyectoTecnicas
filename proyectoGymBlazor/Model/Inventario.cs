using System.ComponentModel.DataAnnotations;

namespace proyectoGymBlazor.Model
{
    public class Inventario
    {
        public int EqupoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser igual o mayor a 0.")]
        public DateTime FechaAdquisicion { get; set; }

        [MaxLength(500)]
        public int VidaUtilMeses { get; set; }

        public string Estado { get; set; } = "Disponible"; // Disponible, En uso, En mantenimiento
    }
}
