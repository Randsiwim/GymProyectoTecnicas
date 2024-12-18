using Microsoft.AspNetCore.Mvc;
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

        // GET: Clases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var clase = await _context.Clases
                .Include(c => c.Entrenador)
                .FirstOrDefaultAsync(m => m.ClaseID == id);

            if (clase == null) return NotFound();

            return View(clase);
        }

        // GET: Clases/Create
        public IActionResult Create()
        {
            ViewBag.Entrenadores = _context.Usuarios
                                           .Where(u => u.Rol == "Entrenador")
                                           .ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Horario,Cupo,EntrenadorID")] Clase clase)
        {
            // Depuración: Mostrar valores en la consola
            Console.WriteLine($"Nombre: {clase.Nombre}, Horario: {clase.Horario}, Cupo: {clase.Cupo}, EntrenadorID: {clase.EntrenadorID}");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(clase);
                    await _context.SaveChangesAsync();
                    Console.WriteLine("Clase guardada correctamente.");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al guardar: {ex.Message}");
                    ModelState.AddModelError("", "Error al guardar la clase.");
                }
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

            ViewBag.Entrenadores = _context.Usuarios.Where(u => u.Rol == "Entrenador").ToList();
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
                    // Manejo de valores nulos asignando valores por defecto
                    clase.Nombre = string.IsNullOrEmpty(clase.Nombre) ? "Clase sin nombre" : clase.Nombre;
                    clase.Horario = clase.Horario ?? TimeSpan.Zero;
                    clase.Cupo = clase.Cupo ?? 0;
                    clase.EntrenadorID = clase.EntrenadorID ?? 1;

                    _context.Update(clase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaseExists(clase.ClaseID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Entrenadores = _context.Usuarios.Where(u => u.Rol == "Entrenador").ToList();
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
            }
            return RedirectToAction(nameof(Index));
        }

        // Método privado para verificar si la clase existe
        private bool ClaseExists(int id)
        {
            return _context.Clases.Any(e => e.ClaseID == id);
        }
    }
}
