using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class MensagensPMap : IEntityTypeConfiguration<MensagensPEntity>
    {
        public void Configure(EntityTypeBuilder<MensagensPEntity> builder)
        {
            builder.ToTable("MensagensP");

            builder.HasKey(i => i.Id);
            builder.HasIndex(p => p.ProdutosId);
            builder.HasIndex(p => p.IdProdutoUsuarioTroca);
            builder.HasIndex(p => p.Mensagens);
            builder.HasOne(p => p.User).WithMany(e => e.MensagensP);
            builder.HasOne(p => p.Produtos).WithMany(e => e.MensagensP);
            builder.HasIndex(p => p.MensagenLida);
            builder.Property(p => p.Imagem);
            // .IsRequired();

        }
    }
}
