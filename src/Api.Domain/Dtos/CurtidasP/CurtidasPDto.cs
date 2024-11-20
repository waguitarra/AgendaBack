using System;
using Api.Domain.Dtos.User;

namespace Api.Domain.Dtos.CurtidasP
{
    public class CurtidasPDto
    {
        public Guid Id { get; set; }
        public Guid ProdutosId { get; set; }
        public Guid UserId { get; set; }
        public bool Curtidas { get; set; }

        //Imagem do Usuario que deu curtidas no produto postado
        //public string ImagemLogin { get; set; }
        public UserGetDadosBasicosDto User { get; set; }

    }
}
