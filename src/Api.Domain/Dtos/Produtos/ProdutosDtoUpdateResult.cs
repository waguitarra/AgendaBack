using System;

namespace Api.Domain.Dtos.Protudos
{
    public class ProdutosDtoUpdateResult
    {
        public string NomeProduto { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid UserId { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public string Descricao { get; set; }
        public Guid ImagensId { get; set; }
        public Guid TipoServicoId { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime? Delete { get; set; }
        public bool ativo { get; set; }
        public string Idioma { get; set; }
        public string Mapa { get; set; }
        public string Endereco { get; set; }
    }
}
