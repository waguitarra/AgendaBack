using System;
using System.Collections.Generic;
using System.Text;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class FornecedorProdutosMap : IEntityTypeConfiguration<FornecedorProdutosEntity>
    {
        public void Configure(EntityTypeBuilder<FornecedorProdutosEntity> builder)
        {
            builder.ToTable("FornecedorProdutos");
            builder.HasKey(i => i.Id);
            //builder.HasIndex(p => p.CategoriaId);
            builder.HasOne(p => p.UserFornecedor).WithMany(e => e.FornecedorProdutos);
            builder.HasMany(p => p.ImagensF).WithOne(i => i.FornecedorProdutos);
            builder.HasMany(p => p.CurtidasP).WithOne(c => c.FornecedorProdutos);
            builder.Property(u => u.Ativo);
            builder.Property(u => u.Delete);
        }
    }
}
