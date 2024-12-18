using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;
using Microsoft.AspNetCore.Mvc.Rendering; // Necesario para SelectList

namespace Gimnasio.Controllers
{
    public class EntrenadorController : Controller
    {
        private readonly GimnasioDbContext _context;

        public EntrenadorController(GimnasioDbContext context)
        {
            _context = context;
        }

        // GET: Entrenador/Index
        public IActionResult Index()
        {
            return View(); // Vista principal del Panel de Entrenador
        }

        // GET: Entrenador/EmitirFactura
        public IActionResult EmitirFactura()
        {
            // Cargar clientes como SelectList
            ViewBag.Clientes = _context.Usuarios
                .Where(u => u.Rol == "Cliente")
                .Select(u => new SelectListItem
                {
                    Value = u.UsuarioID.ToString(),
                    Text = u.Nombre
                }).ToList();

            return View();
        }

        // POST: Entrenador/EmitirFactura
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmitirFactura(Factura factura)
        {
            if (ModelState.IsValid)
            {
                factura.Fecha = DateTime.Now; // Fecha actual
                _context.Facturas.Add(factura);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Recargar clientes en caso de error
            ViewBag.Clientes = _context.Usuarios
                .Where(u => u.Rol == "Cliente")
                .Select(u => new SelectListItem
                {
                    Value = u.UsuarioID.ToString(),
                    Text = u.Nombre
                }).ToList();

            return View(factura);
        }

        // GET: Entrenador/GestionarClases
        public IActionResult GestionarClases()
        {
            var clases = _context.Clases
                .Include(c => c.Entrenador) // Cargar datos del entrenador
                .ToList();

            return View(clases);
        }

        // GET: Entrenador/VerReservas
        public IActionResult VerReservas()
        {
            var reservas = _context.Reservas
                .Include(r => r.Clase) // Incluir datos de la clase
                .Include(r => r.Usuario) // Incluir datos del cliente
                .ToList();

            return View(reservas);
        }
    }
}
