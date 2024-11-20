using System;

namespace Api.Domain.Dtos.Denuncias
{
    public class DenunciasDtoCreateResult
    {
        public Guid Id { get; set; }
        public string TipoDenuncias { get; set; }
        public string Descricao { get; set; }
        public DateTime CreateAt { get; set; }


    }
}
