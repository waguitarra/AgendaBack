using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos.Conteudo;

namespace Api.Domain.Interfaces.Services.Categorias
{
    public interface IConteudosService
    {
        Task<ConteudosDto> Get(Guid Id, string idioma);
        Task<IEnumerable<ConteudosDto>> GetAll(string idioma, string tipo);
        Task<ConteudosDtoCreateResult> Post(ConteudosDtoCreate Categoria);
        Task<ConteudosDtoUpdateResult> Put(ConteudosDtoUpdate Categoria);
    }
}
