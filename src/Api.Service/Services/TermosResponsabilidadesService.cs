using Api.Domain.Dtos.TermosResponsabilidades;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services.TermosResponsabilidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class TermosResponsabilidadesService : ITermosResponsabilidadesService
    {
        private IUTermosResponsabilidadesRepository _repository;

        private readonly IMapper _mapper;

        public TermosResponsabilidadesService(IUTermosResponsabilidadesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TermosResponsabilidadesDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<TermosResponsabilidadesDto>(entity);
        }

        public async Task<IEnumerable<TermosResponsabilidadesDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<TermosResponsabilidadesDto>>(listEntity);
        }

        public async Task<TermosResponsabilidadesDtoCreateResult> Post(TermosResponsabilidadesDtoCreate TermosResponsabilidades)
        {

            var entity = _mapper.Map<TermosResponsabilidadesEntity>(TermosResponsabilidades);
            entity.Ativo = true;

            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<TermosResponsabilidadesDtoCreateResult>(result);

        }

        public async Task<TermosResponsabilidadesDtoUpdateResult> Put(TermosResponsabilidadesDtoUpdate TermosResponsabilidades)
        {
            var entity = _mapper.Map<TermosResponsabilidadesEntity>(TermosResponsabilidades);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<TermosResponsabilidadesDtoUpdateResult>(result);
        }


        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
