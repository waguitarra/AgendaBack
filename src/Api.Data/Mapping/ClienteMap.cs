using Api.Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Nome);
            builder.HasIndex(u => u.Email);
            builder.HasIndex(u => u.Telefone);
            builder.HasIndex(u => u.Descricao);
            builder.HasIndex(u => u.UserId);
        }
    }
}
