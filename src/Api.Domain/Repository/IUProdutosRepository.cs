using Api.Domain.Interfaces;
using Api.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Api.Domain.Repository
{
    public interface IUProdutosRepository : IRepository<ProdutosEntity>
    {
        Task<ProdutosEntity> GetCompleteByImagensP(Guid ProdutosId);
        Task<ProdutosEntity> GetCompleteById(Guid ProdutosId);
        Task<IEnumerable<ProdutosEntity>> GetAllMyProduto(Guid userId);
        Task<ProdutosEntity> GetCompleteByCategoria(Guid categoriaId);
        Task<ProdutosEntity> GetCompleteByUser(Guid userId);
        Task<ProdutosEntity> GetCompleteByTipoServico(Guid TipoServicoId);
        Task<ProdutosEntity> GetCompleteByMensagensP(Guid ProdutosId);
        Task<ProdutosEntity> GetCompleteByCurtidasP(Guid ProdutosId);
        Task<ProdutosEntity> GetByMensagensPrivadas(Guid userId, Guid ClienteUserId);
        Task<IEnumerable<ProdutosEntity>> GetAllMensagensPrivadas(Guid userId);
        Task<int> GetQtdProdutosFinalizados(Guid userId);
        Task<IEnumerable<ProdutosEntity>> GetAllAssuntosLivres(Guid userId);
        Task<IEnumerable<ProdutosEntity>> GetAllPesquisaIdioma(Guid userId);
        Task<ProdutosEntity> GetPesquisaProduto(Guid id);
    }
}
