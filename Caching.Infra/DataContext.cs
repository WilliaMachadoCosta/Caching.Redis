using Caching.Domain;
using Caching.Infra.Mapa;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Caching.Infra
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options) =>
        Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }

        public DbSet<Tarefa> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Tarefa");
        }
    }
}
