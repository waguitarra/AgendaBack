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
    public class ImagensConteudosService : IImagensConteudosService
    {

        private IUImagensConteudosRepository _repository;
        private IUConteudosRepository _repositoryConteudo;
        private IMapper _mapper;



        public ImagensConteudosService(IUImagensConteudosRepository repository
                                , IMapper mapper
                                , IUConteudosRepository repositoryProdutos
                                )
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryConteudo = repositoryProdutos;
        }

        public async Task<ImagensConteudosDto> Get(Guid id)
        {
            var listEntity = await _repository.SelectAsync(id);
            if (listEntity == null)
                return null;

            return _mapper.Map<ImagensConteudosDto>(listEntity);
        }

        public async Task<IEnumerable<ImagensConteudosDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ImagensConteudosDto>>(listEntity);
        }

        public async Task<ImagensConteudosDto> GetPorProdutos(Guid ProdutosId)
        {
            var listEntity = await _repository.GetCompleteByImagensConteudos(ProdutosId);
            if (listEntity == null)
                return null;
            return _mapper.Map<ImagensConteudosDto>(listEntity);
        }

        public async Task<ImagensConteudosDtoCreateResult> Post(ImagensConteudosDtoCreate ImagensConteudos)
        {
            //verificando se ProdutosId existe 
            var Conteudos = await _repositoryConteudo.SelectAsync(ImagensConteudos.ConteudosId);
            if (Conteudos != null)
            {
                var entity = _mapper.Map<ImagensConteudosEntity>(ImagensConteudos);
                entity.ConteudosId = Conteudos.Id;
       
                var result = await _repository.InsertAsync(entity);
                return _mapper.Map<ImagensConteudosDtoCreateResult>(result);
            }
            return null;
        }

        public async Task<ImagensConteudosDtoUpdateResult> Put(ImagensConteudosDtoUpdate ImagensConteudos)
        {
            //verificando se ProdutosId existe 
            var Conteudos = await _repositoryConteudo.SelectAsync(ImagensConteudos.ConteudosId);
            if (Conteudos != null)
            {
                var entity = _mapper.Map<ImagensConteudosEntity>(ImagensConteudos);

                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<ImagensConteudosDtoUpdateResult>(result);
            }
            return null;

        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }


    }
}
