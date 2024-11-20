using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Domain.Entities;

namespace Domain.Repository
{
    public interface IUDenunciaProdutoUsuarioRepository : IRepository<DenunciaProdutoUsuarioEntity>
    {
        Task<DenunciaProdutoUsuarioEntity> GetCompleteByProdutos(Guid ProdutosId);
        Task<DenunciaProdutoUsuarioEntity> GetCompleteByUser(Guid UserId);
        Task<DenunciaProdutoUsuarioEntity> GetCompleteByDenuncias(Guid DenunciasId);
        Task<DenunciaProdutoUsuarioEntity> GetUserProdutos(Guid UserId, Guid ProdutosId);

    }
}
