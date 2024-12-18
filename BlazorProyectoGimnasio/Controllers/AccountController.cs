using Microsoft.AspNetCore.Mvc;
using Gimnasio.Data;
using Gimnasio.Models;

namespace Gimnasio.Controllers
{
    public class AccountController : Controller
    {
        private readonly GimnasioDbContext _context;

        public AccountController(GimnasioDbContext context)
        {
            _context = context;
        }

        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        public IActionResult Login(string email, string password)
        {
            // Verifica si los parámetros son válidos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "El email y la contraseña son obligatorios.";
                return View();
            }

            // Buscar usuario en la base de datos
            var usuario = _context.Usuarios
     .Where(u => u.Email == email && u.Contraseña == password)
     .Select(u => new
     {
         UsuarioID = u.UsuarioID,
         Rol = u.Rol ?? "Unknown" // Provide a default value if Rol is null
     })
     .FirstOrDefault();


            if (usuario != null)
            {
                // Almacenar datos en sesión
                HttpContext.Session.SetString("UsuarioID", usuario.UsuarioID.ToString());
                HttpContext.Session.SetString("Rol", usuario.Rol);

                // Redirigir según el rol
                return usuario.Rol switch
                {
                    "Administrador" => RedirectToAction("Index", "Home"),
                    "Entrenador" => RedirectToAction("EntrenadorHome", "Home"),
                    "Cliente" => RedirectToAction("ClienteHome", "Home"),
                    _ => RedirectToAction("Login")
                };
            }

            // Si las credenciales son incorrectas
            ViewBag.Error = "Email o contraseña incorrectos.";
            return View();
        }


        // GET: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Elimina la sesión
            return RedirectToAction("Login");
        }
    }
}

