using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gimnasio.Tests
{
    public class FacturasControllerTests
    {
        private readonly GimnasioDbContext _context;
        private readonly Mock<GimnasioDbContext> _mockContext;
        private readonly FacturasController _controller;

        public FacturasControllerTests()
        {
            // Configurar una base de datos en memoria
            var options = new DbContextOptionsBuilder<GimnasioDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;
            _context = new GimnasioDbContext(options);

            // Llenar la base de datos con datos iniciales
            _context.Usuarios.Add(new Usuario { UsuarioID = 1, Nombre = "Cliente 1", Rol = "Cliente" });
            _context.Facturas.Add(new Factura { FacturaID = 1, UsuarioID = 1, Monto = 100, Fecha = System.DateTime.Now });
            _context.SaveChanges();

            _controller = new FacturasController(_context);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfFacturas()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Factura>>(viewResult.Model);
            Assert.Single(model); // Debe haber una sola factura de prueba
        }

        [Fact]
        public void Create_Post_ValidModel_ReturnsRedirectToAction()
        {
            // Arrange
            var factura = new Factura { UsuarioID = 1, Monto = 150, Detalle = "Nueva Factura" };

            // Act
            var result = _controller.Create(factura);

            // Assert
            var redirectToAction = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToAction.ActionName);
        }

        [Fact]
        public void Create_Post_InvalidModel_ReturnsViewResult()
        {
            // Arrange
            var factura = new Factura { UsuarioID = 0, Monto = 0 };
            _controller.ModelState.AddModelError("UsuarioID", "Required");

            // Act
            var result = _controller.Create(factura);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Factura>(viewResult.Model);
        }
    }
}
