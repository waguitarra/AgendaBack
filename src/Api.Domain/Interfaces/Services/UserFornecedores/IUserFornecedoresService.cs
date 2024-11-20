using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.UserFornecedor;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.UseFornecedor
{
    public interface IUUserFornecedorService
    {
        Task<UserFornecedorDto> Get(Guid id);
        Task<IEnumerable<UserFornecedorDto>> GetAll();
        Task<UserFornecedorDto> GetProdutoPorUserId(Guid id);
        Task<UserFornecedorDtoUpdateResult> DesativarUsuario(Guid id);
        Task<UserFornecedorDtoCreateResult> Post(UserFornecedorDtoCreate user);
        Task<UserFornecedorDtoUpdateResult> Put(UserFornecedorDtoUpdate user);
        //Task<bool> Delete(Guid id);
    }
}
