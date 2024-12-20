using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimnasio.Models
{
    public class Membresia
    {
        [Key]
        public int MembresiaID { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio.")]
        public int UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "El tipo de membresía es obligatorio.")]
        [StringLength(50, ErrorMessage = "El tipo no puede exceder los 50 caracteres.")]
        public string Tipo { get; set; } = "Mensual"; // Valor predeterminado

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaInicio { get; set; } = DateTime.Now; // Valor predeterminado

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(20, ErrorMessage = "El estado no puede exceder los 20 caracteres.")]
        public string Estado { get; set; } = "Activa"; // Valor predeterminado
    }
}
