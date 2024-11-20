using System;
using System.Collections.Generic;
using Api.Domain.Dtos.CurtidasConteudosP;
using Api.Domain.Dtos.CurtidasP;
using Api.Domain.Dtos.ImagensP;

namespace Domain.Dtos.Conteudo
{
    public class ConteudosDtoCreate
    {
        public string NomeConteudo { get; set; }
        public Guid UserId { get; set; }
        public Guid IdConteudoCategoria { get; set; }
        public string Descricao { get; set; }
        public string VideoRelacionado { get; set; }
        public string Json { get; set; }
        public int TotalCurtidas { get; set; }
        public IEnumerable<ImagensConteudosDtoCreate> ImagensConteudos { get; set; }

    }
}
