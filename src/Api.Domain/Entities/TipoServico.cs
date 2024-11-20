using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class TipoServicoEntity : BaseEntity
    {
        [Required]
        [MaxLength(40)]
        public string TipoCategoria { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }

        public string UrlImagens { get; set; }
        public bool Ativo { get; set; }

        public int Tipo { get; set; }

        public string Pais { get; set; }
    }
}
