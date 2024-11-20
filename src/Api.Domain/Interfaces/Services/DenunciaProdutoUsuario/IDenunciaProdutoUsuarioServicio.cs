using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos.DenunciaProdutoUsuario;

namespace Api.Domain.Interfaces.Services.DenunciaProdutoUsuario
{
    public interface IDenunciaProdutoUsuarioService
    {
        Task<DenunciaProdutoUsuarioDto> Get(Guid Id);
        Task<IEnumerable<DenunciaProdutoUsuarioDto>> GetAll();
        Task<DenunciaProdutoUsuarioDtoCreateResult> Post(DenunciaProdutoUsuarioDtoCreate DenunciaProdutoUsuario);
        Task<DenunciaProdutoUsuarioDtoUpdateResult> Put(DenunciaProdutoUsuarioDtoUpdate DenunciaProdutoUsuario);
        //Task<bool> Delete(Guid id);
    }
}
