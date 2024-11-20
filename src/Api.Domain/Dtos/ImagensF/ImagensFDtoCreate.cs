using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensFDtoCreate
    {
        public Guid FornecedorProdutosId { get; set; }

        [Required(ErrorMessage = "É nescessario ter pelo menos uma imagem")]
        public string UrlImagens { get; set; }
        public string CodigoImagem { get; set; }
    }
}
