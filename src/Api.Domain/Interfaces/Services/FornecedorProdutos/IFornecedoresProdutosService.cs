


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;

namespace Api.Domain.Interfaces.Services.FornecedorProdutosService
{
    public interface IFornecedorProdutosService
    {
        Task<FornecedorProdutosDto> Get(Guid Id);
        Task<IEnumerable<FornecedorProdutosDto>> GetAll(Guid UserFornecedorId);
        Task<FornecedorProdutosDtoCreateResult> Post(FornecedorProdutosDtoCreate FornecedorProdutos);
        Task<FornecedorProdutosDtoUpdateResult> Put(FornecedorProdutosDtoUpdate FornecedorProdutos);
        Task<IEnumerable<FornecedorProdutosDto>> GetAllMeusFornecedorProdutos(Guid UserFornecedorId);
        //Task<bool> Delete(Guid id);
    }
}
