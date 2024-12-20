using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class MembresiasControllerTest
{
    private readonly MembresiasController _controller;
    private readonly Mock<GimnasioDbContext> _mockContext;
    private readonly Mock<DbSet<Membresia>> _mockDbSet;

    public MembresiasControllerTest()
    {
        var membresiasData = new List<Membresia>
        {
            new Membresia { MembresiaID = 1, Tipo = "Mensual", UsuarioID = 1, Estado = "Activa" },
            new Membresia { MembresiaID = 2, Tipo = "Anual", UsuarioID = 2, Estado = "Expirada" }
        }.AsQueryable();

        _mockDbSet = new Mock<DbSet<Membresia>>();
        _mockDbSet.As<IQueryable<Membresia>>().Setup(m => m.Provider).Returns(membresiasData.Provider);
        _mockDbSet.As<IQueryable<Membresia>>().Setup(m => m.Expression).Returns(membresiasData.Expression);
        _mockDbSet.As<IQueryable<Membresia>>().Setup(m => m.ElementType).Returns(membresiasData.ElementType);
        _mockDbSet.As<IQueryable<Membresia>>().Setup(m => m.GetEnumerator()).Returns(membresiasData.GetEnumerator());

        _mockContext = new Mock<GimnasioDbContext>();
        _mockContext.Setup(c => c.Membresias).Returns(_mockDbSet.Object);

        _controller = new MembresiasController(_mockContext.Object);
    }

    [Fact]
    public void Index_ReturnsViewResult_WithListOfMembresias()
    {
        var result = _controller.Index();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Membresia>>(viewResult.Model);
        Assert.Equal(2, model.Count());
    }

    [Fact]
    public void Create_PostValidModel_RedirectsToIndex()
    {
        var nuevaMembresia = new Membresia { Tipo = "Mensual", UsuarioID = 3, Estado = "Activa" };

        var result = _controller.Create(nuevaMembresia);

        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }
}

