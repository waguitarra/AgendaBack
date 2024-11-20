using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.MensagensP
{
    public class MensagensPDtoCreate
    {

        //[Required(ErrorMessage = "Id de Usuario é umn campo obrigatorio")]
        public Guid UserId { get; set; }
        //[Required(ErrorMessage = "Id de Produto é umn campo obrigatorio")]
        public Guid ProdutosId { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public Guid IdProdutoUsuarioTroca { get; set; }

        [Required(ErrorMessage = "Mensagens é umn campo obrigatorio")]
        public string Mensagens { get; set; }
        public string Imagem { get; set; }

    }
}
