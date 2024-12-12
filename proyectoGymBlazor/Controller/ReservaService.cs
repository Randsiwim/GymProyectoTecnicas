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

        public async Task<List<ReservaViewModel>> GetReservasAsync(int usuarioId)
        {
            return await _context.Reservas
                .Where(r => r.UsuarioId == usuarioId)
                .Select(r => new ReservaViewModel
                {
                    Id = r.Id,
                    ClaseNombre = _context.Clases.Where(c => c.ClaseID == r.ClaseId).Select(c => c.Nombre).FirstOrDefault(),
                    FechaClase = _context.Clases.Where(c => c.ClaseID == r.ClaseId).Select(c => c.Horario).FirstOrDefault(),
                    FechaReserva = r.FechaReserva,
                    Estado = r.Estado
                }).ToListAsync();
        }

        public async Task RegistrarReservaAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task CancelarReservaAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                reserva.Estado = "Cancelada";
                await _context.SaveChangesAsync();
            }
        }
    }

    public class ReservaViewModel
    {
        public int Id { get; set; }
        public string ClaseNombre { get; set; }
        public DateTime FechaClase { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Estado { get; set; }
    }
}
