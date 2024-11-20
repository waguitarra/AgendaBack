using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Sexo).IsRequired().HasMaxLength(11);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.Estado);
            builder.Property(u => u.CodEstado);
            builder.Property(u => u.Pais); ;
            builder.Property(u => u.Idioma);
            builder.Property(u => u.Latitude);
            builder.Property(u => u.Longitude);
            builder.Property(u => u.Tipo);
            builder.Property(u => u.ImagemLogin);
            builder.Property(u => u.TokenRedes);
            builder.HasMany(p => p.Produtos).WithOne(i => i.User);
            builder.HasMany(p => p.Agente).WithOne(i => i.User);
            builder.HasMany(p => p.Conteudos).WithOne(i => i.User);
            builder.Property(u => u.Ativo);
            builder.Property(u => u.Delete);
            builder.Property(u => u.UserLogado);
            builder.Property(u => u.EnviarEmail);
            builder.Property(u => u.TrocarSenha);
            builder.Property(u => u.TermosResponsabilidades) ;
        }
    }
}
