using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class InventarioControllerTests
{
    private readonly InventarioController _controller;
    private readonly Mock<GimnasioDbContext> _mockContext;
    private readonly Mock<DbSet<Inventario>> _mockSet;

    public InventarioControllerTests()
    {
        var options = new DbContextOptionsBuilder<GimnasioDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var dbContext = new GimnasioDbContext(options);
        _mockContext = new Mock<GimnasioDbContext>(options);
        _mockSet = new Mock<DbSet<Inventario>>();

        _controller = new InventarioController(dbContext);
    }

    [Fact]
    public void Index_ReturnsViewResult_WithListOfInventarios()
    {
        // Arrange
        var inventarios = new List<Inventario>
        {
            new Inventario { EquipoID = 1, Nombre = "Cinta de Correr" },
            new Inventario { EquipoID = 2, Nombre = "Mancuernas" }
        }.AsQueryable();

        _mockSet.As<IQueryable<Inventario>>().Setup(m => m.Provider).Returns(inventarios.Provider);
        _mockSet.As<IQueryable<Inventario>>().Setup(m => m.Expression).Returns(inventarios.Expression);
        _mockSet.As<IQueryable<Inventario>>().Setup(m => m.ElementType).Returns(inventarios.ElementType);
        _mockSet.As<IQueryable<Inventario>>().Setup(m => m.GetEnumerator()).Returns(inventarios.GetEnumerator());

        _mockContext.Setup(db => db.Inventarios).Returns(_mockSet.Object);

        // Act
        var result = _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.IsAssignableFrom<IEnumerable<Inventario>>(viewResult.Model);
    }
}

