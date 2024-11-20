using System;


namespace Api.Domain.Dtos.TermosResponsabilidades
{
    public class TermosResponsabilidadesDto
    {
        public Guid Id { get; set; }
        public string Responsabilidades { get; set; }
        public bool Ativo { get; set; }
    }
}
