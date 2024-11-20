using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CurtidasP;
using Api.Domain.Dtos.Protudos;

namespace Api.Domain.Interfaces.Services.CuntidasP
{
    public interface ICurtidasPService
    {
        Task<CurtidasPDto> Get(Guid Id);
        Task<IEnumerable<CurtidasPDto>> GetAll();
        Task<int> GetAllMyCurtidasTotal(Guid UserId);
        Task<ProdutosDto> Post(CurtidasPDtoCreate curtidasP);
        Task<ProdutosDto> Put(CurtidasPDtoUpdate curtidasP);
        //Task<bool> Delete(Guid id);
    }
}
