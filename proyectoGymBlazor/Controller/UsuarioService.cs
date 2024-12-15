using proyectoGymBlazor.Model; 
using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Data; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyectoGymBlazor.Services
{
    public class UsuarioService
    {
        private readonly GimnasioDbContext _context;

        public UsuarioService(GimnasioDbContext context)
        {
            _context = context;
        }

        // Obtener todos los usuarios
        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // Obtener un usuario por ID
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        // Agregar un usuario
        public async Task AddUsuarioAsync(Usuario usuario)
        {
            usuario.FechaRegistro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        // Actualizar un usuario existente
        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        // Eliminar un usuario por ID
        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await GetUsuarioByIdAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
