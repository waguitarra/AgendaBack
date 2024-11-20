using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Categorias;
using Api.Domain.Dtos.CurtidasP;
using Api.Domain.Dtos.ImagensP;
using Api.Domain.Dtos.UserFornecedor;


namespace Api.Domain.Dtos
{
    public class FornecedorProdutosDto
    {
        public Guid Id { get; set; }
        public string NomeProdutoFornecedor { get; set; }
        public UserFornecedorDto UserFornecedor { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<ImagensFDto> ImagensF { get; set; }
        public IEnumerable<CurtidasPDto> CurtidasP { get; set; }
        public double KM { get; set; }
        public double MaxKM { get; set; }
        public DateTime? Delete { get; set; }
        public bool Ativo { get; set; }
        public int CurtidasTotal { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
