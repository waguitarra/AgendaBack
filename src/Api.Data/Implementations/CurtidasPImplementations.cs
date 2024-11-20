using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CurtidasPImplementation : BaseRepository<CurtidasPEntity>, IUCurtidasPRepository
    {
        private DbSet<CurtidasPEntity> _dataset;
        private DbSet<ProdutosEntity> _dataSetProdutos;
        private DbSet<CurtidasConteudosEntity> _dataSetCurtidasConteudos;
        public CurtidasPImplementation(MyContext context) : base(context) 
        {
            _dataset = context.Set<CurtidasPEntity>();
            _dataSetProdutos = context.Set<ProdutosEntity>();
            _dataSetCurtidasConteudos = context.Set<CurtidasConteudosEntity>();
        }

        public async Task<int> GetAllMyCurtidasTotal(Guid UserId)
        {
            var result = await _dataSetProdutos
            .Include(p => p.CurtidasP)
            .Where(p => p.UserId == UserId && p.Ativo == true)
            //.Select(p => p.CurtidasP)
            .ToListAsync();

            var resultCurtidasConteudos = await _dataSetCurtidasConteudos
                .Include(p => p.Conteudos)
                .Where(p => p.Conteudos.UserId == UserId && p.Curtidas == true).ToListAsync();

            int resultCurtida = 0;

            foreach (var item in result)
            {
                resultCurtida = resultCurtida + item.CurtidasP.Count();
            }

            return resultCurtida + resultCurtidasConteudos.Count();
        }



        public async Task<CurtidasPEntity> GetCompleteByCurtidasProdutos(Guid ProdutosId)
        {
            return await _dataset.Include(p => p.Produtos)
                   .FirstOrDefaultAsync(c => c.Curtidas.Equals(ProdutosId));
        }

        public async Task<CurtidasPEntity> GetCompleteByCurtidasPUser(Guid UserId)
        {
            return await _dataset.FirstOrDefaultAsync(c => c.Id.Equals(UserId));
        }
    }
}
