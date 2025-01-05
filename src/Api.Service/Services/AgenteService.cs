using Api.Domain.Interfaces.Services.Agente;
using Api.Domain.Interfaces.Services.Produtos;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.Agente;
using Domain.Dtos.AgenteProduto;
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
        private IUProdutosRepository _produtosRepositorio;
        public IUAgenteProdutoRepository _agenteProdutoRepository { get; set; }

        public AgenteService(IUAgenteRepository repository, IMapper mapper, IUUserRepository userRepositorio, IUAgenteProdutoRepository agenteProdutoRepository, IUProdutosRepository produtosRepositorio)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepositorio = userRepositorio;
            _agenteProdutoRepository = agenteProdutoRepository;
            _produtosRepositorio = produtosRepositorio;
        }

        public async Task<AgenteDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<AgenteDto>(entity);
        }

        public async Task<IEnumerable<AgenteDto>> GetAll(string idioma, Guid UserId)
        {
            var listEntity = await _repository.SelectAsync();
            listEntity = listEntity.Where(p => p.Ativo == true && p.UserId == UserId).ToList();

            return _mapper.Map<IEnumerable<AgenteDto>>(listEntity);
        }

        public async Task<IEnumerable<ProdutoAgenteDto>> GetAllAgenteProduto(Guid produtoId)
        {
            // Obtém o produto com o ID fornecido
            var produto = await _produtosRepositorio.GetPesquisaProduto(produtoId);

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            // Obtém todas as associações de AgenteProduto com base no produtoId
            var agenteProdutos = await _agenteProdutoRepository.GetAllUserClientesProdutoId(produtoId);

            if (agenteProdutos == null || !agenteProdutos.Any())
            {
                return Enumerable.Empty<ProdutoAgenteDto>(); // Retorna lista vazia se nenhum agente for encontrado
            }

            // Filtra os IDs de agentes encontrados em agenteProdutos
            var agenteIds = agenteProdutos.Select(ap => ap.AgenteId).Distinct().ToList();

            // Busca todos os agentes
            var allAgentes = await _repository.SelectAsync();

            // Filtra os agentes manualmente com base nos IDs encontrados
            var agentesFiltrados = allAgentes.Where(a => agenteIds.Contains(a.Id)).ToList();

            // Mapeia os agentes para ProdutoAgenteDto e preenche as informações do produto
            var resultado = agentesFiltrados.Select(agente => new ProdutoAgenteDto
            {
                Id = agente.Id,
                Nome = agente.Nome,
                Email = agente.Email,
                Imagem = agente.Imagem,
                NomeProduto = produto.NomeProduto,
                Ativo = agente.Ativo,
                TipoCategoria = produto.Categoria?.TipoCategoria ?? string.Empty,
                TipoServico = produto.TipoServico?.TipoCategoria ?? string.Empty,
                Endereco = produto.Endereco,
                CEP = produto.CEP,
                Numero = produto.Numero,
                Estado = produto.Estado,
                Pais = produto.Pais,
                UserId = produto.UserId,
                ProdutoId = produto.Id
            });

            return resultado;
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

        public async Task<bool> DeleteMaster(Guid id)
        {
            var agente = await Get(id);
            if (agente != null)
            {
                // Alterna o valor do campo Ativo
                agente.Ativo = !agente.Ativo;

                // Atualiza o agente no repositório
                await _repository.UpdateAsync(_mapper.Map<AgenteEntity>(agente));
                return true;
            }

            return false;
        }


    }
}
