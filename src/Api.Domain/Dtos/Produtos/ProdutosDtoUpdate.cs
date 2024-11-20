using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.ImagensP;


namespace Api.Domain.Dtos.Protudos
{
    public class ProdutosDtoUpdate
    {
        [Required(ErrorMessage = "Id Produto é umn campo obrigatorio")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome do produto é campo obrigatorio")]
        [StringLength(60, ErrorMessage = "O nome de produto deve ter no maximo {1} Caracteres")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "Deve selecionar o tipo de Categoria. Ex: trocas o doaçoes")]
        public Guid CategoriaId { get; set; }
        public Guid UserId { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Deve ser lecionar o tipo de Categoria. Ex: trocas o doaçoes")]
        public Guid TipoServicoId { get; set; }
        public IEnumerable<ImagensPDtoUpdate> ImagensP { get; set; }
        //public DateTime UpdateAt { get; set; }

        public string Idioma { get; set; }
        public DateTime? Delete { get; set; }
        public bool ativo { get; set; }
        public string Mapa { get; set; }
        public string Endereco { get; set; }
    }    
}
