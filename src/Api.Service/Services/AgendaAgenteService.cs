using Api.Domain.Interfaces.Services.Categorias;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.AgendaAgente;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class AgendaAgenteService : IAgendaAgenteService
    {
        private IUAgendaAgenteRepository _repository;

        private readonly IMapper _mapper;

        public AgendaAgenteService(IUAgendaAgenteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AgendaAgenteDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<AgendaAgenteDto>(entity);
        }

        public async Task<IEnumerable<AgendaAgenteDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            listEntity = listEntity.Where(p => p.Cancelado == false).ToList();

            return _mapper.Map<IEnumerable<AgendaAgenteDto>>(listEntity);
        }

        public async Task<AgendaAgenteDto> Post(AgendaAgenteDto Agendaagente)
        {
            var listEntity = _mapper.Map<AgendaAgente>(Agendaagente);

            var result = await _repository.InsertAsync(listEntity);

            return _mapper.Map<AgendaAgenteDto>(result);


        }

        public async Task<AgendaAgenteDto> Put(AgendaAgenteDto Agendaagente)
        {
            var AgendaagenteId = await _repository.SelectAsync(Agendaagente.Id);
            if (AgendaagenteId != null)
            {
                var entity = _mapper.Map<AgendaAgente>(Agendaagente);

                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<AgendaAgenteDto>(result);
            }
            return null;
        }


        public async Task<bool> Delete(Guid id)
        {
            var AgendaagenteId =  _repository.SelectAsync(id);
            if (AgendaagenteId != null)
            {
                var entity = _mapper.Map<AgendaAgente>(AgendaagenteId);
                entity.Cancelado = true;
 
                await _repository.UpdateAsync(entity);
                return true;
            }

            return false;
   
        }

    }
}
