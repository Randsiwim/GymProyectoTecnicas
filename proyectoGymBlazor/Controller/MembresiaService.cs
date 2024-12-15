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
        public async Task<List<Membresia>> ObtenerMembresiasAsync()
        {
            return await _context.Membresias.ToListAsync();
        }

        // Obtener una membresía por ID
        public async Task<Membresia> ObtenerMembresiaPorIdAsync(int id)
        {
            return await _context.Membresias.FirstOrDefaultAsync(m => m.MembresiaID == id);
        }

        // Crear una nueva membresía
        public async Task CrearMembresiaAsync(Membresia membresia)
        {
            _context.Membresias.Add(membresia);
            await _context.SaveChangesAsync();
        }

        // Actualizar una membresía existente
        public async Task ActualizarMembresiaAsync(Membresia membresia)
        {
            _context.Membresias.Update(membresia);
            await _context.SaveChangesAsync();
        }

        // Eliminar una membresía
        public async Task EliminarMembresiaAsync(int id)
        {
            var membresia = await _context.Membresias.FirstOrDefaultAsync(m => m.MembresiaID == id);
            if (membresia != null)
            {
                _context.Membresias.Remove(membresia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
