using System;

namespace Api.Domain.Dtos.Denuncias
{
    public class DenunciasDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string TipoDenuncias { get; set; }
        public string Descricao { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
