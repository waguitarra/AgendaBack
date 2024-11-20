using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CurtidasConteudosP;
using Api.Domain.Dtos.CurtidasP;
using Domain.Dtos.Conteudo;

namespace Api.Domain.Interfaces.Services.CuntidasP
{
    public interface ICurtidasConteudosService
    {
        Task<CurtidasConteudosDto> Get(Guid Id);
        Task<IEnumerable<CurtidasConteudosDto>> GetAll(Guid ConteudosId );
        Task<ConteudosDto> Post(CurtidasConteudosDtoCreate curtidasP);
        Task<ConteudosDto> Put(CurtidasConteudosDtoUpdate curtidasP);
        //Task<bool> Delete(Guid id);
    }
}
