using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Data;
using proyectoGymBlazor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyectoGymBlazor.Services
{
    public class InventarioService
    {
        private readonly GimnasioDbContext _context;

        public InventarioService(GimnasioDbContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos del inventario
        public async Task<List<Inventario>> GetInventarioAsync()
        {
            return await _context.Inventarios.ToListAsync();
        }

        // Obtener un elemento del inventario por ID
        public async Task<Inventario> GetInventarioByIdAsync(int id)
        {
            return await _context.Inventarios.FindAsync(id);
        }

        // Agregar un nuevo elemento al inventario
        public async Task AddInventarioAsync(Inventario inventario)
        {
            _context.Inventarios.Add(inventario);
            await _context.SaveChangesAsync();
        }

        // Actualizar un elemento existente del inventario
        public async Task UpdateInventarioAsync(Inventario inventario)
        {
            _context.Inventarios.Update(inventario);
            await _context.SaveChangesAsync();
        }

        // Eliminar un elemento del inventario por ID
        public async Task DeleteInventarioAsync(int id)
        {
            var inventario = await GetInventarioByIdAsync(id);
            if (inventario != null)
            {
                _context.Inventarios.Remove(inventario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
