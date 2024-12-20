using Xunit;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;
using Gimnasio.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gimnasio.Tests.Controllers
{
    public class UsuariosControllerTests
    {
        private readonly GimnasioDbContext _dbContext;
        private readonly UsuariosController _controller;

        public UsuariosControllerTests()
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
                Nombre = "Usuario 1",
                Email = "usuario1@example.com",
                Contraseña = "password123",
                Rol = "Cliente"
            });

            _dbContext.SaveChanges();

            // Inicializar el controlador
            _controller = new UsuariosController(_dbContext);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfUsuarios()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<List<Usuario>>(result.Model);
            Assert.Single(model);
        }

        [Fact]
        public void Create_Get_ReturnsViewResult()
        {
            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Create_Post_RedirectsToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var nuevoUsuario = new Usuario
            {
                UsuarioID = 2,
                Nombre = "Usuario 2",
                Email = "usuario2@example.com",
                Contraseña = "password123",
                Rol = "Cliente"
            };

            // Act
            var result = _controller.Create(nuevoUsuario) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal(2, _dbContext.Usuarios.Count());
        }

        [Fact]
        public void Create_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var nuevoUsuario = new Usuario
            {
                UsuarioID = 2,
                Nombre = null, // Nombre inválido
                Email = "usuario2@example.com",
                Contraseña = "password123",
                Rol = "Cliente"
            };

            // Act
            var result = _controller.Create(nuevoUsuario) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.False(_controller.ModelState.IsValid);
        }

        [Fact]
        public async Task Edit_Get_ReturnsViewResult_WhenUsuarioExists()
        {
            // Act
            var result = await _controller.Edit(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Usuario>(result.Model);
            Assert.Equal(1, model.UsuarioID);
        }

        [Fact]
        public void Edit_Post_RedirectsToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var usuarioToUpdate = _dbContext.Usuarios.First();
            usuarioToUpdate.Nombre = "Usuario Actualizado";

            // Act
            var result = _controller.Edit(1, usuarioToUpdate) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal("Usuario Actualizado", _dbContext.Usuarios.First().Nombre);
        }

        [Fact]
        public void Edit_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var usuarioToUpdate = _dbContext.Usuarios.First();
            usuarioToUpdate.Nombre = null; // Nombre inválido

            // Act
            var result = _controller.Edit(1, usuarioToUpdate) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.False(_controller.ModelState.IsValid);
        }

        [Fact]
        public void Delete_Get_ReturnsViewResult_WhenUsuarioExists()
        {
            // Act
            var result = _controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Usuario>(result.Model);
            Assert.Equal(1, model.UsuarioID);
        }

        [Fact]
        public void DeleteConfirmed_RedirectsToIndex_WhenUsuarioIsDeleted()
        {
            // Act
            var result = _controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Empty(_dbContext.Usuarios);
        }
    }
}
