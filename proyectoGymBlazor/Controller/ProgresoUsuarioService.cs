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

        public async Task<List<ProgresoUsuarioViewModel>> GetProgresoAsync(int usuarioId)
        {
            return await _context.ProgresosUsuarios
                .Where(p => p.UsuarioId == usuarioId)
                .Select(p => new ProgresoUsuarioViewModel
                {
                    Id = p.Id,
                    FechaRegistro = p.FechaRegistro,
                    Peso = p.Peso,
                    PorcentajeGrasa = p.PorcentajeGrasa,
                    TiempoEntrenamientoHoras = p.TiempoEntrenamientoHoras
                }).ToListAsync();
        }

        public async Task RegistrarProgresoAsync(ProgresoUsuario progreso)
        {
            _context.ProgresosUsuarios.Add(progreso);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarProgresoAsync(int id)
        {
            var progreso = await _context.ProgresosUsuarios.FindAsync(id);
            if (progreso != null)
            {
                _context.ProgresosUsuarios.Remove(progreso);
                await _context.SaveChangesAsync();
            }
        }
    }

    public class ProgresoUsuarioViewModel
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double Peso { get; set; }
        public double PorcentajeGrasa { get; set; }
        public double TiempoEntrenamientoHoras { get; set; }
    }
}
