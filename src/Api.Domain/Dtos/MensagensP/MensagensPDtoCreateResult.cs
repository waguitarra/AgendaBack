using System;

namespace Api.Domain.Dtos.MensagensP
{
    public class MensagensPDtoCreateResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProdutosId { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public Guid IdProdutoUsuarioTroca { get; set; }
        public string Mensagens { get; set; }
        public DateTime CreateAt { get; set; }
        public bool MensagenLida { get; set; }
        public string Imagem { get; set; }
    }
}
