using Domain.Dtos.Agente;
using Domain.Dtos.Client;
using System;

namespace Domain.Dtos.AgendaAgente
{
    public class AgendaAgenteResultDto
    {
        public Guid Id { get; set; }

        public Guid ProdutoId { get; set; }

        public Guid AgenteId { get; set; }
        public AgenteDto Agente { get; set; }

        public Guid ClienteId { get; set; }
        public ClienteDto Cliente { get; set; }

        public DateTime Dia { get; set; }
        public string HorarioStart { get; set; }
        public string HorarioEnd { get; set; }

        public bool Cancelado { get; set; }
        public DateTime? DataCancelamento { get; set; }


    }
}
