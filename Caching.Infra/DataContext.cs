using Caching.Domain;
using Caching.Infra.Mapa;
using Microsoft.EntityFrameworkCore;

namespace Caching.Infra
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options) =>
        Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
        }

        public DbSet<TaskItem> TaskItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Tarefa");
        }
    }
}
