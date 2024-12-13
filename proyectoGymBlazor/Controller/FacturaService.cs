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
                    FacturaId = f.FacturaId,
                    UsuarioId = f.UsuarioId,
                    Fecha = f.Fecha,
                    Monto = f.Monto,
                    Detalle = f.Detalle,
                    UsuarioNombre = _context.Usuarios
                        .Where(u => u.UsuarioID == f.UsuarioId)
                        .Select(u => u.Nombre)
                        .FirstOrDefault() ?? "Usuario no encontrado"
                }).ToListAsync();
        }
    }

    public class FacturaViewModel
    {
        public int FacturaId { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Detalle { get; set; }
    }
}
