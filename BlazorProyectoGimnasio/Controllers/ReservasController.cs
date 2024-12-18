using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;

namespace Gimnasio.Controllers
{
    public class ReservasController : Controller
    {
        private readonly GimnasioDbContext _context;

        public ReservasController(GimnasioDbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public IActionResult Index()
        {
            var reservas = _context.Reservas
                                   .Include(r => r.Usuario)
                                   .Include(r => r.Clase)
                                   .ToList();
            return View(reservas);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            ViewBag.Clases = _context.Clases.Include(c => c.Entrenador).ToList();
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            ViewBag.Clases = _context.Clases.Include(c => c.Entrenador).ToList();
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var reserva = _context.Reservas.Find(id);
            if (reserva == null) return NotFound();

            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            ViewBag.Clases = _context.Clases.Include(c => c.Entrenador).ToList();
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Reserva reserva)
        {
            if (id != reserva.ReservaID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(reserva);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            ViewBag.Clases = _context.Clases.Include(c => c.Entrenador).ToList();
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var reserva = _context.Reservas
                                  .Include(r => r.Usuario)
                                  .Include(r => r.Clase)
                                  .FirstOrDefault(m => m.ReservaID == id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
