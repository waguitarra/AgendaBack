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
        Task<AgendaAgenteDto> Post(AgendaAgenteDto Categoria);
        Task<AgendaAgenteDto> Put(AgendaAgenteDto Categoria);
        Task<bool> Delete(Guid id);
    }
}
