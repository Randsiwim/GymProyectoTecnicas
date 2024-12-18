using System.ComponentModel.DataAnnotations;

namespace Gimnasio.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Contraseña { get; set; }

        public string? Rol { get; set; } 

        public string? PuntosFuertes { get; set; } 
        public string? Horario { get; set; } 
        public DateTime FechaRegistro { get; set; } = DateTime.Now; // Valor por defecto

        // Relaciones
        public ICollection<Membresia>? Membresias { get; set; }
        public ICollection<Reserva>? Reservas { get; set; }
        public ICollection<Factura>? Facturas { get; set; }
        public ICollection<ProgresoUsuario>? Progresos { get; set; }
    }
}
