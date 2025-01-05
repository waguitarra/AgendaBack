using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class AgenteMap : IEntityTypeConfiguration<AgenteEntity>
    {
        public void Configure(EntityTypeBuilder<AgenteEntity> builder)
        {
            // Configurações básicas
            builder.ToTable("Agente");
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Nome);
            builder.HasIndex(u => u.Email);
            builder.HasIndex(u => u.Descricao);
            builder.Property(u => u.Imagem).HasColumnType("MEDIUMTEXT");
            builder.HasIndex(u => u.Ativo);

            // Relacionamento com User
            builder.HasOne(p => p.User)
                   .WithMany(e => e.Agente);

            // Relacionamento com Produto
            builder.HasOne(a => a.Produto)
                   .WithMany(p => p.Agente)
                   .HasForeignKey(a => a.ProdutoId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);
 
            // Relacionamento com AgendaAgenteEntity (um para muitos)
            builder.HasMany(a => a.AgendaAgente)
                   .WithOne(ag => ag.Agente)
                   .HasForeignKey(ag => ag.AgenteId) // Chave estrangeira em AgendaAgenteEntity
                   .OnDelete(DeleteBehavior.Restrict); // Impede exclusão em cascata


        }
    }
}
