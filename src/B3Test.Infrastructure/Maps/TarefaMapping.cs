using B3Test.Domain.Entities;
using B3Test.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B3Test.Infrastructure.Maps
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas", B3TestContext.DEFAULT_SCHEMA);

            builder.HasKey(p => p.Id);
            builder.Ignore(b => b.DomainEvents);

            builder.Property(p => p.Descricao)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired();
        }
    }
}
