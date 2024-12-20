using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class ProgresoUsuariosControllerTest
{
    private readonly ProgresoUsuariosController _controller;
    private readonly Mock<GimnasioDbContext> _mockContext;
    private readonly Mock<DbSet<ProgresoUsuario>> _mockDbSet;

    public ProgresoUsuariosControllerTest()
    {
        var progresoData = new List<ProgresoUsuario>
        {
            new ProgresoUsuario { ProgresoID = 1, UsuarioID = 1, Metrica = "Peso", Valor = 75.5m },
            new ProgresoUsuario { ProgresoID = 2, UsuarioID = 2, Metrica = "Grasa", Valor = 20.5m }
        }.AsQueryable();

        _mockDbSet = new Mock<DbSet<ProgresoUsuario>>();
        _mockDbSet.As<IQueryable<ProgresoUsuario>>().Setup(m => m.Provider).Returns(progresoData.Provider);
        _mockDbSet.As<IQueryable<ProgresoUsuario>>().Setup(m => m.Expression).Returns(progresoData.Expression);
        _mockDbSet.As<IQueryable<ProgresoUsuario>>().Setup(m => m.ElementType).Returns(progresoData.ElementType);
        _mockDbSet.As<IQueryable<ProgresoUsuario>>().Setup(m => m.GetEnumerator()).Returns(progresoData.GetEnumerator());

        _mockContext = new Mock<GimnasioDbContext>();
        _mockContext.Setup(c => c.ProgresoUsuarios).Returns(_mockDbSet.Object);

        _controller = new ProgresoUsuariosController(_mockContext.Object);
    }

    [Fact]
    public void Index_ReturnsViewResult_WithListOfProgresos()
    {
        var result = _controller.Index();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<ProgresoUsuario>>(viewResult.Model);
        Assert.Equal(2, model.Count());
    }
}
