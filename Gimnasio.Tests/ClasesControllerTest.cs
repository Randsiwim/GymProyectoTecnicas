using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gimnasio.Tests.Controllers
{
    public class ClasesControllerTests
    {
        private readonly GimnasioDbContext _dbContext;
        private readonly ClasesController _controller;

        public ClasesControllerTests()
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
                Nombre = "Entrenador 1",
                Rol = "Entrenador",
                Email = "entrenador1@example.com", // Proporcionar Email requerido
                Contraseña = "password123"        // Proporcionar Contraseña requerida
            });
            _dbContext.Usuarios.Add(new Usuario
            {
                UsuarioID = 2,
                Nombre = "Entrenador 2",
                Rol = "Entrenador",
                Email = "entrenador2@example.com", // Proporcionar Email requerido
                Contraseña = "password123"        // Proporcionar Contraseña requerida
            });
            _dbContext.Clases.Add(new Clase
            {
                ClaseID = 1,
                Nombre = "Clase 1",
                EntrenadorID = 1,
                Cupo = 10,
                Horario = new System.TimeSpan(10, 0, 0)
            });
            _dbContext.SaveChanges();

            _controller = new ClasesController(_dbContext);
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfClases()
        {
            // Act
            var result = await _controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<System.Collections.Generic.List<Clase>>(result.Model);
            Assert.Single(model);
        }

        [Fact]
        public void Create_Get_ReturnsViewResult_WithDefaultValues()
        {
            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Clase>(result.Model);
            Assert.Equal(0, model.Cupo);
            Assert.Equal(System.TimeSpan.Zero, model.Horario);
        }

        [Fact]
        public void Create_Post_RedirectsToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var newClase = new Clase
            {
                ClaseID = 2,
                Nombre = "Clase 2",
                EntrenadorID = 1,
                Cupo = 20,
                Horario = new System.TimeSpan(12, 0, 0)
            };

            // Act
            var result = _controller.Create(newClase) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal(2, _dbContext.Clases.Count());
        }

        [Fact]
        public async Task Edit_Get_ReturnsViewResult_WhenClaseExists()
        {
            // Act
            var result = await _controller.Edit(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Clase>(result.Model);
            Assert.Equal(1, model.ClaseID);
        }

        [Fact]
        public async Task Edit_Post_RedirectsToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var claseToUpdate = _dbContext.Clases.First();
            claseToUpdate.Nombre = "Clase 1 Actualizada";

            // Act
            var result = await _controller.Edit(1, claseToUpdate) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal("Clase 1 Actualizada", _dbContext.Clases.First().Nombre);
        }

        [Fact]
        public async Task Delete_Get_ReturnsViewResult_WhenClaseExists()
        {
            // Act
            var result = await _controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Clase>(result.Model);
            Assert.Equal(1, model.ClaseID);
        }

        [Fact]
        public async Task DeleteConfirmed_RedirectsToIndex_WhenClaseIsDeleted()
        {
            // Act
            var result = await _controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Empty(_dbContext.Clases);
        }
    }
}
