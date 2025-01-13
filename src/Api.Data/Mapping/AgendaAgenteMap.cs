using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class AgendaAgenteMap : IEntityTypeConfiguration<AgendaAgente>
    {
        public void Configure(EntityTypeBuilder<AgendaAgente> builder)
        {
            // Define a tabela
            builder.ToTable("agendaagente");
            builder.HasKey(u => u.Id);

            // Define a chave primária
            builder.HasKey(a => a.Id);

            // Relacionamento muitos para um com AgenteEntity
            builder.HasOne(a => a.Agente)
                   .WithMany(ae => ae.AgendaAgente)
                   .HasForeignKey(a => a.AgenteId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento muitos para um com ClienteEntity
            builder.HasOne(a => a.Cliente)
                   .WithMany(c => c.AgendaAgente) // Propriedade de navegação para a lista de agendas
                   .HasForeignKey(a => a.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
