using proyectoGymBlazor.Data;
using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;

public class AuthService
{
    private readonly GimnasioDbContext _context;

    public AuthService(GimnasioDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> AuthenticateAsync(string username, string password)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == username && u.Contraseña == password);
    }

    public async Task<string> GetRoleAsync(Usuario usuario)
    {
        return usuario?.Rol; // Retorna el rol del usuario (Cliente, Entrenador, Administrador)
    }
}
