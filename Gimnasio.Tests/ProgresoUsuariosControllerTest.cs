using Xunit;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;
using Gimnasio.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gimnasio.Tests.Controllers
{
    public class ProgresoUsuariosControllerTests
    {
        private readonly GimnasioDbContext _dbContext;
        private readonly ProgresoUsuariosController _controller;

        public ProgresoUsuariosControllerTests()
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

            _dbContext.ProgresoUsuarios.Add(new ProgresoUsuario
            {
                ProgresoID = 1,
                UsuarioID = 1,
                Fecha = System.DateTime.Now,
                Metrica = "Pecho",
                Valor = 95.5m
            });

            _dbContext.SaveChanges();

            // Inicializar el controlador
            _controller = new ProgresoUsuariosController(_dbContext);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfProgresos()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<List<ProgresoUsuario>>(result.Model);
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
            var nuevoProgreso = new ProgresoUsuario
            {
                ProgresoID = 2,
                UsuarioID = 1,
                Metrica = "Bíceps",
                Valor = 40.0m
            };

            // Act
            var result = _controller.Create(nuevoProgreso) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal(2, _dbContext.ProgresoUsuarios.Count());
        }

        [Fact]
        public void Create_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var nuevoProgreso = new ProgresoUsuario
            {
                ProgresoID = 2,
                UsuarioID = 1,
                Metrica = null, // Métrica inválida
                Valor = 40.0m
            };

            // Act
            var result = _controller.Create(nuevoProgreso) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.False(_controller.ModelState.IsValid);
        }

        [Fact]
        public void Delete_Get_ReturnsViewResult_WhenProgresoExists()
        {
            // Act
            var result = _controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<ProgresoUsuario>(result.Model);
            Assert.Equal(1, model.ProgresoID);
        }

        [Fact]
        public void DeleteConfirmed_RedirectsToIndex_WhenProgresoIsDeleted()
        {
            // Act
            var result = _controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Empty(_dbContext.ProgresoUsuarios);
        }
    }
}
