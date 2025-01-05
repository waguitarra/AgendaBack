using System;

namespace Domain.Dtos.Agente
{
    public class AgenteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
        public string Descricao { get; set; }
        public Guid UserId { get; set; }
        public Guid? ProdutoId { get; set; }

        public string PauseStartComer { get; set; }
        public string PauseEndComer { get; set; }
    }
}
