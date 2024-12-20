using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class ReservasControllerTest
{
    private readonly ReservasController _controller;
    private readonly Mock<GimnasioDbContext> _mockContext;
    private readonly Mock<DbSet<Reserva>> _mockDbSet;

    public ReservasControllerTest()
    {
        var reservasData = new List<Reserva>
        {
            new Reserva { ReservaID = 1, UsuarioID = 1, TipoReserva = "Clase", ClaseID = 1 },
            new Reserva { ReservaID = 2, UsuarioID = 2, TipoReserva = "Gimnasio" }
        }.AsQueryable();

        _mockDbSet = new Mock<DbSet<Reserva>>();
        _mockDbSet.As<IQueryable<Reserva>>().Setup(m => m.Provider).Returns(reservasData.Provider);
        _mockDbSet.As<IQueryable<Reserva>>().Setup(m => m.Expression).Returns(reservasData.Expression);
        _mockDbSet.As<IQueryable<Reserva>>().Setup(m => m.ElementType).Returns(reservasData.ElementType);
        _mockDbSet.As<IQueryable<Reserva>>().Setup(m => m.GetEnumerator()).Returns(reservasData.GetEnumerator());

        _mockContext = new Mock<GimnasioDbContext>();
        _mockContext.Setup(c => c.Reservas).Returns(_mockDbSet.Object);

        _controller = new ReservasController(_mockContext.Object);
    }

    [Fact]
    public void Index_ReturnsViewResult_WithListOfReservas()
    {
        var result = _controller.Index();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Reserva>>(viewResult.Model);
        Assert.Equal(2, model.Count());
    }
}
