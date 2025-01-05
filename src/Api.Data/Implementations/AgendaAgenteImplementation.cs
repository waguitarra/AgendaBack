using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class AgendaAgenteImplementation : BaseRepository<AgendaAgenteEntity>, IUAgendaAgenteRepository
    {
        private DbSet<IUAgendaAgenteRepository> _dataset;

        public AgendaAgenteImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<IUAgendaAgenteRepository>();
        }
    }
}
