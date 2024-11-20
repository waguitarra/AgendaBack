using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUImagensConteudosRepository : IRepository<ImagensConteudosEntity>
    {
        Task<ImagensConteudosEntity> GetCompleteByImagensConteudos(Guid ImagensConteudosId);
    }
}
