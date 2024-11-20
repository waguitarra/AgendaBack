using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUCurtidasConteudosRepository : IRepository<CurtidasConteudosEntity>
    {
        Task<CurtidasConteudosEntity> GetCompleteByCurtidasPUser(Guid userId);

        Task<IEnumerable<CurtidasConteudosEntity>> GetCompleteByCurtidasConteudos(Guid ConteudosId);
        Task<IEnumerable<CurtidasConteudosEntity>> GetByCurtidasConteudosUserId(Guid ConteudosId, Guid UserId);

    }
}

