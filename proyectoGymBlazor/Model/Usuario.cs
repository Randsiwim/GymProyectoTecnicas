using System.ComponentModel.DataAnnotations;

namespace proyectoGymBlazor.Model
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Email { get; set; }

        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public string PuntosFuertes { get; set; }
        public string Horario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

