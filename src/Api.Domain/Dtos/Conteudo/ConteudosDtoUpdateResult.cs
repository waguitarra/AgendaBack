using System;
using System.Collections.Generic;
using Api.Domain.Dtos.CurtidasConteudosP;
using Api.Domain.Dtos.ImagensP;
using Api.Domain.Dtos.User;
using Domain.Dtos.ConteudoCategoria;

namespace Domain.Dtos.Conteudo
{
    public class ConteudosDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string NomeConteudo { get; set; }
        public Guid IdConteudoCategoria { get; set; }
        public string Descricao { get; set; }
        public string VideoRelacionado { get; set; }
        public string Json { get; set; }
        public int TotalCurtidas { get; set; }
        public Guid UserId { get; set; }
        public UserGetDadosBasicosDto User { get; set; }
        public IEnumerable<ConteudoCategoriaDto> ConteudoCategoria { get; set; }
        public IEnumerable<ImagensConteudosDto> ImagensConteudos { get; set; }
        public IEnumerable<CurtidasConteudosDto> CurtidasConteudos { get; set; }
        public DateTime UpdateAt { get; set; }      
    }
}
