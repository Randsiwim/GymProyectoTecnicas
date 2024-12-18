using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class EntrenadorControllerTest
{
    private readonly EntrenadorController _controller;
    private readonly Mock<GimnasioDbContext> _mockContext;
    private readonly Mock<DbSet<Usuario>> _mockDbSet;

    public EntrenadorControllerTest()
    {
        // Crear datos simulados
        var entrenadoresData = new List<Usuario>
        {
            new Usuario { UsuarioID = 1, Nombre = "Entrenador 1", Rol = "Entrenador" },
            new Usuario { UsuarioID = 2, Nombre = "Entrenador 2", Rol = "Entrenador" }
        }.AsQueryable();

        // Simular DbSet<Usuario> con IQueryable
        _mockDbSet = new Mock<DbSet<Usuario>>();
        _mockDbSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(entrenadoresData.Provider);
        _mockDbSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(entrenadoresData.Expression);
        _mockDbSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(entrenadoresData.ElementType);
        _mockDbSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(entrenadoresData.GetEnumerator());

        // Mock del GimnasioDbContext
        _mockContext = new Mock<GimnasioDbContext>();
        _mockContext.Setup(c => c.Usuarios).Returns(_mockDbSet.Object);

        // Inicializar el controlador
        _controller = new EntrenadorController(_mockContext.Object);
    }

    [Fact]
    public void Index_ReturnsViewResult_WithListOfEntrenadores()
    {
        // Act
        var result = _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Usuario>>(viewResult.Model);
        Assert.Equal(2, model.Count());
    }

    [Fact]
    public void Create_PostValidModel_RedirectsToIndex()
    {
        // Arrange
        var newEntrenador = new Usuario { Nombre = "Entrenador 3", Rol = "Entrenador" };

        // Act
        var result = _controller.Create(newEntrenador);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }
}
