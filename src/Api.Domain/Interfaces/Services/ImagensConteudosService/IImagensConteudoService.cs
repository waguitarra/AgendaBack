using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.ImagensP;

namespace Api.Domain.Interfaces.Services.ImagensP
{
    public interface IImagensConteudosService
    {
        Task<ImagensConteudosDto> Get(Guid Id);
        Task<IEnumerable<ImagensConteudosDto>> GetAll();
        Task<ImagensConteudosDto> GetPorProdutos(Guid ProdutosId);
        Task<ImagensConteudosDtoCreateResult> Post(ImagensConteudosDtoCreate imagensP);
        Task<ImagensConteudosDtoUpdateResult> Put(ImagensConteudosDtoUpdate imagensP);
        //Task<bool> Delete(Guid id);

    }
}
