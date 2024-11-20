using System;
using Api.Domain.Dtos.Protudos;
using Api.Domain.Entities;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensConteudosDtoCreateResult
    {
        public Guid Id { get; set; }
        public Guid ConteudosId { get; set; }
        public string UrlImagens { get; set; }
        public string CodigoImagem { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
