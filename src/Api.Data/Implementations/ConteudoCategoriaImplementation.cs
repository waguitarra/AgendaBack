using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class ConteudoCategoriaImplementation : BaseRepository<ConteudoCategoriaEntity>, IUConteudoCategoriaRepository
    {
        private DbSet<IUControleRigadoresRepository> _dataset;
        public ConteudoCategoriaImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<IUControleRigadoresRepository>();
        }

        public Task<ConteudoCategoriaEntity> GetConteudosCategoriaById(Guid ConteudoscategoriaId)
        {
            throw new NotImplementedException();
        }
    }
}
