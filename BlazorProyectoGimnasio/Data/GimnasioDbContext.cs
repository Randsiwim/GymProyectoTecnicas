using Microsoft.EntityFrameworkCore;
using Gimnasio.Models;

namespace Gimnasio.Data
{
    public class GimnasioDbContext : DbContext
    {
        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options) : base(options) { }

        // Tablas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Membresia> Membresias { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ProgresoUsuario> ProgresoUsuarios { get; set; }

        // Reportes (Vistas de solo lectura)
        public DbSet<ReporteContable> ReporteContable { get; set; }
        public DbSet<ReporteMatricula> ReporteMatricula { get; set; }
        public DbSet<ReporteClasesPopulares> ReporteClasesPopulares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar ReporteMatricula como vista
            modelBuilder.Entity<ReporteMatricula>(entity =>
            {
                entity.HasNoKey(); // Sin clave primaria
                entity.ToView("ReporteMatricula"); // Asociado a la vista en la base de datos
            });

            // Configurar ReporteClasesPopulares como vista
            modelBuilder.Entity<ReporteClasesPopulares>(entity =>
            {
                entity.HasNoKey(); // Sin clave primaria
                entity.ToView("ReporteClasesPopulares"); // Asociado a la vista en la base de datos
            });

            // Configurar ReporteContable como vista (si es una vista y no una tabla)
            modelBuilder.Entity<ReporteContable>(entity =>
            {
                entity.HasNoKey(); // Sin clave primaria
                entity.ToView("ReporteContable"); // Asociado a la vista en la base de datos
            });
        }
    }
}


