using System;

namespace Api.Domain.Dtos.ImagensP
{
    public class ImagensConteudosDtoUpdate
    {
        public Guid Id { get; set; }
        public Guid ConteudosId { get; set; }
        public string UrlImagens { get; set; }
        public string CodigoImagem { get; set; }

    }
}
