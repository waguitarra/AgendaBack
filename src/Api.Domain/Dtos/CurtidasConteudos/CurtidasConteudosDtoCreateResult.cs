using System;

namespace Api.Domain.Dtos.CurtidasP
{
    public class CurtidasConteudosDtoCreateResult
    {
        public Guid Id { get; set; }
        public Guid ConteudosId { get; set; }
        public Guid UserId { get; set; }
        public bool Curtidas { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
