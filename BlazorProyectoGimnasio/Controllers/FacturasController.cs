﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;
using System.Text;
using System.Globalization;
using System.IO;

namespace Gimnasio.Controllers
{
    public class FacturasController : Controller
    {
        private readonly GimnasioDbContext _context;
        private readonly string csvPath;

        public FacturasController(GimnasioDbContext context)
        {
            _context = context;

            // Ruta del archivo CSV en wwwroot
            csvPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "facturas.csv");
        }

        // GET: Facturas
        public IActionResult Index()
        {
            var facturas = _context.Facturas.Include(f => f.Usuario).ToList();
            return View(facturas);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Factura factura)
        {
            if (ModelState.IsValid)
            {
                factura.Fecha = DateTime.Now;

                // Guardar en la base de datos
                _context.Facturas.Add(factura);
                _context.SaveChanges();

                // Guardar en CSV
                AppendFacturaToCSV(factura);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Factura factura)
        {
            if (id != factura.FacturaID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(factura);
                _context.SaveChanges();

                // Reescribir CSV
                RewriteFacturasToCSV();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = _context.Usuarios.Where(u => u.Rol == "Cliente").ToList();
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var factura = _context.Facturas.Include(f => f.Usuario).FirstOrDefault(f => f.FacturaID == id);
            if (factura == null) return NotFound();

            return View(factura);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var factura = _context.Facturas.Find(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                _context.SaveChanges();

                // Reescribir CSV
                RewriteFacturasToCSV();
            }

            return RedirectToAction(nameof(Index));
        }

        // Método para agregar una factura al archivo CSV
        private void AppendFacturaToCSV(Factura factura)
        {
            bool fileExists = System.IO.File.Exists(csvPath);

            using (var writer = new StreamWriter(csvPath, append: true))
            {
                // Si el archivo no existe, escribe el encabezado
                if (!fileExists)
                {
                    writer.WriteLine("FacturaID,UsuarioID,Monto,Detalle,Fecha");
                }

                // Agregar la nueva factura
                writer.WriteLine($"{factura.FacturaID},{factura.UsuarioID},{factura.Monto.ToString(CultureInfo.InvariantCulture)},{factura.Detalle},{factura.Fecha:yyyy-MM-dd}");
            }
        }

        // Método para reescribir todas las facturas al CSV
        private void RewriteFacturasToCSV()
        {
            var facturas = _context.Facturas.ToList();
            var sb = new StringBuilder();
            sb.AppendLine("FacturaID,UsuarioID,Monto,Detalle,Fecha");

            foreach (var f in facturas)
            {
                sb.AppendLine($"{f.FacturaID},{f.UsuarioID},{f.Monto.ToString(CultureInfo.InvariantCulture)},{f.Detalle},{f.Fecha:yyyy-MM-dd}");
            }

            System.IO.File.WriteAllText(csvPath, sb.ToString());
        }
    }
}
