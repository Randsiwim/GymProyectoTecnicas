using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model; // Aquí importamos el modelo Inventario
using proyectoGymBlazor.Views.Components.Pages;
using System.Collections.Generic;

namespace proyectoGymBlazor.Data
{
    public class GimnasioDbContext : DbContext
    {
        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Membresia> Membresias { get; set; }
        public DbSet<Clases> Clase { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<proyectoGymBlazor.Model.Inventario> Inventarios { get; set; } // Asegúrate de que sea del espacio de nombres correcto
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ProgresoUsuario> ProgresosUsuarios { get; set; }
    }
}

