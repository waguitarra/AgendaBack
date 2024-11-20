using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.TermosResponsabilidades;

namespace Domain.Interfaces.Services.TermosResponsabilidades
{
    public interface ITermosResponsabilidadesService
    {
  
            Task<TermosResponsabilidadesDto> Get(Guid Id);
            Task<IEnumerable<TermosResponsabilidadesDto>> GetAll();
            Task<TermosResponsabilidadesDtoCreateResult> Post(TermosResponsabilidadesDtoCreate TermosResponsabilidades);
            Task<TermosResponsabilidadesDtoUpdateResult> Put(TermosResponsabilidadesDtoUpdate TermosResponsabilidades);
            //Task<bool> Delete(Guid id);
        
    }
}
