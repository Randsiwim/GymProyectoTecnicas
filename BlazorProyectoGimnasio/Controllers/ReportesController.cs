using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;



namespace Gimnasio.Controllers
{
    public class ReportesController : Controller
    {
        private readonly GimnasioDbContext _context;

        public ReportesController(GimnasioDbContext context)
        {
            _context = context;
        }

        // Reporte Contable: Ingresos vs Egresos
        public IActionResult ReporteContable(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var reportes = _context.ReporteContable
                                   .Where(r => (!fechaInicio.HasValue || r.Fecha >= fechaInicio) &&
                                               (!fechaFin.HasValue || r.Fecha <= fechaFin))
                                   .OrderBy(r => r.Fecha)
                                   .ToList();
            return View(reportes);
        }

        // Reporte de Matrícula
        public IActionResult ReporteMatricula()
        {
            var reporte = _context.ReporteMatricula
                                  .FromSqlRaw("SELECT * FROM ReporteMatricula")
                                  .ToList();
            return View(reporte);
        }

        // Reporte de Clases Populares
        public IActionResult ReporteClasesPopulares()
        {
            var reporte = _context.ReporteClasesPopulares
                                  .FromSqlRaw("SELECT * FROM ReporteClasesPopulares")
                                  .ToList();
            return View(reporte);
        }
    }
}
