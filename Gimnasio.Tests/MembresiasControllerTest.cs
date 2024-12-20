using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;
using Gimnasio.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gimnasio.Tests.Controllers
{
    public class MembresiasControllerTests
    {
        private readonly GimnasioDbContext _dbContext;
        private readonly MembresiasController _controller;

        public MembresiasControllerTests()
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

            _dbContext.Membresias.Add(new Membresia
            {
                MembresiaID = 1,
                UsuarioID = 1,
                Tipo = "Mensual",
                FechaInicio = System.DateTime.Now,
                FechaFin = System.DateTime.Now.AddMonths(1),
                Estado = "Activa"
            });

            _dbContext.SaveChanges();

            // Inicializar el controlador
            _controller = new MembresiasController(_dbContext);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfMembresias()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<List<Membresia>>(result.Model);
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
            var nuevaMembresia = new Membresia
            {
                MembresiaID = 2,
                UsuarioID = 1,
                Tipo = "Anual",
                FechaInicio = System.DateTime.Now,
                FechaFin = System.DateTime.Now.AddYears(1),
                Estado = "Activa"
            };

            // Act
            var result = _controller.Create(nuevaMembresia) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal(2, _dbContext.Membresias.Count());
        }

        [Fact]
        public void Create_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var nuevaMembresia = new Membresia
            {
                MembresiaID = 2,
                UsuarioID = 1,
                Tipo = "Mensual",
                FechaInicio = System.DateTime.Now,
                FechaFin = System.DateTime.Now.AddDays(-1), // FechaFin inválida
                Estado = "Activa"
            };

            // Act
            var result = _controller.Create(nuevaMembresia) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.False(_controller.ModelState.IsValid);
        }

        [Fact]
        public void Edit_Get_ReturnsViewResult_WhenMembresiaExists()
        {
            // Act
            var result = _controller.Edit(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Membresia>(result.Model);
            Assert.Equal(1, model.MembresiaID);
        }

        [Fact]
        public void Edit_Post_RedirectsToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var membresiaToUpdate = _dbContext.Membresias.First();
            membresiaToUpdate.Tipo = "Anual";

            // Act
            var result = _controller.Edit(1, membresiaToUpdate) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal("Anual", _dbContext.Membresias.First().Tipo);
        }

        [Fact]
        public void Edit_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var membresiaToUpdate = _dbContext.Membresias.First();
            membresiaToUpdate.FechaFin = membresiaToUpdate.FechaInicio.AddDays(-1); // FechaFin inválida

            // Act
            var result = _controller.Edit(1, membresiaToUpdate) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.False(_controller.ModelState.IsValid);
        }

        [Fact]
        public void Delete_Get_ReturnsViewResult_WhenMembresiaExists()
        {
            // Act
            var result = _controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Membresia>(result.Model);
            Assert.Equal(1, model.MembresiaID);
        }

        [Fact]
        public void DeleteConfirmed_RedirectsToIndex_WhenMembresiaIsDeleted()
        {
            // Act
            var result = _controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Empty(_dbContext.Membresias);
        }
    }
}
