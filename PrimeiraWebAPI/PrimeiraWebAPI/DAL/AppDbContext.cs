using Microsoft.EntityFrameworkCore;
using PrimeiraWebAPI.Domain.Entity;

namespace PrimeiraWebAPI.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Album> Albuns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(x => x.Nome).IsUnicode(false);
                entity.Property(x => x.Artista).IsUnicode(false);
            });
        }
    }
}
