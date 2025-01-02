using System;

namespace Domain.Dtos.Agente
{
    public class ProdutoAgenteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Imagem { get; set; }
        public string NomeProduto { get; set; }
        public bool Ativo { get; set; }
        public string TipoCategoria { get; set; }
        public string TipoServico { get; set; }

        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public Guid UserId { get; set; }
        public Guid? ProdutoId { get; set; }
    }
}
