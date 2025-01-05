using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Categorias;
using Api.Domain.Dtos.ImagensP;
using Api.Domain.Dtos.MensagensP;
using Api.Domain.Dtos.TipoServico;
using Domain.Dtos.Agente;

namespace Api.Domain.Dtos.Protudos
{
    public class ProdutosDtoCreateResult
    {

        public Guid Id { get; set; }
        public string NomeProduto { get; set; }
        public CategoriaDto Categoria { get; set; }
        public Guid UserId { get; set; }
        public string Descricao { get; set; }
        public TipoServicoDto TipoServico { get; set; }
        public DateTime CreateAt { get; set; }
        public string Idioma { get; set; }
        public IEnumerable<ImagensPDtoCreateResult> ImagensP { get; set; }
        public string Mapa { get; set; }
        public string Endereco { get; set; }
        public IEnumerable<AgenteDto> Agente { get; set; }

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
