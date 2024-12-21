using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Implementations
{
    public class AgenteProdutoImplementations : BaseRepository<AgenteProdutosEntity>, IUAgenteProdutoRepository
    {
        private DbSet<AgenteProdutosEntity> _dataset;

        public AgenteProdutoImplementations(MyContext context) : base(context)
        {
            _dataset = context.Set<AgenteProdutosEntity>();
        }

        public async Task<IEnumerable<AgenteProdutosEntity>> GetAllUserClientesProdutoId(Guid ProdutoId)
        {
            var response = await _dataset
                .Where(p => p.ProdutoId == ProdutoId) // Filtra por UserId e Ativo
                .ToListAsync();
            return response;
        }
    }
}
