using Api.Domain.Entities;
using System;

namespace Domain.Entities
{
    public class AgenteProdutosEntity : BaseEntity
    {
        public bool Ativo { get; set; }
        public Guid AgenteId { get; set; }
        public Guid? ProdutoId { get; set; }
    }
}
