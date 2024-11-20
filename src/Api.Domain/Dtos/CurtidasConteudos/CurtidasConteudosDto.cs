using System;
using Api.Domain.Dtos.User;

namespace Api.Domain.Dtos.CurtidasConteudosP
{
    public class CurtidasConteudosDto
    {
        public Guid Id { get; set; }
        public Guid ConteudosId { get; set; }
        public Guid UserId { get; set; }
        public bool Curtidas { get; set; }
        public UserGetDadosBasicosDto User { get; set; }

    }
}
