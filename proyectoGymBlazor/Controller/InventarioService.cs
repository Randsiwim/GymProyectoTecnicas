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

        public async Task<List<EquipoViewModel>> GetEquiposAsync()
        {
            return await _context.Inventarios
                .Select(e => new EquipoViewModel
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Cantidad = e.Cantidad,
                    Descripcion = e.Descripcion
                }).ToListAsync();
        }

        public async Task AgregarEquipoAsync(Inventario inventario)
        {
            _context.Inventarios.Add(inventario);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarEquipoAsync(int id)
        {
            var equipo = await _context.Inventarios.FindAsync(id);
            if (equipo != null)
            {
                _context.Inventarios.Remove(equipo);
                await _context.SaveChangesAsync();
            }
        }
    }

    public class EquipoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
    }
}
