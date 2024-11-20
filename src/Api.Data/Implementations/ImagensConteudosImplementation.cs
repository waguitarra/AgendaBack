using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ImagensConteudosImplementation : BaseRepository<ImagensConteudosEntity>, IUImagensConteudosRepository
    {

        private DbSet<ImagensConteudosEntity> _dataset;

        public ImagensConteudosImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ImagensConteudosEntity>();
        }


        public async Task<ImagensConteudosEntity> GetCompleteByImagensConteudos(Guid ImagensConteudosId)
        {
            return await _dataset.Include(p => p.Conteudos)
                       .FirstOrDefaultAsync(c => c.Conteudos.IdConteudoCategoria.Equals(ImagensConteudosId));
        }
    }
}
