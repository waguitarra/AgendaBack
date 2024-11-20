using Api.Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class TermosResponsabilidadesMap : IEntityTypeConfiguration<TermosResponsabilidadesEntity>
    {
        public void Configure(EntityTypeBuilder<TermosResponsabilidadesEntity> builder)
        {
            builder.ToTable("TermosResponsabilidades");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Responsabilidades);
            builder.Property(u => u.Titulo);
            builder.Property(u => u.Ativo);
            builder.HasIndex(u => u.Pais);
        }

    }
}
