using System;
using System.Collections.Generic;
using Api.Domain.Dtos.ImagensP;

namespace Api.Domain.Dtos.Protudos
{
    public class ProdutosDtoBasic
    {

        public Guid Id { get; set; }
        public string NomeProduto { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid TipoServicoId { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public IEnumerable<ImagensPDto> ImagensP { get; set; }
        public double KM { get; set; }
        public string Idioma { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string Mapa { get; set; }
        public string Endereco { get; set; }

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
    }
}
