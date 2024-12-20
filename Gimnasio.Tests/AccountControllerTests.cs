using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using Moq;

namespace Gimnasio.Tests.Controllers
{
    public class AccountControllerTests
    {
        private GimnasioDbContext _dbContext;
        private AccountController _controller;

        public AccountControllerTests()
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
                Email = "test@example.com",
                Contraseña = "password123",
                Rol = "Cliente"
            });
            _dbContext.SaveChanges();

            // Configurar el controlador
            _controller = new AccountController(_dbContext);

            // Simular HttpContext para sesión
            var mockHttpContext = new DefaultHttpContext();
            mockHttpContext.Session = new Mock<ISession>().Object;

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext
            };
        }

        [Fact]
        public void Login_Post_ReturnsErrorView_WhenEmailOrPasswordIsEmpty()
        {
            // Act
            var result = _controller.Login(string.Empty, string.Empty) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("El email y la contraseña son obligatorios.", _controller.ViewBag.Error);
        }

        [Fact]
        public void Login_Post_ReturnsErrorView_WhenCredentialsAreInvalid()
        {
            // Act
            var result = _controller.Login("wrong@example.com", "wrongpassword") as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Email o contraseña incorrectos.", _controller.ViewBag.Error);
        }

        [Fact]
        public void Login_Post_RedirectsToCorrectAction_WhenCredentialsAreValid()
        {
            // Act
            var result = _controller.Login("test@example.com", "password123") as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ClienteHome", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public void Logout_ClearsSession_AndRedirectsToLogin()
        {
            // Arrange
            var mockSession = new Mock<ISession>();
            _controller.HttpContext.Session = mockSession.Object;

            // Act
            var result = _controller.Logout() as RedirectToActionResult;

            // Assert
            mockSession.Verify(s => s.Clear(), Times.Once);
            Assert.NotNull(result);
            Assert.Equal("Login", result.ActionName);
        }
    }
}
