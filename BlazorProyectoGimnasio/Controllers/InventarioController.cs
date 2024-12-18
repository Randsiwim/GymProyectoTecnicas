using Microsoft.AspNetCore.Mvc;
using Gimnasio.Data;
using Gimnasio.Models;

namespace Gimnasio.Controllers
{
    public class InventarioController : Controller
    {
        private readonly GimnasioDbContext _context;

        public InventarioController(GimnasioDbContext context)
        {
            _context = context;
        }

        // GET: Inventario
        public IActionResult Index()
        {
            var inventario = _context.Inventarios.ToList();
            return View(inventario);
        }

        // GET: Inventario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inventario equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Inventarios.Add(equipo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: Inventario/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var equipo = _context.Inventarios.Find(id);
            if (equipo == null) return NotFound();

            return View(equipo);
        }

        // POST: Inventario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Inventario equipo)
        {
            if (id != equipo.EquipoID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(equipo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: Inventario/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var equipo = _context.Inventarios.Find(id);
            if (equipo == null) return NotFound();

            return View(equipo);
        }

        // POST: Inventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var equipo = _context.Inventarios.Find(id);
            if (equipo != null)
            {
                _context.Inventarios.Remove(equipo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
