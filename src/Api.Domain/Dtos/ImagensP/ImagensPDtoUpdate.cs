using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensPDtoUpdate
    {
        public Guid Id { get; set; }
        public Guid ProdutosId { get; set; }
        public string UrlImagens { get; set; }
        public string CodigoImagem { get; set; }

    }
}
