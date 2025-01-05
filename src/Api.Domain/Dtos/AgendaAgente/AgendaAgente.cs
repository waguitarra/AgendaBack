﻿using Api.Domain.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.AgendaAgente
{
    public class AgendaAgenteDto 
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Identificador do agente relacionado a esta agenda.
        /// </summary>
        public Guid AgenteId { get; set; }

        /// <summary>
        /// Data do agendamento.
        /// </summary>
        public DateTime Dia { get; set; }

        /// <summary>
        /// Lista de horários disponíveis ou agendados para o agente.
        /// </summary>
        public List<TimeSpan> Horarios { get; set; } = new List<TimeSpan>();

        /// <summary>
        /// Lista de clientes associados aos horários nesta agenda.
        /// </summary>
        public List<ClienteEntity> Clientes { get; set; } = new List<ClienteEntity>();

        /// <summary>
        /// Indica se o agendamento foi cancelado.
        /// </summary>
        public bool Cancelado { get; set; }

        /// <summary>
        /// Data e hora do cancelamento, se aplicável.
        /// </summary>
        public DateTime? DataCancelamento { get; set; }
    }
}