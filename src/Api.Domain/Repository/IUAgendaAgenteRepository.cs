using Api.Domain.Interfaces;
using Domain.Dtos.AgendaAgente;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Repository
{
    public interface IUAgendaAgenteRepository : IRepository<AgendaAgente>
    {
        Task<IEnumerable<AgendaAgente>> GetAllAgenteProdutoId(Guid ProdutoId, Guid AgenteId);
    }
}
