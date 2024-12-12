using proyectoGymBlazor.Data;
using proyectoGymBlazor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace proyectoGymBlazor.Controllers
{
    public class ClaseService
    {
        private readonly GimnasioDbContext _context;

        public ClaseService(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClaseViewModel>> GetClasesAsync()
        {
            return await _context.Clases
                .Select(c => new ClaseViewModel
                {
                    ClaseID = c.ClaseID,
                    Nombre = c.Nombre,
                    Horario = c.Horario,
                    EntrenadorID = _context.Usuarios
                        .Where(u => u.UsuarioID == c.EntrenadorID)
                        .Select(u => u.Nombre)
                        .FirstOrDefault() ?? "Sin asignar"
                }).ToListAsync();
        }
    }
}
