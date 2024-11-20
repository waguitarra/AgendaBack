using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.MensagensP
{
    public class MensagensPDtoUpdate
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Id de Usuario é umn campo obrigatorio")]
        public Guid UserId { get; set; }
        public Guid ProdutosId { get; set; }
        public Guid IdProdutoUsuarioTroca { get; set; }

        [Required(ErrorMessage = "Mensagens está com campo vazio")]
        public string Mensagens { get; set; }

        public bool MensagenLida { get; set; }
        public string Imagem { get; set; }

    }
}
