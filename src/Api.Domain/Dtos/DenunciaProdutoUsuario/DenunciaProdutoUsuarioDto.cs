using System;
using System.Collections.Generic;
using System.Text;
using Api.Domain.Dtos.Denuncias;
using Api.Domain.Dtos.Protudos;
using Api.Domain.Dtos.User;

namespace Domain.Dtos.DenunciaProdutoUsuario
{
    public class DenunciaProdutoUsuarioDto
    {
        public Guid Id { get; set; }
        public Guid ProdutosId { get; set; }
        public Guid UserId { get; set; }
        public Guid DenunciasId { get; set; }
        public ProdutosDto Produtos { get; set; }
        public UserGetDadosBasicosDto User { get; set; }
        public DenunciasDto Denuncias { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
