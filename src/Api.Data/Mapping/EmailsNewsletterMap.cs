using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class EmailsNewsletterMap : IEntityTypeConfiguration<EmailsNewsletterEntity>
    {
        public void Configure(EntityTypeBuilder<EmailsNewsletterEntity> builder)
        {
            builder.ToTable("EmailsNewsletter");
            builder.HasKey(i => i.Id);
            builder.HasIndex(p => p.Nome);
            builder.HasIndex(p => p.TipoNewsletter);
            builder.HasIndex(p => p.DescricaoNewsletter);
            builder.Property(u => u.HTML).IsRequired().HasMaxLength(5000);
            builder.HasIndex(p => p.Ativo);
            builder.HasIndex(u => u.Pais);
        }
    }
}
