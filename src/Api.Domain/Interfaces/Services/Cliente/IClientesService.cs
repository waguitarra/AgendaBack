using Domain.Dtos.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Api.Domain.Interfaces.Services.Cliente
{
    public interface IClientesService
    {
        Task<ClienteDto> Get(Guid Id);
        Task<IEnumerable<ClienteDto>> GetAll(string idioma);
        Task<ClienteDto> Post(ClienteDto Cliente);
        Task<ClienteDto> Put(ClienteDto Cliente);

    }
}
