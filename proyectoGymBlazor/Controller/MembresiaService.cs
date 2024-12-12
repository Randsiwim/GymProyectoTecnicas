using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;

namespace proyectoGymBlazor.Data
{
    public class MembresiaService
    {
        private readonly GimnasioDbContext _context;

        public MembresiaService(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<List<MembresiaViewModel>> GetMembresiasAsync()
        {
            return await _context.Membresias
                .Select(m => new MembresiaViewModel
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Precio = m.Precio,
                    DuracionMeses = m.DuracionMeses,
                    Beneficios = m.Beneficios
                }).ToListAsync();
        }

        public async Task AgregarMembresiaAsync(Membresia membresia)
        {
            _context.Membresias.Add(membresia);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarMembresiaAsync(int id)
        {
            var membresia = await _context.Membresias.FindAsync(id);
            if (membresia != null)
            {
                _context.Membresias.Remove(membresia);
                await _context.SaveChangesAsync();
            }
        }
    }

    public class MembresiaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int DuracionMeses { get; set; }
        public string Beneficios { get; set; }
    }
}
