using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ImagensPMap : IEntityTypeConfiguration<ImagensPEntity>
    {
        public void Configure(EntityTypeBuilder<ImagensPEntity> builder)
        {
            builder.ToTable("ImagensP");

            builder.HasKey(i => i.Id);

            builder.HasIndex(p => p.CodigoImagem);

            builder.HasOne(p => p.Produtos)
                   .WithMany(e => e.ImagensP);
            // .IsRequired();
        }

    }
}
