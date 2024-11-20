using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ImagensConteudosMap : IEntityTypeConfiguration<ImagensConteudosEntity>
    {
        public void Configure(EntityTypeBuilder<ImagensConteudosEntity> builder)
        {
            builder.ToTable("ImagensConteudos");

            builder.HasKey(i => i.Id);

            builder.HasIndex(p => p.CodigoImagem);

            builder.HasOne(p => p.Conteudos)
                   .WithMany(e => e.ImagensConteudos);
         
        }

    }
}
