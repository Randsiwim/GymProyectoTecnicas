using Microsoft.EntityFrameworkCore;

namespace BlazorProyectoGimnasio.Data
{
    public class GimnasioDbContext : DbContext
    {
        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options) : base(options) { }

        // Define tus tablas (entidades)
        public DbSet<User> Users { get; set; }
        public DbSet<Membership> Memberships { get; set; }
    }

    // Ejemplo de entidad: User
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    // Ejemplo de entidad: Membership
    public class Membership
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
