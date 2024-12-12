using System;
using System.ComponentModel.DataAnnotations;

namespace proyectoGymBlazor.Model
{
    public class Factura
    {
        public int FacturaId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor a 0.")]
        public decimal Monto { get; set; }

        [MaxLength(500)]
        public string Detalle { get; set; }
    }
}
