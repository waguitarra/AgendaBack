using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.AgenteProduto
{
    public interface IAgenteProdutoService
    {
        Task GerenciarAgentesAsync(Guid produtoId, List<Guid> agentesRecebidos);
    }
}
