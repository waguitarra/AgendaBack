using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class DenunciaProdutoUsuarioImplementation : BaseRepository<DenunciaProdutoUsuarioEntity>, IUDenunciaProdutoUsuarioRepository
    {
        private DbSet<DenunciaProdutoUsuarioEntity> _dataset;

        public DenunciaProdutoUsuarioImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<DenunciaProdutoUsuarioEntity>();
        }

        public async Task<DenunciaProdutoUsuarioEntity> GetCompleteByProdutos(Guid ProdutosId)
        {
            return await _dataset
                .FirstOrDefaultAsync(c => c.ProdutosId.Equals(ProdutosId));
        }

        public async Task<DenunciaProdutoUsuarioEntity> GetCompleteByUser(Guid UserId)
        {
            return await _dataset
                .FirstOrDefaultAsync(c => c.UserId.Equals(UserId));
        }

        public async Task<DenunciaProdutoUsuarioEntity> GetCompleteByDenuncias(Guid DenunciasId)
        {
            return await _dataset
                .FirstOrDefaultAsync(c => c.DenunciasId.Equals(DenunciasId));
        }

        public async Task<DenunciaProdutoUsuarioEntity> GetUserProdutos(Guid UserId, Guid ProdutosId)
        {
            return await _dataset
                 .FirstOrDefaultAsync(c => c.UserId.Equals(UserId) &&  c.ProdutosId.Equals(ProdutosId));
        }
    }
}