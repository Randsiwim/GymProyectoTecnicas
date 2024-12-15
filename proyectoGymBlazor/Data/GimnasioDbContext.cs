using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model; 
using proyectoGymBlazor.Views.Components.Pages;
using System.Collections.Generic;

namespace proyectoGymBlazor.Data
{
    public class GimnasioDbContext : DbContext
    {
        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Membresias> Membresias { get; set; }
        public DbSet<Clases> Clases { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<proyectoGymBlazor.Model.Inventario> Inventarios { get; set; } 
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<ProgresoUsuario> ProgresosUsuario { get; set; }


    }
}

