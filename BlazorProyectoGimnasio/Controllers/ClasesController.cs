using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;

namespace Gimnasio.Controllers
{
    public class ClasesController : Controller
    {
        private readonly GimnasioDbContext _context;

        public ClasesController(GimnasioDbContext context)
        {
            _context = context;
        }


        // GET: Clases
        public async Task<IActionResult> Index()
        {
            var clases = await _context.Clases.Include(c => c.Entrenador).ToListAsync();
            return View(clases);
        }

        // GET: Clases/Create
        public IActionResult Create()
        {
            ViewBag.Entrenadores = _context.Usuarios
                                           .Where(u => u.Rol == "Entrenador")
                                           .ToList();

            // Inicializa el modelo con valores predeterminados
            var clase = new Clase
            {
                Horario = TimeSpan.Zero, // Horario predeterminado
                Cupo = 0 // Cupo predeterminado
            };

            return View(clase);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Clase clase)
        {
            if (_context.Clases.Any(c => c.ClaseID == clase.ClaseID))
            {
                ModelState.AddModelError("ClaseID", "El ID de la Clase ya existe. Ingresa un ID único.");
                ViewBag.Entrenadores = _context.Usuarios
                                               .Where(u => u.Rol == "Entrenador")
                                               .ToList();
                return View(clase);
            }

            if (ModelState.IsValid)
            {
                _context.Clases.Add(clase);
                _context.SaveChanges();
                TempData["Success"] = "Clase creada correctamente.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Entrenadores = _context.Usuarios.Where(u => u.Rol == "Entrenador").ToList();
            return View(clase);
        }



        // GET: Clases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var clase = await _context.Clases.FindAsync(id);
            if (clase == null) return NotFound();

            var entrenadores = _context.Usuarios
                                       .Where(u => u.Rol == "Entrenador")
                                       .ToList();

            if (!entrenadores.Any())
            {
                // Log para verificar si no hay entrenadores
                Console.WriteLine("No hay entrenadores disponibles para el dropdown.");
            }

            ViewData["EntrenadorID"] = new SelectList(
                entrenadores,
                "UsuarioID",
                "Nombre",
                clase.EntrenadorID);

            return View(clase);
        }

        // POST: Clases/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClaseID,Nombre,Horario,Cupo,EntrenadorID")] Clase clase)
        {
            if (id != clase.ClaseID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaseExists(clase.ClaseID)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["EntrenadorID"] = new SelectList(
                _context.Usuarios.Where(u => u.Rol == "Entrenador"), "UsuarioID", "Nombre", clase.EntrenadorID);

            return View(clase);
        }



        // GET: Clases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var clase = await _context.Clases
                .Include(c => c.Entrenador)
                .FirstOrDefaultAsync(m => m.ClaseID == id);

            if (clase == null) return NotFound();

            return View(clase);
        }

        // POST: Clases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            if (clase != null)
            {
                _context.Clases.Remove(clase);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Clase eliminada correctamente.";
            }
            return RedirectToAction(nameof(Index));
        }
        private bool ClaseExists(int id)
        {
            return _context.Clases.Any(e => e.ClaseID == id);
        }

    }
}
