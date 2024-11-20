using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Denuncias;


namespace Api.Domain.Interfaces.Services.Denuncias
{
    public interface IDenunciasService
    {
        Task<DenunciasDto> Get(Guid Id);
        Task<IEnumerable<DenunciasDto>> GetAll();
        Task<DenunciasDtoCreateResult> Post(DenunciasDtoCreate Denuncias);
        Task<DenunciasDtoUpdateResult> Put(DenunciasDtoUpdate Denuncias);
        //Task<bool> Delete(Guid id);
    }
}
