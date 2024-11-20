using System;
using System.Collections.Generic;
using System.Text;
using Api.Domain.Dtos.Protudos;
using Api.Domain.Dtos.User;

namespace Domain.Dtos.DenunciaProdutoUsuario
{
    public class DenunciaProdutoUsuarioDtoUpdate
    {
        public Guid Id { get; set; }

        public Guid ProdutosId { get; set; }
        public Guid UserId { get; set; }
        public Guid DenunciasId { get; set; }

    }
}
