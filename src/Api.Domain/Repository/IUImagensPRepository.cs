using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUImagensPRepository : IRepository<ImagensPEntity>
    {
        Task<ImagensPEntity> GetCompleteByProdutos(Guid ProdutosId);
    }
}
