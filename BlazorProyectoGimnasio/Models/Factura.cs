using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimnasio.Models
{
    public class Factura
    {
        [Key]
        public int FacturaID { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio.")]
        public int UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Column(TypeName = "decimal(18,2)")] // Asegura precisión en la base de datos
        public decimal Monto { get; set; }

        [StringLength(500, ErrorMessage = "El detalle no puede exceder los 500 caracteres.")]
        public string Detalle { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
    }
}

