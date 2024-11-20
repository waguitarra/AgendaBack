using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensFDtoUpdate
    {
        [Required(ErrorMessage = "Id Imagem Produto é umn campo obrigatorio")]
        public Guid Id { get; set; }
        public Guid FornecedorProdutosId { get; set; }
        [Required(ErrorMessage = "É nescessario ter pelo menos uma imagem")]
        public string UrlImagens { get; set; }
        public string CodigoImagem { get; set; }

    }
}
