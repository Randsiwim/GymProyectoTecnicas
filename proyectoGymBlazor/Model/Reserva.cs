using System;
using System.ComponentModel.DataAnnotations;

namespace proyectoGymBlazor.Model
{
    public class Reserva
    {
        
        public int ReservaId { get; set; }

        
        public int UsuarioId { get; set; }


        [Required]
        public int ClaseId { get; set; }

        [Required]
        public DateTime FechaReserva { get; set; }

        public string TipoReserva { get; set; } = "Pendiente"; // Pendiente, Confirmada, Cancelada
    }
}
