using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.TermosResponsabilidades
{
    public class TermosResponsabilidadesDtoUpdate
    {
        public Guid Id { get; set; }
        public string Responsabilidades { get; set; }

        public bool Ativo { get; set; }
    }
}
