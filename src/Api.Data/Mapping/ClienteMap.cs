using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            // Configura��o b�sica
            builder.ToTable("Cliente");
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Nome);
            builder.HasIndex(c => c.Email);
            builder.HasIndex(c => c.Telefone);

            // Relacionamento um para muitos com AgendaAgenteEntity
            builder.HasMany(c => c.AgendaAgente) // Define o relacionamento
                   .WithOne(a => a.Cliente) // Propriedade de navega��o em AgendaAgenteEntity
                   .HasForeignKey(a => a.ClienteId) // Chave estrangeira em AgendaAgenteEntity
                   .OnDelete(DeleteBehavior.Cascade); // Exclus�o em cascata
        }
    }
}
