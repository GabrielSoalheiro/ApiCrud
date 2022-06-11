using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}