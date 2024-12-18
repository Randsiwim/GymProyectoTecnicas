using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;

namespace Gimnasio.Controllers
{
    public class ProgresoUsuariosController : Controller
    {
        private readonly GimnasioDbContext _context;

        public ProgresoUsuariosController(GimnasioDbContext context)
        {
            _context = context;
        }

        // GET: ProgresoUsuarios
        public IActionResult Index()
        {
            var progresos = _context.ProgresoUsuarios
                                    .Include(p => p.Usuario)
                                    .ToList();
            return View(progresos);
        }

        // GET: ProgresoUsuarios/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View();
        }

        // POST: ProgresoUsuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProgresoUsuario progreso)
        {
            if (ModelState.IsValid)
            {
                progreso.Fecha = DateTime.Now; // Fecha actual al registrar el progreso
                _context.ProgresoUsuarios.Add(progreso);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View(progreso);
        }

        // GET: ProgresoUsuarios/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var progreso = _context.ProgresoUsuarios
                                   .Include(p => p.Usuario)
                                   .FirstOrDefault(m => m.ProgresoID == id);
            if (progreso == null) return NotFound();

            return View(progreso);
        }

        // POST: ProgresoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var progreso = _context.ProgresoUsuarios.Find(id);
            if (progreso != null)
            {
                _context.ProgresoUsuarios.Remove(progreso);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
