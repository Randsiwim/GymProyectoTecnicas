using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Data;
using proyectoGymBlazor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyectoGymBlazor.Services
{
    public class MembresiaService
    {
        private readonly GimnasioDbContext _context;

        public MembresiaService(GimnasioDbContext context)
        {
            _context = context;
        }

        // Obtener todas las membresías
        public async Task<List<Membresia>> GetMembresiasAsync()
        {
            return await _context.Membresias.ToListAsync();
        }

        // Obtener una membresía por ID
        public async Task<Membresia> GetMembresiaByIdAsync(int id)
        {
            return await _context.Membresias.FindAsync(id);
        }

        // Agregar una nueva membresía
        public async Task AddMembresiaAsync(Membresia membresia)
        {
            _context.Membresias.Add(membresia);
            await _context.SaveChangesAsync();
        }

        // Actualizar una membresía existente
        public async Task UpdateMembresiaAsync(Membresia membresia)
        {
            _context.Membresias.Update(membresia);
            await _context.SaveChangesAsync();
        }

        // Eliminar una membresía
        public async Task DeleteMembresiaAsync(int id)
        {
            var membresia = await GetMembresiaByIdAsync(id);
            if (membresia != null)
            {
                _context.Membresias.Remove(membresia);
                await _context.SaveChangesAsync();
            }
        }
    }
}

