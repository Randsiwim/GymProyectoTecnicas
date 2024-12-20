
namespace Gimnasio.Models
{
    public class ReporteContable
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // Ingreso o Egreso
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
   

}
