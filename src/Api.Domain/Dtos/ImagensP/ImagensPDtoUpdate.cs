using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensPDtoUpdate
    {
        [Required(ErrorMessage = "Id Imagem Produto é umn campo obrigatorio")]
        public Guid Id { get; set; }
        public Guid ProdutosId { get; set; }

        [Required(ErrorMessage = "É nescessario ter pelo menos uma imagem")]
        public string UrlImagens { get; set; }
        public string CodigoImagem { get; set; }

    }
}
