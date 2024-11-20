using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.EmailsNewsletter
{
    public class EmailsNewsletterDtoCreate
    {     
        public string Nome { get; set; }
        public int TipoNewsletter { get; set; }
        public string DescricaoNewsletter { get; set; }
        [StringLength(10000)]
        public string HTML { get; set; }
        public bool Ativo { get; set; }
    }
}
