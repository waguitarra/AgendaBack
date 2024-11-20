using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUCurtidasPRepository : IRepository<CurtidasPEntity>
    {
        Task<CurtidasPEntity> GetCompleteByCurtidasPUser(Guid userId);
        Task<int> GetAllMyCurtidasTotal(Guid userId);
    }
}

