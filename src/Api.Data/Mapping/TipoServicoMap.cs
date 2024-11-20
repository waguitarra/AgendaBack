using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class TipoServicoMap : IEntityTypeConfiguration<TipoServicoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoServicoEntity> builder)
        {
            builder.ToTable("TipoServico");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.TipoCategoria);
            builder.Property(i => i.Descricao);
            builder.HasIndex(u => u.Ativo);
            builder.HasIndex(u => u.Tipo);
            builder.HasIndex(u => u.Pais);
        }
    }
}
