using Api.Domain.Dtos.ImagensP;
using Domain.Dtos.Agente;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Protudos
{
    public class ProdutosDtoCreate
    {
        [Required(ErrorMessage = "Nome do produto é campo obrigatorio")]
        [StringLength(60, ErrorMessage = "O nome de produto deve ter no maximo {1} Caracteres")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "Deve selecionar o tipo de Categoria. Ex: trocas o doaçoes")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "Deve ser lecionar o tipo de Categoria. Ex: trocas o doaçoes")]
        public Guid TipoServicoId { get; set; }
        public Guid UserId { get; set; }
        public string Descricao { get; set; }
        public string Idioma { get; set; }
        public IEnumerable<ImagensPDtoCreate> ImagensP { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public string Mapa { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
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
