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

        [Required]
        [MaxLength(400)]
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

        public string Endereco { get; set; }

        public IEnumerable<DenunciaProdutoUsuarioEntity> DenunciaProdutoUsuario { get; set; }

        public IEnumerable<AgenteEntity> Agente { get; set; }


    }
}
