using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Categorias;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.ConteudoCategoria;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class ConteudoCategoriaService : IConteudoCategoriaService
    {
        private IUConteudoCategoriaRepository _repository;

        private readonly IMapper _mapper;

        public ConteudoCategoriaService(IUConteudoCategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ConteudoCategoriaDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ConteudoCategoriaDto>(entity);
        }

        public async Task<IEnumerable<ConteudoCategoriaDto>> GetAll(string idioma)
        {
            var translatorService = new TranslationService();

            var listEntity = await _repository.SelectAsync();

            foreach (var item in listEntity)
            {
                item.Tipo = await translatorService.TranslateTextAsync(item.Tipo , idioma);
            }


            return _mapper.Map<IEnumerable<ConteudoCategoriaDto>>(listEntity);
        }

        public async Task<ConteudoCategoriaDtoCreateResult> Post(ConteudoCategoriaDtoCreate ConteudoCategoria)
        {    
            var entity = _mapper.Map<ConteudoCategoriaEntity>(ConteudoCategoria);

            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<ConteudoCategoriaDtoCreateResult>(result);      

        }

        public async Task<ConteudoCategoriaDtoUpdateResult> Put(ConteudoCategoriaDtoUpdate ConteudoCategoria)
        {
            var ConteudoCategoriaId = await _repository.SelectAsync(ConteudoCategoria.Id);
            if (ConteudoCategoriaId != null)
            {
                var entity = _mapper.Map<ConteudoCategoriaEntity>(ConteudoCategoria);

                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<ConteudoCategoriaDtoUpdateResult>(result);
            }
            return null;
        }

    }
}
