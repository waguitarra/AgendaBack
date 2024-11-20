using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ConteudosMap : IEntityTypeConfiguration<ConteudosEntity>
    {
        public void Configure(EntityTypeBuilder<ConteudosEntity> builder)
        {
            builder.ToTable("Conteudos");
            builder.HasKey(u => u.Id);
            builder.HasIndex(p => p.IdConteudoCategoria);
            builder.HasIndex(u => u.NomeConteudo);
            builder.Property(u => u.Descricao).IsRequired().HasMaxLength(5000);
            builder.HasIndex(u => u.VideoRelacionado);
            builder.HasIndex(u => u.Json);
            builder.HasIndex(u => u.TotalCurtidas);
            builder.HasOne(p => p.User).WithMany(e => e.Conteudos);

        }
    }
}
