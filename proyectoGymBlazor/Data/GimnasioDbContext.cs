using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Model;

namespace proyectoGymBlazor.Data
{
    public class GimnasioDbContext : DbContext
    {
        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Membresia> Membresias { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ProgresoUsuario> ProgresoUsuarios { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relaciones

            // Usuario -> Membresia (1:N)
            modelBuilder.Entity<Membresia>()
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Membresias)
                .HasForeignKey(m => m.UsuarioID);

            // Usuario -> Reserva (1:N)
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Reservas)
                .HasForeignKey(r => r.UsuarioID);

            // Clase -> Reserva (1:N)
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Clase)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClaseID);

            // Usuario -> Factura (1:N)
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Usuario)
                .WithMany(u => u.Facturas)
                .HasForeignKey(f => f.UsuarioID);

            // Usuario -> ProgresoUsuario (1:N)
            modelBuilder.Entity<ProgresoUsuario>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.ProgresosUsuario)
                .HasForeignKey(p => p.UsuarioID);

            base.OnModelCreating(modelBuilder);
        }
    }
}


