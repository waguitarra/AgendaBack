using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.ImagensP;

namespace Api.Domain.Interfaces.Services.ImagensP
{
    public interface IImagensPService
    {
        Task<ImagensPDto> Get(Guid Id);
        Task<IEnumerable<ImagensPDto>> GetAll();
        Task<ImagensPDto> GetPorProdutos(Guid ProdutosId);
        Task<ImagensPDtoCreateResult> Post(ImagensPDtoCreate imagensP);
        Task<ImagensPDtoUpdateResult> Put(ImagensPDtoUpdate imagensP);
        Task<bool> Delete(Guid id);

    }
}
