using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUMensagensPRepository : IRepository<MensagensPEntity>
    {
        Task<MensagensPEntity> GetCompleteByProdutos(Guid ProdutosId);
        Task<MensagensPEntity> GetCompleteByMensagensPUser(Guid UserId);
        Task<IEnumerable<MensagensPEntity>> GetAllByMensagensPUser(Guid UserId, int TipoServico);       
        Task<int> GetCountMensagensUnico(Guid UserId, int TipoServico);
        Task<int> GetCountMensagensAll(Guid UserId);
        Task<IEnumerable<MensagensPEntity>> GetMensagensAllNoLida(Guid UserId);
        Task<bool> GetAllBMensagensNaoLidas(Guid UserId);

    }
}

