using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutosEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutosEntity> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(i => i.Id);
            builder.HasIndex(p => p.CategoriaId);
            builder.HasOne(p => p.User).WithMany(e => e.Produtos);
            builder.Property(c => c.TipoServicoId);
            builder.HasMany(p => p.ImagensP).WithOne(i => i.Produtos);
            builder.Property(u => u.Ativo);
            builder.Property(u => u.Idioma);
            builder.Property(u => u.Mapa);
            builder.Property(u => u.Endereco);
            builder.Property(u => u.Delete);
            builder.Property(u => u.Endereco);
            builder.Property(u => u.Mapa);

            builder.HasMany(p => p.Agente)
                .WithOne(a => a.Produto)
                .HasForeignKey(a => a.ProdutoId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
