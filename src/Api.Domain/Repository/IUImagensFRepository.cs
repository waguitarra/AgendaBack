using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUImagensFRepository : IRepository<ImagensFEntity>
    {
        Task<ImagensFEntity> GetCompleteByFornecedorProdutos(Guid FornecedorProdutosId);
    }
}
