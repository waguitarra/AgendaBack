using System;
using System.Collections.Generic;
using Api.Domain.Dtos.ImagensP;

namespace Api.Domain.Dtos.Protudos
{
    public class ProdutosDtoBasic
    {

        public Guid Id { get; set; }
        public string NomeProduto { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid TipoServicoId { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public IEnumerable<ImagensPDto> ImagensP { get; set; }
        public double KM { get; set; }
        public string Idioma { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public string Mapa { get; set; }

        public string Endereco { get; set; }
    }
}
