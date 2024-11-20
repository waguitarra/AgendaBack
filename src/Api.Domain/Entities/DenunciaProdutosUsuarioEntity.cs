using System;
using System.Collections.Generic;
using System.Text;
using Api.Domain.Entities;

namespace Domain.Entities
{
    public class DenunciaProdutoUsuarioEntity : BaseEntity
    {
        public Guid ProdutosId { get; set; }
        public Guid UserId { get; set; }
        public Guid DenunciasId { get; set; }
        public ProdutosEntity Produtos { get; set; }
        public UserEntity User { get; set; }
        public DenunciasEntity Denuncias { get; set; }

    }
}
