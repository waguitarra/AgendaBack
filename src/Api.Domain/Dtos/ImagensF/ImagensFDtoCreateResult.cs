using System;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensFDtoCreateResult
    {
        public Guid Id { get; set; }
        public Guid FornecedorProdutosId { get; set; }
        public string UrlImagens { get; set; }
        public DateTime CreateAt { get; set; }
        public string CodigoImagem { get; set; }
    }
}
