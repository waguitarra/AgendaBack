using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos.ConteudoCategoria;

namespace Api.Domain.Interfaces.Services.Categorias
{
    public interface IConteudoCategoriaService
    {
        Task<ConteudoCategoriaDto> Get(Guid Id);
        Task<IEnumerable<ConteudoCategoriaDto>> GetAll(string idioma);
        Task<ConteudoCategoriaDtoCreateResult> Post(ConteudoCategoriaDtoCreate Categoria);
        Task<ConteudoCategoriaDtoUpdateResult> Put(ConteudoCategoriaDtoUpdate Categoria);
    }
}
