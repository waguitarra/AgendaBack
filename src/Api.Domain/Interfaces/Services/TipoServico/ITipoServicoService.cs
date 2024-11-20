using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.TipoServico;

namespace Api.Domain.Interfaces.Services.TipoServico
{
    public interface ITipoServicoService
    {
        Task<TipoServicoDto> Get(Guid Id);
        Task<IEnumerable<TipoServicoDto>> GetAll(string idioma);
    }
}
