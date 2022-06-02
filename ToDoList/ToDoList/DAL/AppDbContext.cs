using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entity;

namespace ToDoList.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ToDo> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>(entity =>
            {
                entity.Property(todo => todo.Title).IsUnicode(false);
                entity.Property(todo => todo.Description).IsUnicode(false);
            });
        }
    }
}
