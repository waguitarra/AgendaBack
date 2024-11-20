using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ControleRigadoresImplementation : BaseRepository<ControleRigadoresEntity>, IUControleRigadoresRepository
    {
        private DbSet<IUControleRigadoresRepository> _dataset;

        public ControleRigadoresImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<IUControleRigadoresRepository>();
        }

    }
}


