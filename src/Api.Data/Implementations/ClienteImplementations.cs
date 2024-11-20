using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ClienteImplementation : BaseRepository<ClienteEntity>, IUClienteRepository
    {
        private DbSet<IUClienteRepository> _dataset;

        public ClienteImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<IUClienteRepository>();
        }
    }
}
