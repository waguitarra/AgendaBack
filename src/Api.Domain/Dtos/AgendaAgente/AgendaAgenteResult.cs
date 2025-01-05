using System;

namespace Domain.Dtos.AgendaAgente
{
    public class AgendaAgenteDto 
    {
        public Guid Id { get; set; }

        public Guid AgenteId { get; set; }
        //public AgenteEntity Agente { get; set; }

        public Guid ClienteId { get; set; }
        //public ClienteEntity Cliente { get; set; }

        public DateTime Dia { get; set; }
        public string HorarioStart { get; set; }
        public string HorarioEnd { get; set; }

        public bool Cancelado { get; set; }
        public DateTime? DataCancelamento { get; set; }
    }
}
