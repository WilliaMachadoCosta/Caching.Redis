using Caching.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caching.Infra.Mapa
{
    internal class TaskMap : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("Tarefa");

            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Property(p => p.Title).HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Description).HasColumnType("varchar(200)");

            builder.Property(p => p.Priority).IsRequired();

            builder.Property(p => p.Completed).IsRequired();

            builder.Property(p => p.Deadline).IsRequired().HasColumnType("datetime");

            builder.HasData(TarefaSeedData.Seed());
        }


    }
}