using Api.Domain.Interfaces.Services.Cliente;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.Client;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class ClienteService : IClientesService
    {
        private IUClienteRepository _repository;
        private IUUserRepository _userRepositorio;



        private readonly IMapper _mapper;

        public ClienteService(IUClienteRepository repository, IMapper mapper, IUUserRepository userRepositorio)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepositorio = userRepositorio;
        }

        public async Task<ClienteDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ClienteDto>(entity);
        }

        public async Task<IEnumerable<ClienteDto>> GetAll(string idioma)
        {
            var listEntity = await _repository.SelectAsync();       
            return _mapper.Map<IEnumerable<ClienteDto>>(listEntity);
        }

        public async Task<ClienteDto> Post(ClienteDto clienteDto)
        {
            var user = await _userRepositorio.GetUserIdDadosBasicos(clienteDto.Id);

            if (user == null)
            {
                return null; // Retorna null para indicar que o usuário não foi encontrado
            }

            var clienteEntity = _mapper.Map<ClienteEntity>(clienteDto);
            var result = await _repository.InsertAsync(clienteEntity);
            return _mapper.Map<ClienteDto>(result);
        }



        public async Task<ClienteDto> Put(ClienteDto clienteDto)
        {
            var clienteEntity = await _repository.SelectAsync(clienteDto.Id);
            if (clienteEntity != null)
            {
                // Mapeia o DTO atualizado para a entidade existente
                _mapper.Map(clienteDto, clienteEntity);

                var result = await _repository.UpdateAsync(clienteEntity);
                return _mapper.Map<ClienteDto>(result);
            }
            return null;
        }

        public async Task<bool> Delete(Guid id)
        {
            var clienteEntity = await _repository.SelectAsync(id); // Aguarda a conclusão da Task para obter o objeto
            if (clienteEntity != null)
            {
                // Atualiza a entidade diretamente
                await _repository.UpdateAsync(clienteEntity);
                return true;
            }

            return false;
        }


    }
}
