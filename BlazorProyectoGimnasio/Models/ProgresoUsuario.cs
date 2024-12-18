using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Gimnasio.Models
{
    public class ProgresoUsuario
    {
        [Key]
        public int ProgresoID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime Fecha { get; set; }
        public string Metrica { get; set; } // Pecho, Biceps, Piernas, etc.

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }


        // Relación
        public Usuario Usuario { get; set; }
    }

}
