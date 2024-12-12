using Microsoft.EntityFrameworkCore;
using Model;
using proyectoGym;

using proyectoGymBlazor.Model;
using proyectoGymBlazor.Views.Components.Pages;
using System.Collections.Generic;
namespace proyectoGymBlazor.Data
{
    public class GimnasioDbContext : DbContext
    {
        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Membresias> Membresia { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ProgresoUsuario> ProgresosUsuarios { get; set; }

    }
}

