using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUUserFornecedorRepository : IRepository<UserFornecedorEntity>
    {
        Task<UserFornecedorEntity> FindByLogin(string email);
        Task<UserFornecedorEntity> FindByEmail(string email);
        Task<UserFornecedorEntity> GetProdutoPorUserId(Guid id);
        Task<UserFornecedorEntity> GetUserIdDadosBasicos(Guid id);


    }
}
