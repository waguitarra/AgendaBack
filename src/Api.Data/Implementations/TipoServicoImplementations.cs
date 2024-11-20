using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class TipoServicoImplementation : BaseRepository<TipoServicoEntity>, IUTipoServicoRepository
    {
        private DbSet<IUTipoServicoRepository> _dataset;

        public TipoServicoImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<IUTipoServicoRepository>();
        }
    }
}
