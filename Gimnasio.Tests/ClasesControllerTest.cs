using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class ClasesControllerTests
{
    private readonly ClasesController _controller;
    private readonly Mock<GimnasioDbContext> _mockContext;
    private readonly Mock<DbSet<Clase>> _mockDbSet;

    public ClasesControllerTests()
    {
        // Crear datos simulados
        var clasesData = new List<Clase>
        {
            new Clase { ClaseID = 1, Nombre = "Yoga", Cupo = 20, Entrenador = new Usuario { Nombre = "Entrenador1" } },
            new Clase { ClaseID = 2, Nombre = "Crossfit", Cupo = 15, Entrenador = new Usuario { Nombre = "Entrenador2" } }
        }.AsQueryable();

        // Crear un Mock de DbSet con datos
        _mockDbSet = new Mock<DbSet<Clase>>();
        _mockDbSet.As<IQueryable<Clase>>().Setup(m => m.Provider).Returns(clasesData.Provider);
        _mockDbSet.As<IQueryable<Clase>>().Setup(m => m.Expression).Returns(clasesData.Expression);
        _mockDbSet.As<IQueryable<Clase>>().Setup(m => m.ElementType).Returns(clasesData.ElementType);
        _mockDbSet.As<IQueryable<Clase>>().Setup(m => m.GetEnumerator()).Returns(clasesData.GetEnumerator());

        // Crear un Mock del contexto y configurar DbSet
        _mockContext = new Mock<GimnasioDbContext>();
        _mockContext.Setup(c => c.Clases).Returns(_mockDbSet.Object);

        // Inicializar el controlador
        _controller = new ClasesController(_mockContext.Object);
    }

    [Fact]
    public async Task Index_ReturnsViewResult_WithListOfClases()
    {
        // Act
        var result = await _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Clase>>(viewResult.Model);
        Assert.Equal(2, model.Count());
    }

    [Fact]
    public void Create_PostValidModel_RedirectsToIndex()
    {
        // Arrange
        var newClase = new Clase { Nombre = "Pilates", Cupo = 10 };

        // Act
        var result = _controller.Create(newClase);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }
}
