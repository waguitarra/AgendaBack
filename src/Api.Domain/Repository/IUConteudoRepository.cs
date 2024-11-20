using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Domain.Entities;

namespace Api.Domain.Repository
{
    public interface IUConteudosRepository : IRepository<ConteudosEntity>
    {
        Task<ConteudosEntity> GetCompleteByConteudosCategoria(Guid ConteudoscategoriaId);
        Task<ConteudosEntity> GetCompleteByImagensConteudos(Guid ConteudosId);
        Task<IEnumerable<ConteudosEntity>> GetTipoConteudos(string tipo);
        Task<IEnumerable<ConteudosEntity>> GetAllTipoConteudos();
    }
}
