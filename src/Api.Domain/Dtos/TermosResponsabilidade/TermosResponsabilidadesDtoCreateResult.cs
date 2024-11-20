using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.TermosResponsabilidades
{
    public class TermosResponsabilidadesDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Responsabilidades { get; set; }
        public bool Ativo { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
