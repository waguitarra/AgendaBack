using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CategoriaImplementation : BaseRepository<CategoriaEntity>, IUCategoriaRepository
    {
        private DbSet<IUCategoriaRepository> _dataset;

        public CategoriaImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<IUCategoriaRepository>();
        }
    }
}
