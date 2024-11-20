using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
        Task<UserEntity> FindByEmail(string email);
        Task<UserEntity> GetProdutoPorUserId(Guid id);
        Task<UserEntity> GetControleRigadoresPorUserId(Guid UserId);
        Task<UserEntity> GetUserIdDadosBasicos(Guid id);
        Task<UserEntity> GetCurtidasPPorUserId(Guid UserId);
        Task<UserEntity> GetUserId(Guid UserId);
        Task<IEnumerable<UserEntity>> PutRecuperarSenha(string email);
        Task<int> CountUser();
        Task<int> CountUserTermosResponsabilidadesAtivos();
        Task<int> CountUserTermosResponsabilidadesInativos();
    }
}
