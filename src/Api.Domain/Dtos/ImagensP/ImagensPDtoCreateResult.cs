using System;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensPDtoCreateResult
    {
        public Guid Id { get; set; }
        public Guid ProdutosId { get; set; }
        public string UrlImagens { get; set; }
        public DateTime CreateAt { get; set; }
        public string CodigoImagem { get; set; }
    }
}
