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

        public virtual DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(x => x.Nome).IsUnicode(false);
                entity.Property(x => x.Artista).IsUnicode(false);
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.Property(x => x.Comentario).IsUnicode(false);
                entity.HasOne(x => x.Album).WithMany(y => y.Avaliacoes).HasForeignKey(x => x.IdAlbum).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
