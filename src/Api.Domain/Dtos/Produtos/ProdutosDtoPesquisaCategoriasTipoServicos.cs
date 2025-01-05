using System;
using System.Collections.Generic;
using Api.Domain.Dtos.ImagensP;

namespace Api.Domain.Dtos.Protudos
{
    public class ProdutosDtoPesquisaCategoriasTipoServicos
    {
        public Guid? userId { get; set; }
        public double km { get; set; }
        public string pesquisa  { get; set; }
        public IEnumerable<int>? CategoriaIdLista { get; set; }
        public IEnumerable<int>? TipoServicoIdLista { get; set; }
        public int Pagina { get; set; } = 1;
        public int QuantidadePorPagina { get; set; }
        public string Idioma { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
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
