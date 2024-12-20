using Microsoft.AspNetCore.Mvc;
using Gimnasio.Data;
using Gimnasio.Models;
using Microsoft.EntityFrameworkCore;

namespace Gimnasio.Controllers
{
    public class MembresiasController : Controller
    {
        private readonly GimnasioDbContext _context;

        public MembresiasController(GimnasioDbContext context)
        {
            _context = context;
        }

        // GET: Membresias
        public IActionResult Index()
        {
            var membresias = _context.Membresias
                                     .Include(m => m.Usuario)
                                     .ToList();
            return View(membresias);
        }


        // GET: Membresias/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View();
        }

        // POST: Membresias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Membresia membresia)
        {
            // Validación para valores faltantes
            if (membresia.FechaInicio == default)
            {
                ModelState.AddModelError("FechaInicio", "La fecha de inicio es obligatoria.");
            }
            if (membresia.FechaFin == default || membresia.FechaFin <= membresia.FechaInicio)
            {
                ModelState.AddModelError("FechaFin", "La fecha de fin debe ser válida y posterior a la fecha de inicio.");
            }
            if (string.IsNullOrEmpty(membresia.Tipo))
            {
                ModelState.AddModelError("Tipo", "El tipo de membresía es obligatorio.");
            }
            if (ModelState.IsValid)
            {
                _context.Membresias.Add(membresia);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View(membresia);
        }

        // GET: Membresias/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var membresia = _context.Membresias.Find(id);
            if (membresia == null) return NotFound();

            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View(membresia);
        }

        // POST: Membresias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Membresia membresia)
        {
            if (id != membresia.MembresiaID) return NotFound();

            if (membresia.FechaFin <= membresia.FechaInicio)
            {
                ModelState.AddModelError("FechaFin", "La fecha de fin debe ser posterior a la fecha de inicio.");
            }

            if (ModelState.IsValid)
            {
                _context.Update(membresia);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View(membresia);
        }


        // GET: Membresias/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var membresia = _context.Membresias.Include(m => m.Usuario)
                                               .FirstOrDefault(m => m.MembresiaID == id);
            if (membresia == null) return NotFound();

            return View(membresia);
        }

        // POST: Membresias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var membresia = _context.Membresias.Find(id);
            if (membresia != null)
            {
                _context.Membresias.Remove(membresia);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}