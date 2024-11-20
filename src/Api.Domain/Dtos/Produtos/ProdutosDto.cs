using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Categorias;
using Api.Domain.Dtos.CurtidasP;
using Api.Domain.Dtos.ImagensP;
using Api.Domain.Dtos.MensagensP;
using Api.Domain.Dtos.TipoServico;
using Api.Domain.Dtos.User;
using Domain.Dtos.Agente;

namespace Api.Domain.Dtos.Protudos
{
    public class ProdutosDto
    {

        public Guid Id { get; set; }
        public string NomeProduto { get; set; }
        public Guid CategoriaId { get; set; }
        public CategoriaDto Categoria { get; set; }
        public UserGetDadosBasicosDto User { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public UserGetDadosBasicosDto ClienteUser { get; set; }
        public string Descricao { get; set; }
        public Guid TipoServicoId { get; set; }
        public TipoServicoDto TipoServico { get; set; }
        public IEnumerable<ImagensPDto> ImagensP { get; set; }
        public IEnumerable<MensagensPDto> MensagensP { get; set; }
        public IEnumerable<CurtidasPDto> CurtidasP { get; set; }
        public double KM { get; set; }
        public string Idioma { get; set; }
        public DateTime? Delete { get; set; }
        public bool Ativo { get; set; }
        public int CurtidasTotal { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ultimaMensagem { get; set; }
        public DateTime UpdateAt { get; set; }
        public int TotalMensagenNaoLida { get; set; }
        public string Mapa { get; set; }
        public string Endereco { get; set; }
        public IEnumerable<AgenteDto> Agente { get; set; }

    }

}
