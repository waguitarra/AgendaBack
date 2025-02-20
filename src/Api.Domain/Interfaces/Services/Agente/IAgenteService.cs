using Domain.Dtos.Agente;
using Domain.Dtos.AgenteProduto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Api.Domain.Interfaces.Services.Agente
{
    public interface IAgenteService
    {
        Task<AgenteDto> Get(Guid Id);
        Task<IEnumerable<AgenteDto>> GetAll(string idioma, Guid userId);
        Task<AgenteDto> Post(AgenteDto Agente);
        Task<AgenteDto> Put(AgenteDto Agente);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteMaster(Guid id);
        Task<List<ProdutoAgenteDto>> GetAllAgenteProduto(Guid produtoId);


    }
}
