using System;

namespace Api.Domain.Dtos.TipoServico
{
    public class TipoServicoDtoUpdate
    {
        public Guid Id { get; set; }
        public string TipoCategoria { get; set; }
        public string Descricao { get; set; }
        public string UrlImagens { get; set; }
        public int Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}
