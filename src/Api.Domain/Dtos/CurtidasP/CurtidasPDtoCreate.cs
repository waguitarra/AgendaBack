using System;

namespace Api.Domain.Dtos.CurtidasP
{
    public class CurtidasPDtoCreate
    {
        public Guid ProdutosId { get; set; }
        public Guid UserId { get; set; }
        public bool Curtidas { get; set; }
    }
}
