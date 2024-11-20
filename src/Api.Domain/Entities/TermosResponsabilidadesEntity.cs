using System;
using System.Collections.Generic;
using System.Text;
using Api.Domain.Entities;

namespace Domain.Entities
{
    public class TermosResponsabilidadesEntity : BaseEntity
    {
        public string Titulo { get; set; }
        public string Responsabilidades { get; set; }

        public bool Ativo { get; set; }

        public string Pais { get; set; }
    }
}
