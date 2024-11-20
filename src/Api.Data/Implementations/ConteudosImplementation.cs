using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class ConteudosImplementation : BaseRepository<ConteudosEntity>, IUConteudosRepository
    {
        private DbSet<ConteudosEntity> _dataset;
        public ConteudosImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ConteudosEntity>();
        }

        public async Task<ConteudosEntity> GetCompleteByConteudosCategoria(Guid ConteudoscategoriaId)
        {
            return await _dataset.Include(p => p.ConteudoCategoria)
            .FirstOrDefaultAsync(c => c.IdConteudoCategoria.Equals(ConteudoscategoriaId));
        }

        public async Task<ConteudosEntity> GetCompleteByImagensConteudos(Guid ConteudosId)
        {
            return await _dataset
                .Include(p => p.ImagensConteudos).FirstOrDefaultAsync(c => c.Id.Equals(ConteudosId));

        }

        public async Task<IEnumerable<ConteudosEntity>> GetTipoConteudos(string tipo)
        {
            return await _dataset
                .Include(p => p.ConteudoCategoria)
                .Include(p => p.ImagensConteudos)
                .Where(p => p.ConteudoCategoria.Nome == tipo)
                .ToListAsync();
        }

        public async Task<IEnumerable<ConteudosEntity>> GetAllTipoConteudos()
        {
            return await _dataset
                .Include(p => p.ConteudoCategoria)
                .Include(p => p.ImagensConteudos)
                .ToListAsync();
        }

    }
}
