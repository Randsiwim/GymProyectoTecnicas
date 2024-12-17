using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Data;
using proyectoGymBlazor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyectoGymBlazor.Services
{
    public class FacturaService
    {
        private readonly GimnasioDbContext _context;

        public FacturaService(GimnasioDbContext context)
        {
            _context = context;
        }

        // Obtener todas las facturas
        public async Task<List<Factura>> GetFacturasAsync()
        {
            return await _context.Facturas.ToListAsync();
        }

        // Obtener una factura por ID
        public async Task<Factura> GetFacturaByIdAsync(int id)
        {
            return await _context.Facturas.FindAsync(id);
        }

        // Agregar una nueva factura
        public async Task<bool> AddFacturaAsync(Factura factura)
        {
            try
            {
                _context.Facturas.Add(factura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                // Log o manejo de error
                return false;
            }
        }

        // Actualizar una factura existente
        public async Task<bool> UpdateFacturaAsync(Factura factura)
        {
            try
            {
                _context.Entry(factura).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                // Log o manejo de error
                return false;
            }
        }

        // Eliminar una factura por ID
        public async Task<bool> DeleteFacturaAsync(int id)
        {
            try
            {
                var factura = await GetFacturaByIdAsync(id);
                if (factura == null) return false;

                _context.Facturas.Remove(factura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                // Log o manejo de error
                return false;
            }
        }
    }
}


