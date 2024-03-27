using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caching.Domain;

namespace Caching.Infra.Mapa
{
    internal class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");

            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Property(p => p.Titulo).HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Descricao).HasColumnType("varchar(200)");

            builder.Property(p => p.Prioridade).IsRequired();

            builder.Property(p => p.Concluida).IsRequired();

            builder.Property(p => p.DataLimite).IsRequired().HasColumnType("datetime");

            builder.HasData(TarefaSeedData.Seed());
        }


    }
}