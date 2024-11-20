using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class DenunciaProdutoUsuarioMap : IEntityTypeConfiguration<DenunciaProdutoUsuarioEntity>
    {

        public void Configure(EntityTypeBuilder<DenunciaProdutoUsuarioEntity> builder)
        {
            builder.ToTable("DenunciaProdutoUsuario");
            builder.HasKey(u => u.Id);
            builder.HasIndex(p => p.ProdutosId);
            builder.HasIndex(p => p.UserId);
            builder.HasOne(p => p.User).WithMany(e => e.DenunciaProdutoUsuario);
            builder.HasOne(p => p.Produtos).WithMany(e => e.DenunciaProdutoUsuario);
            builder.HasOne(p => p.Denuncias).WithMany(d => d.DenunciaProdutoUsuario);
        }
    }
}
