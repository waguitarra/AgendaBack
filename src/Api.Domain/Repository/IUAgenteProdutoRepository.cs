using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Api.Domain.Repository
{
    public interface IUAgenteProdutoRepository : IRepository<AgenteProdutosEntity>
    {
        Task<IEnumerable<AgenteProdutosEntity>> GetAllUserClientesProdutoId(Guid ProdutoId);
    }
}
