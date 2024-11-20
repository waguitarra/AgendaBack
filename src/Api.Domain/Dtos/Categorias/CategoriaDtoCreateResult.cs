using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Categorias
{
    public class CategoriaDtoCreateResult
    {

        public Guid Id { get; set; }

        [MaxLength(60)]
        public string TipoCategoria { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }
        public string UrlImagens { get; set; }
        public int Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}
