using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class DenunciasMap : IEntityTypeConfiguration<DenunciasEntity>
    {
        public void Configure(EntityTypeBuilder<DenunciasEntity> builder)
        {
            builder.ToTable("Denuncias");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.TipoDenuncias);
            builder.HasIndex(u => u.Descricao);

        }
    }
}
