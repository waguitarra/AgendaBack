using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class DenunciasImplementation : BaseRepository<DenunciasEntity>, IUDenunciasRepository
    {
        private DbSet<IUDenunciasRepository> _dataset;

        public DenunciasImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<IUDenunciasRepository>();
        }
    }
}
