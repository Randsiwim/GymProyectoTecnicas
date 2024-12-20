using Microsoft.EntityFrameworkCore;
using Gimnasio.Models;

namespace Gimnasio.Data
{
    public class GimnasioDbContext : DbContext
    {
        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options) : base(options) { }

        // Tablas
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Membresia> Membresias { get; set; }
        public virtual DbSet<Clase> Clases { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<ProgresoUsuario> ProgresoUsuarios { get; set; }

        // Reportes (Vistas de solo lectura)
        public virtual DbSet<ReporteContable> ReporteContable { get; set; }
        public virtual DbSet<ReporteMatricula> ReporteMatricula { get; set; }
        public virtual DbSet<ReporteClasesPopulares> ReporteClasesPopulares { get; set; }    



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

            // Configurar ReporteContable como vista
            modelBuilder.Entity<ReporteContable>(entity =>
            {
                entity.HasNoKey(); // Sin clave primaria
                entity.ToView("ReporteContable"); // Asociado a la vista en la base de datos
            });

            // Relación entre Reservas y Usuarios
            modelBuilder.Entity<Reserva>()
          .Property(r => r.FechaReserva)
          .HasColumnType("date"); 

            base.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);

            // Relación entre Reservas y Clases
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Clase)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClaseID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación entre Clases y Usuarios (Entrenador)
            modelBuilder.Entity<Clase>()
                .HasOne(c => c.Entrenador)
                .WithMany()
                .HasForeignKey(c => c.EntrenadorID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación entre Membresias y Usuarios
            modelBuilder.Entity<Membresia>()
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Membresias)
                .HasForeignKey(m => m.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación entre ProgresoUsuarios y Usuarios
            modelBuilder.Entity<ProgresoUsuario>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Progresos)
                .HasForeignKey(p => p.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación entre Facturas y Usuarios
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Usuario)
                .WithMany(u => u.Facturas)
                .HasForeignKey(f => f.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


