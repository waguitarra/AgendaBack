using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.ImagensP;
using Domain.Dtos.Agente;
using Domain.Entities;


namespace Api.Domain.Dtos.Protudos
{
    public class ProdutosDtoUpdate
    {
       
        public Guid Id { get; set; }
        public string NomeProduto { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid UserId { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public string Descricao { get; set; }
        public Guid TipoServicoId { get; set; }
        public IEnumerable<ImagensPDtoUpdate> ImagensP { get; set; }
        public DateTime UpdateAt { get; set; }

        public string Idioma { get; set; }
        public DateTime? Delete { get; set; }
        public bool Ativo { get; set; }
        public string Mapa { get; set; }
        public string Endereco { get; set; }

        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public IEnumerable<AgenteDto> Agente { get; set; }
    }    
}
