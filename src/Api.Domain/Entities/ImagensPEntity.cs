using System;

namespace Api.Domain.Entities
{
    public class ImagensPEntity : BaseEntity
    {
        public string UrlImagens { get; set; }

        public Guid ProdutosId { get; set; }

        public ProdutosEntity Produtos { get; set; }

        public string CodigoImagem { get; set; }
    }
}



