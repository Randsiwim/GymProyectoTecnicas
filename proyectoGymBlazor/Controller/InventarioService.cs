using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;

namespace proyectoGymBlazor.Data
{
    public class InventarioService
    {
        private readonly GimnasioDbContext _context;

        public InventarioService(GimnasioDbContext context)
        {
            _context = context;
        }

        // Obtener todos los equipos
        public async Task<List<Inventario>> GetInventarioAsync()
        {
            return await _context.Inventarios.ToListAsync();
        }

        // Agregar un nuevo equipo
        public async Task AddInventarioAsync(Inventario inventario)
        {
            _context.Inventarios.Add(inventario);
            await _context.SaveChangesAsync();
        }

        // Actualizar un equipo
        public async Task UpdateInventarioAsync(Inventario inventario)
        {
            var equipoExistente = await _context.Inventarios.FindAsync(inventario.EqupoId);
            if (equipoExistente != null)
            {
                equipoExistente.Nombre = inventario.Nombre;
                equipoExistente.FechaAdquisicion = inventario.FechaAdquisicion;
                equipoExistente.VidaUtilMeses = inventario.VidaUtilMeses;
                equipoExistente.Estado = inventario.Estado;

                await _context.SaveChangesAsync();
            }
        }

        // Eliminar un equipo
        public async Task DeleteInventarioAsync(int equipoId)
        {
            var equipo = await _context.Inventarios.FindAsync(equipoId);
            if (equipo != null)
            {
                _context.Inventarios.Remove(equipo);
                await _context.SaveChangesAsync();
            }
        }

    

    }
}
