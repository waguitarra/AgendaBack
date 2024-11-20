using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class AgenteMap : IEntityTypeConfiguration<AgenteEntity>
    {
        public void Configure(EntityTypeBuilder<AgenteEntity> builder)
        {
            builder.ToTable("Agente");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Nome);
            builder.HasIndex(u => u.Email);
            builder.HasIndex(u => u.Descricao);
            builder.Property(u => u.Imagem).HasColumnType("MEDIUMTEXT");
            builder.HasIndex(u => u.Ativo);
            builder.HasOne(p => p.User).WithMany(e => e.Agente);

            builder.HasOne(a => a.Produto)
                  .WithMany(p => p.Agente)
                  .HasForeignKey(a => a.ProdutoId)
                  .IsRequired(false)
                  .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
