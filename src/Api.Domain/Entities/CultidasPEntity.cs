using System;

namespace Api.Domain.Entities
{
    public class CurtidasPEntity : BaseEntity
    {
        public Guid ProdutosId { get; set; }
        public Guid UserId { get; set; }
        public bool Curtidas { get; set; }
        public UserEntity User { get; set; }
        public ProdutosEntity Produtos { get; set; }
        public FornecedorProdutosEntity FornecedorProdutos { get; set; }

    }
}
