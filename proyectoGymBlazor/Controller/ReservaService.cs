using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;

namespace proyectoGymBlazor.Data
{
    public class ReservaService
    {
        private readonly GimnasioDbContext _context;

        public ReservaService(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReservaViewModel>> GetReservasAsync()
        {
            return await _context.Reservas
                .Include(r => r.UsuarioId)
                .Include(r => r.ClaseId)
                .Select(r => new ReservaViewModel
                {
                    ReservaId = r.ReservaId,
                    UsuarioId = r.UsuarioId,
                    UsuarioNombre = r.Usuario.Nombre,
                    ClaseId = r.ClaseId,
                    ClaseNombre = r.ClaseId.Nombre,
                    FechaReserva = r.FechaReserva,
                    TipoReserva = r.TipoReserva
                }).ToListAsync();
        }

        public async Task<ReservaViewModel> GetReservaByIdAsync(int id)
        {
            return await _context.Reservas
                .Where(r => r.ReservaId == id)
                .Include(r => r.UsuarioId)
                .Include(r => r.ClaseId)
                .Select(r => new ReservaViewModel
                {
                    ReservaId = r.ReservaId,
                    UsuarioId = r.UsuarioId,
                    UsuarioNombre = r.UsuarioId.Nombre,
                    ClaseId = r.ClaseId,
                    ClaseNombre = r.Clase.Nombre,
                    FechaReserva = r.FechaReserva,
                    TipoReserva = r.TipoReserva
                }).FirstOrDefaultAsync();
        }
    }

    public class ReservaViewModel
    {
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public int ClaseId { get; set; }
        public string ClaseNombre { get; set; }
        public DateTime FechaReserva { get; set; }
        public string TipoReserva { get; set; }
    }
}
