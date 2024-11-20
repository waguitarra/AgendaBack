using System;

namespace Api.Domain.Entities
{
    public class ImagensFEntity : BaseEntity
    {
        public string UrlImagens { get; set; }

        public Guid FornecedorProdutosId { get; set; }

        public FornecedorProdutosEntity FornecedorProdutos { get; set; }

        public string CodigoImagem { get; set; }
    }
}



