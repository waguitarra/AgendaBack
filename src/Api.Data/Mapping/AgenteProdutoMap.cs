using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class AgenteProdutoMap
    {
        public void Configure(EntityTypeBuilder<AgenteProdutosEntity> builder)
        {
            builder.ToTable("AgenteProduto");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.ProdutoId);
            builder.HasIndex(u => u.AgenteId);
        }
    }
}
