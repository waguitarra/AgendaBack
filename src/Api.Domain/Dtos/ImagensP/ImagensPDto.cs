using System;
using Api.Domain.Dtos.Protudos;
using Api.Domain.Entities;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensPDto
    {
        public Guid Id { get; set; }
        public Guid ProdutosId { get; set; }
        public string UrlImagens { get; set; }
        public string CodigoImagem { get; set; }

    }
}
