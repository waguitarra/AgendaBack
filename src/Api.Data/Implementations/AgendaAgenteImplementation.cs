using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Implementations
{
    public class AgendaAgenteImplementation : BaseRepository<AgendaAgente>, IUAgendaAgenteRepository
    {
        private DbSet<AgendaAgente> _dataset;

        public AgendaAgenteImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<AgendaAgente>();
        }

        public async Task<IEnumerable<AgendaAgente>> GetAllAgenteProdutoId(Guid produtoId, Guid agenteId)
        {
            return await _dataset
                .AsNoTracking()
                .Where(p => p.ProdutoId == produtoId && p.AgenteId == agenteId && !p.Cancelado)
                .ToListAsync();
        }

    }
}
