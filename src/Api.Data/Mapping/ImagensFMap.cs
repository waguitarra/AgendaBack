using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ImagensFMap : IEntityTypeConfiguration<ImagensFEntity>
    {
        public void Configure(EntityTypeBuilder<ImagensFEntity> builder)
        {
            builder.ToTable("ImagensF");

            builder.HasKey(i => i.Id);

            builder.HasIndex(p => p.CodigoImagem);

            builder.HasOne(p => p.FornecedorProdutos)
                .WithMany(e => e.ImagensF);
            // .IsRequired();
        }

    }
}
