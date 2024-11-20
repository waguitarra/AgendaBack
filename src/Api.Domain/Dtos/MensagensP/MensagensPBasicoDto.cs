using System;
using Api.Domain.Dtos.Protudos;
using Api.Domain.Dtos.User;

namespace Api.Domain.Dtos.MensagensP
{
    public class MensagensPDto
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProdutosId { get; set; }
        public UserGetDadosBasicosDto User { get; set; }
        public ProdutosDtoBasic Produtos { get; set; }
        public Guid clienteUsuarioId { get; set; }
        public Guid idProdutoUsuarioTroca { get; set; }
        public UserGetDadosBasicosDto UserCliente { get; set; }
        public ProdutosDtoBasic ProdutoCliente { get; set; }
        public string Mensagens { get; set; }
        public DateTime CreateAt { get; set; }
        public bool MensagenLida { get; set; }
        public string Imagem { get; set; }

    }
}
