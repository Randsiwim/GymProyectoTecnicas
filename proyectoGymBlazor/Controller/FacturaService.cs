using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;

namespace proyectoGymBlazor.Data
{
    public class FacturaService
    {
        private readonly GimnasioDbContext _context;

        public FacturaService(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<List<FacturaViewModel>> GetFacturasAsync()
        {
            return await _context.Facturas
                .Select(f => new FacturaViewModel
                {
                    Id = f.Id,
                    ClienteId = f.ClienteId,
                    Fecha = f.Fecha,
                    Total = f.Total,
                    Descripcion = f.Descripcion,
                    ClienteNombre = _context.Usuarios
                        .Where(u => u.UsuarioID == f.ClienteId)
                        .Select(u => u.Nombre)
                        .FirstOrDefault() ?? "Cliente no encontrado"
                }).ToListAsync();
        }
    }

    public class FacturaViewModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Descripcion { get; set; }
    }
}
