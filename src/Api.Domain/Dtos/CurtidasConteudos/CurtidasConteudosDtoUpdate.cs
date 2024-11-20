using System;
using Api.Domain.Entities;

namespace Api.Domain.Dtos.CurtidasP
{
    public class CurtidasConteudosDtoUpdate
    {
        public Guid Id { get; set; }
        public Guid ConteudosId { get; set; }
        public Guid UserId { get; set; }
        public bool Curtidas { get; set; }

    }
}
