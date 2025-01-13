using Domain.Dtos.AgendaAgente;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Categorias
{
    public interface IAgendaAgenteService
    {
        Task<AgendaAgenteDto> Get(Guid Id);
        Task<IEnumerable<AgendaAgenteDto>> GetAll();
        Task<AgendaAgenteDto> Post(AgendaAgenteDto agenda);
        Task<AgendaAgenteDto> Put(AgendaAgenteDto agenda);
        Task<bool> Delete(Guid id);
    }
}
