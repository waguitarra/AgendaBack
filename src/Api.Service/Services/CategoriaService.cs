using Api.Domain.Dtos.Categorias;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Categorias;
using Api.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class CategoriaService : ICategoriasService
    {
        private IUCategoriaRepository _repository;

        private readonly IMapper _mapper;

        public CategoriaService(IUCategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CategoriaDto>(entity);
        }

        public async Task<IEnumerable<CategoriaDto>> GetAll(string idioma)
        {
            var listEntity = await _repository.SelectAsync();
            listEntity = listEntity.Where(p => p.Pais == idioma).ToList();

            return _mapper.Map<IEnumerable<CategoriaDto>>(listEntity);
        }

        public async Task<CategoriaDtoCreateResult> Post(CategoriaDtoCreate Categoria)
        {
            var listEntity = await _repository.SelectAsync();
            var TipoCategoria = listEntity.AsQueryable().Where(p => p.TipoCategoria == Categoria.TipoCategoria).ToList();
            if (TipoCategoria.Count == 0)
            {
                var entity = _mapper.Map<CategoriaEntity>(Categoria);

                var result = await _repository.InsertAsync(entity);
                return _mapper.Map<CategoriaDtoCreateResult>(result);
            }
            return new CategoriaDtoCreateResult();

        }

        public async Task<CategoriaDtoUpdateResult> Put(CategoriaDtoUpdate Categoria)
        {
            var CategoriaId = await _repository.SelectAsync(Categoria.Id);
            if (CategoriaId != null)
            {
                var entity = _mapper.Map<CategoriaEntity>(Categoria);

                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<CategoriaDtoUpdateResult>(result);
            }
            return null;
        }


        public async Task<bool> Delete(Guid id)
        {
            var CategoriaId =  _repository.SelectAsync(id);
            if (CategoriaId != null)
            {
                var entity = _mapper.Map<CategoriaEntity>(CategoriaId);
                entity.Ativo = false;
 
                await _repository.UpdateAsync(entity);
                return true;
            }

            return false;
   
        }

    }
}
