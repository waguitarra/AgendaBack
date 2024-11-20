using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUConteudoCategoriaRepository : IRepository<ConteudoCategoriaEntity>
    {
        Task<ConteudoCategoriaEntity> GetConteudosCategoriaById(Guid ConteudoscategoriaId);
    }
}
