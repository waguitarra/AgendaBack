using System;

namespace Api.Domain.Dtos.Denuncias
{
    public class DenunciasDto
    {
        public Guid Id { get; set; }
        public string TipoDenuncias { get; set; }
        public string Descricao { get; set; }
    }
}
