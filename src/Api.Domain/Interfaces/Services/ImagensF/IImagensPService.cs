using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.ImagensP;

namespace Api.Domain.Interfaces.Services.ImagensF
{
    public interface IImagensFService
    {
        Task<ImagensFDto> Get(Guid Id);
        Task<IEnumerable<ImagensFDto>> GetAll();
        Task<ImagensFDto> GetPorProdutos(Guid FornecedorProdutosId);
        Task<ImagensFDtoCreateResult> Post(ImagensFDtoCreate ImagensF);
        Task<ImagensFDtoUpdateResult> Put(ImagensFDtoUpdate ImagensF);
        Task<bool> Delete(Guid id);

    }
}
