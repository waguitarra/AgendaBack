using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CurtidasConteudosMap : IEntityTypeConfiguration<CurtidasConteudosEntity>
    {
        public void Configure(EntityTypeBuilder<CurtidasConteudosEntity> builder)
        {
            builder.ToTable("CurtidasConteudos");
            builder.HasKey(i => i.Id);
            builder.HasIndex(p => p.ConteudosId);
            builder.HasIndex(p => p.UserId);
            builder.HasOne(p => p.User).WithMany(e => e.CurtidasConteudos);
            builder.HasOne(p => p.Conteudos).WithMany(e => e.CurtidasConteudos);

        }
    }
}
