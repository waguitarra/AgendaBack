using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUUserRepository
    {
        private DbSet<UserEntity> _dataset;  

        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();


        }
        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Ativo == true); // para login apenas
        }

        public async Task<UserEntity> FindByEmail(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email)); // para login apenas
        }


        public async Task<UserEntity> GetProdutoPorUserId(Guid Id)
        {
            if (Id == null)
            {
                return null;
            }
            var entity = await _dataset.Include(p => p.Produtos)
                            .FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return entity;
        }

        public async Task<UserEntity> GetUserIdDadosBasicos(Guid Id)
        {
            var entity = await _dataset.FirstOrDefaultAsync(c => c.Id == Id);
            return entity;
        }


        public async Task<UserEntity> GetControleRigadoresPorUserId(Guid UserId)
        {
            var entity = await _dataset.Include(p => p.ControleRigadores)
                            .FirstOrDefaultAsync(c => c.Id.Equals(UserId));
            return entity;
        }

        public async Task<UserEntity> GetCurtidasPPorUserId(Guid UserId)
        {
            var entity = await _dataset.Include(p => p.CurtidasP)
                .FirstOrDefaultAsync(c => c.Id.Equals(UserId));
            return entity;
        }

        public async Task<UserEntity> GetUserId(Guid UserId)
        {
            try
            {
                var response = await _dataset.Where(p => p.Id == UserId).FirstAsync();
                return response;
            }
            catch 
            {
                return null;
            }
        }     

        public async Task<IEnumerable<UserEntity>> PutRecuperarSenha(string email)
        {
            return await _dataset.Where(p => p.Email == email).ToListAsync();          
        }

        public async Task<int> CountUser()
        {
            var response = await _dataset.Where(p => p.Ativo).ToListAsync();

            return response.Count;
        }


        public async Task<int> CountUserTermosResponsabilidadesInativos()
        {
            var response = await _dataset.Where(p => p.Ativo && p.TermosResponsabilidades == new Guid("00000000-0000-0000-0000-000000000000")).ToListAsync();
            return response.Count;
        }

        public async Task<int> CountUserTermosResponsabilidadesAtivos()
        {
            var response = await _dataset.Where(p => p.Ativo && p.TermosResponsabilidades == new Guid("00000000-0000-0000-0000-000000000000")).ToListAsync();
            return response.Count;
        }
    }
}
