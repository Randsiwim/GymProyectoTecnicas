using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Controllers;
using Gimnasio.Data;
using Gimnasio.Models;
using System.Linq;

namespace Gimnasio.Tests.Controllers
{
    public class AccountControllerTests
    {
        private readonly GimnasioDbContext _context;
        private readonly AccountController _controller;
        private readonly Mock<ISession> _sessionMock;

        public AccountControllerTests()
        {
            // Configuración del DbContext en memoria
            var options = new DbContextOptionsBuilder<GimnasioDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            _context = new GimnasioDbContext(options);

            // Insertar datos simulados
            _context.Usuarios.AddRange(
                new Usuario { UsuarioID = 1, Email = "admin@test.com", Contraseña = "1234", Rol = "Administrador" },
                new Usuario { UsuarioID = 2, Email = "entrenador@test.com", Contraseña = "1234", Rol = "Entrenador" },
                new Usuario { UsuarioID = 3, Email = "cliente@test.com", Contraseña = "1234", Rol = "Cliente" }
            );
            _context.SaveChanges();

            // Mock de la sesión
            _sessionMock = new Mock<ISession>();
            var httpContext = new DefaultHttpContext
            {
                Session = _sessionMock.Object
            };

            // Crear el controlador
            _controller = new AccountController(_context)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };
        }

        [Fact]
        public void Login_AdminUser_SuccessfulLogin()
        {
            // Act
            var result = _controller.Login("admin@test.com", "1234") as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public void Login_EntrenadorUser_SuccessfulLogin()
        {
            // Act
            var result = _controller.Login("entrenador@test.com", "1234") as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("EntrenadorHome", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public void Login_ClienteUser_SuccessfulLogin()
        {
            // Act
            var result = _controller.Login("cliente@test.com", "1234") as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ClienteHome", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public void Login_InvalidCredentials_ReturnsError()
        {
            // Act
            var result = _controller.Login("invalid@test.com", "wrongpassword") as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Email o contraseña incorrectos.", result.ViewData["Error"]);
        }

        [Fact]
        public void Login_EmptyCredentials_ReturnsError()
        {
            // Act
            var result = _controller.Login("", "") as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("El email y la contraseña son obligatorios.", result.ViewData["Error"]);
        }

        [Fact]
        public void Logout_ClearsSessionAndRedirects()
        {
            // Act
            var result = _controller.Logout() as RedirectToActionResult;

            // Assert
            _sessionMock.Verify(s => s.Clear(), Times.Once);
            Assert.NotNull(result);
            Assert.Equal("Login", result.ActionName);
        }
    }
}
