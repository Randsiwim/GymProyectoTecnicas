using Model.Model;
using proyectoGymBlazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ClaseService
{
    private readonly GimnasioDbContext _context;

    public ClaseService(GimnasioDbContext context)
    {
        _context = context;
    }

    public async Task<List<ClaseViewModel>> GetClasesAsync()
    {
        return await _context.Clases
            .Select(c => new ClaseViewModel
            {
                ClaseID = c.ClaseID,
                Nombre = c.Nombre,
                Horario = c.Horario,
                EntrenadorID = _context.Usuarios
                    .Where(u => u.UsuarioID == c.EntrenadorID)
                    .Select(u => u.Nombre)
                    .FirstOrDefault() ?? "Sin asignar"
            }).ToListAsync();
    }
}

public class ClaseViewModel
{
    public int ClaseID { get; set; }
    public string Nombre { get; set; }
    public DateTime Horario { get; set; }
    public string EntrenadorID { get; set; }
}


