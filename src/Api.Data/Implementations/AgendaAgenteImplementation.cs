using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Implementations
{
    public class AgendaAgenteImplementation : BaseRepository<AgendaAgente>, IUAgendaAgenteRepository
    {
        private DbSet<AgendaAgente> _dataset;

        public AgendaAgenteImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<AgendaAgente>();
        }

        public async Task<IEnumerable<AgendaAgente>> GetAllAgenteProdutoId(Guid produtoId, Guid agenteId)
        {
            return await _dataset
                .AsNoTracking()
                .Where(p => p.ProdutoId == produtoId && p.AgenteId == agenteId && !p.Cancelado)
                .ToListAsync();
        }

        public async Task<bool> IsAgendamentoDisponivel(Guid produtoId, Guid agenteId, DateTime data, string email, string telefone)
        {
            var hoje = DateTime.UtcNow.Date; // Considerando UTC, ajuste se necessário

            // Obtém todos os agendamentos ativos (não cancelados) para o cliente com o agente/produto
            var agendamentosAtivos = await _dataset
                .AsNoTracking()
                .Where(p => p.ProdutoId == produtoId &&
                            p.AgenteId == agenteId &&
                            !p.Cancelado &&
                            (p.Cliente.Email == email || p.Cliente.Telefone == telefone))
                .ToListAsync();

            // Filtra os agendamentos que ainda são futuros ou são para a mesma data
            var agendamentosRelevantes = agendamentosAtivos.Where(p => p.Dia.Date >= hoje).ToList();

            // Se existir qualquer agendamento relevante para outra data, bloqueia o agendamento
            if (agendamentosRelevantes.Any(p => p.Dia.Date != data.Date))
            {
                return false;
            }

            // Permite o agendamento caso não haja bloqueios
            return true;
        }




    }
}
