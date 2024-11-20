using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserFornecedorImplementation : BaseRepository<UserFornecedorEntity>, IUUserFornecedorRepository
    {
        private DbSet<UserFornecedorEntity> _dataset;
        private DbSet<FornecedorProdutosEntity> _produtos;

        public UserFornecedorImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserFornecedorEntity>();
            _produtos = context.Set<FornecedorProdutosEntity>();

        }
        public async Task<UserFornecedorEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email)); // para login apenas
            //return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password)); // para login apenas
        }

        public async Task<UserFornecedorEntity> FindByEmail(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email)); // para login apenas
        }

        public async Task<UserFornecedorEntity> GetProdutoPorUserId(Guid Id)
        {
            var entity = await _dataset.Include(p => p.FornecedorProdutos)
                            .FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return entity;
        }

        public async Task<UserFornecedorEntity> GetUserIdDadosBasicos(Guid Id)
        {
            var entity = await _dataset.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return entity;
        }




    }
}
