
using System;

namespace Domain.Dtos.MensagensP
{
    public class MensagensPClienteUserProdutoUserDto
    {
        public Guid UserId { get; set; }
        public Guid ProdutosId { get; set; }
        public Guid clienteUsuarioId { get; set; }
        public Guid idProdutoUsuarioTroca { get; set; }
    }
}
