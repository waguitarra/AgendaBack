using Api.Domain.Entities;
using System;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensPDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string UrlImagens { get; set; }

        public Guid ProdutosId { get; set; }

        public ProdutosEntity Produtos { get; set; }

        public string CodigoImagem { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
