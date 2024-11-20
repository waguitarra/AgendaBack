using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.TipoCategoria);
            builder.HasIndex(u => u.Descricao);
            builder.HasIndex(u => u.UrlImagens);
            builder.HasIndex(u => u.Ativo);
            builder.HasIndex(u => u.Tipo);
            builder.HasIndex(u => u.Pais);
        }
    }
}
