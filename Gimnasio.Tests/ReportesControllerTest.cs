/*using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class ReportesControllerTest
{
    private readonly ReportesController _controller;
    private readonly Mock<GimnasioDbContext> _mockContext;

    public ReportesControllerTest()
    {
        _mockContext = new Mock<GimnasioDbContext>();
        _controller = new ReportesController(_mockContext.Object);
    }

   [Fact]
public void ReporteContable_ValidDates_ReturnsViewResultWithReportes()
{
    // Arrange
    var mockContext = new Mock<GimnasioDbContext>();
    var reportes = new List<ReporteContable>
    {
        new ReporteContable { ReporteID = 1, Fecha = DateTime.Now, Tipo = "Ingreso", Monto = 5000 },
        new ReporteContable { ReporteID = 2, Fecha = DateTime.Now, Tipo = "Egreso", Monto = 3000 }
    }.AsQueryable();

    var mockDbSet = new Mock<DbSet<ReporteContable>>();
    mockDbSet.As<IQueryable<ReporteContable>>().Setup(m => m.Provider).Returns(reportes.Provider);
    mockDbSet.As<IQueryable<ReporteContable>>().Setup(m => m.Expression).Returns(reportes.Expression);
    mockDbSet.As<IQueryable<ReporteContable>>().Setup(m => m.ElementType).Returns(reportes.ElementType);
    mockDbSet.As<IQueryable<ReporteContable>>().Setup(m => m.GetEnumerator()).Returns(reportes.GetEnumerator());

    mockContext.Setup(c => c.ReporteContable).Returns(mockDbSet.Object);

    var controller = new ReportesController(mockContext.Object);

    // Act
    var result = controller.ReporteContable(DateTime.Now.AddDays(-1), DateTime.Now) as ViewResult;

    // Assert
    Assert.NotNull(result);
    var model = Assert.IsAssignableFrom<IEnumerable<ReporteContable>>(result.Model);
    Assert.Equal(2, model.Count());
}

}

    */