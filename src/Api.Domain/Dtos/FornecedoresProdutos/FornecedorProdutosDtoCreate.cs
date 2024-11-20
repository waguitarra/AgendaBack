using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.ImagensP;


namespace Api.Domain.Dtos{

    public class FornecedorProdutosDtoCreate
    {
        [Required(ErrorMessage = "Nome do produto é campo obrigatorio")]
        [StringLength(60, ErrorMessage = "O nome de produto deve ter no maximo {1} Caracteres")]
        public string NomeProdutoFonecedor { get; set; }


        [Required(ErrorMessage = "Deve ser lecionar o tipo de Categoria. Ex: trocas o doaçoes")]
        public Guid UserFornecedorId { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<ImagensFDtoCreate> ImagensF { get; set; }

    }
}
