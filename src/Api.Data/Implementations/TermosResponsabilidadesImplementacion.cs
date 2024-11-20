using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class TermosResponsabilidadesImplementation : BaseRepository<TermosResponsabilidadesEntity>, IUTermosResponsabilidadesRepository
    {
        private DbSet<IUTermosResponsabilidadesRepository> _dataset;

        public TermosResponsabilidadesImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<IUTermosResponsabilidadesRepository>();
        }
    }
}
