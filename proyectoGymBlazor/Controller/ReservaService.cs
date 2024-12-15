using Microsoft.AspNetCore.Mvc;
using proyectoGymBlazor.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;

namespace proyectoGymBlazor.Services
{
    public class ReservasController : Controller
    {
        private readonly GimnasioDbContext _context;

        public ReservasController(GimnasioDbContext context)
        {
            _context = context;
        }

        // Listar todas las reservas
        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reserva.ToListAsync();
            return View(reservas);
        }

        // Detalles de una reserva específica
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reserva.FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // Crear una nueva reserva - Formulario GET
        public IActionResult Create()
        {
            return View();
        }

        // Crear una nueva reserva - Guardar datos POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,ClaseId,FechaReserva,TipoReserva")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // Editar una reserva existente - Formulario GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // Editar una reserva existente - Guardar cambios POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaId,UsuarioId,ClaseId,FechaReserva,TipoReserva")] Reserva reserva)
        {
            if (id != reserva.ReservaId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ReservaId)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // Eliminar una reserva - Confirmación GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reserva.FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // Eliminar una reserva - Acción POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.ReservaId == id);
        }
    }
}

