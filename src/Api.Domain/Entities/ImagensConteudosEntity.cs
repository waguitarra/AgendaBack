using System;
using Domain.Entities;

namespace Api.Domain.Entities
{
    public class ImagensConteudosEntity : BaseEntity
    {
        public string UrlImagens { get; set; }

        public Guid ConteudosId { get; set; }

        public ConteudosEntity Conteudos { get; set; }

        public string CodigoImagem { get; set; }
    }
}



