using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;

namespace proyectoGymBlazor.Data
{
    public class UsuarioService
    {
        private readonly GimnasioDbContext _context;

        public UsuarioService(GimnasioDbContext context)
        {
            _context = context;
        }

        // Obtener la lista de usuarios
        public async Task<List<UsuarioViewModel>> GetUsuariosAsync()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioViewModel
                {
                    UsuarioID = u.UsuarioID,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Rol = u.Rol,
                    FechaRegistro = u.FechaRegistro
                }).ToListAsync();
        }

        // Obtener un usuario por ID
        public async Task<UsuarioViewModel> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios
                .Where(u => u.UsuarioID == id)
                .Select(u => new UsuarioViewModel
                {
                    UsuarioID = u.UsuarioID,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Rol = u.Rol,
                    PuntosFuertes = u.PuntosFuertes,
                    Horario = u.Horario,
                    FechaRegistro = u.FechaRegistro
                }).FirstOrDefaultAsync();
        }
    }

    // Modelo de vista para representar al usuario
    public class UsuarioViewModel
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string PuntosFuertes { get; set; }
        public string Horario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
