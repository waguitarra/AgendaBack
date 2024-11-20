using System;
using System.Collections.Generic;
using Api.Domain.Entities;

namespace Domain.Entities
{
    public class ConteudosEntity : BaseEntity
    {
        public string NomeConteudo { get; set; }
        public Guid IdConteudoCategoria { get; set; }
        public ConteudoCategoriaEntity ConteudoCategoria { get; set; }
        public string Descricao { get; set; }
        public string Json { get; set; }
        public int TotalCurtidas { get; set; }
        public Guid IdImagensConteudos { get; set; }
        public string VideoRelacionado { get; set; }
        public Guid UserId { get; set; }
        public string Idioma { get; set; }
        public UserEntity User { get; set; }
        public IEnumerable<ImagensConteudosEntity> ImagensConteudos { get; set; }
        public IEnumerable<CurtidasConteudosEntity> CurtidasConteudos { get; set; }
    }
}
