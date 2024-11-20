

using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class FornecedorProdutosImplementation : BaseRepository<FornecedorProdutosEntity>, IUFornecedorProdutosRepository
    {
        private DbSet<FornecedorProdutosEntity> _dataset;

        public FornecedorProdutosImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<FornecedorProdutosEntity>();
        }

        //public async Task<FornecedorProdutosEntity> GetCompleteByCategoria(Guid categoriaId)
        //{
        //    return await _dataset.Include(p => p.Categoria)
        //                .FirstOrDefaultAsync(c => c.CategoriaId.Equals(categoriaId));
        //}



        public async Task<FornecedorProdutosEntity> GetCompleteByUserFornecedor(Guid UserFornecedorId)
        {
            return await _dataset.Include(p => p.UserFornecedor)
                      .FirstOrDefaultAsync(c => c.UserFornecedorId.Equals(UserFornecedorId));
        }

        public async Task<FornecedorProdutosEntity> GetCompleteByImagensF(Guid FornecedorProdutosId)
        {
            return await _dataset.Include(p => p.ImagensF)
                      .FirstOrDefaultAsync(c => c.ImagensF.Equals(FornecedorProdutosId));
        }



        public async Task<FornecedorProdutosEntity> GetCompleteByCurtidasP(Guid FornecedorProdutosId)
        {
            return await _dataset.Include(p => p.CurtidasP)
                      .FirstOrDefaultAsync(c => c.Id.Equals(FornecedorProdutosId));

        }

        public async Task<FornecedorProdutosEntity> GetCompleteById(Guid FornecedorProdutosId)
        {
            return await _dataset.FirstOrDefaultAsync(c => c.Id.Equals(FornecedorProdutosId));
        }
    }
}
