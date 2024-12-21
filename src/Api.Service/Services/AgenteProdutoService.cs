using Api.Data.Context;
using Api.Domain.Repository;
using Domain.Entities;
using Domain.Interfaces.Services.AgenteProduto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace Service.Services
{
    public class AgenteProdutoService : IAgenteProdutoService
    {
        private readonly IUAgenteProdutoRepository _uagenteProtudoRepository;
        private readonly MyContext _context;

        public AgenteProdutoService(IUAgenteProdutoRepository uagenteProtudoRepository, MyContext context)
        {
            _uagenteProtudoRepository = uagenteProtudoRepository;
            _context = context;
        }

        public async Task GerenciarAgentesAsync(Guid produtoId, List<Guid> agentesRecebidos)
        {
            // Busca todos os agentes associados ao produto
            var agentesProdutosAtuais = await _uagenteProtudoRepository.GetAllUserClientesProdutoId(produtoId);

            // Desativa agentes que não estão na DTO
            foreach (var agenteProdutoAtual in agentesProdutosAtuais)
            {
                if (!agentesRecebidos.Contains(agenteProdutoAtual.AgenteId) && agenteProdutoAtual.Ativo)
                {
                    agenteProdutoAtual.Ativo = false;
                    agenteProdutoAtual.UpdateAt = DateTime.UtcNow;
                    _context.Entry(agenteProdutoAtual).State = EntityState.Modified; // Marca como modificado
                }
            }

            // Ativa novos agentes ou reativa os inativos
            foreach (var agenteId in agentesRecebidos)
            {
                var agenteProdutoAtual = agentesProdutosAtuais.FirstOrDefault(ap => ap.AgenteId == agenteId);

                if (agenteProdutoAtual == null)
                {
                    // Insere um novo registro como ativo para agentes que não existem no banco
                    var novoRegistroAtivo = new AgenteProdutosEntity
                    {
                        Id = Guid.NewGuid(),
                        ProdutoId = produtoId,
                        AgenteId = agenteId,
                        Ativo = true,
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    };
                    _context.Add(novoRegistroAtivo); // Adiciona a nova entidade
                }
                else if (!agenteProdutoAtual.Ativo)
                {
                    // Atualiza o registro existente para ativar o agente
                    agenteProdutoAtual.Ativo = true;
                    agenteProdutoAtual.UpdateAt = DateTime.UtcNow;
                    _context.Entry(agenteProdutoAtual).State = EntityState.Modified;
                }
            }

            // Salva as alterações no banco
            await _context.SaveChangesAsync();
        }
    }

}
