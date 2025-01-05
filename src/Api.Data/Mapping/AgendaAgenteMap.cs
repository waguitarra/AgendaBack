using Domain.Entities.AgendaAgente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class AgendaAgenteMap : IEntityTypeConfiguration<AgendaAgenteEntity>
    {
        public void Configure(EntityTypeBuilder<AgendaAgenteEntity> builder)
        {
            // Define a tabela
            builder.ToTable("AgendaAgente");

            // Chave primária
            builder.HasKey(a => a.Id);

            // Ignora a propriedade Horarios
            builder.Ignore(a => a.Horarios);

            // Relacionamento um para um com AgenteEntity
            builder.HasOne(a => a.Agente)
                   .WithOne(ae => ae.AgendaAgente) // Propriedade correta em AgenteEntity
                   .HasForeignKey<AgendaAgenteEntity>(a => a.AgenteId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento um para muitos com ClienteEntity
            builder.HasMany(a => a.Clientes)
                   .WithOne(c => c.AgendaAgente)
                   .HasForeignKey(c => c.AgendaAgenteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
