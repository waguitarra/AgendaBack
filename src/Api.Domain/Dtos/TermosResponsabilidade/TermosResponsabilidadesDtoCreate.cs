using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.TermosResponsabilidades
{
    public class TermosResponsabilidadesDtoCreate
    {
        public string Titulo { get; set; }
        public string Responsabilidades { get; set; }
    }
}
