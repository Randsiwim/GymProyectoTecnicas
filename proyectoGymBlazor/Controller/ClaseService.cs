using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Data;
using proyectoGymBlazor.Models; // Importación correcta del namespace

namespace proyectoGymBlazor.Services
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
            return await _context.Clases.ToListAsync();
        }

        public async Task<Clase> GetClaseByIdAsync(int id)
        {
            return await _context.Clases.FindAsync(id);
        }

        public async Task AddClaseAsync(Clase clase)
        {
            _context.Clases.Add(clase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClaseAsync(Clase clase)
        {
            _context.Entry(clase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClaseAsync(int id)
        {
            var clase = await GetClaseByIdAsync(id);
            if (clase != null)
            {
                _context.Clases.Remove(clase);
                await _context.SaveChangesAsync();
            }
        }
    }
}
