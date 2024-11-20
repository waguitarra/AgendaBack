using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ControleRigadoresMap : IEntityTypeConfiguration<ControleRigadoresEntity>
    {
        public void Configure(EntityTypeBuilder<ControleRigadoresEntity> builder)
        {
            builder.ToTable("ControleRigadores");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Email);
            builder.Property(i => i.Password);
            builder.Property(i => i.Mac);
            builder.Property(i => i.Cabecario);
            builder.Property(i => i.Humidade);
            builder.Property(i => i.Temperatura);
            builder.Property(i => i.StatusBomba1);
            builder.Property(i => i.StatusBomba2);
            builder.Property(i => i.NivelTanque1);
            builder.Property(i => i.NivelTanque2);
            builder.Property(i => i.Fonte1);
            builder.Property(i => i.Fonte2);
            builder.Property(i => i.UserId);
            builder.HasOne(p => p.User).WithMany(e => e.ControleRigadores);


        }
    }
}
