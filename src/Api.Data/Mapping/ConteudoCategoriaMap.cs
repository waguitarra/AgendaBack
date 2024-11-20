using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ConteudoCategoriaMap : IEntityTypeConfiguration<ConteudoCategoriaEntity>
    {
        public void Configure(EntityTypeBuilder<ConteudoCategoriaEntity> builder)
        {
            builder.ToTable("ConteudoCategoria");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Nome);
            builder.HasIndex(u => u.Tipo);
            builder.HasIndex(u => u.Descricao);
            builder.HasIndex(u => u.UrlImagens);
            builder.HasIndex(u => u.Ativo);

        }
    }
}


