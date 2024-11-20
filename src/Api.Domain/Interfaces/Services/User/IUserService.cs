using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetProdutoPorUserId(Guid id);
        Task<UserLatLogDtoUpdate> PutLatitudeLongitude(UserLatLogDtoUpdate UserLatLongMOdoEscuro);
        Task<UserDtoUpdateResult> DesativarUsuario(Guid id);
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> ArrumarImagensUsuario();
        Task<bool> PutRecuperarSenha(string email);
        Task<bool> PutSenhaRecuperada(string email, string senha);
        Task<bool> DesativarEMail(string email);
        //Task<bool> Delete(Guid id);  
    }
}
