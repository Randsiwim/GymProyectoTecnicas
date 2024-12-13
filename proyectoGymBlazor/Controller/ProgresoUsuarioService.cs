using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;

namespace proyectoGymBlazor.Data
{
    public class ProgresoUsuarioService
    {
        private readonly GimnasioDbContext _context;

        public ProgresoUsuarioService(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProgresoUsuarioViewModel>> GetProgresosAsync()
        {
            return await _context.ProgresosUsuarios
                .Select(p => new ProgresoUsuarioViewModel
                {
                    ProgresoId = p.ProgresoId,
                    UsuarioId = p.UsuarioId,
                    UsuarioNombre = _context.Usuarios
                        .Where(u => u.UsuarioID == p.UsuarioId)
                        .Select(u => u.Nombre)
                        .FirstOrDefault() ?? "Usuario no encontrado",
                    Fecha = p.Fecha,
                    Metrica = p.Metrica,
                    Valor = p.Valor
                }).ToListAsync();
        }

        public async Task<ProgresoUsuarioViewModel> GetProgresoByIdAsync(int id)
        {
            return await _context.ProgresosUsuarios
                .Where(p => p.ProgresoId == id)
                .Select(p => new ProgresoUsuarioViewModel
                {
                    ProgresoId = p.ProgresoId,
                    UsuarioId = p.UsuarioId,
                    UsuarioNombre = _context.Usuarios
                        .Where(u => u.UsuarioID == p.UsuarioId)
                        .Select(u => u.Nombre)
                        .FirstOrDefault() ?? "Usuario no encontrado",
                    Fecha = p.Fecha,
                    Metrica = p.Metrica,
                    Valor = p.Valor
                }).FirstOrDefaultAsync();
        }
    }

    public class ProgresoUsuarioViewModel
    {
        public int ProgresoId { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Metrica { get; set; }
        public decimal Valor { get; set; }
    }
}
