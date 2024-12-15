using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;
using proyectoGymBlazor.Data;

namespace proyectoGymBlazor.Services
{
    public class ProgresoUsuarioService
    {
        private readonly GimnasioDbContext _context;

        public ProgresoUsuarioService(GimnasioDbContext context)
        {
            _context = context;
        }

        // Obtener todos los registros
        public async Task<List<ProgresoUsuario>> GetProgresosAsync()
        {
            return await _context.ProgresosUsuario.ToListAsync();
        }

        // Obtener un registro por ID
        public async Task<ProgresoUsuario> GetProgresoByIdAsync(int id)
        {
            return await _context.ProgresosUsuario.FindAsync(id);
        }

        // Agregar un nuevo progreso
        public async Task AddProgresoAsync(ProgresoUsuario progreso)
        {
            _context.ProgresosUsuario.Add(progreso);
            await _context.SaveChangesAsync();
        }

        // Actualizar un registro existente
        public async Task UpdateProgresoAsync(ProgresoUsuario progreso)
        {
            _context.ProgresosUsuario.Update(progreso);
            await _context.SaveChangesAsync();
        }

        // Eliminar un registro por ID
        public async Task DeleteProgresoAsync(int id)
        {
            var progreso = await GetProgresoByIdAsync(id);
            if (progreso != null)
            {
                _context.ProgresosUsuario.Remove(progreso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
