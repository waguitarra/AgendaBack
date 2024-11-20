using System;
using Domain.Entities;

namespace Api.Domain.Entities
{
    public class CurtidasConteudosEntity : BaseEntity
    {
        public Guid ConteudosId { get; set; }
        public Guid UserId { get; set; }
        public bool Curtidas { get; set; }
        public UserEntity User { get; set; }
        public ConteudosEntity Conteudos { get; set; }

    }
}
