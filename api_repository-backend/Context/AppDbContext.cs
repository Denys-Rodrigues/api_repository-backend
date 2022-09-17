using api_repository_backend.Model;
using Microsoft.EntityFrameworkCore;

namespace api_repository_backend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definição de propriedades
            modelBuilder.Entity<Produto>()
                .Property(v => v.Preco)
                .HasPrecision(10,2);
        }
    }
}
