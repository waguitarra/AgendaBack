using Api.Domain.Dtos.ImagensP;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.ImagensF;
using Api.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class ImagensFService : IImagensFService
    {

        private IUImagensFRepository _repository;
        private IUFornecedorProdutosRepository _repositoryFornecedorProdutos;
        private IMapper _mapper;



        public ImagensFService(IUImagensFRepository repository
                                , IMapper mapper
                                , IUFornecedorProdutosRepository repositoryFornecedorProdutos
                                )
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryFornecedorProdutos = repositoryFornecedorProdutos;
        }

        public async Task<ImagensFDto> Get(Guid id)
        {
            var listEntity = await _repository.SelectAsync(id);
            if (listEntity == null)
                return null;

            return _mapper.Map<ImagensFDto>(listEntity);
        }

        public async Task<IEnumerable<ImagensFDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ImagensFDto>>(listEntity);
        }

        public async Task<ImagensFDto> GetPorProdutos(Guid ProdutosId)
        {
            var listEntity = await _repository.GetCompleteByFornecedorProdutos(ProdutosId);
            if (listEntity == null)
                return null;
            return _mapper.Map<ImagensFDto>(listEntity);
        }

        public async Task<ImagensFDtoCreateResult> Post(ImagensFDtoCreate ImagensF)
        {
            //verificando se ProdutosId existe 
            var produtosId = await _repositoryFornecedorProdutos.GetCompleteById(ImagensF.FornecedorProdutosId);
            if (produtosId != null)
            {
                var entity = _mapper.Map<ImagensFEntity>(ImagensF);

                var result = await _repository.InsertAsync(entity);
                return _mapper.Map<ImagensFDtoCreateResult>(result);
            }
            return new ImagensFDtoCreateResult();
        }

        public async Task<ImagensFDtoUpdateResult> Put(ImagensFDtoUpdate ImagensF)
        {
            //verificando se ProdutosId existe 
            var produtosId = await _repositoryFornecedorProdutos.GetCompleteByImagensF(ImagensF.FornecedorProdutosId);
            if (produtosId != null)
            {
                var entity = _mapper.Map<ImagensFEntity>(ImagensF);

                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<ImagensFDtoUpdateResult>(result);
            }
            return null;

        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
