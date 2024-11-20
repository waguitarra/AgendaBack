using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ImagensFImplementation : BaseRepository<ImagensFEntity>, IUImagensFRepository
    {

        private DbSet<ImagensFEntity> _dataset;

        public ImagensFImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ImagensFEntity>();
        }

        public async Task<ImagensFEntity> GetCompleteByFornecedorProdutos(Guid FornecedorProdutosId)
        {
            return await _dataset.Include(p => p.FornecedorProdutos)
                       .FirstOrDefaultAsync(c => c.FornecedorProdutosId.Equals(FornecedorProdutosId));
        }
    }
}
