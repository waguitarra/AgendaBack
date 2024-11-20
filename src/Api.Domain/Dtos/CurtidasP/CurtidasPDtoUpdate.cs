using System;
using Api.Domain.Entities;

namespace Api.Domain.Dtos.CurtidasP
{
    public class CurtidasPDtoUpdate
    {
        public Guid Id { get; set; }
        public Guid ProdutosId { get; set; }
        public Guid UserId { get; set; }
        public bool Curtidas { get; set; }

    }
}
