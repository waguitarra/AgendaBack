using System;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensFDtoUpdateResult
    {
        public Guid Id { get; set; }
        public Guid FornecedorProdutosId { get; set; }
        public string UrlImagens { get; set; }
        public DateTime UpdateAt { get; set; }
        public string CodigoImagem { get; set; }

    }
}
