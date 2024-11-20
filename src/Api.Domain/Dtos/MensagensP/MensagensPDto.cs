using System;

namespace Api.Domain.Dtos.MensagensP
{
    public class MensagensPBasicoDto
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UrlImagem { get; set; }
        public string Mensagens { get; set; }
        public DateTime CreateAt { get; set; }
        public bool MensagemUserIdPrincipal { get; set; }
        public bool MensagenLida { get; set; }
        public string Imagem { get; set; }

    }
}
