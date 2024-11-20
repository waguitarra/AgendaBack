using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Categorias;
using Api.Domain.Dtos.ImagensP;
using Api.Domain.Dtos.MensagensP;
using Api.Domain.Dtos.TipoServico;
using Domain.Dtos.Agente;

namespace Api.Domain.Dtos.Protudos
{
    public class ProdutosDtoCreateResult
    {

        public Guid Id { get; set; }
        public string NomeProduto { get; set; }
        public CategoriaDto Categoria { get; set; }
        public Guid UserId { get; set; }
        public string Descricao { get; set; }
        public TipoServicoDto TipoServico { get; set; }
        public DateTime CreateAt { get; set; }
        public string Idioma { get; set; }
        public IEnumerable<ImagensPDtoCreateResult> ImagensP { get; set; }
        public string Mapa { get; set; }
        public string Endereco { get; set; }
        public IEnumerable<AgenteDto> Agente { get; set; }

    }
}
