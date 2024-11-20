using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CurtidasConteudosImplementations : BaseRepository<CurtidasConteudosEntity>, IUCurtidasConteudosRepository
    {
        private DbSet<CurtidasConteudosEntity> _dataset;
        public CurtidasConteudosImplementations(MyContext context) : base(context) => _dataset = context.Set<CurtidasConteudosEntity>();

        public Task<CurtidasConteudosEntity> GetCompleteByCurtidasConteudosUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CurtidasConteudosEntity>> GetCompleteByCurtidasConteudos(Guid ConteudosId)
        {
            return await _dataset.Where(p => p.ConteudosId == ConteudosId).ToArrayAsync();
        }

        public async Task<CurtidasConteudosEntity> GetCompleteByCurtidasPUser(Guid UserId)
        {
            return await _dataset.FirstOrDefaultAsync(c => c.Id.Equals(UserId));
        }

        public async Task<IEnumerable<CurtidasConteudosEntity>> GetByCurtidasConteudosUserId(Guid ConteudosId, Guid UserId)
        {
            return await _dataset.Where(p => p.ConteudosId == ConteudosId && p.UserId == UserId).ToArrayAsync();
        }
    }
}
