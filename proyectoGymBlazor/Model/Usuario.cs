namespace proyectoGymBlazor.Model
{
    // Tabla Usuarios
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public string PuntosFuertes { get; set; }
        public string Horario { get; set; }
        public DateTime FechaRegistro { get; set; }

        public ICollection<Membresia> Membresias { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Factura> Facturas { get; set; }
        public ICollection<ProgresoUsuario> ProgresosUsuario { get; set; }
    }
}