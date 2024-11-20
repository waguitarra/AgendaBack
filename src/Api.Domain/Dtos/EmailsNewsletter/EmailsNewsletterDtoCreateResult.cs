using System;

namespace Domain.Dtos.EmailsNewsletter
{
    public class EmailsNewsletterDtoCreateResult
    {
        public Guid Id { get; set; } 
        public string Nome { get; set; }
        public int TipoNewsletter { get; set; }
        public string DescricaoNewsletter { get; set; }
        public string HTML { get; set; }
        public bool Ativo { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
