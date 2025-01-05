using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            // Configuração básica
            builder.ToTable("Cliente");
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Nome);
            builder.HasIndex(c => c.Email);
            builder.HasIndex(c => c.Telefone);

            // Relacionamento com AgendaAgenteEntity
            builder.HasOne(c => c.AgendaAgente)
                   .WithMany(a => a.Clientes)
                   .HasForeignKey(c => c.AgendaAgenteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
