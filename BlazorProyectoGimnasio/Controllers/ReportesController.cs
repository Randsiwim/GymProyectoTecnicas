using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Gimnasio.Data;
using Gimnasio.Models;
using iText.IO.Font.Constants;


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

        // Descargar Reporte Contable en PDF
        public IActionResult DescargarReporteContable(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var reportes = _context.ReporteContable
                                   .Where(r => (!fechaInicio.HasValue || r.Fecha >= fechaInicio) &&
                                               (!fechaFin.HasValue || r.Fecha <= fechaFin))
                                   .OrderBy(r => r.Fecha)
                                   .ToList();

            using (var stream = new MemoryStream())
            {
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                document.Add(new Paragraph("Reporte Contable")
    .SetTextAlignment(TextAlignment.CENTER)
    .SetFontSize(18)
    .SetFont(iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD)));


                var table = new Table(4); // 4 columnas
                table.AddHeaderCell("Fecha");
                table.AddHeaderCell("Tipo");
                table.AddHeaderCell("Descripción");
                table.AddHeaderCell("Monto");

                foreach (var reporte in reportes)
                {
                    table.AddCell(reporte.Fecha.ToString("yyyy-MM-dd"));
                    table.AddCell(reporte.Tipo);
                    table.AddCell(reporte.Descripcion);
                    table.AddCell(reporte.Monto.ToString("C"));
                }

                document.Add(table);
                document.Close();

                var fileName = $"ReporteContable_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                return File(stream.ToArray(), "application/pdf", fileName);
            }
        }

        // Reporte de Matrícula
        public IActionResult ReporteMatricula()
        {
            var reporte = _context.ReporteMatricula
                                  .FromSqlRaw("SELECT * FROM ReporteMatricula")
                                  .ToList();
            return View(reporte);
        }

        // Descargar Reporte de Matrícula en PDF
        public IActionResult DescargarReporteMatricula()
        {
            var reporte = _context.ReporteMatricula
                                  .FromSqlRaw("SELECT * FROM ReporteMatricula")
                                  .ToList();

            using (var stream = new MemoryStream())
            {
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

               

                document.Add(new Paragraph("Reporte Contable")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(18)
                    .SetFont(iText.Kernel.Font.PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)));


                var table = new Table(2); // 2 columnas
                table.AddHeaderCell("Mes");
                table.AddHeaderCell("Matrículas");

                foreach (var item in reporte)
                {
                    table.AddCell(item.Mes);
                    table.AddCell(item.Matriculas.ToString());
                }

                document.Add(table);
                document.Close();

                var fileName = $"ReporteMatricula_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                return File(stream.ToArray(), "application/pdf", fileName);
            }
        }

        // Reporte de Clases Populares
        public IActionResult ReporteClasesPopulares()
        {
            var reporte = _context.ReporteClasesPopulares
                                  .FromSqlRaw("SELECT * FROM ReporteClasesPopulares")
                                  .ToList();
            return View(reporte);
        }

        // Descargar Reporte de Clases Populares en PDF
        public IActionResult DescargarReporteClasesPopulares()
        {
            var reporte = _context.ReporteClasesPopulares
                                  .FromSqlRaw("SELECT * FROM ReporteClasesPopulares")
                                  .ToList();

            using (var stream = new MemoryStream())
            {
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                document.Add(new Paragraph("Reporte Contable")
    .SetTextAlignment(TextAlignment.CENTER)
    .SetFontSize(18)
    .SetFont(iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD)));


                var table = new Table(3); // 3 columnas
                table.AddHeaderCell("Clase");
                table.AddHeaderCell("Horario");
                table.AddHeaderCell("Total Reservas");

                foreach (var item in reporte)
                {
                    table.AddCell(item.Clase);
                    table.AddCell(item.Horario.HasValue ? item.Horario.ToString() : "N/A");
                    table.AddCell(item.TotalReservas.ToString());
                }

                document.Add(table);
                document.Close();

                var fileName = $"ReporteClasesPopulares_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                return File(stream.ToArray(), "application/pdf", fileName);
            }
        }
    }
}

