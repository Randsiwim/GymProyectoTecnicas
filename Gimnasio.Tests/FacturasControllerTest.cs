using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Gimnasio.Controllers;

using Microsoft.EntityFrameworkCore;
using Xunit;
using Gimnasio.Data;
using Gimnasio.Models;
using Gimnasio.Controllers;

using Moq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Gimnasio.Tests.Controllers
{
    public class FacturasControllerTests
    {
        private readonly GimnasioDbContext _dbContext;
        private readonly FacturasController _controller;

        public FacturasControllerTests()
        {
            // Configurar DbContext con base de datos en memoria
            var options = new DbContextOptionsBuilder<GimnasioDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dbContext = new GimnasioDbContext(options);

            // Agregar datos iniciales
            _dbContext.Usuarios.Add(new Usuario
            {
                UsuarioID = 1,
                Nombre = "Cliente 1",
                Rol = "Cliente",
                Email = "cliente1@example.com",
                Contraseña = "password123"
            });

            _dbContext.Facturas.Add(new Factura
            {
                FacturaID = 1,
                UsuarioID = 1,
                Monto = 100.00m,
                Detalle = "Factura inicial",
                Fecha = System.DateTime.Now
            });

            _dbContext.SaveChanges();

            // Configurar TempData usando un Mock
            var tempDataMock = new Mock<ITempDataDictionary>();

            // Inicializar el controlador
            _controller = new FacturasController(_dbContext)
            {
                TempData = tempDataMock.Object
            };
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfFacturas()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<List<Factura>>(result.Model);
            Assert.Single(model);
        }

        [Fact]
        public void Create_Get_ReturnsViewResult()
        {
            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.ViewData.ContainsKey("Clientes"));
        }

        [Fact]
        public void Create_Post_RedirectsToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var nuevaFactura = new Factura
            {
                FacturaID = 2,
                UsuarioID = 1,
                Monto = 200.50m,
                Detalle = "Nueva factura"
            };

            // Act
            var result = _controller.Create(nuevaFactura) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal(2, _dbContext.Facturas.Count());
        }

        [Fact]
        public void Edit_Get_ReturnsViewResult_WhenFacturaExists()
        {
            // Act
            var result = _controller.Edit(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Factura>(result.Model);
            Assert.Equal(1, model.FacturaID);
        }

        [Fact]
        public void Edit_Post_RedirectsToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var facturaToUpdate = _dbContext.Facturas.First();
            facturaToUpdate.Detalle = "Factura actualizada";

            // Act
            var result = _controller.Edit(1, facturaToUpdate) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal("Factura actualizada", _dbContext.Facturas.First().Detalle);
        }

        [Fact]
        public void Delete_Get_ReturnsViewResult_WhenFacturaExists()
        {
            // Act
            var result = _controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Factura>(result.Model);
            Assert.Equal(1, model.FacturaID);
        }

        [Fact]
        public void DeleteConfirmed_RedirectsToIndex_WhenFacturaIsDeleted()
        {
            // Act
            var result = _controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Empty(_dbContext.Facturas);
        }
    }
}
