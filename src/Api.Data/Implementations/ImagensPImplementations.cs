using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ImagensPImplementation : BaseRepository<ImagensPEntity>, IUImagensPRepository
    {

        private DbSet<ImagensPEntity> _dataset;

        public ImagensPImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ImagensPEntity>();
        }

        public async Task<ImagensPEntity> GetCompleteByProdutos(Guid ProdutosId)
        {
            return await _dataset.Include(p => p.Produtos.MensagensP)
                       .FirstOrDefaultAsync(c => c.ProdutosId.Equals(ProdutosId));
        }
    }
}
