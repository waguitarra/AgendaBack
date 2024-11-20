using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CurtidasPMap : IEntityTypeConfiguration<CurtidasPEntity>
    {
        public void Configure(EntityTypeBuilder<CurtidasPEntity> builder)
        {
            builder.ToTable("CurtidasP");
            builder.HasKey(i => i.Id);
            builder.HasIndex(p => p.ProdutosId);
            builder.HasIndex(p => p.UserId);
            builder.HasOne(p => p.User).WithMany(e => e.CurtidasP);
            builder.HasOne(p => p.Produtos).WithMany(e => e.CurtidasP);

        }
    }
}
