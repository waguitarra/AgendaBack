using Api.Domain.Entities;
using System;

namespace Domain.Entities
{
    public class AgenteEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string Descricao { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid? ProdutoId { get; set; }
        public ProdutosEntity Produto { get; set; }

    }
}
