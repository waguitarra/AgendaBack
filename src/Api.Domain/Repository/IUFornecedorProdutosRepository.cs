using Api.Domain.Interfaces;
using Api.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Api.Domain.Repository
{
    public interface IUFornecedorProdutosRepository : IRepository<FornecedorProdutosEntity>
    {
        Task<FornecedorProdutosEntity> GetCompleteByImagensF(Guid FornecedorProdutosId);
        Task<FornecedorProdutosEntity> GetCompleteById(Guid FornecedorProdutosId);
        //Task<FornecedorProdutosEntity> GetCompleteByCategoria(Guid categoriaId);
        Task<FornecedorProdutosEntity> GetCompleteByUserFornecedor(Guid UserFornecedorId);
        Task<FornecedorProdutosEntity> GetCompleteByCurtidasP(Guid FornecedorProdutosId);
    }
}
