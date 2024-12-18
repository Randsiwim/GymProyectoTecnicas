using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;

namespace Gimnasio.Controllers
{
    public class FacturasController : Controller
    {
        private readonly GimnasioDbContext _context;

        public FacturasController(GimnasioDbContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public IActionResult Index()
        {
            var facturas = _context.Facturas
                                   .Include(f => f.Usuario)
                                   .ToList();
            return View(facturas);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol != null && u.Rol == "Cliente").ToList();
            return View();
        }

        // POST: Facturas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Factura factura)
        {
            if (ModelState.IsValid)
            {
                factura.Fecha = DateTime.Now; // Fecha actual al crear la factura
                _context.Facturas.Add(factura);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var factura = _context.Facturas.Find(id);
            if (factura == null) return NotFound();

            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View(factura);
        }

        // POST: Facturas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Factura factura)
        {
            if (id != factura.FacturaID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(factura);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var factura = _context.Facturas
                                  .Include(f => f.Usuario)
                                  .FirstOrDefault(f => f.FacturaID == id);
            if (factura == null) return NotFound();

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var factura = _context.Facturas.Find(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
