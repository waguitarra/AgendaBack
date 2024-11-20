using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserFornecedorMap : IEntityTypeConfiguration<UserFornecedorEntity>
    {
        public void Configure(EntityTypeBuilder<UserFornecedorEntity> builder)
        {
            builder.ToTable("UserFornecedor");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.NomeEmpresa).IsRequired().HasMaxLength(200);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.Property(u => u.CodRegistroEmpresas).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Endereco);
            builder.Property(u => u.Numero);
            builder.Property(u => u.Estado);
            builder.Property(u => u.CodEstado);
            builder.Property(u => u.Latitude);
            builder.Property(u => u.Longitude);
            builder.Property(u => u.LogoTipo);
            builder.Property(u => u.Telefone);
            builder.Property(u => u.WhatsApp);
            builder.HasMany(p => p.FornecedorProdutos).WithOne(i => i.UserFornecedor);
            builder.Property(u => u.Ativo);
            builder.Property(u => u.Delete);
        }
    }
}
