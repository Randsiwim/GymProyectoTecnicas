using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Models;


namespace proyectoGymBlazor.Data
{
    public class ClaseService
    {
        private readonly GimnasioDbContext _context;

        public ClaseService(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<List<Clase>> GetClasesAsync()
        {
            return await _context.Clase
                .Select(c => new Clase
                {
                    ClaseID = c.ClaseID, // ID de la clase
                    Nombre = c.Nombre, // Nombre de la clase
                    Horario = c.Horario, // Horario de la clase
                    EntrenadorID = _context.Usuarios
                        .Where(u => u.UsuarioID == c.EntrenadorID)
                        .Select(u => u.Nombre)
                        .FirstOrDefault() ?? "Sin entrenador", // Nombre del entrenador
                    Cupo = c.Cupo // Cupos disponibles
                }).ToListAsync();
        }
    }
}