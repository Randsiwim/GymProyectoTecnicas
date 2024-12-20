using Xunit;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;
using Gimnasio.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gimnasio.Tests.Controllers
{
    public class ReservasControllerTests
    {
        private readonly GimnasioDbContext _dbContext;
        private readonly ReservasController _controller;

        public ReservasControllerTests()
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

            _dbContext.Clases.Add(new Clase
            {
                ClaseID = 1,
                Nombre = "Clase 1",
                EntrenadorID = 1,
                Horario = new System.TimeSpan(10, 0, 0),
                Cupo = 10
            });

            _dbContext.Reservas.Add(new Reserva
            {
                ReservaID = 1,
                UsuarioID = 1,
                ClaseID = 1,
                FechaReserva = System.DateTime.Now,
                TipoReserva = "Individual"
            });

            _dbContext.SaveChanges();

            // Inicializar el controlador
            _controller = new ReservasController(_dbContext);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfReservas()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<List<Reserva>>(result.Model);
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
            Assert.True(result.ViewData.ContainsKey("Clases"));
        }

        [Fact]
        public void Create_Post_RedirectsToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var nuevaReserva = new Reserva
            {
                ReservaID = 2,
                UsuarioID = 1,
                ClaseID = 1,
                FechaReserva = System.DateTime.Now,
                TipoReserva = "Grupal"
            };

            // Act
            var result = _controller.Create(nuevaReserva) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal(2, _dbContext.Reservas.Count());
        }

        [Fact]
        public void Create_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var nuevaReserva = new Reserva
            {
                ReservaID = 2,
                UsuarioID = 1,
                ClaseID = 1,
                FechaReserva = System.DateTime.Now,
                TipoReserva = null // TipoReserva inválido
            };

            // Act
            var result = _controller.Create(nuevaReserva) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.False(_controller.ModelState.IsValid);
        }

        [Fact]
        public void Edit_Get_ReturnsViewResult_WhenReservaExists()
        {
            // Act
            var result = _controller.Edit(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Reserva>(result.Model);
            Assert.Equal(1, model.ReservaID);
        }

        [Fact]
        public void Edit_Post_RedirectsToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var reservaToUpdate = _dbContext.Reservas.First();
            reservaToUpdate.TipoReserva = "Grupal";

            // Act
            var result = _controller.Edit(1, reservaToUpdate) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Equal("Grupal", _dbContext.Reservas.First().TipoReserva);
        }

        [Fact]
        public void Edit_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var reservaToUpdate = _dbContext.Reservas.First();
            reservaToUpdate.TipoReserva = null; // TipoReserva inválido

            // Act
            var result = _controller.Edit(1, reservaToUpdate) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.False(_controller.ModelState.IsValid);
        }

        [Fact]
        public void Delete_Get_ReturnsViewResult_WhenReservaExists()
        {
            // Act
            var result = _controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Reserva>(result.Model);
            Assert.Equal(1, model.ReservaID);
        }

        [Fact]
        public void DeleteConfirmed_RedirectsToIndex_WhenReservaIsDeleted()
        {
            // Act
            var result = _controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(nameof(_controller.Index), result.ActionName);
            Assert.Empty(_dbContext.Reservas);
        }
    }
}
