using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.TermosResponsabilidades
{
    public class TermosResponsabilidadesDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Responsabilidades { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Ativo { get; set; }
    }
}
