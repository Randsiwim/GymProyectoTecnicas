using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;

namespace proyectoGymBlazor.Data
{
    public class MembresiaService
    {
        private readonly GimnasioDbContext _context;

        public MembresiaService(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<List<MembresiaViewModel>> GetMembresiasAsync()
        {
            return await _context.Membresias
                .Select(m => new MembresiaViewModel
                {
                    MembresiaID = m.MembresiaID,
                    UsuarioID = m.UsuarioID,
                    UsuarioNombre = _context.Usuarios
                        .Where(u => u.UsuarioID == m.UsuarioID)
                        .Select(u => u.Nombre)
                        .FirstOrDefault() ?? "Usuario no encontrado",
                    Tipo = m.Tipo,
                    FechaInicio = m.FechaInicio,
                    FechaFin = m.FechaFin,
                    Estado = m.Estado
                }).ToListAsync();
        }

        public async Task<MembresiaViewModel> GetMembresiaByIdAsync(int id)
        {
            return await _context.Membresias
                .Where(m => m.MembresiaID == id)
                .Select(m => new MembresiaViewModel
                {
                    MembresiaID = m.MembresiaID,
                    UsuarioID = m.UsuarioID,
                    UsuarioNombre = _context.Usuarios
                        .Where(u => u.UsuarioID == m.UsuarioID)
                        .Select(u => u.Nombre)
                        .FirstOrDefault() ?? "Usuario no encontrado",
                    Tipo = m.Tipo,
                    FechaInicio = m.FechaInicio,
                    FechaFin = m.FechaFin,
                    Estado = m.Estado
                }).FirstOrDefaultAsync();
        }
    }

    public class MembresiaViewModel
    {
        public int MembresiaID { get; set; }
        public int UsuarioID { get; set; }
        public string UsuarioNombre { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
    }
}

