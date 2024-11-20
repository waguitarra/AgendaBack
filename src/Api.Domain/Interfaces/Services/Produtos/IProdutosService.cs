using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Protudos;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Produtos
{
    public interface IProdutosService
    {
        Task<ProdutosDto> Get(Guid Id, Guid? userId, double lat, double longi, string idioma);
        Task<IEnumerable<ProdutosDto>> GetAll(Guid userId);
        Task<IEnumerable<ProdutosDto>> GetAllMyProduto(Guid userId);
        Task<IEnumerable<ProdutosDto>> PesquisaPorNomeMaxKm(ProdutosDtoPesquisaCategoriasTipoServicos listaCategoriasServico, Guid userId);
        Task<ProdutosDtoCreateResult> Post(ProdutosDtoCreate Produtos);
        Task<ProdutosDtoUpdateResult> Put(ProdutosDtoUpdate Produtos);
        Task<ProdutosDtoUpdateResult> PutServiceClienteUsuarioId(Guid userId, Guid clienteUsuarioId);
        Task<IEnumerable<ProdutosDto>> GetAllMeusProdutos(Guid userId);
        Task<ProdutosDtoUpdateResult> PutDeleteProduto(Guid userId);
        Task<ProdutosDtoCreateResult> EmailAllNewProduct(string idioma);
        Task<IEnumerable<ProdutosDto>> GetAllMensagensPrivadas(Guid userId);
        Task<int> GetQtdProdutosFinalizados(Guid userId);
        Task<IEnumerable<ProdutosDto>> GetAllAssuntosLivres(Guid userId);
    }
}