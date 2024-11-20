using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class MensagensPEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProdutosId { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public Guid IdProdutoUsuarioTroca { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Mensagens { get; set; }
        public string Imagem { get; set; }
        public UserEntity User { get; set; }
        public ProdutosEntity Produtos { get; set; }
        public bool MensagenLida { get; set; }


    }
}
