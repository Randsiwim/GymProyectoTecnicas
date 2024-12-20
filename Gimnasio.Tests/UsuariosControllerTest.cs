using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class UsuariosControllerTest
{
    private readonly UsuariosController _controller;
    private readonly Mock<GimnasioDbContext> _mockContext;
    private readonly Mock<DbSet<Usuario>> _mockDbSet;

    public UsuariosControllerTest()
    {
        var usuariosData = new List<Usuario>
        {
            new Usuario { UsuarioID = 1, Nombre = "Usuario 1", Rol = "Cliente" },
            new Usuario { UsuarioID = 2, Nombre = "Usuario 2", Rol = "Entrenador" }
        }.AsQueryable();

        _mockDbSet = new Mock<DbSet<Usuario>>();
        _mockDbSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(usuariosData.Provider);
        _mockDbSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(usuariosData.Expression);
        _mockDbSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(usuariosData.ElementType);
        _mockDbSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(usuariosData.GetEnumerator());

        _mockContext = new Mock<GimnasioDbContext>();
        _mockContext.Setup(c => c.Usuarios).Returns(_mockDbSet.Object);

        _controller = new UsuariosController(_mockContext.Object);
    }

    [Fact]
    public void Index_ReturnsViewResult_WithListOfUsuarios()
    {
        var result = _controller.Index();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Usuario>>(viewResult.Model);
        Assert.Equal(2, model.Count());
    }
}
