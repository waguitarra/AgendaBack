using Api.Data.Context;
using Api.Domain.Dtos.ImagensP;
using Api.Domain.Interfaces.Services.Agente;
using Api.Domain.Interfaces.Services.Produtos;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.AgendaAgente;
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
        private IUAgendaAgenteRepository _agendaAgenteRepository;
        public IUAgenteProdutoRepository _agenteProdutoRepository { get; set; }

        public AgenteService(IUAgenteRepository repository, IMapper mapper, IUUserRepository userRepositorio, IUAgenteProdutoRepository agenteProdutoRepository, IUProdutosRepository produtosRepositorio, IUAgendaAgenteRepository agendaAgenteRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepositorio = userRepositorio;
            _agenteProdutoRepository = agenteProdutoRepository;
            _produtosRepositorio = produtosRepositorio;
            _agendaAgenteRepository = agendaAgenteRepository;
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

        public async Task<List<ProdutoAgenteDto>> GetAllAgenteProduto(Guid produtoId)
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
                return new List<ProdutoAgenteDto>(); // Retorna lista vazia se nenhum agente for encontrado
            }

            // Filtra os IDs de agentes encontrados em agenteProdutos
            var agenteIds = agenteProdutos.Select(ap => ap.AgenteId).Distinct().ToList();

            // Busca todos os agentes SEM fazer chamadas concorrentes
            var allAgentes = await _repository.SelectAsync();
            var agentesFiltrados = allAgentes.Where(a => agenteIds.Contains(a.Id)).ToList();

            // Criar um dicionário para armazenar as agendas e evitar concorrência
            var agendaDictionary = new Dictionary<Guid, List<AgendaAgenteHorasDto>>();

            foreach (var agente in agentesFiltrados)
            {
                // Agora cada chamada aguarda a anterior terminar antes de executar outra
                agendaDictionary[agente.Id] = await GetAllAgenteAsync(produto.Id, agente.Id);
            }

            // Mapeia os agentes para ProdutoAgenteDto e preenche as informações do produto
            var resultado = agentesFiltrados.Select(agente => new ProdutoAgenteDto
            {
                Id = agente.Id,
                Nome = agente.Nome,
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
                ProdutoId = produto.Id,
                AgentePauseStartComer = agente.PauseStartComer,
                AgentePauseEndComer = agente.PauseEndComer,
                SemanaStartHora = produto.SemanaStartHora,
                SemanaEndHora = produto.SemanaEndHora,
                PauseStartHora = produto.PauseStartHora,
                PauseEndHora = produto.PauseEndHora,
                Sabado = produto.Sabado,
                SabadoStartHorario = produto.SabadoStartHorario,
                SabadoEndHorario = produto.SabadoEndHorario,
                Domingo = produto.Domingo,
                DomingoStartHora = produto.DomingoStartHora,
                DomingoEndHora = produto.DomingoEndHora,
                Feriados = produto.Feriados,
                FeriadoStartHora = produto.FeriadoStartHora,
                FeriadoEndHora = produto.FeriadoEndHora,
                ImagensP = produto.ImagensP.Select(p => p.UrlImagens).FirstOrDefault(),
                AgendaAgente = agendaDictionary.ContainsKey(agente.Id) ? agendaDictionary[agente.Id] : null
            }).ToList();

            return resultado;
        }


        private async Task<List<AgendaAgenteHorasDto>> GetAllAgenteAsync(Guid produtoId, Guid agenteId)
        {
            // Obtém as entidades do repositório
            var entityAgente = await _agendaAgenteRepository.GetAllAgenteProdutoId(produtoId, agenteId);

            if (entityAgente == null || !entityAgente.Any())
            {
                return new List<AgendaAgenteHorasDto>(); // Retorna uma lista vazia se não houver resultados
            }

            // Mapeia as entidades para DTOs usando AutoMapper
            return _mapper.Map<List<AgendaAgenteHorasDto>>(entityAgente);
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
