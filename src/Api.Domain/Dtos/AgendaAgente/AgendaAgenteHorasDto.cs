using Domain.Dtos.Agente;
using Domain.Dtos.Client;
using Domain.Entities;
using System;

namespace Domain.Dtos.AgendaAgente
{
    public class AgendaAgenteHorasDto
    {
        public Guid Id { get; set; }

        public Guid ProdutoId { get; set; }

        public Guid AgenteId { get; set; }

        public DateTime Dia { get; set; }
        public string HorarioStart { get; set; }
        public string HorarioEnd { get; set; }

    }
}
