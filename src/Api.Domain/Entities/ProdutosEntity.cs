using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Api.Domain.Entities
{
    public class ProdutosEntity : BaseEntity
    {
        [Required]
        [MaxLength(40)]
        public string NomeProduto { get; set; }
        public Guid CategoriaId { get; set; }
        public CategoriaEntity Categoria { get; set; } 
        public Guid ClienteUsuarioId { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid TipoServicoId { get; set; }
        public TipoServicoEntity TipoServico { get; set; }
        public string Descricao { get; set; }
        public double KM { get; set; }
        public DateTime? Delete { get; set; }
        public bool Ativo { get; set; }
        public string Idioma { get; set; }

        public IEnumerable<ImagensPEntity> ImagensP { get; set; }
        public IEnumerable<MensagensPEntity> MensagensP { get; set; }
        public IEnumerable<CurtidasPEntity> CurtidasP { get; set; }
        public int CurtidasTotal { get; set; }

        public string Mapa { get; set; }

        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public IEnumerable<DenunciaProdutoUsuarioEntity> DenunciaProdutoUsuario { get; set; }

        public IEnumerable<AgenteEntity> Agente { get; set; }

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
