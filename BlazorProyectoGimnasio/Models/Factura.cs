using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gimnasio.Models
{
    public class Factura
    {
        [Key]
        public int FacturaID { get; set; }

        [Required]
        public int UsuarioID { get; set; } // Relación con Cliente

        [ForeignKey("UsuarioID")]
        public Usuario Usuario { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public string Detalle { get; set; }

        public DateTime Fecha { get; set; }
    }

}
