using System;
using System.Collections.Generic;


namespace Api.Domain.Entities
{
    public class FornecedorProdutosEntity : BaseEntity
    {

        public string NomeProdutoFornecedor { get; set; }
        public Guid UserFornecedorId { get; set; }
        public UserFornecedorEntity UserFornecedor { get; set; }
        public string Descricao { get; set; }
        public double KM { get; set; }
        public double MaxKM { get; set; }
        public DateTime? Delete { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<ImagensFEntity> ImagensF { get; set; }
        public IEnumerable<CurtidasPEntity> CurtidasP { get; set; }
        public int CurtidasTotal { get; set; }

    }
}
