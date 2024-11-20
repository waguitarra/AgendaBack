using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Api.Domain.Entities;

namespace Domain.Entities
{
    public class EmailsNewsletterEntity : BaseEntity
    {
        public string Nome { get; set; }
        public int TipoNewsletter { get; set; }
        public string DescricaoNewsletter { get; set; }
  
        public string HTML { get; set; }
        public bool Ativo { get; set; }

        public string Pais { get; set; }

    }
}
