using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimnasio.Models
{
    public class ProgresoUsuario
    {
        [Key]
        public int ProgresoID { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio.")]
        public int UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La métrica es obligatoria.")]
        [StringLength(50, ErrorMessage = "La métrica no puede exceder los 50 caracteres.")]
        public string Metrica { get; set; } // Pecho, Bíceps, Piernas, etc.

        [Required(ErrorMessage = "El valor es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
    }
}
