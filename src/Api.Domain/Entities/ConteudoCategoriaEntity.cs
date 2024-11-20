using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class ConteudoCategoriaEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }
        public string UrlImagens { get; set; }
        public bool Ativo { get; set; }

    }
}
