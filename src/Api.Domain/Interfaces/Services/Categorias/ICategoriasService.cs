using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Categorias;

namespace Api.Domain.Interfaces.Services.Categorias
{
    public interface ICategoriasService
    {
        Task<CategoriaDto> Get(Guid Id);
        Task<IEnumerable<CategoriaDto>> GetAll(string idioma);
        Task<CategoriaDtoCreateResult> Post(CategoriaDtoCreate Categoria);
        Task<CategoriaDtoUpdateResult> Put(CategoriaDtoUpdate Categoria);
        //Task<bool> Delete(Guid id);
    }
}
