using System;
using System.Collections.Generic;
using Api.Domain.Dtos.MensagensP;
using Api.Domain.Dtos.Protudos;


namespace Domain.Dtos.MensagensP
{
    public class MensagensPPorUnicoUsuarioDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserImagem { get; set; }
        public DateTime UserLogado { get; set; }
        public Guid ProdutosId { get; set; }
        public string Categoria { get; set; }
        public string TipoServico { get; set; }
        public string Imagem { get; set; }
        public ProdutosDtoBasic Produtos { get; set; }
        public Guid clienteUsuarioId { get; set; }
        public Guid idProdutoUsuarioTroca { get; set; }
        public string UserClienteName { get; set; }
        public string UserClienteImagem { get; set; }
        public DateTime? UserClienteLogado { get; set; }
        public ProdutosDtoBasic ProdutoCliented { get; set; }
        public int QtdMensagensLidas { get; set; }
        public IEnumerable<MensagensPBasicoDto> MensagensP { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
