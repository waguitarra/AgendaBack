using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Implementations
{
    public class AgenteImplementation : BaseRepository<AgenteEntity>, IUAgenteRepository
    {
        private DbSet<AgenteEntity> _dataset;

        public AgenteImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<AgenteEntity>();
        }
        public async Task<IEnumerable<AgenteEntity>> GetAllUserClientes(Guid userId)
        {
            var response = await _dataset
                .Include(p => p.User) // Inclui a entidade User
                .Where(p => p.User.Id == userId && p.Ativo) // Filtra por UserId e Ativo
                .ToListAsync();
            return response;
        }
    }
}
