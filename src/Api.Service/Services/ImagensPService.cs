using Api.Domain.Dtos.ImagensP;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.ImagensP;
using Api.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class ImagensPService : IImagensPService
    {

        private IUImagensPRepository _repository;
        private IUProdutosRepository _repositoryProdutos;
        private IMapper _mapper;



        public ImagensPService(IUImagensPRepository repository
                                , IMapper mapper
                                , IUProdutosRepository repositoryProdutos
                                )
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryProdutos = repositoryProdutos;
        }

        public async Task<ImagensPDto> Get(Guid id)
        {
            var listEntity = await _repository.SelectAsync(id);
            if (listEntity == null)
                return null;

            return _mapper.Map<ImagensPDto>(listEntity);
        }

        public async Task<IEnumerable<ImagensPDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ImagensPDto>>(listEntity);
        }

        public async Task<ImagensPDto> GetPorProdutos(Guid ProdutosId)
        {
            var listEntity = await _repository.GetCompleteByProdutos(ProdutosId);
            if (listEntity == null)
                return null;
            return _mapper.Map<ImagensPDto>(listEntity);
        }

        public async Task<ImagensPDtoCreateResult> Post(ImagensPDtoCreate imagensP)
        {
            //verificando se ProdutosId existe 
            var produtosId = await _repositoryProdutos.GetCompleteByImagensP(imagensP.ProdutosId);
            if (produtosId != null)
            {
                var entity = _mapper.Map<ImagensPEntity>(imagensP);

                var result = await _repository.InsertAsync(entity);
                return _mapper.Map<ImagensPDtoCreateResult>(result);
            }
            return new ImagensPDtoCreateResult();
        }

        public async Task<ImagensPDtoUpdateResult> Put(ImagensPDtoUpdate imagensP)
        {
            //verificando se ProdutosId existe 
            var produtosId = await _repositoryProdutos.GetCompleteByImagensP(imagensP.ProdutosId);
            if (produtosId != null)
            {
                var entity = _mapper.Map<ImagensPEntity>(imagensP);

                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<ImagensPDtoUpdateResult>(result);
            }
            return null;

        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
