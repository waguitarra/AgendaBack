using Api.Domain.Dtos.ImagensP;
using Domain.Dtos.AgendaAgente;
using System;
using System.Collections.Generic;

namespace Domain.Dtos.AgenteProduto
{
    public class ProdutoAgenteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        //public string Email { get; set; }
        public string Imagem { get; set; }
        public string NomeProduto { get; set; }
        public bool Ativo { get; set; }
        public string TipoCategoria { get; set; }
        public string TipoServico { get; set; }

        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public Guid UserId { get; set; }
        public Guid? ProdutoId { get; set; }

        public string AgentePauseStartComer { get; set; }
        public string AgentePauseEndComer { get; set; }

        public string SemanaStartHora { get; set; }
        public string SemanaEndHora { get; set; }

        public string PauseStartHora { get; set; }
        public string PauseEndHora { get; set; }

        public bool Sabado { get; set; }
        public string SabadoStartHorario { get; set; }
        public string SabadoEndHorario { get; set; }

        public bool Domingo { get; set; }
        public string DomingoStartHora { get; set; }
        public string DomingoEndHora { get; set; }

        public bool Feriados { get; set; }
        public string FeriadoStartHora { get; set; }
        public string FeriadoEndHora { get; set; }
        public string ImagensP { get; set; }

        public IEnumerable<AgendaAgenteHorasDto> AgendaAgente { get; set; }
    }
}
