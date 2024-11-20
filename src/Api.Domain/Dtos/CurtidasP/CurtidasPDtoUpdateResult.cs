using System;

namespace Api.Domain.Dtos.CurtidasP
{
    public class CurtidasPDtoUpdateResult
    {
        public Guid Id { get; set; }
        public Guid ProdutosId { get; set; }
        public Guid UserId { get; set; }
        public bool Curtidas { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
}
