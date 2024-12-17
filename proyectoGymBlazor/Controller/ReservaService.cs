using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Data;
using proyectoGymBlazor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyectoGymBlazor.Services
{
    public class ReservaService
    {
        private readonly GimnasioDbContext _context;

        public ReservaService(GimnasioDbContext context)
        {
            _context = context;
        }

        // Obtener todas las reservas
        public async Task<List<Reserva>> GetReservasAsync()
        {
            return await _context.Reservas.ToListAsync();
        }

        // Obtener una reserva por ID
        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        // Agregar una nueva reserva
        public async Task AddReservaAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }

        // Actualizar una reserva existente
        public async Task UpdateReservaAsync(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }

        // Eliminar una reserva por ID
        public async Task DeleteReservaAsync(int id)
        {
            var reserva = await GetReservaByIdAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }
    }
}

