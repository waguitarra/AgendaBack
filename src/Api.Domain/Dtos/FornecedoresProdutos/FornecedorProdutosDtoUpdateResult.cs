using System;
using System.Collections.Generic;
using Api.Domain.Dtos.ImagensP;

namespace Api.Domain.Dtos
{
    public class FornecedorProdutosDtoUpdateResult
    {
        public Guid Id { get; set; } 
        public string NomeProduto { get; set; }
        public Guid UserFornecedorId { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<ImagensFDtoUpdate> ImagensF { get; set; }
        public Guid TipoServicoId { get; set; }
        //public DateTime UpdateAt { get; set; }
        public DateTime? Delete { get; set; }
        public bool ativo { get; set; }
    }
}
