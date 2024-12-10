using Api.Domain.Interfaces.Services.Agente;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.Agente;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class AgenteService : IAgenteService
    {
        private IUAgenteRepository _repository;

        private readonly IMapper _mapper;
        private IUUserRepository _userRepositorio;

        public AgenteService(IUAgenteRepository repository, IMapper mapper, IUUserRepository userRepositorio)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepositorio = userRepositorio;
        }

        public async Task<AgenteDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<AgenteDto>(entity);
        }

        public async Task<IEnumerable<AgenteDto>> GetAll(string idioma, Guid UserId)
        {
            var listEntity = await _repository.SelectAsync();
            listEntity = listEntity.Where(p => p.Ativo == true && p.UserId == UserId && p.ProdutoId == null).ToList();

            return _mapper.Map<IEnumerable<AgenteDto>>(listEntity);
        }

        public async Task<AgenteDto> Post(AgenteDto agenteDto)
        {


            var user = await _userRepositorio.GetUserIdDadosBasicos(agenteDto.UserId);

            if (user == null)
            {
                return null; // Retorna null para indicar que o usuário não foi encontrado
            }

            // Mapeia o DTO para a entidade Agente
            var entity = _mapper.Map<AgenteEntity>(agenteDto);
            entity.Ativo = true; // Define o campo Ativo como true
            entity.ProdutoId = null;

            // Insere a entidade no repositório e obtém o resultado
            var result = await _repository.InsertAsync(entity);

            // Mapeia o resultado de volta para o DTO e retorna
            return _mapper.Map<AgenteDto>(result);
        }


        public async Task<AgenteDto> Put(AgenteDto Agente)
        {
            var AgenteId = await _repository.SelectAsync(Agente.Id);
            if (AgenteId != null)
            {
                if (Agente.ProdutoId == Guid.Empty)
                {
                    Agente.ProdutoId = null;
                }

                var entity = _mapper.Map<AgenteEntity>(Agente);

                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<AgenteDto>(result);
            }
            return null;
        }


        public async Task<bool> Delete(Guid id)
        {
            var Agente = await Get(id);
            if (Agente != null)
            {
                var agenteDto = _mapper.Map<AgenteDto>(Agente);

                agenteDto.Ativo = false;
 
                await _repository.UpdateAsync(_mapper.Map<AgenteEntity>(Agente));
                return true;
            }

            return false;
   
        }

    }
}
