using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Categorias;
using Api.Domain.Dtos.ImagensP;
using Api.Domain.Dtos.TipoServico;

namespace Api.Domain.Dtos
{
    public class FornecedorProdutosDtoCreateResult
    {
        public Guid Id { get; set; }
        public string NomeProduto { get; set; }
        public Guid UserFornecedorId { get; set; }
        public string Descricao { get; set; }
        public TipoServicoDto TipoServico { get; set; }
        public DateTime CreateAt { get; set; }
        public IEnumerable<ImagensFDtoCreateResult> ImagensF { get; set; }
    }
}
